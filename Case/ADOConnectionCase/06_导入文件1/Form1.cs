using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
//添加引用
using Application = Microsoft.Office.Interop.Excel.Application;

namespace _06_导入文件1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择导入的文件";
            ofd.Multiselect = false;
            ofd.InitialDirectory = "D:/";
            ofd.Filter = "文本文件|*.txt";
            DialogResult dialogResult = ofd.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                string[] strings = File.ReadAllLines(fileName);

                var connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    const string sql = "insert into Person2 values(@id,@pname,@age,@sex)";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        foreach (var s in strings)
                        {
                            string[] split = s.Split(' ');
                            sqlCommand.Parameters.AddWithValue("@id", split[0]);
                            sqlCommand.Parameters.AddWithValue("@pname", split[1]);
                            sqlCommand.Parameters.AddWithValue("@age", split[2]);
                            sqlCommand.Parameters.AddWithValue("@sex", split[3]);
                            var res = sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("执行成功！影响的行数:"+res);
                            sqlCommand.Parameters.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择导入的文件");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择导入的文件";
            ofd.Multiselect = false;
            ofd.InitialDirectory = "D:/";
            ofd.Filter = "excel|*.xlsx";
            DialogResult dialogResult = ofd.ShowDialog();
            string fileName = ofd.FileName;

            //1.创建Excel应用程序（将本地excel读取到程序的excel中）
            Application excelApp = new Application();
            //2.创建Excel
            Workbook excelWorkbook = excelApp.Workbooks.Open(fileName);
            //3.获取Sheet
            _Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            //4.获取以使用的范围
            Range excelRange = excelWorksheet.UsedRange;
            //5.读取每行数据
            for (int i = 2; i <= excelRange.Rows.Count; i++)
            {
                Console.WriteLine(excelWorksheet.Cells[i, 1].Value + " " + excelWorksheet.Cells[i, 2].Value + " " + excelWorksheet.Cells[i, 3].Value + " " + excelWorksheet.Cells[i, 4].Value);
                // 将读取的数据存入数据库
                string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    const string sql = "insert into Person2 values(@id,@pname,@age,@sex)";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", excelWorksheet.Cells[i, 1].Value);
                        sqlCommand.Parameters.AddWithValue("@pname", excelWorksheet.Cells[i, 2].Value);
                        sqlCommand.Parameters.AddWithValue("@age", excelWorksheet.Cells[i, 3].Value);
                        sqlCommand.Parameters.AddWithValue("@sex", excelWorksheet.Cells[i, 4].Value);
                        var res = sqlCommand.ExecuteNonQuery();
                        Console.WriteLine("执行成功！影响的行数:" + res);
                    }
                }
            }
            excelWorkbook.Close();
            excelApp.Quit();
        }
    }
}

