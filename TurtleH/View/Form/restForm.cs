using System;
using System.Drawing;
using System.Windows.Forms;
using TurtleH.Controller;

namespace TurtleH
{
    public partial class restForm : Form
    {
        public int countDown = 20;

        private const string str = "Rest for ";

        private readonly TimerHandler timerHandler;

        public restForm()
        {
            InitializeComponent();

            timerHandler = new TimerHandler();
            timerHandler.TimerTicked += TimerHandler_TimerTicked;
            timerHandler.TimerStateChanged += TimerHandler_TimerStateChanged; ;

            TextPosition();            
        }

        #region Events

        private void RestForm_Load(object sender, EventArgs e)
        {
            timerHandler.Start(countDown);
            lblTime.Text = str + DisplayTime(timerHandler.TimerValue) + "s";
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            timerHandler.Stop();
            this.Close();
        }

        private void TimerHandler_TimerTicked(int value)
        {
            lblTime.Text = str + DisplayTime(timerHandler.TimerValue) + "s";
        }

        private void TimerHandler_TimerStateChanged(bool state)
        {
            if (state == false)
            {
                this.Close();
            }
        }

        #endregion

        #region Methods

        private void TextPosition()
        {
            // Label
            this.lblTime.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width / 2 - lblTime.Size.Width / 2 + 10,
                Screen.PrimaryScreen.Bounds.Height / 2 - lblTime.Size.Height / 2 - 100
                );

            // Button
            this.btnSkip.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width / 2 - btnSkip.Size.Width / 2,
                lblTime.Location.Y + lblTime.Size.Height / 2 + 35
                );
        }

        private string DisplayTime(int str)
        {
            return str.ToString("00");
        }

        #endregion
    }
}
