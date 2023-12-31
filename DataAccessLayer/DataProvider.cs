﻿using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataProvider
    {
        public static SqlConnection Openconnect()
        {
            string sChuoiKetNoi = @"Data Source=DESKTOP-K7RF00F;Initial Catalog=DBTGDD;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            return con;
        }
        public static void Disconnect(SqlConnection con)
        {
            con.Close();
        }
        public static int JustExcuteNoParameter(string sql)
        {
            SqlConnection con = Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            int rows = cmd.ExecuteNonQuery();
            Disconnect(con);
            if (rows > 0)
            {
                return rows;
            }
            else
            {
                return -1;
            }
        }
        public static DataTable GetTable(string sql)
        {
            SqlConnection con = Openconnect();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Disconnect(con);
            return dt;
        }
    }
}
