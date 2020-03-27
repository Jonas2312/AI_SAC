﻿using AI_SAC.Model.XML;
using AI_SAC.Others;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AI_SAC_TestUnit
{
    [TestClass]
    public class SaveLoadTest
    {
        [TestMethod]
        public void SaveLoadTest1()
        {
            DataCollection xmlData = new DataCollection();
            xmlData.Add(new DataItem(1, "a", "bc", false));
            xmlData.Add(new DataItem(2, "tiat", "This is a test.", true));

            string filePath = Utils.getXMLFilePath();
            filePath += "test.xml";

            XMLSave.Save(xmlData, filePath);
            xmlData = XMLLoad.Load(filePath);
            foreach(DataItem dataItem in xmlData)
            {
                foreach(var v in dataItem.GetType().GetProperties())
                {
                    System.Diagnostics.Debug.WriteLine("Property " + v.Name + " has value " + v.GetValue(dataItem) + ".");
                }
            }
        }
    }
}