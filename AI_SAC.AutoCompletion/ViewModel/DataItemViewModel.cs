﻿using AI_SAC.AutoCompletion.Model.XML;
using AI_SAC.AutoCompletion.Others;
using System.Windows;

namespace AI_SAC.AutoCompletion.ViewModel
{
    public class DataItemViewModel : ObservableObject
    {
        public DataItem dataItem;
        public DataItemViewModel(DataItem dataItem)
        {
            this.dataItem = dataItem;
            ID = dataItem.id;
            Trigger = dataItem.trigger;
            Completion = dataItem.completion;
            IsReplacing = dataItem.isReplacing;
        }

        public DataItem ToModel()
        {
            return dataItem;
        }



        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                dataItem.id = value;
                NotifyPropertyChanged();
            }
        }


        private string trigger;
        public string Trigger
        {
            get { return trigger; }
            set
            {
                trigger = value;
                dataItem.trigger = value;
                dataItem.CreateID();
                ID = dataItem.id;
                NotifyPropertyChanged();
            }
        }


        private string completion;
        public string Completion
        {
            get { return completion; }
            set
            {
                completion = value;
                dataItem.completion = value;
                dataItem.CreateID();
                ID = dataItem.id;
                NotifyPropertyChanged();
            }
        }


        private bool isReplacing;
        public bool IsReplacing
        {
            get { return isReplacing; }
            set
            {
                isReplacing = value;
                dataItem.isReplacing = value;
                dataItem.CreateID();
                ID = dataItem.id;
                NotifyPropertyChanged();
            }
        }

        private Visibility itemVisibility;
        public Visibility ItemVisibility
        {
            get { return itemVisibility; }
            set
            {
                itemVisibility = value;
                NotifyPropertyChanged();
            }
        }
    }
}