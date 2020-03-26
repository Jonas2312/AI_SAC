using AI_SAC.Model.HookFeed;
using System.Collections.Generic;
using AI_SAC.Model.XML;

namespace AI_SAC.Model.Analyzer
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
