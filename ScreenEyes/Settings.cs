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
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainForm.timer1.Enabled = true;
        }
    }
}
