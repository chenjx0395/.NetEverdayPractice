using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _01_分页
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 页码
        /// </summary>
        private int _pageNumber = 1;

        /// <summary>
        /// 页大小
        /// </summary>
        private const int PageSize = 3;

        /// <summary>
        /// 总页数
        /// </summary>
        private int _totalPages;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CalculateTotalPages();
            LoadData();
        }

        private void LoadData()
        {
            string sql = @"SELECT * FROM Products ORDER BY pid OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@offset",(_pageNumber-1)*PageSize),
                new SqlParameter("@pageSize",PageSize)
            };
            dataGridView1.DataSource = SqlHelper.FillDataTable(sql, parameters);
            // 显示页数信息
            label1.Text = _pageNumber.ToString();
            label2.Text = _totalPages.ToString();

        }

        private void CalculateTotalPages()
        {
            // 获取总页数
            string sql = "SELECT COUNT(*) FROM Products";
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
            // 计算总页数
            _totalPages = count % PageSize == 0 ? count / PageSize : count / PageSize + 1;
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (_pageNumber > 1)
            {
                _pageNumber--;
                LoadData();
            }
            else
            {
                MessageBox.Show("已经是第一页了");
            }

        }
        /// <summary>
        /// 下一页
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (_pageNumber < _totalPages)
            {
                _pageNumber++;
                LoadData();
            }
            else
            {
                MessageBox.Show("已经是最后一页了");
            }
        }
    }
}
