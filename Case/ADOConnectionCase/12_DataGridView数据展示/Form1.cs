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

namespace _12_DataGridView数据展示
{
    public partial class Form1 : Form
    {
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
            string connStr = ConfigurationManager
                .ConnectionStrings["_12_DataGridView数据展示.Properties.Settings._02_School_LearnConnectionString"]
                .ConnectionString;
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "Select * from Person";
                SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
                adapter.Fill(dataTable);
            }
            dataGridView1.DataSource = dataTable;
        }
    }
}
