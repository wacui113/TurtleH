using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace TurtleH.Controller
{
    class StartWithWindows
    {
        private static StartWithWindows instance;

        public static StartWithWindows Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StartWithWindows();
                }

                return instance;
            }
                
            private set => instance = value;
        }

        public static readonly string keyValue = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public static readonly string keyName = "TurtleH";

        public bool CheckStartupState()
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(keyValue, false);
                if (key.GetValue(keyName) == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logs.Instance.WriteToFile(Logs.Instance.serviceFile, ex.Message);

                return false;
            }
        }

        public bool SetStartup(bool state)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyValue, true))
                {
                    if (state == true)
                    {
                        key.SetValue(keyName, Application.ExecutablePath);
                        key.Close();
                    }
                    else
                    {
                        key.DeleteValue(keyName);
                        key.Close();
                    }

                    Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                        "Application " + 
                        (   state == true ?
                            "registered startup key in " + "\"" + Application.ExecutablePath + "\"" + "successfully"
                            : "removed startup state successfully"
                        )

                        );
                }

                return true;
            }
            catch (Exception ex)
            {
                Logs.Instance.WriteToFile(Logs.Instance.serviceFile, ex.Message);

                return false;
            }
        }

    }
}
