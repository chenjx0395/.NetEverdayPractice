using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application  = Microsoft.Office.Interop.Excel.Application;

namespace _07_导出文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "文本文件|*.txt";
            dialog.InitialDirectory = "D:/";
            dialog.Title = "请选择保存的文件";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;

                string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {

                    sqlConnection.Open();
                    string sql = "select * from Person2";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string pname = reader["pname"].ToString();
                                string age = reader["age"].ToString();
                                string sex = reader["sex"].ToString();
                                string s = $"{id} {pname} {age} {sex}\n";
                                File.AppendAllText(fileName, s);
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "表格|*.xls";
            dialog.InitialDirectory = "D:/";
            dialog.Title = "请选择保存的文件";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //1.创建 excel 应用程序
                Application excelApp = new Application();
                //2. 创建 excel
                Workbook excelWorkbook = excelApp.Workbooks.Add();
                //3. 获取 sheet
                _Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                //4. 设置第一行标题
                excelWorksheet.Cells[1, 1].Value = "编号";
                excelWorksheet.Cells[1, 2].Value = "姓名";
                excelWorksheet.Cells[1, 3].Value = "年龄";
                excelWorksheet.Cells[1, 4].Value = "性别";
                //5. 查询数据
                string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    string sql = "select * from Person2";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            for (int i = 2; reader.Read(); i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    excelWorksheet.Cells[i,j+1].Value = reader[j].ToString();
                                }
                            }
                        }
                    }
                }

                string fileName = dialog.FileName;
                //保存到指定的位置
                excelWorkbook.SaveAs(fileName);
                excelWorkbook.Close();
                excelApp.Quit();
            }
        }
    }
}
