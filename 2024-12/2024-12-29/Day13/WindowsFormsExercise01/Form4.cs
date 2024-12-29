using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void Form4_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
