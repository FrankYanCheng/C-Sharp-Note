///编写人：范衍铖
///时间：2013-12-12
///建立查找数据库的类并进行读取配对
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
namespace Entry
{
    #region 查找账户密码类
    public class SqlAccount
    {
       
        private string Search;//将查找到的密码设为私有
        public string search//只读操作
        {
            get
            {
                return Search;
            }
        }
        #region 构造函数传递account为用户的账号
        public SqlAccount(string account)
        {
            #region 从配置文件中查找所需查询语句
            string searchcode = ConfigurationManager.ConnectionStrings["SqlAccount SearchCode"].ConnectionString;  
            #endregion
            #region 连接数据库
            using (SqlConnection con = new SqlConnection(searchcode))
            {
                using (SqlCommand com = con.CreateCommand())
                {
                    con.Open();
                    #region 从配置文件中调用查询命令语句
                    string ComCommandText = ConfigurationManager.ConnectionStrings["SqlAccount comSqlCommand"].ConnectionString;
                    #endregion
                    com.CommandText = ComCommandText;
                    #region 添加传递的参数为账户名并进行搜索
                    com.Parameters.AddWithValue("@StudentID", account);
                    #endregion
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        int i = sdr.GetOrdinal("StudentCode");
                        while (sdr.Read())
                        {
                            Search = sdr.GetString(i);
                        }
                        
                    }
                }

            }
            #endregion
        }
        #endregion
    }
    #endregion
}
