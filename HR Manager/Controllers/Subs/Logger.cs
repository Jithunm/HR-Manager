using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace HR_Manager.Controllers.Subs
{
    public class Logger
    {

        public static void WriteLog(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];

            using (StreamWriter writer = new StreamWriter(logPath,true))
            {
                writer.WriteLine($"{DateTime.Now} : { message }");
            }
        }
        
    }
}