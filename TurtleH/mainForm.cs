using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace TurtleH
{
    public partial class mainForm : Form
    {
        private const int TwentyMinutes = 1200;

        Timer timer;

        // Path variable
        private string path = AppDomain.CurrentDomain.BaseDirectory;
        private string appStatusFileName = "\\status\\status_" + DateTime.Now.ToShortDateString();
        private string errorFileName = "\\errors\\error_" + DateTime.Now.ToShortDateString();

        // Needed variable
        private int tickValue;
        private bool stop = false;
        private bool notify = false;

        public mainForm()
        {
            InitializeComponent();

            WriteToFile(appStatusFileName,
                "Application is started at " + DateTime.Now.ToString()
                ); ;

            // Determine a Duration of a Locked Workstation
            Microsoft.Win32.SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            tickValue = TwentyMinutes;

            pnlDisplay.Visible = false;
            pnlSelect.Visible = true;

            notifyIcon.Visible = true;
                        
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            try
            {
                switch (e.Mode)
                {
                    case PowerModes.Resume:
                        Start();
                        break;

                    case PowerModes.Suspend:
                        Stop();
                        break;
                }
            }
            catch (Exception err)
            {
                WriteToFile(errorFileName, err.Message);

                TerminatedApp();
            }
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            try
            {
                switch (e.Reason)
                {
                    case SessionSwitchReason.SessionLock:
                        Stop();
                        break;

                    case SessionSwitchReason.SessionUnlock:
                        Start();
                        break;
                }
            }
            catch (Exception err)
            {
                WriteToFile(errorFileName, err.Message);

                TerminatedApp();
            }
        }

        // Startup registry key and value
        public static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public static readonly string StartupValue = "TurtleH";

        private void SetStartup(bool startupStatus)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true))
            {
                if (startupStatus == true)
                {
                    key.SetValue(StartupValue, Application.ExecutablePath.ToString());
                    key.Close();
                }
                else
                {
                    key.DeleteValue(StartupValue);
                    key.Close();
                }
            }
        }

        #region Events
        /* 
         Timer_Tick :
         - Stop after time is less than 0
         - Time still is greater than 0 :
            + Run progress
            + Notify user when value is less than 10
         */
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tickValue <= 0)
            {
                Stop();
                Start();
            }
            else
            {
                tickValue--;
                if (tickValue <= 10 && notify == false)
                {
                    notifyIcon.ShowBalloonTip(3, "Time to rest", "Begin resting after " + tickValue + "s", ToolTipIcon.Info);
                    notify = true;
                }
            }

            timerToolStripMenuItem.Text = lblDisplayTime.Text = DisplayTime();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                stop = false;
                Start();
            }
            else
            {
                stop = true;
                Stop();
            }
        }

        private void BtnHideToTray_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
        }

        /* Menu on tray icon
         * ---
         * Start/Stop function on tray icon
         * Timer
         * Show Windows function
         * Exit app fuction
         * ---
         */
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnStart_Click(btnStart, e);
        }

        private void ShowWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            this.ShowIcon = true;
        }

        private void ChkbStartup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            SetStartup(cb.Checked);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminatedApp();
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminatedApp();
        }
        #endregion

        #region Methods

        private void Start()
        {
            tickValue = Convert.ToInt32(nudRemind.Value * 60);
            timerToolStripMenuItem.Text = lblDisplayTime.Text = DisplayTime();

            startToolStripMenuItem.Text = btnStart.Text = "Stop";

            notify = false;

            pnlDisplay.Visible = true;
            pnlSelect.Visible = false;

            timer.Enabled = true;

            WriteToFile(appStatusFileName,
                "Timer is started at " + DateTime.Now.ToString()
                ); ;
        }


        /* Stop method : 
         * - Setup needed things
         * - Show RestForm if user don't force STOP
         */
        private void Stop()
        {
            timer.Enabled = false;

            startToolStripMenuItem.Text = btnStart.Text = "Start";


            pnlDisplay.Visible = false;
            pnlSelect.Visible = true;

            if (stop == false)
            {
                try
                {
                    restForm restF = new restForm();
                    restF.tickRestTime = Convert.ToInt32(nudRestIn.Value);
                    this.Hide();
                    restF.ShowDialog();
                }
                catch (Exception err)
                {
                    WriteToFile(errorFileName, err.Message);

                    TerminatedApp();
                }

                if (this.ShowInTaskbar == true)
                {
                    this.Show();
                }
            }

            WriteToFile(appStatusFileName,
               "Timer is stopped at " + DateTime.Now.ToString()
                ); ;
        }

        private string DisplayTime()
        {
            return (tickValue / 60).ToString("00") + ":" + (tickValue % 60).ToString("00");
        }

        private void WriteToFile(string path, string message)
        {
            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(message);
                }
            }
        }

        private void TerminatedApp()
        {
            Microsoft.Win32.SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
            Microsoft.Win32.SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;

            WriteToFile(appStatusFileName,
                "Application is terminated at " + DateTime.Now.ToString()
                ); ;

            this.Dispose();

            Application.Exit();
        }
        #endregion

    }
}
