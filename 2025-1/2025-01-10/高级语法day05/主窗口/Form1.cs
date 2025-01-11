using System;
using System.Windows.Forms;

namespace 主窗口
{
    public delegate void ChangeTextDel(string str);
    public partial class Form1 : Form
    {
        private Form2 _child;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (_child == null)
            {
                // 构造子窗口时将修改文本框的方法以委托的形式传递过去
                _child = new Form2(ChangeText);
                _child.Show();
            }
            _child.ChangeText(textBox1.Text);
        }

        // 定义一个给文本框赋值的方法
        private void ChangeText(string str)
        {
            textBox1.Text = str;
        }
    }
}