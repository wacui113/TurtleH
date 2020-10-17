using Microsoft.Win32;
using System;
using System.Windows.Forms;
using TurtleH.Controller;

namespace TurtleH
{
    public partial class mainForm : Form
    {
        private readonly TimerHandler timerHandler;

        // Force stop variable
        private bool fStop = false;
        private bool fWindowsPwr_Sta = false;

        /** Function
         * 
         * Log to file
         * Check startup state
         * Initalize timer
         * 
         */
        public mainForm()
        {
            InitializeComponent();

            Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                "Application started"
                );

            notifyIcon.Visible = true;
            chkbStartup.Checked = Startup.Instance.IsStartWithWindows();

            timerHandler = new TimerHandler();
            timerHandler.TimerTicked += TimerHandler_TimerTicked;
            timerHandler.TimerStateChanged += TimerHandler_TimerStateChanged;

            StartupWithWindows();
        }

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(Startup.Instance.IsStartWithWindows())
            {
                DisplayTimerPanel(true);
                DisplayWindow(false);
            }
            else
            {
                DisplayTimerPanel(false);
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminatedApp();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if(timerHandler.IsRunning())
            {
                fStop = true;
                this.Stop();

                Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                    "Forced to stop"
                    );
            }
            else
            {
                fStop = false;
                this.Start();

                Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                    "Forced to start"
                    );
            }
        }

        /** Events-Delegate
         * 
         * Automatically start after stopping and RestForm closed
         * OR
         * Stop completely when the user is forced to stop
         * 
         * @param bool state
         */
        private void TimerHandler_TimerStateChanged(bool state)
        {
            DisplayTimerPanel(state);
              if (state == false && fStop == false && fWindowsPwr_Sta == false)
            {
                Stop();
                Start();
            }
             if(fWindowsPwr_Sta == true) { fWindowsPwr_Sta = false; }
        }

        private void TimerHandler_TimerTicked(int value)
        {
            if (value == 10)
            {
                notifyIcon.ShowBalloonTip(3, "Take a rest", "Rest after " + value + " seconds !", ToolTipIcon.Info);
            }

            notifyIcon.Text = timerToolStripMenuItem.Text = lblDisplayTime.Text = DisplayTime(value);
        }

        private void NudRemind_ValueChanged(object sender, EventArgs e)
        {
            timerToolStripMenuItem.Text = lblDisplayTime.Text = DisplayTime(Convert.ToInt32(nudRemind.Value) * 60);
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnStart_Click(btnStart, e);
        }

        private void BtnHideToTray_Click(object sender, EventArgs e)
        {
            DisplayWindow(false);
        }

        private void ShowWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayWindow(true);
        }

        private void ChkbStartup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if(Startup.Instance.SetStartup(cb.Checked) == false)
            {
                chkbStartup.Checked = !chkbStartup.Checked;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminatedApp();
        }  
        
        #endregion

        #region Methods

        private void Start()
        {
            timerHandler.Start(Convert.ToInt32(nudRemind.Value) * 60);
        }

        private void Stop()
        {
            timerHandler.Stop();

            timerToolStripMenuItem.Text = lblDisplayTime.Text = DisplayTime(Convert.ToInt32(nudRemind.Value) * 60);

            if (fStop == false)
            {
                ShowRestForm();
            }
        }

        private void StartupWithWindows()
        {
            if(Startup.Instance.IsStartWithWindows() == true)
            {
                Start();
            }
        }

        private void DisplayTimerPanel(bool display)
        {
            startToolStripMenuItem.Text = btnStart.Text =
                display == false ? "START" : "STOP";

            pnlDisplay.Visible = display;
            pnlSelect.Visible = !display;
        }

        private void DisplayWindow(bool display)
        {
            if(display == true) {
                this.Show();
            } else {
                this.Hide();
            }

            this.ShowInTaskbar = this.ShowIcon = display;
        }

        private string DisplayTime(int value)
        {
            return (value / 60).ToString("00") + ":" + (value % 60).ToString("00");
        }

        private void ShowRestForm()
         {
            using (restForm restF = new restForm
            {
                countDown = Convert.ToInt32(nudRestIn.Value)
            })
            {
                restF.ShowDialog();
            }
            this.Hide();

            if (this.ShowInTaskbar == true)
            {
                this.Show();
            }
        }

        private void TerminatedApp()
        {
            // ---
            timerHandler.TimerTicked -= TimerHandler_TimerTicked;
            timerHandler.TimerStateChanged -= TimerHandler_TimerStateChanged;

            Logs.Instance.WriteToFile(Logs.Instance.serviceFile,
                "Application stopped"
                ); ;

            this.Dispose();

            Application.Exit();
        }
        #endregion
    }
}
