using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _11_SqlDataAdapter的使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "select * from Person";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,conn);
                // 填充数据到表结构中
                dataAdapter.Fill(dataTable);
            }

            // 读取数据
            // 获取数据表的列信息
            DataColumnCollection columnCollection = dataTable.Columns;
            foreach (DataColumn column in columnCollection)
            {
                Console.Write(column.ColumnName + "\t");
            }

            Console.WriteLine();
            // 获取数据表的行信息
            DataRowCollection rowCollection = dataTable.Rows;
            foreach (DataRow row in rowCollection)
            {
                // 打印每行数据
                Console.WriteLine($"{row[0]}\t{row[1]}\t{row[2]}");

            }

        }
    }
}
