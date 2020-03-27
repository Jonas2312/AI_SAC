using AI_SAC.AutoCompletion.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AI_SAC.AutoCompletion.Model.XML
{
    public class DataCollection : List<DataItem>
    {
        public DataCollection(string filePath) : base()
        {
            this.filePath = filePath;
        }
        public string filePath;

        public void FromViewModel(DataCollectionViewModel dataCollectionViewModel)
        {
            Clear();
            foreach (DataItemViewModel dataItemViewModel in dataCollectionViewModel)
            {
                Add(dataItemViewModel.ToModel());
            }
        }

        public void Save()
        {
            System.Diagnostics.Debug.WriteLine("Saving");
            XMLSave.Save(this, filePath);
        }
    }
}
