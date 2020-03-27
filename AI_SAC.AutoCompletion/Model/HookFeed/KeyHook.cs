
using AI_SAC.View;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_SAC.Model.HookFeed
{
    public class KeyHook
    {
        IKeyboardMouseEvents keyboardEvents;

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

        public KeyHook()
        {
            hookedKeyUps = new List<Keys>();
            hookedKeyDowns = new List<KeyData>();
            isSupressing = true;
            isHookingKeyDowns = true;

            keyboardEvents = Hook.GlobalEvents();
            keyboardEvents.KeyDown += HookKeyDown;
            keyboardEvents.KeyUp += HookKeyUp;

            isProcessingKeyDown = 0;
            isProcessingKeyUp = 0;

            shiftPressed = false;
            ctrlPressed = false;
            ignoreNextUp = 0;
            ignoreNextDown = 0;
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

        private async void HookKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                ctrlPressed = true;
                return;
            }
            if (e.KeyCode == Keys.Space && ctrlPressed)
            {
                EditorView.instance.StopProgramButton_Click(null, null);
                ctrlPressed = false;
                return;
            }

            if (!isActive)
                return;
            if (ignoreNextDown > 0)
            {
                --ignoreNextDown;
                return;
            }
            if (e.KeyCode == Keys.Tab)
            {
                EditorView.instance.Tab_Pressed();
                return;
            }

            if (!StringConverter.CanProcess(e.KeyCode))
                return;
            ++isProcessingKeyDown;
            if(isSupressing)
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
