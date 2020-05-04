using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ScreenEyes
{
    public partial class Form1 : Form
    {

        private int SETTING_WORK_TIME_LENGTH = 10; //this will be 3600 secs
        private int SETTING_BREAK_TIME_LENGTH = 5; // this will be 300 secs
        

        int workTime;
        int breakTime;
        Boolean working = true;

        int workcycles = 0;
        

        public Form1()
        {
            InitializeComponent();
            
            if (Properties.Settings.Default.timermode == "")
            {
                Properties.Settings.Default.timermode = "Default";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.timermode == "Default")
            {
                DefaultTimerModeTick();
            } else if (Properties.Settings.Default.timermode == "Pomodoro")
            {
                PomodoroTimerModeTick();
            }
        }

        private void PomodoroTimerModeTick()
        {
            //label1.Text = "pomodoro";
            SETTING_BREAK_TIME_LENGTH = 300;
            SETTING_WORK_TIME_LENGTH = 1500;
            DefaultTimerModeTick();
            if (working)
            {
                if (workTime == 1)
                {
                    workcycles++;
                }
                
            }
            if (workcycles == 3)
            {
                breakTime = 900;
                workcycles = 0;
            }
        }

        private void DefaultTimerModeTick()
        {
            if (Properties.Settings.Default.timermode == "Default")
            {
                SETTING_BREAK_TIME_LENGTH = 300;
                SETTING_WORK_TIME_LENGTH = 3600;
            }

            TimeSpan ts;
            if (working)
            {
                label3.Text = "WORK TIME";
                label3.ForeColor = SystemColors.HotTrack;
                workTime--;
                label2.Text = "Work Time Left:";
                label2.ForeColor = SystemColors.HotTrack;
                ts = TimeSpan.FromSeconds(workTime);

                if (workTime == 0)
                {
                    SystemSounds.Exclamation.Play();
                    if (breakTime != 900)
                    {
                        breakTime = SETTING_BREAK_TIME_LENGTH;
                    }
                    working = false;
                    //MessageBox.Show("Work time is over!!");

                    this.Activate();
                }
            }
            else
            {
                label3.Text = "BREAK TIME";
                label3.ForeColor = Color.LimeGreen;

                breakTime--;
                label2.Text = "Break Time Left:";
                label2.ForeColor = Color.Crimson;
                ts = TimeSpan.FromSeconds(breakTime);
                if (breakTime == 0)
                {
                    SystemSounds.Hand.Play();
                    workTime = SETTING_WORK_TIME_LENGTH;
                    working = true;
                    this.Activate();
                }
            }

            label1.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                ts.Hours,
                ts.Minutes,
                ts.Seconds);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 495, Screen.PrimaryScreen.Bounds.Height - 303);

            if (Properties.Settings.Default.timermode == "Default")
            {
                SETTING_WORK_TIME_LENGTH = 3600;
                SETTING_BREAK_TIME_LENGTH = 300;
            }
            else if (Properties.Settings.Default.timermode == "Pomodoro")
            {
                SETTING_WORK_TIME_LENGTH = 1500;
                SETTING_BREAK_TIME_LENGTH = 300;
            }

            workTime = SETTING_WORK_TIME_LENGTH;

            breakTime = SETTING_BREAK_TIME_LENGTH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Settings settingsForm = new Settings(this);
            settingsForm.ShowDialog();
        }
    }
}
