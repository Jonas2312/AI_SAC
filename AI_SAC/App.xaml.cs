using AI_SAC.Model.HookFeed;
using AI_SAC.Model.XML;
using AI_SAC.Others;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AI_SAC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Process.GetCurrentProcess().Kill();
        }

    }
}
