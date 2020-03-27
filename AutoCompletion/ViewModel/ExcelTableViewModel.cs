using AI_SAC.Model.XML;
using AI_SAC.Others;
using AI_SAC.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace AI_SAC.ViewModel
{
    public class ExcelTableViewModel : ObservableObject
    {
        public DataCollection dataCollection;
        public ExcelTableViewModel(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
            XMLData = new DataCollectionViewModel(dataCollection);
            XMLData.CollectionChanged += XMLDataCollection_Changed;
            foreach(var item in XMLData)
            {
                item.PropertyChanged += XMLDataItem_Changed;
            }
        }


        private DataCollectionViewModel xmlData;
        public DataCollectionViewModel XMLData
        {
            get { return xmlData; }
            set
            {
                if(xmlData != value)
                {
                    xmlData = value;
                    dataCollection.FromViewModel(value);
                    dataCollection.Save();
                    NotifyPropertyChanged();
                }
            }
        }

        public void XMLDataCollection_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach(INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += XMLDataItem_Changed;
                }
            }

            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged += XMLDataItem_Changed;
                }
            }

            EditorView.instance.StopProgramButton_Click(sender, null);
            dataCollection.FromViewModel(XMLData);
            dataCollection.Save();
        }

        public void XMLDataItem_Changed(object sender, PropertyChangedEventArgs e)
        {
            EditorView.instance.StopProgramButton_Click(sender, null);
            dataCollection.FromViewModel(XMLData);
            dataCollection.Save();
        }


    }
}
