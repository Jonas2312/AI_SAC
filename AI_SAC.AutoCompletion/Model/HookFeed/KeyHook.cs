
using AI_SAC.AutoCompletion.Model.Analyzer;
using AI_SAC.AutoCompletion.View;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_SAC.AutoCompletion.Model.HookFeed
{
    public class KeyHook
    {
        KeyAnalyzer analyzer;

        IKeyboardMouseEvents keyboardEvents;
        IKeyboardMouseEvents mouseEvents;

        public bool isSupressing;
        public int ignoreNextDown;
        public int ignoreNextUp;

        public int isProcessingKeyDown;
        public int isProcessingKeyUp;

        public List<Keys> hookedKeyUps;
        public List<KeyData> hookedKeyDowns;
        public bool isHookingKeyDowns;

        public bool shiftPressed;
        public bool ctrlPressed;

        public bool isActive;

        public KeyHook(KeyAnalyzer analyzer)
        {
            this.analyzer = analyzer;

            hookedKeyUps = new List<Keys>();
            hookedKeyDowns = new List<KeyData>();
            isSupressing = true;
            isHookingKeyDowns = true;

            keyboardEvents = Hook.GlobalEvents();
            keyboardEvents.KeyDown += HookKeyDown;
            keyboardEvents.KeyUp += HookKeyUp;

            mouseEvents = Hook.GlobalEvents();
            mouseEvents.MouseDown += MouseDown;

            isProcessingKeyDown = 0;
            isProcessingKeyUp = 0;

            shiftPressed = false;
            ctrlPressed = false;
            ignoreNextUp = 0;
            ignoreNextDown = 0;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            //analyzer.CurrentString = string.Empty;
        }

        private void HookKeyUp(object sender, KeyEventArgs e)
        {
            if (!isActive)
                return;
            if (ignoreNextUp > 0)
            {
                --ignoreNextUp;
                return;
            }

            ++isProcessingKeyUp;
            //await Task.Delay(5);
            //if(isProcessingKeyDown > 0)
            //{
            //    --isProcessingKeyUp;
            //    return;
            //}
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                ctrlPressed = false;
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                shiftPressed = false;
            //hookedKeyUps.Add(e.KeyCode);
            --isProcessingKeyUp;
        }

        private void HookKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                ctrlPressed = true;
                return;
            }
            if (e.KeyCode == Keys.Space && ctrlPressed)
            {
                EditorView.instance.StopProgramButton_Click(null, null);
                shiftPressed = false;
                ctrlPressed = false;
                analyzer.CurrentString = string.Empty;
                return;
            }

            if (!isActive)
                return;
            System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                Thread t = new Thread(() => EditorView.instance.ShowSuggestionDialog());
                t.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                t.Start();
                return;
            }
            if (ignoreNextDown > 0)
            {
                --ignoreNextDown;
                return;
            }
            if (!StringConverter.CanProcess(e.KeyCode))
                return;
            ++isProcessingKeyDown;
            if (isSupressing)
                e.SuppressKeyPress = true;
            if (isHookingKeyDowns)
            {
                if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                    shiftPressed = true;
                else
                    hookedKeyDowns.Add(new KeyData(e.KeyCode, shiftPressed, ctrlPressed));
            }
            //while (isProcessingKeyUp > 0)
              //  await Task.Delay(1);
            --isProcessingKeyDown;
        }


    }
}
