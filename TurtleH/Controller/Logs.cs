using System;
using System.IO;

namespace TurtleH.Controller
{
    class Logs
    {
        public readonly string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        public readonly string serviceFile = "\\service\\service_" + DateTime.Now.ToShortDateString() + ".txt";
        // public readonly string errorFile = "\\error\\error_" + DateTime.Now.ToShortDateString() + ".txt";

        private static Logs instance;
        public static Logs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logs();
                }

                return instance;
            }
            private set => instance = value;
        }

        public void WriteToFile(string path, string message)
        {
            if(!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }

            string fullPath = this.path + path;

            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
