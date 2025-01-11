using System;
using System.Windows.Forms;

namespace 主窗口
{
    public partial class Form2 : Form
    {
        private readonly ChangeTextDel _changeText;
        public Form2(ChangeTextDel del)
        {
            InitializeComponent();
            _changeText = del;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _changeText(textBox1.Text);
        }

        
        public void ChangeText(string str)
        {
            textBox1.Text = str;
        }
    }
}