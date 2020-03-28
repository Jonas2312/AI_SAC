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
            CurrentString = string.Empty;
        }
        public override void RecieveKeyPress(KeyData key)
        {
            if (key.key == Keys.Back)
            {
                if (CurrentString.Length == 0)
                    return;
                CurrentString = CurrentString.Remove(CurrentString.Length - 1);                
            }
            else if (key.key == Keys.Space)
            {
                if (!string.IsNullOrWhiteSpace(CurrentString))
                    CurrentString += " ";
            }
            else
                CurrentString += StringConverter.KeyToString(key);
            System.Diagnostics.Debug.WriteLine(CurrentString);
        }

        public override void checkInputs()
        {
            foreach (var p in xmlData)
            {
                int keyLength = p.trigger.Length;
                if (keyLength < 2)
                    continue;   //Lets not allow that
                if (p.completion.Length < 1)
                    continue;   //Lets not allow that
                int currentStringLength = CurrentString.Length;
                if (keyLength > currentStringLength)
                    continue;

                if (p.trigger.ToLower() == 
                    CurrentString.Substring(currentStringLength - keyLength).ToLower())
                {
                    FeedDataItem(p);
                    break;
                }
            }
        }

        public override void FeedDataItem(DataItem dataItem)
        {
            System.Diagnostics.Debug.WriteLine("Current string: " + CurrentString);
            DataItem temp = dataItem.DeepCopy();
            if (CurrentString.Length <= temp.trigger.Length)
            {
                if (!temp.isReplacing)
                {
                    temp.completion = temp.completion.Insert(0, temp.trigger);
                    temp.completion = temp.completion.Remove(0, CurrentString.Length);
                }

                else
                {
                    temp.isReplacing = false;
                    foreach (char c in CurrentString)
                    {
                        temp.completion = temp.completion.Insert(0, "{BACKSPACE}");
                    }
                    
                }
                
            }
            //else if(CurrentString.Length > temp.trigger.Length)
            //{
            //    if (!temp.isReplacing)
            //    {
            //        foreach (var v in CurrentString)
            //        {
            //            temp.trigger.Remove(0);
            //        }
            //        temp.completion.Insert(0, temp.trigger);
            //    }                
            //}
            
                    
            base.FeedDataItem(temp);
        }
        
    }
}
