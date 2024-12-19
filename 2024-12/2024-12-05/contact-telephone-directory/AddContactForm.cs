using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace contact_telephone_directory
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // 公开一个方法来访问 TextBox 的值
        public string GetAddNameBoxValue()
        {
            return AddNameText.Text;  // 假设你有一个名为 textBox1 的 TextBox 控件
        }
        public string GetAddPhoneBoxValue()
        {
            return AddPhoneText.Text;  // 假设你有一个名为 textBox1 的 TextBox 控件
        }


    }
}
