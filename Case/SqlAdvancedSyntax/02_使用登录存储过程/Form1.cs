using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _02_使用登录存储过程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr =
                "Data Source=.;Initial Catalog=02_School_Learn;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("Login", conn))
                {
                    // 设置指令类型
                    command.CommandType = CommandType.StoredProcedure;
                    // 创建参数数组
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@username", textBox1.Text),
                        new SqlParameter("@password", textBox2.Text),
                        new SqlParameter("@msg", SqlDbType.NVarChar,20)
                    };
                    parameters[2].Direction = ParameterDirection.Output;
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                    label3.Text = parameters[2].Value.ToString();
                }
                
            }
        }
    }
}
