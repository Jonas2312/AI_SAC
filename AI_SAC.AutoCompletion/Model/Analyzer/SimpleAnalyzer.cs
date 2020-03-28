using AI_SAC.AutoCompletion.Model.HookFeed;
using AI_SAC.AutoCompletion.Model.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AI_SAC.AutoCompletion.Model.Analyzer
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
                    FeedDataItem(p);
                    break;
                }
            }
        }
        
    }
}
