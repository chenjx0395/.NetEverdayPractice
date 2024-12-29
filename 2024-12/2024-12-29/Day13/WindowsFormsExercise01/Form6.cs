using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExercise01
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "标签被点击了";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.baidu.com");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '\0';
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(FontFamily.GenericSansSerif, 24);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var path = @"D://text.rtf";
            richTextBox1.SaveFile(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var path = @"D://text.rtf";
            richTextBox1.LoadFile(path);
        }
    }
}
