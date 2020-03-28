using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AI_SAC.AutoCompletion.Others
{
    public static class Utils
    {
        public static string getXMLFilePath()
        {
            string filePath = Directory.GetCurrentDirectory();
            filePath += "\\Databases0";
            return filePath;
        }
    }
}
