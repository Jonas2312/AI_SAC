using AI_SAC.AutoCompletion.Model.HookFeed;
using System.Collections.Generic;
using AI_SAC.AutoCompletion.Model.XML;
using System;
using AI_SAC.AutoCompletion.Others;

namespace AI_SAC.AutoCompletion.Model.Analyzer
{
    public class KeyAnalyzer : ObservableObject
    {
        public virtual void RecieveKeyPress(KeyData key) { }
        public virtual void checkInputs() { }

        public virtual void FeedDataItem(DataItem dataItem)
        {
            int keyLength = dataItem.trigger.Length;
            string s = string.Empty;
            // Verwenden Sie das Format {Key Number}, um sich wiederholende Schlüssel anzu
            // geben. Sie müssen ein Leerzeichen zwischen Schlüssel und Zahl platzieren.
            // {Left 42} bedeutet beispielsweise, dass die nach-links-Taste 42 Mal gedrückt
            // wird. {h 10} bedeutet, h 10-Mal zu drücken.
            if (dataItem.isReplacing)
            {
                for (int i = 0; i < keyLength; i++)
                {
                    s += "{BACKSPACE}";
                }
            }
            s += dataItem.completion;
            stringsToFeed.Add(s);
            CurrentString = string.Empty;            
        }

        private string currentString;
        public string CurrentString
        {
            get { return currentString; }
            set
            {
                if(currentString != value)
                {
                    currentString = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<string> stringsToFeed;
        public DataCollection xmlData;
    }
}
