﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExercise01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BackColor = Color.Red;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            BackColor = Color.Green;
        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }
    }
}
