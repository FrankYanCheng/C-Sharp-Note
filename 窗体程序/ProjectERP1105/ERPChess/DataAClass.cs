using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERPLibrary
{
    public class DataAClass
    {

        static DataAClass o = new DataAClass();
        public static DataAClass getInstanse()
        {
            if (o != null)
                return o;
            else
                return new DataAClass();
        }
        public OleDbConnection getDAO()
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\bill.mdb";
            OleDbConnection cn = new OleDbConnection(con);

            return cn;
        }
    }
}
