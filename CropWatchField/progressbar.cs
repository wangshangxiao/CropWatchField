using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CropWatchField
{
    public partial class progressbar : Form
    {
        bool flag2 = false, flag3 = false, flag4 = false;
        public progressbar()
        {
            InitializeComponent();
        }

        private void progressbar_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Left += 10;
            label3.Left += 10;
            label4.Left += 10;

            if (label4.Left >= 300)
            {
                label4.Visible = false;
                flag4 = true;
            }
            if (label3.Left >= 300)
            {
                label3.Visible = false;
                flag3 = true;
            }
            if (label2.Left >= 300)
            {
                label2.Visible = false;
                flag2 = true;
            }


            if (label3.Left >= 15 && label3.Left < 300)
            {
                label3.Visible = true;
            }
            if (label2.Left >= 15)
            {
                label2.Visible = true;
            }
            if (flag2 && flag3 && flag4)
            {
                label2.Left = -25;
                label2.Visible = false;
                label3.Left = -5;
                label3.Visible = false;
                label4.Left = 15;
                label4.Visible = true;
                flag2 = flag3 = flag4 = false;
            }
        }
    }
}
