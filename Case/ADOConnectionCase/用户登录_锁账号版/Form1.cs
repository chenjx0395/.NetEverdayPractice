using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 用户登录_锁账号版
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string errorMessage = "账号密码错误！";
            // 检查是否输入了账号密码

            if (string.IsNullOrWhiteSpace(textBox1.Text)||string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("账号密码不能为空！");
                return;
            }
            const string connStr =
                "Data Source=.;Initial Catalog=02_School_Learn;Integrated Security=True;TrustServerCertificate=True";
            const string querySql =
                "SELECT password , errorCount , lastErrorTime FROM UserInfo WHERE username = @username;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand comm  = new SqlCommand(querySql, conn))
                {
                    comm.Parameters.AddWithValue("@username", textBox1.Text);
                    SqlDataReader dataReader = comm.ExecuteReader();
                    var isExist = dataReader.Read();
                    // 1. 输入账号不存在
                    if (!isExist)
                    {
                        MessageBox.Show(errorMessage);
                        return;
                    }
                    // 获取账号信息
                    string password = dataReader.GetString(0);
                    int errorCount = dataReader.GetInt32(1);
                    DateTime lastErrorTime = dataReader.GetDateTime(2);
                    dataReader.Close();
                    // 2. 检查错误次数是否 >= 3
                    // 2.1 计算最后一次输入错误的时间和当前时间的分钟差
                    TimeSpan timeDifference = DateTime.Now - lastErrorTime  ;
                    int minutesDifference = (int)timeDifference.TotalMinutes;
                    if (errorCount >= 3 && minutesDifference <= 15)
                    {
                        // 当错误次数>=3且错误时间差<=15分钟时，代表你目前登录
                        MessageBox.Show($"账号已被锁定，请{15 - minutesDifference}分钟后重试！");
                        return;
                    }
                    //3. 检查密码是否正确
                    if (errorCount >= 3)
                    {
                       errorMessage = "错误次数超过3次，请15分钟后重试";
                    }
                    if (password != textBox2.Text)
                    {
                        // 3.1 错误次数+1，更新错误次数和错误时间。
                        const string updateSql =
                            "UPDATE UserInfo SET errorCount = errorCount + 1 , lastErrorTime = @lastErrorTime WHERE username = @username2;";
                        using (SqlCommand comm2 = new SqlCommand(updateSql, conn))
                        {
                            comm2.Parameters.AddWithValue("@username2", textBox1.Text);
                            comm2.Parameters.AddWithValue("@lastErrorTime", DateTime.Now);
                            comm2.ExecuteNonQuery();
                        }
                        MessageBox.Show(errorMessage);
                        return;
                    }
                    //4. 检查错误次数是否为0
                    if (errorCount != 0)
                    {
                        //4.1 将错误次数重置为0
                        const string updateSql =
                            "UPDATE UserInfo SET errorCount = 0 WHERE username = @username3;";
                        using (SqlCommand comm2 = new SqlCommand(updateSql, conn))
                        {
                            comm2.Parameters.AddWithValue("@username3", textBox1.Text);
                            comm2.ExecuteNonQuery();
                        }
                    }
                    //5. 显示登录成功
                    MessageBox.Show("登录成功！");
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
