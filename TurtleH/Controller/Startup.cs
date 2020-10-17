using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace TurtleH.Controller
{
    class Startup
    {
        private static Startup instance;

        public static Startup Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Startup();
                }
                return instance;
            }
            private set => instance = value;
        }

        public static readonly string keyValue = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public static readonly string keyName = "TurtleH";

        public bool IsStartWithWindows()
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
                Logs.Instance.WriteToFile(Logs.Instance.errorFile, "_startup_ " + ex.Message);

                return false;
            }
        }

        public bool SetStartup(bool startup)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyValue, true))
                {
                    if(startup == true)
                    {
                        key.SetValue(keyName, Application.ExecutablePath);
                        key.Close();
                    }
                    else
                    {
                        key.DeleteValue(keyName);
                        key.Close();
                    }
                }

                Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                    (startup == true ? "Enable" : "Disable") + " startup successfully"
                    );

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enable/Disable startup failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logs.Instance.WriteToFile(Logs.Instance.errorFile, "_startup_ " + ex.Message);

                return false;
            }
        }
    }
}
