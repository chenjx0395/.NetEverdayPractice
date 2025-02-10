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


