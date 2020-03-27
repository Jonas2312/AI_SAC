using AI_SAC.Model.Analyzer;
using AI_SAC.Model.XML;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_SAC.Model.HookFeed
{
    public class HookFeedController
    {
        public KeyAnalyzer keyAnalyzer;
        public KeyHook keyHook;
        public KeyFeed keyFeed;

        public DataCollection xmlData;

        bool repeatKeypress;
        bool analyzeKeypress;

        private readonly Thread hookThread;
        private readonly Thread feedThread;
        private readonly Thread analyzeThread;
        public bool isRunning;
        public bool isActive;
        const int LOOP_DELAY = 10;

        public HookFeedController(DataCollection xmlData)
        {
            analyzeKeypress = true;
            repeatKeypress = true;
            isRunning = true;
            isActive = false;

            this.xmlData = xmlData;
            keyAnalyzer = new SimpleAnalyzer(xmlData);
            keyHook = new KeyHook();
            keyFeed = new KeyFeed(keyHook);
            hookThread = new Thread(() => Hook());            
            feedThread = new Thread(() => Feed());
            analyzeThread = new Thread(() => Analyze());
            hookThread.Start();
            feedThread.Start();
            analyzeThread.Start();
        }

        public void Hook()
        {
            while (isRunning)
            {
                keyHook.isActive = isActive;
                keyFeed.isActive = isActive;
                while (keyHook.hookedKeyDowns.Count > 0)
                {
                    KeyData key = keyHook.hookedKeyDowns[0];
                    if (analyzeKeypress)
                    {
                        keyAnalyzer.RecieveKeyPress(key);
                    }
                    if (repeatKeypress)
                    {
                        keyFeed.AddKeyToFeed(key);
                    }
                    keyHook.hookedKeyDowns.RemoveAt(0);
                }
                
                Thread.Sleep(LOOP_DELAY);
            }
        }

        public void Feed()
        {
            while (isRunning)
            {
                keyFeed.Feed();
                Thread.Sleep(LOOP_DELAY);
            }
        }

        public void Analyze()
        {
            while (isRunning)
            {
                keyAnalyzer.checkInputs();
                while (keyAnalyzer.stringsToFeed.Count > 0)
                {
                    keyFeed.AddStringToFeed(keyAnalyzer.stringsToFeed[0]);
                    keyAnalyzer.stringsToFeed.RemoveAt(0);
                }                
                Thread.Sleep(LOOP_DELAY);
            }
        }

    }
}
