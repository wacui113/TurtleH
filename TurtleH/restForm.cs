using System;
using System.Drawing;
using System.Windows.Forms;

namespace TurtleH
{
    public partial class restForm : Form
    {
        public int tickRestTime = 20;

        private const string str = "This screen will close after ";

        public restForm()
        {
            InitializeComponent();

            TextPosition();            
        }

        #region Events

        private void RestForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = str + DisplayTime() + "s";
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            if(tickRestTime <= 0)
            {
                this.Close();
                return;
            }

            tickRestTime--;
            lblTime.Text = str + DisplayTime() + "s";
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            timerMain.Enabled = false;
            this.Close();
        }

        #endregion

        #region Methods

        private void TextPosition()
        {
            // Label
            this.lblTime.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width / 2 - lblTime.Size.Width / 2,
                Screen.PrimaryScreen.Bounds.Height / 2 - lblTime.Size.Height / 2 - 100
                );

            // Button
            this.btnSkip.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width / 2 - btnSkip.Size.Width / 2,
                lblTime.Location.Y + lblTime.Size.Height / 2 + 35
                );
        }

        private string DisplayTime()
        {
            return tickRestTime.ToString("00");
        }

        #endregion
    }
}
