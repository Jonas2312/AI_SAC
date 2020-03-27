
using AI_SAC.AutoCompletion.Model.XML;
using AI_SAC.AutoCompletion.Others;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AI_SAC.AutoCompletion_TestUnit
{
    [TestClass]
    public class SaveLoadTest
    {
        [TestMethod]
        public void SaveLoadTest1()
        {
            DataCollection xmlData = new DataCollection("");
            xmlData.Add(new DataItem("", "a", "bc", false));
            xmlData.Add(new DataItem("", "tiat", "This is a test.", true));

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
