namespace TurtleH
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.lblDisplayTime = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.nudRestIn = new System.Windows.Forms.NumericUpDown();
            this.lblRestIn = new System.Windows.Forms.Label();
            this.lblRestInSecond = new System.Windows.Forms.Label();
            this.nudRemind = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblRemindMe = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHideToTray = new System.Windows.Forms.Button();
            this.chkbStartup = new System.Windows.Forms.CheckBox();
            this.pnlSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemind)).BeginInit();
            this.pnlDisplay.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDisplayTime
            // 
            this.lblDisplayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayTime.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblDisplayTime.Location = new System.Drawing.Point(23, 14);
            this.lblDisplayTime.Name = "lblDisplayTime";
            this.lblDisplayTime.Size = new System.Drawing.Size(158, 106);
            this.lblDisplayTime.TabIndex = 0;
            this.lblDisplayTime.Text = "20:00";
            this.lblDisplayTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(227, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 40);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.nudRestIn);
            this.pnlSelect.Controls.Add(this.lblRestIn);
            this.pnlSelect.Controls.Add(this.lblRestInSecond);
            this.pnlSelect.Controls.Add(this.nudRemind);
            this.pnlSelect.Controls.Add(this.lblMinutes);
            this.pnlSelect.Controls.Add(this.lblRemindMe);
            this.pnlSelect.Location = new System.Drawing.Point(27, 26);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(175, 120);
            this.pnlSelect.TabIndex = 2;
            // 
            // nudRestIn
            // 
            this.nudRestIn.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.nudRestIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRestIn.ForeColor = System.Drawing.SystemColors.Window;
            this.nudRestIn.Location = new System.Drawing.Point(64, 84);
            this.nudRestIn.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudRestIn.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRestIn.Name = "nudRestIn";
            this.nudRestIn.Size = new System.Drawing.Size(47, 22);
            this.nudRestIn.TabIndex = 3;
            this.nudRestIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRestIn.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblRestIn
            // 
            this.lblRestIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestIn.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRestIn.Location = new System.Drawing.Point(15, 82);
            this.lblRestIn.Name = "lblRestIn";
            this.lblRestIn.Size = new System.Drawing.Size(54, 25);
            this.lblRestIn.TabIndex = 2;
            this.lblRestIn.Text = "Rest in";
            this.lblRestIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRestInSecond
            // 
            this.lblRestInSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestInSecond.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRestInSecond.Location = new System.Drawing.Point(117, 82);
            this.lblRestInSecond.Name = "lblRestInSecond";
            this.lblRestInSecond.Size = new System.Drawing.Size(57, 25);
            this.lblRestInSecond.TabIndex = 2;
            this.lblRestInSecond.Text = "second";
            this.lblRestInSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudRemind
            // 
            this.nudRemind.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.nudRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRemind.ForeColor = System.Drawing.SystemColors.Window;
            this.nudRemind.Location = new System.Drawing.Point(17, 41);
            this.nudRemind.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudRemind.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRemind.Name = "nudRemind";
            this.nudRemind.Size = new System.Drawing.Size(80, 22);
            this.nudRemind.TabIndex = 3;
            this.nudRemind.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRemind.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRemind.ValueChanged += new System.EventHandler(this.NudRemind_ValueChanged);
            // 
            // lblMinutes
            // 
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMinutes.Location = new System.Drawing.Point(103, 41);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(60, 25);
            this.lblMinutes.TabIndex = 2;
            this.lblMinutes.Text = "minutes";
            this.lblMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemindMe
            // 
            this.lblRemindMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemindMe.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRemindMe.Location = new System.Drawing.Point(15, 9);
            this.lblRemindMe.Name = "lblRemindMe";
            this.lblRemindMe.Size = new System.Drawing.Size(148, 29);
            this.lblRemindMe.TabIndex = 1;
            this.lblRemindMe.Text = "Remind me after";
            this.lblRemindMe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.lblDisplayTime);
            this.pnlDisplay.Location = new System.Drawing.Point(12, 6);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(203, 137);
            this.pnlDisplay.TabIndex = 3;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TurtleH";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.timerToolStripMenuItem,
            this.showWindowsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(169, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.startToolStripMenuItem.Text = "START";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // timerToolStripMenuItem
            // 
            this.timerToolStripMenuItem.Enabled = false;
            this.timerToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.timerToolStripMenuItem.Text = "00:00";
            // 
            // showWindowsToolStripMenuItem
            // 
            this.showWindowsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.showWindowsToolStripMenuItem.Name = "showWindowsToolStripMenuItem";
            this.showWindowsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showWindowsToolStripMenuItem.Text = "Open the window";
            this.showWindowsToolStripMenuItem.Click += new System.EventHandler(this.ShowWindowsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // btnHideToTray
            // 
            this.btnHideToTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideToTray.Location = new System.Drawing.Point(227, 81);
            this.btnHideToTray.Name = "btnHideToTray";
            this.btnHideToTray.Size = new System.Drawing.Size(109, 30);
            this.btnHideToTray.TabIndex = 1;
            this.btnHideToTray.Text = "Hide window";
            this.btnHideToTray.UseVisualStyleBackColor = true;
            this.btnHideToTray.Click += new System.EventHandler(this.BtnHideToTray_Click);
            // 
            // chkbStartup
            // 
            this.chkbStartup.AutoSize = true;
            this.chkbStartup.ForeColor = System.Drawing.Color.White;
            this.chkbStartup.Location = new System.Drawing.Point(227, 126);
            this.chkbStartup.Name = "chkbStartup";
            this.chkbStartup.Size = new System.Drawing.Size(117, 17);
            this.chkbStartup.TabIndex = 4;
            this.chkbStartup.Text = "Start with Windows";
            this.chkbStartup.UseVisualStyleBackColor = true;
            this.chkbStartup.CheckedChanged += new System.EventHandler(this.ChkbStartup_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(362, 165);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.chkbStartup);
            this.Controls.Add(this.pnlSelect);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.btnHideToTray);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TurtleH ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRestIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemind)).EndInit();
            this.pnlDisplay.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplayTime;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.NumericUpDown nudRemind;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblRemindMe;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.NumericUpDown nudRestIn;
        private System.Windows.Forms.Label lblRestIn;
        private System.Windows.Forms.Label lblRestInSecond;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowsToolStripMenuItem;
        private System.Windows.Forms.Button btnHideToTray;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkbStartup;
    }
}