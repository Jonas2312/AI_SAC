﻿using AI_SAC.AutoCompletion.Model.HookFeed;
using System.Collections.Generic;
using AI_SAC.AutoCompletion.Model.XML;

namespace AI_SAC.AutoCompletion.Model.Analyzer
{
    public class KeyAnalyzer
    {
        public virtual void RecieveKeyPress(KeyData key) { }
        public virtual void checkInputs() { }

        public void FeedDataItem()
        {

        }

        public string currentString;
        public List<string> stringsToFeed;
        public DataCollection xmlData;
    }
}
