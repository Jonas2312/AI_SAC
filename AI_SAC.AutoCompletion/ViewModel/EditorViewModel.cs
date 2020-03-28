using AI_SAC.AutoCompletion.Model.HookFeed;
using AI_SAC.AutoCompletion.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_SAC.AutoCompletion.ViewModel
{
    public class EditorViewModel : ObservableObject
    {
        
        public EditorViewModel(HookFeedController hookFeedController)
        {
            this.HookFeedController = hookFeedController;
            excelTableViewModel = new ExcelTableViewModel(hookFeedController.xmlData);
        }

        private HookFeedController hookFeedController;
        public HookFeedController HookFeedController
        {
            get { return hookFeedController; }
            set
            {
                if (hookFeedController != value)
                {
                    hookFeedController = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ExcelTableViewModel excelTableViewModel;
        public ExcelTableViewModel ExcelTableViewModel
        {
            get { return excelTableViewModel; } 
            set
            {
                if(excelTableViewModel != value)
                {
                    excelTableViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
