using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_DataGridView增删改数据
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "Select * from type";
                 dataAdapter = new SqlDataAdapter(sql, conn);
                 dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataSet.HasChanges())
            {
                string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var dataAdapter = new SqlDataAdapter("SELECT * FROM type", conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(dataSet.Tables[0]);
                }
            }
            else
            {
                MessageBox.Show("请先操作数据");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
