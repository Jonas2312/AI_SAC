using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace AI_SAC.AutoCompletion.Model.XML
{
    public static class XMLLoad
    {
        public static DataCollection Load(string filePath)
        {
            System.Diagnostics.Debug.WriteLine("Filepath: " + filePath);
            DataCollection xmlData = new DataCollection(filePath);

            XElement data;
            Stream s = null;
            try
            {
                s = File.OpenRead(filePath);
                data = XElement.Load(s);
                s.Close();
            }
            catch
            {

                if (s != null)
                {
                    try
                    {

                        s.Close();
                    }
                    catch { }
                }
                
                XMLSave.Save(new DataCollection(filePath), filePath);

                s = File.OpenRead(filePath);
                data = XElement.Load(s);
                s.Close();
            }


            if (data.Name != "DataCollection")
                return null;

            foreach(XElement xmlDataItem in data.Elements())
            {
                if (xmlDataItem.Name != "DataItem")
                    continue;

                DataItem dataItem = new DataItem();
                foreach (var property in dataItem.GetType().GetProperties())
                {
                    string attributeValue = xmlDataItem.Attribute(property.Name)?.Value;
                    if (attributeValue == null)
                        continue;
                    if (property.PropertyType == typeof(bool))
                    {
                        if (attributeValue == "True")
                            property.SetValue(dataItem, true);
                        if (attributeValue == "False")
                            property.SetValue(dataItem, false);
                    }

                    else if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(dataItem, int.Parse(attributeValue));
                    }

                    else if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(dataItem, attributeValue);
                    }
                }
                xmlData.Add(dataItem);
            }

            return xmlData;
        }
    }
}
