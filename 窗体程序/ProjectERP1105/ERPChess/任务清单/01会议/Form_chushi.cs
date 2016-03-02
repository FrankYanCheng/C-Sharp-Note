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

namespace ERPChess
{
    public partial class Form_chushi : Office2007Form
    {
        public Form_chushi(frmMain parent)
        {
            InitializeComponent();
            par = parent;
        }
        ILSGOfrmTipBox mesbox;

        private frmMain par;
        private void ShowResult(int year)
        {
            //this.lbl_cc_account.Text
            //this.lbl_cc_sales.Text=
            
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            par.l_goudian.Text = "0";
            par.l_ddlx.Text = "0";
            par.l_tiexian.Text = "0";
            par.l_cdlx.Text = "0";
            par.l_fuhe.Text = "0";
            label11.Text = "0";
            par.l_leiji.Text = "0";
            par.l_yuanzhi.Text = "0";
            par.l_shuijin.Text = "0";
            par.l_qita.Text = "0";
            par.l_zhejiu.Text = "0";
            par.l_caibao.Text = "0";
            par.l_gongfu.Text = "0";
            par.l_weixiu.Text = "0";
            par.l_xiansun.Text = "0";
            par.l_guanli.Text = "0";
            par.l_goudian.Text = "0";
            par.l_anquan.Text = "0";



            if (PubVar.mark == 0)
            {
                if (PubVar.closing[PubVar.year - 1].Anl_rightsT < 0 || PubVar.closing[PubVar.year - 1].Anl_proCash < 0)
                {
                    Program.Forms.frmMain.step = 0;
                    Form_Fail frm = new Form_Fail();
                    frm.ShowDialog();
                }
            }
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                Program.factory.IEquipment[i].IsEndInvestment();
                Program.factory.IEquipment[i].SetUseOli();
                //Program.factory.IEquipment[i].NitricEquipment.IsEndInvestment();
                Program.factory.Cerficate14000.IsAvailable();
                Program.factory.Certificate9000.IsAvailable();
                Program.factory.Cerficate18000.IsAvailable();
                Program.factory.CerficateSecurity.IsAvailable();
            }
            if (Program.factory.Cerficate14000.Canuse)
            {
                PubVar.IsHaveISO14000 = true;
            }
            if (Program.factory.Certificate9000.Canuse)
            {
                PubVar.IsHaveISO9000 = true;
            }
            if (Program.factory.Cerficate18000.Canuse)
            {
                PubVar.IsHaveISO18000 = true;
            }
            if (Program.factory.CerficateSecurity.Canuse)
            {
                PubVar.IsHaveSecurity = true;
            }
            ///资格认证初始化
            ///
            par.pictureBox11.Visible = false;
            par.pictureBox12.Visible = false;
            par.pictureBox13.Visible = false;
            par.pictureBox14.Visible = false;
            par.pictureBox15.Visible = false;
            par.pictureBox16.Visible = false;
            par.pictureBox17.Visible = false;
            par.pictureBox18.Visible = false;
            par.pictureBox19.Visible = false;
            par.pictureBox20.Visible = false;
            par.pictureBox21.Visible = false;
            par.pictureBox22.Visible = false;
            par.pictureBox23.Visible = false;
            par.pictureBox24.Visible = false;
            if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 1)
                par.pictureBox11.Visible = true;
            if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 2)
                par.pictureBox12.Visible = true;
            if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 3)
                par.pictureBox13.Visible = true;
            if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 4)
                par.pictureBox14.Visible = true;

            if (4 - Program.factory.Cerficate18000.MoneyProgress.Count >= 1)
                par.pictureBox15.Visible = true;
            if (4 - Program.factory.Cerficate18000.MoneyProgress.Count >= 2)
                par.pictureBox16.Visible = true;
            if (4 - Program.factory.Cerficate18000.MoneyProgress.Count >= 3)
                par.pictureBox17.Visible = true;
            if (4 - Program.factory.Cerficate18000.MoneyProgress.Count >= 4)
                par.pictureBox18.Visible = true;
            if (4 - Program.factory.Cerficate14000.MoneyProgress.Count >= 1)
                par.pictureBox19.Visible = true;
            if (4 - Program.factory.Cerficate14000.MoneyProgress.Count >= 2)
                par.pictureBox20.Visible = true;
            if (4 - Program.factory.Cerficate14000.MoneyProgress.Count >= 3)
                par.pictureBox21.Visible = true;
            if (4 - Program.factory.Cerficate14000.MoneyProgress.Count >= 4)
                par.pictureBox22.Visible = true;
            if (2 - Program.factory.Certificate9000.MoneyProgress.Count >= 1)
                par.pictureBox23.Visible = true;
            if (2 - Program.factory.Certificate9000.MoneyProgress.Count >= 2)
                par.pictureBox24.Visible = true;


            //动画

            if (PubVar.shebei == 1)
                par.pictureBox26.Visible = true;
            if (PubVar.shebei == 4)
            {
                par.pictureBox26.Visible = true;
                par.pictureBox25.Visible = true;
            }
            if (PubVar.shebei == 5)
            {
                par.pictureBox26.Visible = true;
                par.pictureBox25.Visible = true;
                par.pictureBox27.Visible = true;
            }


            par.lbl_Raccount1.Text = Math.Round(PubVar.RaccountList[4]).ToString() + "百万";
            par.lbl_Raccount2.Text = Math.Round(PubVar.RaccountList[3]).ToString() + "百万";
            par.lbl_Raccount3.Text = Math.Round(PubVar.RaccountList[2]).ToString() + "百万";
            par.lbl_Raccount4.Text = Math.Round(PubVar.RaccountList[1]).ToString() + "百万";
            par.lbl_Paccount1.Text = Math.Round(PubVar.PaccountList[4]).ToString() + "百万";
            par.lbl_Paccount2.Text = Math.Round(PubVar.PaccountList[3]).ToString() + "百万";
            par.lbl_Paccount3.Text = Math.Round(PubVar.PaccountList[2]).ToString() + "百万";
            par.lbl_Paccount4.Text = Math.Round(PubVar.PaccountList[1]).ToString() + "百万";
            double[] a=new double[11];//长贷初始化
            for(int i=0;i<11;i++)
                a[i]=0;
            for(int i=1;i<11;i++)
                for(int j=0;j<PubVar.longloanlist.Count;j++)
                {
                    if (PubVar.longloanlist[j].payOffyear == i)
                        a[i]+=PubVar.longloanlist[j].save;

                }
            par.label1.Text = Math.Round(a[1]).ToString();
            par.label2.Text = Math.Round(a[2]).ToString();
            par.label3.Text = Math.Round(a[3]).ToString();
            par.label4.Text = Math.Round(a[4]).ToString();
            par.label5.Text = Math.Round(a[5]).ToString();
            par.label6.Text = Math.Round(a[6]).ToString();
            par.label7.Text = Math.Round(a[7]).ToString();
            par.label8.Text = Math.Round(a[8]).ToString();
            par.label9.Text = Math.Round(a[9]).ToString();
            par.label10.Text = Math.Round(a[10]).ToString();


            //财产部分
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            par.lbl_Lloan.Text = Math.Round(PubVar.loanL).ToString() + "百万";
            par.lbl_Sloan.Text = Math.Round(PubVar.loanS).ToString() + "百万";
            //输变电设备初始化
            par.l_fuhe.Text = PubVar.ddys.ToString() + "亿千瓦时";
            label11.Text = PubVar.ddys.ToString() + "亿千瓦时";
            par.l_leiji.Text = Math.Round(PubVar.Tdevicevalueyuan - PubVar.Tdevicevalue).ToString() + "百万";
            par.l_yuanzhi.Text = PubVar.Tdevicevalueyuan.ToString() + "百万";

            //double[] b = new double[5];应付和应收
            for (int i = 0; i < 5; i++)
                a[i] = 0;
            for (int i = 0; i < 5; i++)
            {
                a[i] = PubVar.PaccountList[i];
            }

            par.lbl_Paccount1.Text = Math.Round(a[0]).ToString() + "百万";
            par.lbl_Paccount2.Text = Math.Round(a[1]).ToString() + "百万";
            par.lbl_Paccount3.Text = Math.Round(a[2]).ToString() + "百万";
            par.lbl_Paccount4.Text = Math.Round(a[3]).ToString() + "百万";
            //par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";


            for (int i = 0; i < 5; i++)
            {
                //for (int j = 0; j < PubVar.BidEleResult.Count; j++)
                //{
                a[i] = PubVar.RaccountList[i];
                //if (PubVar.BidEleResult[j].YearLimit == i)
                //    a[i] += PubVar.BidEleResult[j].Sum;

                //}

            }

            par.lbl_Raccount1.Text = Math.Round(a[0]).ToString() + "百万";
            par.lbl_Raccount2.Text = Math.Round(a[1]).ToString() + "百万";
            par.lbl_Raccount3.Text = Math.Round(a[2]).ToString() + "百万";
            par.lbl_Raccount4.Text = Math.Round(a[3]).ToString() + "百万";


        
            this.Close();
        }



        private void Form_chushi_Load(object sender, EventArgs e)
        {
            //应收及应付账款初始化
            //par.lbl_Raccount1.Visible=true;
            //par.lbl_Paccount1.Visible=true;
            //par.lbl_Raccount4.Top =11;
            //par.lbl_Raccount3.Top =34;
            //par.lbl_Raccount2.Top =60;
            //par.lbl_Raccount1.Top =84;
            //par.lbl_Paccount4.Top =125;
            //par.lbl_Paccount3.Top =152;
            //par.lbl_Paccount2.Top =175;
            //par.lbl_Paccount1.Top =198;
            
            
            
            
            
            PubVar.L_ljj = 0;
            PubVar.t_diaoyong = 1;
            this.ControlBox = false; 
            this.tabControl1.SelectedTabIndex = 0;
            
            
            int year = PubVar.year-1;
            this.lbl_year1.Text = "第" + year + "年";
            this.lbl_year2.Text = "第" + year + "年";
            this.lbl_year.Text = "第" + year +"年";


            PubVar.closing[year].Anl_proCash = PubVar.Fund;
            this.lbl_Anl_debtLloan.Text = Math.Round(PubVar.closing[year].Anl_debtLloan).ToString();
            this.lbl_Anl_debtPaccount.Text = Math.Round(PubVar.closing[year].Anl_debtPaccount).ToString();
            this.lbl_Anl_debtSloan.Text = Math.Round(PubVar.closing[year].Anl_debtSloan).ToString();
            this.lbl_Anl_debtT.Text = Math.Round(PubVar.closing[year].Anl_debtT).ToString();
            this.lbl_Anl_debtTex.Text = Math.Round(PubVar.closing[year].Anl_debtTax).ToString();

            this.lbl_Anl_proBuilding.Text = Math.Round(PubVar.closing[year].Anl_proBuilding).ToString();
            this.lbl_Anl_proCash.Text = Math.Round(PubVar.closing[year].Anl_proCash).ToString();
            this.lbl_Anl_proTdevicevalue.Text = Math.Round(PubVar.closing[year].Anl_proTdevicevalue).ToString();

            this.lbl_Anl_proRaccount.Text = Math.Round(PubVar.closing[year].Anl_proRaccount).ToString();
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

            

            this.lbl_Pal_attach.Text = Math.Round(PubVar.closing[year].Pal_attach).ToString();
            this.lbl_Pal_busProfit.Text = Math.Round(PubVar.closing[year].Pal_busProfit).ToString();
            this.lbl_Pal_cost.Text = Math.Round(PubVar.closing[year].Pal_cost).ToString();
            this.lbl_Pal_financial.Text = Math.Round(PubVar.closing[year].Pal_financial).ToString();
            
            this.lbl_Pal_NetProfit.Text = Math.Round(PubVar.closing[year].Pal_netProfit).ToString();
            this.lbl_Pal_profit.Text = Math.Round(PubVar.closing[year].Pal_profit).ToString();
            this.lbl_Pal_sale.Text = Math.Round(PubVar.closing[year].Pal_sale).ToString();
            this.lbl_Pal_tax.Text = Math.Round(PubVar.closing[year].Pal_tax).ToString();
            this.lbl_Pal_TBusProfit.Text = Math.Round(PubVar.closing[year].Pal_TBusProfit).ToString();

            //par.l_goudian.Text="0";
            //par.l_ddlx.Text = "0";
            //par.l_tiexian.Text = "0";
            //par.l_cdlx.Text="0";
            //par.l_fuhe.Text = "0";
            //label11.Text = "0";
            //par.l_leiji.Text = "0";
            //par.l_yuanzhi.Text = "0";
            //par.l_shuijin.Text="0";
            //par.l_qita.Text="0";
            //par.l_zhejiu.Text="0";
            //par.l_caibao.Text="0";
            //par.l_gongfu.Text="0";
            //par.l_weixiu.Text="0";
            //par.l_xiansun.Text="0";
            //par.l_guanli.Text="0";
            //par.l_goudian.Text="0";
            //par.l_anquan.Text = "0";
        
        
        }

    }
}
