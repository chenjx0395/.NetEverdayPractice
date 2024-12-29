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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Form5_DoubleClick(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(
                "hello",
                "我是一个消息框",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation
                );
            Console.WriteLine(dialogResult);
        }

        private void Form5_Click(object sender, EventArgs e)
        {
            
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogResult = MessageBox.Show("是否关闭？", "关闭窗口"
                , MessageBoxButtons.YesNo);
            Console.WriteLine(dialogResult);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
