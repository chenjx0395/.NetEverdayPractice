using System;
using System.Windows.Forms;

namespace WindowsFormsExercise01
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Show();
            Hide();
        }
    }
}
