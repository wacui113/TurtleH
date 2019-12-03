﻿using System;
using System.Windows.Forms;

namespace TurtleH.Controller
{
    public class TimerHandler
    {
        public static readonly int TwentyMinutes = 1200;
        public static readonly int TwentySeconds = 20;

        private int timerValue = TwentyMinutes;

        public delegate void TimerStateChangedHandler(bool state);
        public event TimerStateChangedHandler TimerStateChanged;

        public delegate void TimerTickedHandler(int value);
        public event TimerTickedHandler TimerTicked;


        private Timer mainTimer;
        public TimerHandler()
        {
            mainTimer = new Timer();
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Interval = 1000;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if(timerValue <= 0)
            {
                Stop();
            }
            else
            {
                TimerTicked(timerValue--);
            }
        }

        public void Start(int timesupvalue)
        {
            if(mainTimer.Enabled == false)
            {
                timerValue = timesupvalue;
                mainTimer.Enabled = true;

                TimerStateChanged(true);
            }
        }

        public void Stop()
        {
            if (mainTimer.Enabled == true)
            {
                mainTimer.Enabled = false;

                TimerStateChanged(false);
            }
        }
    }
}