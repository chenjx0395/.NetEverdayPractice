using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace 数据库连接池实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = SqlConnections.GetConnection();
            const string sql = "select * from Person";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object pid = reader[0];
                        object pname = reader[1];
                        object page = reader[2];
                        Console.WriteLine($"{pid}\t{pname}\t{page}");
                    }
                   
                }
            }
            SqlConnections.BackConnection(connection);
        }
    }

    static class SqlConnections
    {
        private static readonly List<SqlConnection> Connections = new List<SqlConnection>();

        static SqlConnections()
        {
            const string connStr =
                "Data Source=.;Initial Catalog=02_School_Learn;Integrated Security=True;TrustServerCertificate=True";
            var sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            for (int i = 0; i < 50; i++)
            {
                Connections.Add(sqlConnection);
            }
        }

        public static SqlConnection GetConnection()
        {
            if (Connections.Count == 0)
            {
                throw new Exception("数据库连接已用完");
            }

            var connection = Connections.First();
            Connections.Remove(connection);
            return connection;
        }

        public static void BackConnection(SqlConnection connection)
        {
            Connections.Add(connection);
        }
    }
}
