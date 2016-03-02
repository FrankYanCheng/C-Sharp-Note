using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using LSGO.PresentationLayer;
using System.Data.OleDb;
using LSGO.DataLinkLayer;
using LSGO.DataLinkLayer.Tool;


namespace ERPChess
{
    public partial class Form_zcj : Office2007Form
    {
        public Form_zcj()
        {
            InitializeComponent();
            
        }

       

        private void Form_zcj_Load(object sender, EventArgs e)
        {

            OleDbConnection cn = ERPLibrary.DataAClass.getInstanse().getDAO();
            //string sql = "select playerName,role,xh,totalPoint,score,lspm,createTime from score where yxid = '001' order by totalPoint desc";
            //"+PubVar.YXID +"'";
            try
            {
                string sql = "SELECT playername AS 姓名,totalpoint as 总积分, paiming as 排名 from grb";
                DataSet mydataset = new DataSet();
                OleDbDataAdapter myadapter = new OleDbDataAdapter(sql, cn);
                myadapter.Fill(mydataset, "grb");
                dgg.SetDataBinding(mydataset.Tables[0], null);
            }
            catch (Exception ex)
            {
                ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                mesbox.ShowMessage(ex.Message, "提示");
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
       
    }
}
