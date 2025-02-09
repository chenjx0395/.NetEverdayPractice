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

namespace _08_省市联动
{
    public partial class Form1 : Form
    {
        private readonly string _connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        private Dictionary<string,int> _provinceNameToId = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProvinceData();
        }

        /// <summary>
        /// 加载省份数据
        /// </summary>
        private void LoadProvinceData()
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                const string sql = "SELECT proId , proName FROM Province";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader =  command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proId = reader.GetInt32(0);
                            var proName = reader.GetString(1);
                            _provinceNameToId.Add(proName,proId);
                            comboBox1.Items.Add(proName);
                        }
                        comboBox1.SelectedIndex = 0;
                    }
                }
            }          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 删除市下列表已有数据
            comboBox2.Items.Clear();
            var selectedItem = comboBox1.SelectedItem.ToString();
            int proId = _provinceNameToId[selectedItem];
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                string sql = "SELECT CityName FROM City WHERE proId = @proId";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@proId", proId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cityName = reader.GetString(0);
                            comboBox2.Items.Add(cityName);
                        }
                    }

                    comboBox2.SelectedIndex = 0;
                }
            }
        }


    }
}
