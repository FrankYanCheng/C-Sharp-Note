using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Data.OleDb;




namespace MySchool
{
    // ������ݿ������ַ��������ݿ����Ӷ���
    class DBHelper
    {
        // ���ݿ������ַ���        
        //public static string connectionString = "Data Source=(local);Initial Catalog=MySchool;uid=sa;pwd=1234";
        // ���ݿ����Ӷ���
        //public static SqlConnection connection = new SqlConnection(connectionString);

        public static string strConnection="Provider=Microsoft.Jet.OleDb.4.0;Data Source=exam.mdb";
        public static OleDbConnection connection = new OleDbConnection(strConnection);

    }
}
