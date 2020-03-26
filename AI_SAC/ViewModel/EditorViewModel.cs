using AI_SAC.Model.HookFeed;
using AI_SAC.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_SAC.ViewModel
{
    public class EditorViewModel : ObservableObject
    {
        public HookFeedController hookFeedController { get; set; }
        public EditorViewModel(HookFeedController hookFeedController)
        {
            this.hookFeedController = hookFeedController;
            excelTableViewModel = new ExcelTableViewModel(hookFeedController.xmlData);
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
