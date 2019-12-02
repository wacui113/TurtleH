using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;
using TurtleH.Controller;

namespace TurtleH
{
    public partial class mainForm : Form
    {
        private const int TwentyMinutes = 1200;

        Timer timer;

        // Needed variable
        private int tickValue;
        private bool stop = false;
        private bool notify = false;

        public mainForm()
        {
            InitializeComponent();

            // Determine a Duration of a Locked Workstation
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                "Application is executed"
                );

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            tickValue = TwentyMinutes;

            pnlDisplay.Visible = false;
            pnlSelect.Visible = true;

            notifyIcon.Visible = true;
                        
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
            catch (Exception ex)
            {
                Logs.Instance.WriteToFile(Logs.Instance.serviceFile, ex.Message);

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
            catch (Exception ex)
            {
                Logs.Instance.WriteToFile(Logs.Instance.serviceFile, ex.Message);

                TerminatedApp();
            }
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

            Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                "Timer is started"
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
                restForm restF = new restForm();
                restF.tickRestTime = Convert.ToInt32(nudRestIn.Value);
                this.Hide();
                restF.ShowDialog();

                if (this.ShowInTaskbar == true)
                {
                    this.Show();
                }
            }

            Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                "Timer is stopped"
                ); ;
        }

        private string DisplayTime()
        {
            return (tickValue / 60).ToString("00") + ":" + (tickValue % 60).ToString("00");
        }

        private void TerminatedApp()
        {
            Microsoft.Win32.SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
            Microsoft.Win32.SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;

            Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                "Application is terminated"
                ); ;

            this.Dispose();

            Application.Exit();
        }
        #endregion

    }
}
