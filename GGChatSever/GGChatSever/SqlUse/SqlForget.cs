using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GGChatSever
{
    class SqlForget
    {
        private string question1;

        public string Question1
        {
            get { return question1; }
            set { question1 = value; }
        }
        private string answer1;

        public string Answer1
        {
            get { return answer1; }
            set { answer1 = value; }
        }
        private string password;
       public string Password
       {
           get { return password; }
           set { password = value; }
       }
        public void SeekQuestion(string account)
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = ".";
            conn.InitialCatalog = "Register";
            conn.IntegratedSecurity = true;
            conn.AsynchronousProcessing = true;//允许异步查询
            using (SqlConnection con = new SqlConnection(conn.ToString()))
            {
                using (SqlCommand com = con.CreateCommand())
                {
                    con.Open();
                    com.CommandText = "select Question1 from Entry where Account=@Account";
                    com.Parameters.AddWithValue("@Account", account);
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        int i = sdr.GetOrdinal("Question1");
                        while (sdr.Read())
                        {
                           Question1 = sdr.GetString(i);

                        }

                    }

                }
            }
        }//寻找账号所对应的密保问题
        public void SeekAnswer(string account)
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = ".";
            conn.InitialCatalog = "Register";
            conn.IntegratedSecurity = true;
            conn.AsynchronousProcessing = true;//允许异步查询
            using (SqlConnection con = new SqlConnection(conn.ToString()))
            {
                using (SqlCommand com = con.CreateCommand())
                {
                    con.Open();
                    com.CommandText = "select Answer1 from Entry where Account=@Account";
                    com.Parameters.AddWithValue("@Account", account);
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        int i = sdr.GetOrdinal("Answer1");
                        while (sdr.Read())
                        {
                          Answer1= sdr.GetString(i);

                        }

                    }

                }
            }
        }//寻找账号所对应的密保答案
        public void SeekPassword(string account)
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = ".";
            conn.InitialCatalog = "Register";
            conn.IntegratedSecurity = true;
            conn.AsynchronousProcessing = true;//允许异步查询
            using (SqlConnection con = new SqlConnection(conn.ToString()))
            {
                using (SqlCommand com = con.CreateCommand())
                {
                    con.Open();
                    com.CommandText = "select PassWord from Entry where Account=@Account";
                    com.Parameters.AddWithValue("@Account", account);
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        int i = sdr.GetOrdinal("PassWord");
                        while (sdr.Read())
                        {
                           Password= sdr.GetString(i);

                        }

                    }

                }
            }
        }
    }
}
