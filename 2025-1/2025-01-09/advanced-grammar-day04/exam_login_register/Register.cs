using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam_login_register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //1. 验证用户名，真实姓名，密码，确认密码，不能为空
            if (string.IsNullOrWhiteSpace(username.Text)
                || string.IsNullOrWhiteSpace(realname.Text)
                || string.IsNullOrWhiteSpace(password.Text)
                || string.IsNullOrWhiteSpace(checkPassword.Text))
            {
                MessageBox.Show("用户名，真实姓名，密码，确认密码，不能为空");
                return;
            }
            //2. 密码和确认密码是否一致
            if (password.Text != checkPassword.Text)
            {
                MessageBox.Show("密码和确认密码不一致");
                return;
            }
            Program.User.Username = username.Text;
            Program.User.Password = password.Text;
            Program.User.Gender = gender1.Checked ? gender1.Text : gender2.Text;
            Program.User.City = (string)city.SelectedItem;

            MessageBox.Show(
                $"您的注册信息为：\n用户名：{Program.User.Username}\n密码：{Program.User.Password}\n性别：{Program.User.Gender}\n城市：{Program.User.City}");
        }

        private void Register_Load(object sender, EventArgs e)
        {
            //性别默认第一个
            gender1.Checked = true;
            //城市默认第一个
            city.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // 勾选同意后才能启用注册按钮
            button2.Enabled = checkBox1.Checked;
        }

        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
