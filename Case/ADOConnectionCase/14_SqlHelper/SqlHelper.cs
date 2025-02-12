using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _14_SqlHelper
{
    public static class SqlHelper
    {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            var conn = new SqlConnection(ConnStr);
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection); // 让 reader 关闭时自动关闭 conn
            }
            catch
            {
                conn.Dispose();
                throw;
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    string finalSql = cmd.CommandText;
                    foreach (SqlParameter param in cmd.Parameters)
                    {
                        string paramValue = param.Value == null ? "NULL" : param.Value.ToString();
                        finalSql = finalSql.Replace(param.ParameterName, $"'{paramValue}'");
                    }
                    Console.WriteLine("Executing SQL: " + finalSql);  // ✅ 这样你可以在控制台或日志里看到完整 SQL
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable FillDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);

                    // 🚀 记录最终执行的 SQL 语句（调试用）
                    string finalSql = adapter.SelectCommand.CommandText;
                    foreach (SqlParameter param in adapter.SelectCommand.Parameters)
                    {
                        string paramValue = param.Value == null ? "NULL" : param.Value.ToString();
                        finalSql = finalSql.Replace(param.ParameterName, $"'{paramValue}'");
                    }
                    Console.WriteLine("Executing SQL: " + finalSql);  // ✅ 这样你可以在控制台或日志里看到完整 SQL

                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int Update(DataTable dataTable, string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddRange(parameters);
                var sqlCommandBuilder = new SqlCommandBuilder(adapter);
                var rows = adapter.Update(dataTable);
                conn.Close();
                return rows;
            }


        }
    }
}


