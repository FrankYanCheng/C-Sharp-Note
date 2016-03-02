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
    public partial class frmLoan : LSGOfrmBasement
    {
        public frmLoan()
        {
            InitializeComponent();
        }
        
        private void btn_OK_Click(object sender, EventArgs e)
        {
            ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
            if (checkBoxX1.Checked == false)
            {
                mesbox.ShowMessage("请认真阅读办理贷款规则", "提示");
                return;
            }
            //this.Visible = false; 
            //Form_LongLoan frm = new Form_LongLoan();
            //frm.ShowDialog();
            this.Close();
            Form_LongLoan frm = new Form_LongLoan();
            frm.ShowDialog();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)

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
            Form_SLoan frm = new Form_SLoan();
            frm.ShowDialog();
        }

        private void frmLoan_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmLoan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
