using AI_SAC.Model.HookFeed;
using AI_SAC.Model.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AI_SAC.Model.Analyzer
{
    public class SimpleAnalyzer : KeyAnalyzer
    {
        public SimpleAnalyzer(DataCollection xmlData)
        {
            stringsToFeed = new List<string>();
            this.xmlData = xmlData;
            currentString = string.Empty;
        }
        public override void RecieveKeyPress(KeyData key)
        {
            if (key.key == Keys.Back)
            {
                if (currentString.Length == 0)
                    return;
                currentString = currentString.Remove(currentString.Length - 1);                
            }
            else if (key.key == Keys.Space)
                currentString += " ";
            else
                currentString += StringConverter.KeyToString(key);
            System.Diagnostics.Debug.WriteLine(currentString);
        }

        public override void checkInputs()
        {
            foreach (var p in xmlData)
            {
                int keyLength = p.trigger.Length;
                if (keyLength < 3)
                    continue;   //Lets not allow that
                if (p.completion.Length < 1)
                    continue;   //Lets not allow that
                int currentStringLength = currentString.Length;
                if (keyLength > currentStringLength)
                    continue;

                if (p.trigger.ToLower() == 
                    currentString.Substring(currentStringLength - keyLength).ToLower())
                {
                    string s = string.Empty;
                    // Verwenden Sie das Format {Key Number}, um sich wiederholende Schlüssel anzu
                    // geben. Sie müssen ein Leerzeichen zwischen Schlüssel und Zahl platzieren.
                    // {Left 42} bedeutet beispielsweise, dass die nach-links-Taste 42 Mal gedrückt
                    // wird. {h 10} bedeutet, h 10-Mal zu drücken.
                    if (p.isReplacing)
                    {
                        for(int i=0;i<keyLength;i++)
                        {
                            s += "{BACKSPACE}";
                        }
                    }
                    s += p.completion;
                    s = StringConverter.replaceSpecialChars(s);
                    System.Diagnostics.Debug.WriteLine(s);
                    stringsToFeed.Add(s);
                    currentString = String.Empty;
                    break;
                }
            }
        }
        
    }
}
