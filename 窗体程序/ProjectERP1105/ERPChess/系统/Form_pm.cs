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
using System.Reflection;




namespace ERPChess
{
    public partial class Form_pm : Office2007Form
    {
        public Form_pm()
        {
            InitializeComponent();
        }
        Form frm;
        DataSet dcdataset;
        private void Form_pm_Load(object sender, EventArgs e)
        {
            OleDbConnection cn = ERPLibrary.DataAClass.getInstanse().getDAO();
            //生成历史数据1.删除总排名数据，2从score表获取最新总排名，并存入grb，再将lspm更新回score表
            try
            {
                cn.Open();
                string del = "delete from grb";
                OleDbCommand cmd = new OleDbCommand(del, cn);
                cmd.ExecuteNonQuery();

                //string del1 = "delete from grb_tmp";
                //OleDbCommand cmd1 = new OleDbCommand(del1, cn);
                //cmd1.ExecuteNonQuery();

                //string lspm_tmp = "insert into grb_tmp (playername,totalpoint) SELECT playername, sum(totalpoint) FROM score GROUP BY playername";
                //OleDbCommand cmd2 = new OleDbCommand(lspm_tmp, cn);
                //cmd2.ExecuteNonQuery();

                string lspm = "insert into grb (yxid,playername,totalpoint,paiming) SELECT yxid, playername, totalpoint, (select count(playername) from grb_tmp " +
                    "as a where a.totalpoint >= b.totalpoint) AS pm FROM grb_tmp AS b ORDER BY b.totalpoint DESC";
                OleDbCommand cmd3 = new OleDbCommand(lspm, cn);
                cmd3.ExecuteNonQuery();

                //更新本次游戏各人员总积分
                string gx = "UPDATE score AS a, grb b SET a.lspm = b.paiming where a.playername = b.playername and a.yxid ='" + PubVar.YXID + "' and b.yxid ='"+ PubVar.YXID +"'";
                OleDbCommand cmd4 = new OleDbCommand(gx, cn);
                cmd4.ExecuteNonQuery();

                //查询出本次游戏结果
                string sql = "SELECT playername AS 姓名, (SELECT count(playername) from score" +
                    " as a where a.yxid = b.yxid and a.totalPoint >= b.totalPoint ) AS 排名," +
                    " totalPoint as 积分, score as 成绩, lspm as 总排名, createTime as 发起时间 FROM score AS b WHERE b.yxid ='" + PubVar.YXID + "' ORDER BY b.totalPoint DESC";

                DataSet mydataset = new DataSet();
                OleDbDataAdapter myadapter = new OleDbDataAdapter(sql, cn);
                myadapter.Fill(mydataset, "score");
                dg1.SetDataBinding(mydataset.Tables[0], null);
                dcdataset = mydataset;
            }
            catch (Exception ex)
            {
                ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                mesbox.ShowMessage(ex.Message, "提示");
            }
            finally { 
                cn.Close(); 
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm = new Form_zcj(); 
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dcdataset.Tables[0];
            int rowNumber = dataTable.Rows.Count;
            int columnNumber = dataTable.Columns.Count;
            //建立Excel对象 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = true;//是否打开该Excel文件

            //填充数据

            excel.Cells[1, 1] = "姓名";
            //excel.Cells[1, 2] = "角色";
            excel.Cells[1, 2] = "排名";
            excel.Cells[1, 3] = "积分";
            excel.Cells[1, 4] = "成绩";
            excel.Cells[1, 5] = "总排名";
            excel.Cells[1, 6] = "创建时间";
                for (int c = 0; c < rowNumber; c++)
                {
                    for (int j = 0; j < columnNumber; j++)
                    {
                        excel.Cells[c + 2, j + 1] = dataTable.Rows[c].ItemArray[j];
                    }
                }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm = new Form_pbjg();
            frm.ShowDialog();
        }
    }
}
