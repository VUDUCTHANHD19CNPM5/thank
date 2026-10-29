using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bai5._5
{
    public class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Port=3307;Database=InventoryDB;Uid=root;Pwd=Thanhbuco12@;Charset=utf8;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
