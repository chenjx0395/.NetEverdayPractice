using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_DataSet的使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 创建数据库
            DataSet dB = new DataSet("Cache");
            // 2. 创建表
            var tPerson = new DataTable("Person");
            // 3. 将表添加到数据库中
            dB.Tables.Add(tPerson);
            // 4. 创建列
            DataColumn column1 = new DataColumn("id",typeof(int));
            // 设置为主键和自增
            column1.AutoIncrement = true;
            column1.AutoIncrementSeed = 100;
            column1.AutoIncrementStep = 10;
            column1.AllowDBNull = false;
            column1.Unique = true;
            DataColumn column2 = new DataColumn("name",typeof(string));
            DataColumn column3 = new DataColumn("age",typeof(int));
            DataColumn column4 = new DataColumn("sex",typeof(char));
            // 设置默认值
            column4.DefaultValue = '男';
            // 5. 将列添加到表中
            tPerson.Columns.Add(column1);
            tPerson.Columns.Add(column2);
            tPerson.Columns.Add(column3);
            tPerson.Columns.Add(column4);
            // 6。 创建行数据
            DataRow row1 = tPerson.NewRow();
            row1["name"] = "张三";
            row1["age"] = 18;
            row1["sex"] = '男';
            DataRow row2 = tPerson.NewRow();
            row2["name"] = "李四";
            row2["age"] = 19;
            row2["sex"] = '女';
            DataRow row3 = tPerson.NewRow();
            row3["name"] = "王五";
            row3["age"] = 20;
            // 将行数据添加到表中
            tPerson.Rows.Add(row1);
            tPerson.Rows.Add(row2);
            tPerson.Rows.Add(row3);

            // 获取数据
            // 获取数据表
            DataTable table = dB.Tables[0];
            // 获取数据表的列信息
            DataColumnCollection columnCollection = table.Columns;
            foreach (DataColumn column in columnCollection)
            {
                Console.Write(column.ColumnName+"\t");
            }

            Console.WriteLine();
            // 获取数据表的行信息
            DataRowCollection rowCollection = table.Rows;
            foreach (DataRow row in rowCollection)
            {
                // 打印每行数据
                Console.WriteLine($"{row["id"]}\t{row["name"]}\t{row["age"]}\t{row["sex"]}");
               
            }
        }
    }
}
