using System;
using System.Windows.Forms;

namespace 窗口传值
{
    public partial class Form2 : Form
    {
        private string msg;
        public Form2()
        {
            InitializeComponent();
            label1.Text = Form1.msg;
        }

        public Form2(string msg) : this()
        {
            this.msg = msg;
            label1.Text = msg;
        }
        
        public void bind(object sender, EventArgs e)
        {
            var s = e as Form1.EventReturnValue;
            label1.Text = s.msg;
        }
    }
}