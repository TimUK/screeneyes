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
    public partial class Settings : Form
    {
        Form1 mainForm;

        public Settings(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            if (Properties.Settings.Default.timermode == "Pomodoro")
            {
                radioButton2.Checked = true;
            }else
            {
                radioButton1.Checked = true;
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainForm.timer1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton box = (RadioButton)sender;
            Properties.Settings.Default.timermode = box.Tag.ToString();
            Properties.Settings.Default.Save();
            
        }
    }
}
