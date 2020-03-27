using System;
using System.Collections.Generic;
using System.Text;

namespace AI_SAC.AutoCompletion.Model.XML
{
    public class DataItem
    {
        public string id { get; set; }
        public string trigger { get; set; }
        public string completion { get; set; }
        public bool isReplacing { get; set; }

        public DataItem()
        {

        }
        public DataItem(string id, string key, string value, bool isReplacing)
        {
            this.id = id;
            this.trigger = key;
            this.completion = value;
            this.isReplacing = isReplacing;
        }

        public void CreateID()
        {
            id = trigger.GetHashCode().ToString();
            id += completion.GetHashCode().ToString();
            id += isReplacing.GetHashCode().ToString();
        }
    }
}
