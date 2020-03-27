using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace AI_SAC.AutoCompletion.Model.XML
{
    public class XMLSave
    {
        public static void Save(DataCollection xmlData, string filePath)
        {
            System.Diagnostics.Debug.WriteLine("Filepath: " + filePath);

            if (!File.Exists(filePath))
            {
                System.Diagnostics.Debug.WriteLine("Filepath: " + filePath);
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    
                }

            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.NewLineOnAttributes = true;
            settings.Indent = true;

            XmlWriter xmlWriter = XmlWriter.Create(filePath, settings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("DataCollection");

            foreach(DataItem dataItem in xmlData)
            {
                xmlWriter.WriteStartElement("DataItem");
                foreach(var property in dataItem.GetType().GetProperties())
                {
                    xmlWriter.WriteAttributeString(property.Name, property.GetValue(dataItem).ToString());
                }
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
    }
}
