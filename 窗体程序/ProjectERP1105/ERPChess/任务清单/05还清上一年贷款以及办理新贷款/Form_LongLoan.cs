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
using ERPLibrary;

namespace ERPChess
{
    public partial class Form_LongLoan : LSGOfrmBasement
    {
        public Form_LongLoan()
        {
            InitializeComponent();
            
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            ILSGOfrmTipBox mesBox=new LSGOfrmInforMessageBox(MessageBoxButtons.OKCancel);
            int year = PubVar.year;
            ERPChess.LongLoanList longloanlist = new ERPChess.LongLoanList();
            if (comb_Count.SelectedItem == null)
            {
                mesBox.ShowMessage("请选择贷款额", "提示");
                return;
            }
            if (Convert.ToDouble(comb_Count.SelectedItem.ToString()) > PubVar.closing[PubVar.year-1].Anl_rightsT*2)
            {
                mesBox.ShowMessage("所能贷的款额不能大于上一年的权益的两倍", "提示");
                return;
            }
            if (mesBox.ShowMessage("选择确定办理长期贷款，退出选取消", "提示") == DialogResult.OK)
            {
                
                longloanlist.loanType = LoanType.LongLoan;
                longloanlist.year = PubVar.year;
                longloanlist.longDateTime = "第" + PubVar.year + "年";
                longloanlist.longLoan = "长期贷款（10年）";
                longloanlist.loan.AnnualInterest = 0.066f;
                longloanlist.loan.LoanLimitRate = "上一年决策者权益的两倍";
                longloanlist.loan.YearLimit = 10;
                longloanlist.payOffyear = 10;
                longloanlist.longLoanAmount = Convert.ToDouble(comb_Count.SelectedItem.ToString());
                longloanlist.save = longloanlist.longLoanAmount;
                //2012.12.18正义 现金更新
                PubVar.loanL += longloanlist.longLoanAmount;
                //Program.Forms.frmMain.lbl_Lloan.Text = Math.Round(PubVar.loanL).ToString() + "百万";
                PubVar.Fund += longloanlist.longLoanAmount;
                //Program.Forms.frmMain.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                Program.Forms.frmMain.lbl_Lloan.Text = Math.Round(PubVar.loanL).ToString() + "百万";
                    
                    if (longloanlist.longLoanAmount > 0)
                    {
                        PubVar.t_diaoyong = 8;
                        Program.Forms.frmMain.p_jinbi.Left = 410;
                        Program.Forms.frmMain.p_jinbi.Top = 20;
                        Program.Forms.frmMain.timer2.Interval = 100;
                        Program.Forms.frmMain.timer2.Start();
 
                    }
                

                    PubVar.lloan.year = PubVar.year;
                    PubVar.lloan.longDateTime = "第" + PubVar.year + "年";
                    PubVar.lloan.longLoan = "长期贷款（10年）";
                    PubVar.lloan.loan.AnnualInterest = 0.066f;
                    PubVar.lloan.loan.LoanLimitRate = "上一年决策者权益的两倍";
                    PubVar.lloan.loan.YearLimit = 10;
                    PubVar.lloan.longLoanAmount = Convert.ToDouble(comb_Count.SelectedItem.ToString());
                
                PubVar.longloanlist.Add(longloanlist);
                ///长贷刷新

                double[] a = new double[11];
                for (int i = 0; i < 11; i++)
                    a[i] = 0;
                for (int i = 1; i < 11; i++)
                    for (int j = 0; j < PubVar.longloanlist.Count; j++)
                    {
                        if (PubVar.longloanlist[j].payOffyear == i)
                            a[i] += PubVar.longloanlist[j].save;

                    }
                Program.Forms.frmMain.label1.Text = Math.Round(a[1]).ToString();
                Program.Forms.frmMain.label2.Text = Math.Round(a[2]).ToString();
                Program.Forms.frmMain.label3.Text = Math.Round(a[3]).ToString();
                Program.Forms.frmMain.label4.Text = Math.Round(a[4]).ToString();
                Program.Forms.frmMain.label5.Text = Math.Round(a[5]).ToString();
                Program.Forms.frmMain.label6.Text = Math.Round(a[6]).ToString();
                Program.Forms.frmMain.label7.Text = Math.Round(a[7]).ToString();
                Program.Forms.frmMain.label8.Text = Math.Round(a[8]).ToString();
                Program.Forms.frmMain.label9.Text = Math.Round(a[9]).ToString();
                Program.Forms.frmMain.label10.Text = Math.Round(a[10]).ToString();

                this.Close();//当comb_LoanType.SelectedIndex没选中为何会窗体为何不关闭？
                //Form_SLoan frm = new Form_SLoan();
                //frm.ShowDialog();
            }       
        }

        private void Form_LongLoan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            lab_LoandateTime.Text = PubVar.year.ToString();
            lab_rights.Text = (PubVar.closing[PubVar.year-1].Anl_rightsT).ToString();
            if (PubVar.closing[PubVar.year - 1].Anl_rightsT * 2 - PubVar.loanL < 20)
            {
                btn_ok.Text = "无法贷款";
                btn_ok.Enabled = false;
            }
            lab_MaxLoan.Text = Math.Round(PubVar.closing[PubVar.year-1].Anl_rightsT*2-PubVar.loanL).ToString();
            for (int i = 1; i <= Convert.ToDouble(lab_MaxLoan.Text)/20;i++ )
            {
                comb_Count.Items.Add((i * 20).ToString());
            }
        }

        private void Form_LongLoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_SLoan frm = new Form_SLoan();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ERPChess.LongLoanList longloanlist = new ERPChess.LongLoanList();
            longloanlist.loanType = LoanType.LongLoan;
            longloanlist.year = PubVar.year;
            longloanlist.longDateTime = "第" + PubVar.year + "年";
            longloanlist.longLoan = "长期贷款（10年）";
            longloanlist.loan.AnnualInterest = 0.066f;
            longloanlist.loan.LoanLimitRate = "上一年决策者权益的两倍";
            longloanlist.loan.YearLimit = 10;
            longloanlist.payOffyear = 10;
            longloanlist.longLoanAmount = 0;
            longloanlist.save = longloanlist.longLoanAmount;
            //2012.12.18正义 现金更新
            PubVar.Fund += longloanlist.longLoanAmount;
            PubVar.loanL += longloanlist.longLoanAmount;

            PubVar.lloan.year = PubVar.year;
            PubVar.lloan.longDateTime = "第" + PubVar.year + "年";
            PubVar.lloan.longLoan = "长期贷款（10年）";
            PubVar.lloan.loan.AnnualInterest = 0.066f;
            PubVar.lloan.loan.LoanLimitRate = "上一年决策者权益的两倍";
            PubVar.lloan.loan.YearLimit = 10;
            PubVar.lloan.longLoanAmount = 0;

            PubVar.longloanlist.Add(longloanlist);
            
            this.Close();
            //this.Visible = false;
            //Form_SLoan frm = new Form_SLoan();
            //frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
