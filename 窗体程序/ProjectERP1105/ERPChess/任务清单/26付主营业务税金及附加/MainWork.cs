using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;
namespace ERPChess
{
    public partial class MainWork : DevComponents.DotNetBar.Office2007Form
    {
        public MainWork(frmMain parent)
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            par = parent;
        }
        frmMain par;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            PubVar.t_diaoyong = 20;

            par.timer2.Interval = 100;
            par.timer2.Start();
            this.Close();
        }

        private void MainWork_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            this.dataGridViewX1.RowCount = 1;
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.EleIncome);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.EleIncome * 0.01);
            PubVar.Fund -= PubVar.EleIncome * 0.01;
            this.dataGridViewX1.Rows[0].Cells[3].Value = Math.Round(PubVar.Fund);
            AddResult();
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
                Application.Exit();
            }
        }
        private void AddResult()
        {
            
            double coalcost = PubVar.mbc_Ele;//本年燃煤费用
            string receiveStr=pal_sale();
            string[] receiveArr=receiveStr.Split(("//").ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            double cc_sales=Convert.ToDouble(receiveArr[0]);
            double raccountThisYear=Convert.ToDouble(receiveArr[1]);

            Result result = new Result();
            do
            {
                
            result.Cc_sales = cc_sales;
            result.Cc_fmt_attach = result.Cc_sales * 0.01;
            result.Cc_fmt_discount =PubVar.discount;
            result.Cc_fmt_insurance = PubVar.valueguarsanttee;//jhkjjjjjjjjjjjjjjjjjjjjjjjj
            result.Cc_fmt_Linterest = AnnualInterest();
            result.Cc_fmt_nitric = PubVar.ISOCost;
            result.Cc_fmt_powerRate = result.Cc_sales * 0.08;
            result.Cc_fmt_Sinterest = PubVar.AnnualInterestS;
            result.Pal_Security = PubVar.Security;

            /*result.Cc_mbc_blowdown = Math.Round(coalcost * 0.02);
            result.Cc_mbc_Ele = Math.Round(PubVar.mbc_Ele);
            result.Cc_mbc_dep = Math.Round(PubVar.depreciation);
            result.Anl_proDepreciationtotal = Math.Round(PubVar.depreciationtotal);
            result.Anl_proTdevicevalueyuan = Math.Round(PubVar.Tdevicevalueyuan);
            result.Cc_mbc_entrust = 5;
            result.Cc_mbc_material = Math.Round(coalcost * 0.035);
            result.Cc_mbc_oil = Math.Round(PubVar.oiluse);
            result.Cc_mbc_others = Math.Round(PubVar.temp) ;
            result.Cc_mbc_repair = Math.Round(PubVar.Cc_mbc_repair);
            result.Cc_mbc_water = Math.Round(coalcost * 0.006);
            result.Cc_mbc_welfare = Math.Round(50 * Math.Pow(1.05, PubVar.year-1));
            result.Cc_mbc_littleOilfire = Math.Round(PubVar.littleOilfire);
            result.Cc_mbc_total = Math.Round(PubVar.mbc_Ele + result.Cc_mbc_entrust + result.Cc_sales * 0.08 + PubVar.Cc_mbc_repair +
                50 * Math.Pow(1.05, PubVar.year - 1) + PubVar.valueguarsanttee + PubVar.depreciation + result.Cc_fmt_nitric);//去掉燃油、厂电等部分，应修改result.Cc_mbc_others +*/


            result.Cc_mbc_blowdown = coalcost * 0.02;
            result.Cc_mbc_Ele = PubVar.mbc_Ele;
            //result.Cc_mbc_Security = Math.Round(PubVar.Security);//安全费
            result.Cc_mbc_dep = PubVar.depreciation;
            result.Anl_proDepreciationtotal = PubVar.depreciationtotal;
            result.Anl_proTdevicevalueyuan = PubVar.Tdevicevalueyuan;
            result.Cc_mbc_entrust = 5;
            result.Cc_mbc_material = coalcost * 0.035;
            result.Cc_mbc_oil = PubVar.oiluse;
            result.Cc_mbc_others = PubVar.temp;
            result.Cc_mbc_repair = PubVar.Cc_mbc_repair;
            result.Cc_mbc_water = coalcost * 0.006;
            result.Cc_mbc_welfare = 50 * Math.Pow(1.05, PubVar.year - 1);
            result.Cc_mbc_Security = PubVar.Security;
            result.Cc_mbc_littleOilfire = PubVar.littleOilfire;
            result.Cc_mbc_total = result.Cc_mbc_Ele + result.Cc_mbc_Security + result.Cc_mbc_entrust + result.Cc_fmt_powerRate + result.Cc_mbc_repair +
                result.Cc_mbc_welfare + result.Cc_fmt_insurance + result.Cc_mbc_dep+ result.Cc_mbc_others + result.Cc_fmt_nitric;//去掉燃油、厂电等部分，应修改





            result.Cc_o_building = PubVar.ValueOnBuilding;
            result.Cc_o_cash = PubVar.Fund;
            result.Cc_o_Lloan = PubVar.loanL;
            result.Cc_o_Tdevicevalue = PubVar.Tdevicevalue;
            result.Cc_o_Paccount = Paccount();//已经取消应付账款
            result.Cc_o_Raccount = Raccount();//应收账款
            result.Cc_o_saveCoal = PubVar.coalValueLeft;
            result.Cc_o_Sloan = PubVar.sloan.shortLoanAmount;

            result.Pal_cost = result.Cc_mbc_total;
            result.Pal_financial = result.Cc_fmt_Sinterest + result.Cc_fmt_Linterest + result.Cc_fmt_discount;
            result.Pal_manage = coalcost * 0.14;
            result.Pal_sale = result.Cc_sales;
            result.Pal_attach = result.Pal_sale * 0.01;
            result.Pal_TBusProfit = result.Pal_sale - result.Pal_cost - result.Pal_attach;
            result.Pal_busProfit = result.Pal_TBusProfit - result.Pal_financial;
            result.Pal_profit = result.Pal_busProfit;

            result.Anl_rprofitSave = PubVar.closing[PubVar.year - 1].Anl_rprofitSave + PubVar.closing[PubVar.year - 1].Anl_rNetprofit;
            if (result.Anl_rprofitSave + result.Pal_profit > 0)
            {
                if (result.Pal_profit < 0)
                {
                    result.Cc_fmt_tax = 0;
                }
                else
                {
                    result.Cc_fmt_tax = Math.Round(result.Pal_profit * 0.25);
                }
            }


            result.Pal_tax = result.Cc_fmt_tax;//所得税
            result.Pal_netProfit = result.Pal_profit - result.Pal_tax;
            result.DdZl = PubVar.DdZl;
            result.Anl_debtLloan = PubVar.loanL;
            result.Anl_debtPaccount = Paccount();//应付账款
            result.Anl_debtSloan = PubVar.sloan.shortLoanAmount;
            result.Anl_debtTax = result.Pal_tax;
            //result.Anl_debtT = Math.Round(PubVar.loanL + Paccount() + PubVar.sloan.shortLoanAmount + result.Cc_fmt_tax);//修改总负债为双精度型
            result.Anl_debtT = result.Anl_debtLloan + result.Anl_debtPaccount + result.Anl_debtSloan + result.Anl_debtTax;


            //result.Anl_proBuilding = Math.Round(PubVar.ValueOnBuilding);//
            result.Anl_proCash = PubVar.Fund;
            result.Anl_proTdevicevalue = PubVar.Tdevicevalue;
            result.Anl_proRaccount = Raccount();
            //result.Anl_proSave = Math.Round(PubVar.coalValueLeft);//存的是钱？
            result.Anl_proTLiquid = result.Anl_proCash + result.Anl_proRaccount;//流动资产
            result.Anl_proTSolid = result.Anl_proTdevicevalue;//固定资产
            result.Anl_proTotal = Math.Round(result.Anl_proTLiquid + result.Anl_proTSolid);
            
            result.Anl_rstock = 500;
            result.Anl_rNetprofit = result.Pal_netProfit;
           
            result.Anl_rightsT = result.Anl_rNetprofit + result.Anl_rprofitSave + result.Anl_rstock;          //////frwufhmdcwelhktfhfrhfjkdh
            result.Anl_rightsDebt = Math.Round(result.Anl_debtT + result.Anl_rightsT);
            PubVar.Fund -= result.Anl_proTotal - result.Anl_rightsDebt;
            } while (result.Anl_proTotal != result.Anl_rightsDebt);
            PubVar.closing.Add(result);

            //有改动
            double right = 0;
            double profit = 0;
            right = result.Anl_rightsT;
            profit = result.Anl_rNetprofit;
            string order = MessageType.ThisYearPoint.ToString() + "//" + PubVar.PlayerName + "//" + right.ToString() + "//" + profit.ToString();
            Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
            /*if (PubVar.year == 2)
            {
                Thread.Sleep(200);
                double totalPoints = 0;
                totalPoints = GameOver.total_Points();
                order = MessageType.ThisYearPoint.ToString() + "//" + PubVar.PlayerName + "//" + totalPoints.ToString();
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
                GameOver.gameOver();//加入gameover语句
            }*/
            //
            PubVar.lloan = new LoanList();
        }
        /// <summary>
        /// 售电
        /// </summary>
        /// <returns>售电额</returns>
        private string pal_sale()
        {
            double temp = 0;//销售额
            double sum = 0;//应收账款
            if (PubVar.BidEleResult != null)
            {
                for (int i = 0; i < PubVar.BidEleResult.Count; i++)
                {
                    if (PubVar.BidEleResult[i].IsCommite)
                    {
                        temp += PubVar.BidEleResult[i].Sum;
                        if (PubVar.BidEleResult[i].YearLimit != 0)
                        {
                            sum += PubVar.BidEleResult[i].Sum;
                        }
                    }
                }
                for (int i = PubVar.BidEleResult.Count - 1; i >= 0; i--)
                {
                    if (PubVar.BidEleResult[i].IsCommite)
                    {
                        PubVar.BidEleResult.Remove(PubVar.BidEleResult[i]);
                    }
                }
            }
            return temp+"//"+sum;
        }
        /// <summary>
        /// 应收账款
        /// </summary>
        /// <returns></returns>
        private double Raccount()
        {
            double sum = 0;
            if (Program.factory.RAccount != null)
            {
                for (int i = 0; i < Program.factory.RAccount.Count; i++)
                {
                    sum += Program.factory.RAccount[i].Fund;
                }
            }
            return sum;
        }
        /// <summary>
        /// 应付账款
        /// </summary>
        /// <returns></returns>
        private double Paccount()
        {
            double sum = 0;
            if (Program.factory.PAccount != null)
            {
                for (int i = 0; i < Program.factory.PAccount.Count; i++)
                {
                    sum += Program.factory.PAccount[i].Fund;
                }
            }
            return sum;
        }
        private double AnnualInterest()
        {
            double sum = 0;
            for (int i = 0; i < PubVar.year; i++)
            {
                sum += PubVar.longloanlist[i].AnnualInterest;
            }
            return sum;
        }
    }
}