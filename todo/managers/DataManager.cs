using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace todo.managers
{
    public class DataManager
    {
        private static string CONN_STRING = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public static DataTable gettask(int id, string state)
        {
            string query = "gettask";

            using (MySqlConnection conn = new MySqlConnection(CONN_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@state", state);
                    using (MySqlDataAdapter data = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        data.Fill(dt);
                        return dt;
                    }

                }
            }
        }

        public static void addtask(AddTask t)
        {
            string query = "addtask";
            using (MySqlConnection conn = new MySqlConnection(CONN_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("id", t.id);
                    cmd.Parameters.AddWithValue("tit", t.tit);
                    cmd.Parameters.AddWithValue("i_url", t.i_url);
                    cmd.Parameters.AddWithValue("state", t.state);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public static void removeComplete(rmTask r)
        {
            string query = "removeComplete";
            using (MySqlConnection conn = new MySqlConnection(CONN_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("id", r.id);
                    cmd.Parameters.AddWithValue("tsid", r.tsid); ;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public static void updateTask(upTask u)
        {
            string query = "updateTask";
            using (MySqlConnection conn = new MySqlConnection(CONN_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("id", u.id);
                    cmd.Parameters.AddWithValue("tsid", u.tsid); ;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        public static void updateTaskTitle(upTitle t)
        {
            string query = "updateTaskTitle";
            using (MySqlConnection conn = new MySqlConnection(CONN_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("id", t.id);
                    cmd.Parameters.AddWithValue("tsid", t.tsid);
                    cmd.Parameters.AddWithValue("tit", t.tit);
                    cmd.Parameters.AddWithValue("img", t.img); ;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

    }
}