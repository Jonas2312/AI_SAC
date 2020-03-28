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
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        public static string getXMLFilePath()
        {
            string filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            filePath += "\\AutoCompletion";
            System.IO.Directory.CreateDirectory(filePath);
            filePath += "\\Databases";
            System.IO.Directory.CreateDirectory(filePath);            
            return filePath;
        }
    }
}
