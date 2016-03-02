using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Data.OleDb;




namespace MySchool
{
    // 存放数据库连接字符串和数据库连接对象
    class DBHelper
    {
        // 数据库连接字符串        
        //public static string connectionString = "Data Source=(local);Initial Catalog=MySchool;uid=sa;pwd=1234";
        // 数据库连接对象
        //public static SqlConnection connection = new SqlConnection(connectionString);

        public static string strConnection="Provider=Microsoft.Jet.OleDb.4.0;Data Source=exam.mdb";
        public static OleDbConnection connection = new OleDbConnection(strConnection);

    }
}
