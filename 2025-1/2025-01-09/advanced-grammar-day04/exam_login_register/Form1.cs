using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace exam_login_register
{
    public partial class Login : Form
    {
        private readonly Random _random = new Random();
        private char[] _code = new char[5];
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 画验证码
        /// </summary>
        private void DrawCode()
        {
            Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Coral, Color.HotPink };
            char[] Code =
            { 'a', 'b', 'c', 'd', 'A', 'B', 'C', 'D',
                '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var bitmap = new Bitmap(180, 50);
            var graphics = Graphics.FromImage(bitmap);
            // 验证码符号
            for (var i = 0; i < 5; i++)
            {
                var codeRandom = _random.Next(0, 17);
                var step = i * 20;
                var xRandom = _random.Next(-3, 4);
                var yRandom = _random.Next(-6, 6);
                _code[i] = Code[codeRandom];
                graphics.DrawString(_code[i].ToString(), new Font("楷体", 12), new SolidBrush(colors[_random.Next(0, colors.Length)]), new PointF(xRandom + step, yRandom));
            }
            // 线条
            for (var i = 0; i < 20; i++)
            {
                graphics.DrawLine(new Pen(new SolidBrush(colors[_random.Next(0, colors.Length)]), 1),
                    new Point(_random.Next(0, bitmap.Width), _random.Next(0, bitmap.Height)),
                    new Point(_random.Next(0, bitmap.Width), _random.Next(0, bitmap.Height)));
            }

            // 背景点
            for (var i = 0; i < 600; i++)
            {
                bitmap.SetPixel(_random.Next(0, bitmap.Width), _random.Next(0, bitmap.Height), colors[_random.Next(0, colors.Length)]);
            }

            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// 跳转登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var register = new Register();
            register.Show();
        }
        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //1. 验证用户名，密码，验证码不能为空
            if (string.IsNullOrWhiteSpace(username.Text)
                || string.IsNullOrWhiteSpace(password.Text)
                || string.IsNullOrWhiteSpace(verificationCode.Text))
            {
                MessageBox.Show("用户名，密码，验证码不能为空");
                return;
            }
            //2. 验证用户名密码和注册的用户名密码是否相同
            if (Program.User.Username != username.Text || Program.User.Password != password.Text)
            {
                MessageBox.Show("账号或密码错误！");
                return;
            }

            //3. 验证登录的验证码和正确验证码是否相同
            if (new string(_code) != verificationCode.Text)
            {
                MessageBox.Show("验证码输入错误！");
                DrawCode();
                return;
            }

            MessageBox.Show("登录成功");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DrawCode();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            DrawCode();
        }
    }
}
