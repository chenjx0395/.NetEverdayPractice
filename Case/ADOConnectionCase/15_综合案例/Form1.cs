using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using _14_SqlHelper;

namespace _15_综合案例
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
            // 加载展示信息
            LoadDisplayData();
            // 加载分组信息
            LoadGroupedData();
            // 数据回显到文本框中
            EchoTextData();
        }

        private void LoadDisplayData()
        {
            string sql = "Select * from PhoneNums";
            DataTable dataTable = SqlHelper.FillDataTable(sql);
            dataGridView1.DataSource = dataTable;
        }

        private void LoadGroupedData()
        {
            string sql2 = "Select * from PhoneNumGroup";
            DataTable dataTable2 = SqlHelper.FillDataTable(sql2);
            comboBox1.DisplayMember = "gname";
            comboBox1.ValueMember = "gid";
            comboBox1.DataSource = dataTable2;
            comboBox2.DisplayMember = "gname";
            comboBox2.ValueMember = "gid";
            comboBox2.DataSource = dataTable2.Copy();
            comboBox3.DisplayMember = "gname";
            comboBox3.ValueMember = "gid";
            comboBox3.DataSource = dataTable2.Copy();
        }

        private void EchoTextData()
        {
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "pid");
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "pname");
            textBox5.DataBindings.Add("Text", dataGridView1.DataSource, "phoneNum");
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //获取条件查询的信息
            var selectItem = comboBox1.SelectedItem as DataRowView;
            int group = Convert.ToInt32(selectItem["gid"]);
            var name = "%" + textBox1.Text + "%";
            var phoneNum = "%" + textBox2.Text + "%";
            StringBuilder sql = new StringBuilder("select * from PhoneNums where gid = @gid");
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter parameter2 = new SqlParameter("@gid", SqlDbType.Int)
            {
                Value = group
            };
            parameters.Add(parameter2);

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                sql.Append(" and pname LIKE @pname");
                SqlParameter parameter = new SqlParameter("@pname", SqlDbType.NVarChar)
                {
                    Value = name
                };
                parameters.Add(parameter);
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                sql.Append(" and phoneNum LIKE @phoneNum ");
                SqlParameter parameter = new SqlParameter("@phoneNum", SqlDbType.NVarChar)
                {
                    Value = phoneNum
                };
                parameters.Add(parameter);
            }

            DataTable dataTable = SqlHelper.FillDataTable(sql.ToString(), parameters.ToArray());
            dataGridView1.DataSource = dataTable;
            // 刷新
            dataGridView1.Refresh();
            EchoTextData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            // 获取当前选中的数据的id
            if (dataGridView1.SelectedRows[0] == null)
            {
                MessageBox.Show("请选中数据后再执行操作！");
                return;
            }
            var dataGridViewRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
            // 根据id删除数据
            string sql = "DELETE FROM PhoneNums WHERE pid  = @pid;";
            int rows = SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@pid", id));
            if (rows > 0)
            {
                MessageBox.Show("删除成功！");
                LoadDisplayData();
                EchoTextData();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //获取新增的数据
            DataRowView rowView = comboBox3.SelectedItem as DataRowView;
            int gid = Convert.ToInt32(rowView.Row["gid"].ToString());
            string pname = textBox6.Text;
            string phoneNum = textBox7.Text;
            string sql = "INSERT INTO PhoneNums VALUES(@name,@phoneNum,@gid)";
            if (string.IsNullOrWhiteSpace(pname) || string.IsNullOrWhiteSpace(phoneNum))
            {
                MessageBox.Show("请先输入新增数据");
                return;
            }

            int rows = SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@name", pname),
                new SqlParameter("@phoneNum", phoneNum), new SqlParameter("@gid", gid));
            if (rows > 0)
            {
                MessageBox.Show("新增成功！");
                LoadDisplayData();
                EchoTextData();
            }
            else
            {
                MessageBox.Show("新增失败");
            }


        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //获取数据
            DataRowView rowView = comboBox2.SelectedItem as DataRowView;
            int gid = Convert.ToInt32(rowView.Row["gid"].ToString());
            string pid = textBox3.Text;
            string pname = textBox4.Text;
            string phoneNum = textBox5.Text;
            string sql = "UPDATE PhoneNums SET pname = @pname , phoneNum = @phoneNum  , gid = @gid WHERE pid = @pid";
            int rows = SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@pname", pname),
                new SqlParameter("@phoneNum", phoneNum), new SqlParameter("@gid", gid),new SqlParameter("@pid",pid));
            if (rows > 0)
            {
                MessageBox.Show("修改成功！");
                LoadDisplayData();
                EchoTextData();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}
