using AI_SAC.AutoCompletion.Model.HookFeed;
using System.Collections.Generic;
using AI_SAC.AutoCompletion.Model.XML;

namespace AI_SAC.AutoCompletion.Model.Analyzer
{
    public abstract class KeyAnalyzer
    {
        public abstract void RecieveKeyPress(KeyData key);
        public abstract void checkInputs();

        public string currentString;
        public List<string> stringsToFeed;
        public DataCollection xmlData;
    }
}
