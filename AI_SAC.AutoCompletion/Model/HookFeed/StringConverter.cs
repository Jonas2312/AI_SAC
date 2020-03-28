using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_SAC.AutoCompletion.Model.HookFeed
{
    public static class StringConverter
    {
        public static char recieveShiftChar(char c)
        {
            if (c == '0')
                return '=';
            else if (c == '1')
                return '!';
            else if (c == '2')
                return '"';
            else if (c == '3')
                return '§';
            else if (c == '4')
                return '$';
            else if (c == '5')
                return '%';
            else if (c == '6')
                return '&';
            else if (c == '7')
                return '/';
            else if (c == '8')
                return '(';
            else if (c == '9')
                return ')';
            return c;
        }
        public static string replaceSpecialChars(string s)
        {

            s = s.Replace("+", "{+}");  // This before replacing the shift+number
            s = s.Replace("~", "{~}");

            s = s.Replace("=", "+0");
            s = s.Replace("!", "+1");
            s = s.Replace("\"", "+2");
            s = s.Replace("§", "+3");
            s = s.Replace("$", "+4");
            s = s.Replace("%", "+5");
            s = s.Replace("&", "+6");
            s = s.Replace("/", "+7");
            s = s.Replace("(", "+8");
            s = s.Replace(")", "+9");
            return s;
        }
        public static bool CanProcess(Keys key)
        {
            string keyToString = key.ToString();
            if (key == Keys.Space)
                return true;
            else if (key == Keys.Tab)
                return true;
            else if (key == Keys.Back)
                return true;
            else if (key == Keys.Enter)
                return true;
            else if (key == Keys.Oemplus)
                return true;
            else if (key == Keys.OemQuestion)
                return true;
            else if (key == Keys.Add)
                return true;
            else if (key == Keys.OemQuotes)
                return true;
            else if (key == Keys.LControlKey || key == Keys.RControlKey)
                return true;
            else if (key == Keys.LShiftKey || key == Keys.RShiftKey)
                return true;
            else if (key == Keys.Oemtilde)
                return true;
            else if (key == Keys.Oem1)
                return true;
            else if (key == Keys.Oem7)
                return true;
            else if (keyToString.Length == 2 && keyToString[0] == 'D')
                return true;
            if (keyToString.Length == 1)
                return true;

            return false;
        }

        internal static bool isShift(string s)
        {
            if (s.Contains("{"))
                return false;
            if (s.Contains("+"))
                return true;
            else if (s.ToLower() != s)
                return true;
            return false;
        }

        public static string ToSendKeys(string s)
        {
            string newString = string.Empty;
            foreach(char c in s)
            {
                if (c.ToString().ToLower() != c.ToString())
                    newString += "+";
                newString += c.ToString().ToLower();
            }
            System.Diagnostics.Debug.WriteLine(newString);
            return newString;
        }

        public static string KeyToString(KeyData key)
        {
            string keyToString = key.key.ToString();
            if (key.key == Keys.Space)
                keyToString = " ";
            else if (key.key == Keys.Back)
                keyToString = "{BACKSPACE}";
            else if (key.key == Keys.OemQuestion)
                keyToString = "#";
            else if (key.key == Keys.Oemplus)
                keyToString = "+";
            else if (key.key == Keys.Add)
                keyToString = "+";
            else if (key.key == Keys.Enter)
                keyToString = "{ENTER}";
            else if (key.key == Keys.Oemtilde)
                keyToString = "ö";
            else if (key.key == Keys.Oem1)
                keyToString = "ü";
            else if (key.key == Keys.Oem7)
                keyToString = "ä";
            else if (keyToString.Length == 2 && keyToString[0] == 'D')
            {
                keyToString = keyToString[1].ToString();
                if (key.shiftPressed)
                    keyToString = keyToString.Insert(0, recieveShiftChar(keyToString[0]).ToString()).Remove(1, 1);

                return keyToString;
            }
            else if (keyToString.Length >= 3)
            {
                keyToString = String.Empty;
            }

            if (keyToString.Length == 1)
            {
                if (!key.shiftPressed)
                    keyToString = keyToString.ToLowerInvariant();
                if (key.shiftPressed)
                {
                    keyToString = keyToString.ToUpperInvariant();
                }

            }

            return keyToString;
        }

        public static KeyData StringToKey(string s)
        {
            throw new NotImplementedException();
        }
    }
}
