using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DevComponents.DotNetBar;
using LSGO.PresentationLayer;
using System.Data.OleDb;
using LSGO.DataLinkLayer;
using LSGO.DataLinkLayer.Tool;

namespace ERPChess
{
    public partial class Form_pbjgnext : Office2007Form
    {
        public Form_pbjgnext()
        {
            InitializeComponent();

            //提取数据
            OleDbConnection cna = ERPLibrary.DataAClass.getInstanse().getDAO();
            
            try
            {
                cna.Open();
                //损益表信息
                string sqla = "select playername, sum(CWFY) as C_WFY,sum(SDSR) as XSE, sum(ZYYWCB) as Z_YYWCB, " +
                    " sum(LRZE) as L_RZE from syb where yxid = '" + PubVar.YXID + "' group by playername";
                DataSet sydataset = new DataSet();
                OleDbDataAdapter myadapter = new OleDbDataAdapter(sqla, cna);
                myadapter.Fill(sydataset, "syb");

                //资产负债信息
                string sqlb = "select playername, (sum(GDZB)+sum(LRLC)+sum(BNJL)) as QY,sum(GDZCJZ) as JZC, sum(ZFZ) as Z_FZ " +
                    " from zcfzb where yxid = '" + PubVar.YXID + "' group by playername";
                DataSet zcdataset = new DataSet();
                OleDbDataAdapter myadapter1 = new OleDbDataAdapter(sqlb, cna);
                myadapter1.Fill(zcdataset, "zcfzb");


                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                //System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2013D, 30D);
                series1.ChartArea = "ChartArea1";
                series1.Legend = "Legend1";
                series1.Name = "净资产";
                int a = zcdataset.Tables[0].Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    int j = i + 1;
                    series1.Points.AddXY("第" + j + "组", (double)zcdataset.Tables[0].Rows[i][2]);
                }


                //series1.Points.AddXY("第1组", 100);
                //series1.Points.AddXY("第2组", 200);
                //series1.Points.AddXY("第3组", 500);
                //series1.Points.AddXY("第4组", 500);
                //series1.Points.AddXY("第5组", 100);
                //series1.Points.AddXY("第6组", 300);

                this.chart1.Series.Add(series1);

                ///////////////
                System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
                //System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2013D, 30D);
                series2.ChartArea = "ChartArea1";
                series2.Legend = "Legend1";
                series2.Name = "比值";

                for (int i = 0; i < a; i++)
                {
                    int j = i + 1;
                    series2.Points.AddXY("第" + j + "组", (double)sydataset.Tables[0].Rows[i][3] / (double)sydataset.Tables[0].Rows[i][4]);
                }

                //series2.Points.AddXY("第1组", 0.9);
                //series2.Points.AddXY("第2组", 0.5);
                //series2.Points.AddXY("第3组", 0.8);
                //series2.Points.AddXY("第4组", 0.7);
                //series2.Points.AddXY("第5组", 0.7);
                //series2.Points.AddXY("第6组", 0.2);

                this.chart2.Series.Add(series2);
                

            }
            catch (Exception ex)
            {
                ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                mesbox.ShowMessage(ex.Message, "提示");
            }
            finally
            {
                cna.Close();
            }


            
        }

        private void Form_pbjgnext_Load(object sender, EventArgs e)
        {

        }

        

    }
}
