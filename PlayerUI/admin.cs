﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ppassrest.Visible= false;
            panel1.Visible= true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ppassrest.Visible = true;
            panel1.Visible = false;
        }
    }
}
