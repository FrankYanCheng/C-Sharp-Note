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
using System.Threading;
using System.Data.OleDb;
using System.Net;


namespace ERPChess
{
    public partial class Form_ShowResult : Office2007Form
    {
        public Form_ShowResult()
        {
            InitializeComponent();
        }
        ILSGOfrmTipBox mesbox;
        private void Form_ShowResult_Load(object sender, EventArgs e)
        {
           
            this.ControlBox = false; 
            int year = -1;
            for (int i = 0; i < PubVar.year; i++)
            {
                this.cmb_year.Items.Add("第" + i.ToString() + "年");
            }
            if (PubVar.mark == 0)
            {
                this.labelX1.Visible = false;
                this.btn_search.Visible = false;
                this.cmb_year.Visible = false;
                year = PubVar.year;
                this.cmb_year.Items.Add("第" + year.ToString() + "年");
                this.cmb_year.Text = "第" + year.ToString() + "年";
                this.cmb_year.SelectedIndex = cmb_year.Items.Count - 1;
                PubVar.discount = 0;

                //edit by tianxin
                OleDbConnection cn = ERPLibrary.DataAClass.getInstanse().getDAO();
                string RYMC = Convert.ToString(PubVar.PlayerName);
                string strHostName = Dns.GetHostName(); //得到本机的主机名            
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP    
                IPAddress[] IPContent = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                IPAddress IPa = IPContent[0];///////////////////////////
                string IP = IPa.ToString();
                cn.Open();
                string sql = "INSERT INTO syb (YXID,PLAYERNAME,FQZBZ,NF,DLIP,SDSR,ZYYWCB,CPXSSJJFJ,ZYYWLR,CWFY,YYLR,LRZE,SDS,JLR,DLSJ) " +
                   "VALUES ('" + PubVar.YXID + "','"
                    + RYMC + "','"
                    + PubVar.identify + "','"
                    + (PubVar.year).ToString() + "','"
                    + IP + "',"
                    + PubVar.closing[year].Pal_sale + ","
                    + PubVar.closing[year].Pal_cost + ","
                    + PubVar.closing[year].Pal_attach + ","
                    + PubVar.closing[year].Pal_TBusProfit + ","
                    + PubVar.closing[year].Pal_financial + ","
                    + PubVar.closing[year].Pal_busProfit + ","
                    + PubVar.closing[year].Pal_profit + ","
                    + PubVar.closing[year].Pal_tax + ","
                    + PubVar.closing[year].Pal_netProfit + ",'"
                    + DateTime.Now.ToString() + "')";

                string sql2 = "INSERT INTO zcfzb (YXID,PLAYERNAME,FQZBZ,NF,DLIP,XJ,YSZK,LDZCHJ,GDZCYZ,LJZJ,GDZCJZ,GDZCHJ,ZCZJ,DQDK,YFZK,YFSJ,CQDK,ZFZ,GDZB,LRLC,BNJL,SYZQY,FZJQY,DLSJ) " +
                  "VALUES ('" + PubVar.YXID + "','"
                   + RYMC + "','"
                   + PubVar.identify + "','"
                   + (PubVar.year).ToString() + "','"
                   + IP + "',"
                   + PubVar.closing[year].Anl_proCash + ","
                   + PubVar.closing[year].Anl_proRaccount + ","
                   + PubVar.closing[year].Anl_proTLiquid + ","
                   + PubVar.closing[year].Anl_proTdevicevalueyuan + ","
                   + PubVar.closing[year].Anl_proDepreciationtotal + ","
                   + PubVar.closing[year].Anl_proTdevicevalue + ","
                   + PubVar.closing[year].Anl_proTSolid + ","
                   + PubVar.closing[year].Anl_proTotal + ","
                   + PubVar.closing[year].Anl_debtSloan + ","
                   + PubVar.closing[year].Anl_debtPaccount + ","
                   + PubVar.closing[year].Anl_debtTax + ","
                   + PubVar.closing[year].Anl_debtLloan + ","
                   + PubVar.closing[year].Anl_debtT + ","
                   + PubVar.closing[year].Anl_rstock + ","
                   + PubVar.closing[year].Anl_rprofitSave + ","
                   + PubVar.closing[year].Anl_rNetprofit + ","
                   + PubVar.closing[year].Anl_rightsT + ","
                   + PubVar.closing[year].Anl_rightsDebt + ",'"
                   + DateTime.Now.ToString() + "')";

                OleDbCommand cmd = new OleDbCommand(sql, cn);
                OleDbCommand cmd2 = new OleDbCommand(sql2, cn);

                try {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                    mesbox.ShowMessage(ex.Message, "提示");
                }
                finally
                {
                    cn.Close();
                }
                
                //end

                PubVar.year++;

                
            }
            else if (PubVar.mark == 1)
            {
                year = PubVar.year - 1;
                this.cmb_year.Text = "第" + year.ToString() + "年";
            }
            else
            {
                return;
            }
            ShowResult(year);
        }
        private void ShowResult(int year)
        {
            this.lbl_year1.Text = "第" + year + "年";
            this.lbl_year2.Text = "第" + year + "年";
            this.lbl_year.Text = "第" + year + "年";
            this.label30.Text = Math.Round(PubVar.closing[year].Anl_proDepreciationtotal).ToString();//增加累计折旧项
            this.label21.Text = Math.Round(PubVar.closing[year].Anl_proTdevicevalueyuan).ToString();//设备原值
            this.lbl_cc_account.Text = Math.Round(PubVar.closing[year].DdZl).ToString();
            this.lbl_cc_sales.Text=Math.Round(PubVar.closing[year].Cc_sales).ToString(); 
            this.lbl_Anl_debtLloan.Text = Math.Round(PubVar.closing[year].Anl_debtLloan).ToString();
            //
            this.lbl_Anl_debtPaccount.Text = Math.Round(PubVar.closing[year].Anl_debtPaccount).ToString();
            //
            this.lbl_Anl_debtSloan.Text = Math.Round(PubVar.closing[year].Anl_debtSloan).ToString();
            this.lbl_Anl_debtT.Text = Math.Round(PubVar.closing[year].Anl_debtT).ToString();
            this.lbl_Anl_debtTex.Text = Math.Round(PubVar.closing[year].Anl_debtTax).ToString();
            this.txt_security.Text = Math.Round(PubVar.closing[year].Pal_Security).ToString();
            //this.lbl_Anl_proBuilding.Text = PubVar.closing[year].Anl_proBuilding).ToString();在建工程，删除
            this.lbl_Anl_proCash.Text = Math.Round(PubVar.closing[year].Anl_proCash).ToString();
            this.lbl_Anl_proTdevicevalue.Text = Math.Round(PubVar.closing[year].Anl_proTdevicevalue).ToString();
            ///////////
            this.lbl_Anl_proRaccount.Text = Math.Round(PubVar.closing[year].Anl_proRaccount).ToString();
            ////////////
            //this.lbl_Anl_proSave.Text = PubVar.closing[year].Anl_proSave).ToString();留存的煤删掉，修改
            this.lbl_Anl_proTLiquid.Text = Math.Round(PubVar.closing[year].Anl_proTLiquid).ToString();
            this.lbl_Anl_proDepAdd.Text = Math.Round(PubVar.closing[year].Anl_proTdevicevalueyuan).ToString();//设备原值增加
            this.lbl_Anl_proNetSolid.Text = Math.Round(PubVar.closing[year].Anl_proDepreciationtotal).ToString();//增加累计折旧项
            this.lbl_Anl_proTotal.Text = Math.Round(PubVar.closing[year].Anl_proTotal).ToString();
            this.lbl_Anl_proTSolid.Text = Math.Round(PubVar.closing[year].Anl_proTSolid).ToString();

            this.lbl_Anl_rightsDebt.Text = Math.Round(PubVar.closing[year].Anl_rightsDebt).ToString();
            this.lbl_Anl_rightsT.Text = Math.Round(PubVar.closing[year].Anl_rightsT).ToString();
            this.lbl_Anl_rNetprofit.Text = Math.Round(PubVar.closing[year].Anl_rNetprofit).ToString();
            this.lbl_Anl_rprofitSave.Text = Math.Round(PubVar.closing[year].Anl_rprofitSave).ToString();
            this.lbl_Anl_rstock.Text = Math.Round(PubVar.closing[year].Anl_rstock).ToString();

            this.lbl_Cc_fmt_attach.Text = Math.Round(PubVar.closing[year].Cc_fmt_attach).ToString();
            this.lbl_Cc_fmt_discount.Text = Math.Round(PubVar.closing[year].Cc_fmt_discount).ToString();
            this.lbl_Cc_fmt_insurance.Text = Math.Round(PubVar.closing[year].Cc_fmt_insurance).ToString();
            this.lbl_Cc_fmt_Linterest.Text = Math.Round(PubVar.closing[year].Cc_fmt_Linterest).ToString();
            //this.lbl_Cc_fmt_nitric.Text = PubVar.closing[year].Cc_fmt_nitric).ToString();
            //this.lbl_Cc_fmt_powerRate.Text = PubVar.closing[year].Cc_fmt_powerRate).ToString();
            this.lbl_Cc_fmt_Sinterest.Text = Math.Round(PubVar.closing[year].Cc_fmt_Sinterest).ToString();
            this.lbl_Cc_fmt_tax.Text = Math.Round(PubVar.closing[year].Cc_fmt_tax).ToString();

            this.lbl_Cc_mbc_blowdown.Text = Math.Round(PubVar.closing[year].Cc_fmt_nitric).ToString();
            this.lbl_Cc_mbc_coal.Text = Math.Round(PubVar.closing[year].Cc_mbc_entrust).ToString();
            this.lbl_Cc_mbc_dep.Text = Math.Round(PubVar.closing[year].Cc_mbc_dep).ToString();
            //this.lbl_Cc_mbc_entrust.Text = PubVar.closing[year].Cc_mbc_entrust).ToString();
            //this.lbl_Cc_mbc_material.Text = PubVar.closing[year].Cc_mbc_material).ToString();
            this.lbl_Cc_mbc_oil.Text = Math.Round(PubVar.closing[year].Cc_mbc_Ele).ToString();
            //this.label34.Text = PubVar.closing[year].Cc_mbc_Security).ToString();
            PubVar.closing[year].Cc_mbc_others = PubVar.temp;
            this.lbl_Cc_mbc_others.Text = Math.Round(PubVar.closing[year].Cc_mbc_others).ToString();
            this.lbl_Cc_mbc_repair.Text = Math.Round(PubVar.closing[year].Cc_mbc_repair).ToString();
            this.lbl_Cc_mbc_total.Text = Math.Round(PubVar.closing[year].Cc_mbc_total).ToString();
            this.lbl_Cc_mbc_water.Text = Math.Round(PubVar.closing[year].Cc_fmt_powerRate).ToString();
            this.lbl_Cc_mbc_welfare.Text = Math.Round(PubVar.closing[year].Cc_mbc_welfare).ToString();

            //this.lbl_Cc_o_building.Text = PubVar.closing[year].Cc_o_building).ToString();
            this.lbl_Cc_o_cash.Text = Math.Round(PubVar.closing[year].Cc_o_cash).ToString();
            this.lbl_Cc_o_Lloan.Text = Math.Round(PubVar.closing[year].Cc_o_Lloan).ToString();
            this.lbl_Cc_o_Paccount.Text = Math.Round(PubVar.closing[year].Anl_debtPaccount).ToString();
            ///////////
            this.lbl_Cc_o_Raccount.Text = Math.Round(PubVar.closing[year].Anl_proRaccount).ToString();
            ///////////////
            //this.lbl_Cc_o_saveCoal.Text = PubVar.closing[year].Cc_o_saveCoal).ToString();
            this.lbl_Cc_o_Sloan.Text = Math.Round(PubVar.closing[year].Cc_o_Sloan).ToString();
            this.lbl_Cc_o_Tdevicevalue.Text = Math.Round(PubVar.closing[year].Cc_o_Tdevicevalue).ToString();

            this.lbl_Pal_attach.Text = Math.Round(PubVar.closing[year].Pal_attach).ToString();
            this.lbl_Pal_busProfit.Text = Math.Round(PubVar.closing[year].Pal_busProfit).ToString();
            this.lbl_Pal_cost.Text = Math.Round(PubVar.closing[year].Pal_cost).ToString();
            this.lbl_Pal_financial.Text = Math.Round(PubVar.closing[year].Pal_financial).ToString();
            //this.lbl_Cc_mbc_littleOilfire.Text = PubVar.closing[year].Cc_mbc_littleOilfire).ToString();
            this.lbl_Pal_NetProfit.Text = Math.Round(PubVar.closing[year].Pal_netProfit).ToString();
            this.lbl_Pal_profit.Text = Math.Round(PubVar.closing[year].Pal_profit).ToString();
            this.lbl_Pal_sale.Text = Math.Round(PubVar.closing[year].Pal_sale).ToString();
            this.lbl_Pal_tax.Text = Math.Round(PubVar.closing[year].Pal_tax).ToString();//所得税
            this.lbl_Pal_TBusProfit.Text = Math.Round(PubVar.closing[year].Pal_TBusProfit).ToString();


            //modify by tianxin 
            //功能：存取损益表、资产负债表信息 
            //time：2013.07.03
            //string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Computer1.mdb";
           
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            int year = PubVar.year-1;
            if (PubVar.mark == 0)
            {
                if (PubVar.closing[PubVar.year - 1].Anl_rightsT < 0 || PubVar.closing[PubVar.year - 1].Anl_proCash < 0)
                {
                    Program.Forms.frmMain.step = 0;
                    Form_Fail frm = new Form_Fail();
                    frm.ShowDialog();
                }

                ////modify by tianxin 
                ////功能：存取损益表、资产负债表信息 
                ////time：2013.07.03
                ////string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Computer1.mdb";
                //OleDbConnection cn = ERPLibrary.DataAClass.getInstanse().getDAO();
                //try
                //{
                //    cn.Open();
                //    string RYMC = Convert.ToString(PubVar.PlayerName);
                //    string sql_s = "select * from syb where yxid = '" + PubVar.YXID + "' and playername = '" + RYMC + "'";
                //    OleDbCommand cmd_s = new OleDbCommand(sql_s, cn);
                //    OleDbDataReader result_s = cmd_s.ExecuteReader();

                //    string sql_z = "select * from zcfzb where yxid = '" + PubVar.YXID + "' and playername = '" + RYMC + "'";
                //    OleDbCommand cmd_z = new OleDbCommand(sql_z, cn);
                //    OleDbDataReader result_z = cmd_z.ExecuteReader();


                //    string NF = Convert.ToString(DateTime.Now.Year);
                //    string strHostName = Dns.GetHostName(); //得到本机的主机名            
                //    IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP    
                //    IPAddress[] IPContent = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                //    IPAddress IPa = IPContent[1];
                //    string IP = IPa.ToString();
                //    // string IP = ipBox1.IP.ToString(); //ipEntry.AddressList[0].ToString();//

                //    string sql = "INSERT INTO syb (YXID,PLAYERNAME,FQZBZ,NF,DLIP,SDSR,ZYYWCB,CPXSSJJFJ,ZYYWLR,CWFY,YYLR,LRZE,SDS,JLR,DLSJ) " +
                //       "VALUES ('" + PubVar.YXID + "','"
                //        + RYMC + "','"
                //        + PubVar.identify + "',"
                //        + NF + ",'"
                //        + IP + "',"
                //        + PubVar.closing[year].Pal_sale + ","
                //        + PubVar.closing[year].Pal_cost + ","
                //        + PubVar.closing[year].Pal_attach + ","
                //        + PubVar.closing[year].Pal_TBusProfit + ","
                //        + PubVar.closing[year].Pal_financial + ","
                //        + PubVar.closing[year].Pal_busProfit + ","
                //        + PubVar.closing[year].Pal_profit + ","
                //        + PubVar.closing[year].Pal_tax + ","
                //        + PubVar.closing[year].Pal_netProfit + ",'"
                //        + DateTime.Now.ToString() + "')";

                //    string sql2 = "INSERT INTO zcfzb (YXID,PLAYERNAME,FQZBZ,NF,DLIP,XJ,YSZK,LDZCHJ,GDZCYZ,LJZJ,GDZCJZ,GDZCHJ,ZCZJ,DQDK,YFZK,YFSJ,CQDK,ZFZ,GDZB,LRLC,BNJL,SYZQY,FZJQY,DLSJ) " +
                //      "VALUES ('" + PubVar.YXID + "','"
                //       + RYMC + "','"
                //       + PubVar.identify + "',"
                //       + NF + ",'"
                //       + IP + "',"
                //       + PubVar.closing[year].Anl_proCash + ","
                //       + PubVar.closing[year].Anl_proRaccount + ","
                //       + PubVar.closing[year].Anl_proTLiquid + ","
                //       + PubVar.closing[year].Anl_proTdevicevalueyuan + ","
                //       + PubVar.closing[year].Anl_proDepreciationtotal + ","
                //       + PubVar.closing[year].Anl_proTdevicevalue + ","
                //       + PubVar.closing[year].Anl_proTSolid + ","
                //       + PubVar.closing[year].Anl_proTotal + ","
                //       + PubVar.closing[year].Anl_debtSloan + ","
                //       + PubVar.closing[year].Anl_debtPaccount + ","
                //       + PubVar.closing[year].Anl_debtTax + ","
                //       + PubVar.closing[year].Anl_debtLloan + ","
                //       + PubVar.closing[year].Anl_debtT + ","
                //       + PubVar.closing[year].Anl_rstock + ","
                //       + PubVar.closing[year].Anl_rprofitSave + ","
                //       + PubVar.closing[year].Anl_rNetprofit + ","
                //       + PubVar.closing[year].Anl_rightsT + ","
                //       + PubVar.closing[year].Anl_rightsDebt + ",'"
                //       + DateTime.Now.ToString() + "')";

                //    OleDbCommand cmd = new OleDbCommand(sql, cn);
                //    OleDbCommand cmd2 = new OleDbCommand(sql2, cn);
                //    if (!result_s.Read())
                //        cmd.ExecuteNonQuery();
                //    result_s.Close();
                //    if (!result_z.Read())
                //        cmd2.ExecuteNonQuery();
                //    result_z.Close();
                //}
                //catch (Exception ex)
                //{
                //    ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                //    mesbox.ShowMessage(ex.Message, "提示");
                //}
                //finally
                //{
                //    cn.Close();
                //}
                ////modify end


            }



            
            this.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            double a=Program.factory.RAccount[0].Fund;
            mesbox = new LSGOfrmInforMessageBox();
            if (cmb_year.SelectedItem == null)
            {
                return;
            }
            string txt= cmb_year.SelectedItem.ToString();
            int year = Convert.ToInt32(txt.Substring(1, 1));
            ShowResult(year);
            this.Refresh();
        }

        private void Form_ShowResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //if (PubVar.year == 11)
            //{
            //    //Thread.Sleep(200);
            //    //double totalPoints = 0;
            //    //totalPoints = GameOver.total_Points();
            //    string order = MessageType.totalPoint.ToString() + "//" + PubVar.PlayerName + "//" + GameOver.total_Points().ToString();
            //    Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
            //    GameOver.gameOver();
            //}
        }


        

    }
}
