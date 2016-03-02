using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GGChatSever
{
    class SqlRegister 
    {
        private string nickname;

        public string Nickname//昵称属性
        {
            get { return nickname; }
            set { nickname = value; }
        }
        private string account;
        public string Account//账号属性
        {
            get { return account; }
            set { account = value; }
        }
          public SqlRegister()
        {
        }
        /// <summary>
          /// 查找昵称是否已经存在
        /// </summary>
        /// <param name="nickname">昵称</param>
          public  SqlRegister(string nickname)
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
                    com.CommandText = "select NickName from Entry where NickName=@NickName";
                    com.Parameters.AddWithValue("@NickName", nickname);
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

                }//查找昵称是否已经存在
        /// <summary>
          /// 查找昵称是否已经存在
        /// </summary>
        /// <param name="nickname"></param>
          public void SearchNickName(string nickname)
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
                      com.CommandText = "select NickName from Entry where NickName=@NickName";
                      com.Parameters.AddWithValue("@NickName", nickname);
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
          }
        /// <summary>
          /// 查找账号是否已经存在
        /// </summary>
        /// <param name="account"></param>
          public void SearchAccount(string account)
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
                      com.CommandText = "select Account from Entry where Account=@Account";
                      com.Parameters.AddWithValue("@Account", account);
                      using (SqlDataReader sdr = com.ExecuteReader())
                      {
                          int i = sdr.GetOrdinal("Account");
                          while (sdr.Read())
                          {
                              Account = sdr.GetString(i);

                          }

                      }

                  }
              }
          }//查找账号是否已经存在
        /// <summary>
          /// 插入信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <param name="question"></param>
        /// <param name="answer"></param>
          public void Register(string account, string nickname, string password, string question, string answer)
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
                      com.CommandText = "insert into Entry(Account,NickName,PassWord,Question1,Answer1) values(@account,@nickname,@password,@question1,@answer1)";
                      com.Parameters.AddWithValue("@account", account);
                      com.Parameters.AddWithValue("@nickname",nickname);
                      com.Parameters.AddWithValue("@password", password);
                      com.Parameters.AddWithValue("@question1", question);
                      com.Parameters.AddWithValue("@answer1", answer);
                      com.ExecuteNonQuery();

                  }
              }
          }//插入信息
    }
}
