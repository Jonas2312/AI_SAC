using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_SAC.Model.HookFeed
{
    public class KeyFeed
    {
        public const int SEND_DELAY = 1;
        public List<string> stringsToFeed;
        public bool isActive;
        private readonly KeyHook keyHook;
        public KeyFeed(KeyHook keyHook)
        {
            stringsToFeed = new List<string>();
            this.keyHook = keyHook;
        }

        public void AddKeyToFeed(KeyData key)
        {
            stringsToFeed.Add(StringConverter.KeyToString(key));
        }

        public void AddStringToFeed(string s)
        {
            stringsToFeed.Add(s);
        }

        public void Feed()
        {
            keyHook.isHookingKeyDowns = false;
            if (stringsToFeed.Count > 0)
            {
                SendString(stringsToFeed[0]);
                stringsToFeed.RemoveAt(0);
            }
            keyHook.isHookingKeyDowns = true;
        }

        public void SendString(string s)
        {
            bool atomicUnfinished = false;
            string atomic = string.Empty;

            foreach(char c in s)
            {
                if (!isActive)
                    return;
                atomic += c.ToString();
                if (c == '+')
                {
                    continue;
                }
                else if (c == '{')
                {
                    atomicUnfinished = true;
                }
                else if(c == '}')
                {
                    atomicUnfinished = false;
                }

                if (atomicUnfinished)
                {
                    continue;
                }
                else
                {
                    SendAtomic(atomic);
                    atomic = string.Empty;
                }
            }
        }

        public void SendAtomic(string s)
        {
            if((s.ToLower() != s || s.Contains("+")) && !s.Contains("{"))
            { 
                ++keyHook.ignoreNextUp;
                ++keyHook.ignoreNextDown;
            }
            ++keyHook.ignoreNextUp;
            ++keyHook.ignoreNextDown;
            SendKeys.SendWait(s);
            Thread.Sleep(SEND_DELAY);
        }

    }
}
