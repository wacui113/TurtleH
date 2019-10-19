using System;
using System.Windows.Forms;

namespace TurtleH
{
    public partial class mainForm : Form
    {
        private const int TwentyMinutes = 1200;

        Timer timer;

        private int tickValue;
        private bool stop = false;
        private bool notify = false;

        public mainForm()
        {
            InitializeComponent();

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
            if(tickValue <= 0)
            {
                Stop();
                Start();
            }
            else
            {
                tickValue--;
                if(tickValue <= 10 && notify == false)
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
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            if(stop == false)
            {
                restForm restF = new restForm();
                restF.tickRestTime = Convert.ToInt32(nudRestIn.Value);
                this.Hide();
                restF.ShowDialog();
                this.Show();
            }
        }

        private string DisplayTime()
        {
            return (tickValue / 60).ToString("00") + ":" + (tickValue % 60).ToString("00");
        }

        #endregion
    }
}
