using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string connStr =
                "Data Source=.;Initial Catalog=02_School_Learn;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // 获取用户输入的账号和密码
                string account = textBox1.Text;
                string password = textBox2.Text;
                string sql = "SELECT COUNT(1) FROM [User] WHERE uAccount = @account AND upassword = @password";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@account", account);
                    command.Parameters.AddWithValue("@password", password);
                    int res = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show(res == 1 ? "登录成功" : "登录失败");
                }
            }
        }
    }
}
