using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace _05_数据库配置文件连接数据库
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                Console.WriteLine(conn.State);
            }
        }
    }
}
