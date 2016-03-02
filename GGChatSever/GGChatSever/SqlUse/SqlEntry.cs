using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace GGChatSever
{
 public class SqlEntry
    {
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
     /// <summary>
     /// 根据账号查找密码
     /// </summary>
     /// <param name="Account">输入的账号</param>
        public  SqlEntry(string Account)
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
                    com.Parameters.AddWithValue("@Account", Account);
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        int i = sdr.GetOrdinal("PassWord");
                        while (sdr.Read())
                        {
                          Password = sdr.GetString(i);
                           
                        }

                        }

                    }
                }

                }//查找用户账号所对应的密码
     /// <summary>
     /// 根据账号查找昵称
     /// </summary>
     /// <param name="Account">账号</param>
        public void NickName(string Account)
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
                    com.CommandText = "select NickName from Entry where Account=@Account";
                    com.Parameters.AddWithValue("@Account", Account);
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        int i = sdr.GetOrdinal("NickName");
                        while (sdr.Read())
                        {
                           Nickname = sdr.GetString(i);

                        }

                    }

                }
            }

        }//查找用户账号所对应的昵称

        
            }

    }
   

