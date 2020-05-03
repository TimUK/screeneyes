using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenEyes
{
    public partial class Form1 : Form
    {

        int SETTING_WORK_TIME_LENGTH = 10;
        int SETTING_BREAK_TIME_LENGTH = 5;

        int workTime;

        int breakTime;

        Boolean working = true;
        

        public Form1()
        {
            InitializeComponent();

            workTime = SETTING_WORK_TIME_LENGTH;

            breakTime = SETTING_BREAK_TIME_LENGTH;           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts;
            if (working)
            {
                workTime--;
                label2.Text = "Work Time Left:";
                label2.ForeColor = SystemColors.HotTrack;
                ts = TimeSpan.FromSeconds(workTime);
                
                if (workTime == 0)
                {
                    breakTime = SETTING_BREAK_TIME_LENGTH;
                    working = false;
                    //MessageBox.Show("Work time is over!!");
                    label3.Visible = true;
                    this.Activate();
                }
            }
            else
            {
                breakTime--;
                label2.Text = "Break Time Left:";
                label2.ForeColor = Color.Crimson;
                ts = TimeSpan.FromSeconds(breakTime);
                if (breakTime == 0)
                {
                    label3.Visible = false;
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
        }
    }
}
