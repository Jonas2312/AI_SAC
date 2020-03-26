using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AI_SAC.Others
{
    public static class Utils
    {
        public static string getXMLFilePath()
        {
            return Directory.GetCurrentDirectory();
            string filePath = Assembly.GetExecutingAssembly().Location;
            if (filePath == null)
                return "\\";
            filePath = Path.GetDirectoryName(filePath);
            filePath = Path.GetDirectoryName(filePath);
            filePath = Path.GetDirectoryName(filePath);
            filePath = Path.GetDirectoryName(filePath);
            filePath += "\\xmlFiles\\";
            return filePath;
        }
    }
}
