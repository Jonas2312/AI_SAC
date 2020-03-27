using AI_SAC.AutoCompletion.Model.XML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AI_SAC.AutoCompletion.ViewModel
{
    public class DataCollectionViewModel : ObservableCollection<DataItemViewModel>
    {
        public DataCollection dataCollection;
        public DataCollectionViewModel(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
            foreach(DataItem dataItem in dataCollection)
            {
                Add(new DataItemViewModel(dataItem));
            }
        }

        

    }
}
