using AI_SAC.AutoCompletion.Model.HookFeed;
using System.Collections.Generic;
using AI_SAC.AutoCompletion.Model.XML;

namespace AI_SAC.AutoCompletion.Model.Analyzer
{
    public class KeyAnalyzer
    {
        public virtual void RecieveKeyPress(KeyData key) { }
        public virtual void checkInputs() { }

        public void FeedDataItem(DataItem dataItem)
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
            s = StringConverter.replaceSpecialChars(s);
            stringsToFeed.Add(s);
            currentString = string.Empty;            
        }

        public string currentString;
        public List<string> stringsToFeed;
        public DataCollection xmlData;
    }
}
