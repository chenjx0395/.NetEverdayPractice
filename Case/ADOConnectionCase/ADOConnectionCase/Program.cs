using System;
using System.Data.SqlClient;

namespace ADOConnectionCase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Case2();
            Case3();
        }


        public static void Case3()
        {
            const string connStr =
                "Data Source =.; Initial Catalog = 02_School_Learn; Integrated Security = True; TrustServerCertificate = True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "insert into Person values('呵呵',18)";
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    int rows = command.ExecuteNonQuery();
                    Console.WriteLine(rows);
                }
            }
        }

        public static void Case2()
        {
            const string connStr =
                "Data Source =.; Initial Catalog = 02_School_Learn; Integrated Security = True; TrustServerCertificate = True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // const string sql = "select count(1) from Person";
                const string sql = "insert into Person values('登门',45) select @@identity";
                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine(result.ToString());
                }
            }
        }

        public static void Case1()
        {
            const string connStr =
                "Data Source =.; Initial Catalog = 02_School_Learn; Integrated Security = True; TrustServerCertificate = True";
            // 1. 通过单参数构造函数连接
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "select pid,pname,age from Person";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            // 方式一：通过指定列类型和索引获取数据
                            var pid = dataReader.GetInt32(0);
                            var pname = dataReader.GetString(1);
                            var age = dataReader.GetInt32(2);
                            // 方式二：通过索引器和索引获取数据
                            // object pid = dataReader[0];
                            // 方式三：通过索引器和列名获取数据
                            // object pid = dataReader["pid"];
                            Console.WriteLine($"pid：{pid}   pname: {pname}age: {age}");
                        }
                    }
                }
            }
        }
    }
}
