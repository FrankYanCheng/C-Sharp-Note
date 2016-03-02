﻿using System;
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
    public partial class Form_ShortLoan : LSGOfrmBasement
    {
        public Form_ShortLoan()
        {
            InitializeComponent();
            
        }
       
        private void but_Next_Click(object sender, EventArgs e)
        {
            ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox(MessageBoxButtons.OKCancel);
            if (comb_count.SelectedItem == null)
            {
                mesbox.ShowMessage("请选择贷款额","提示");
                return;
            }
            if (Convert.ToDouble(comb_count.SelectedItem.ToString()) > PubVar.closing[PubVar.year-1].Anl_rightsT * 2)
            {
                mesbox.ShowMessage("所能贷的款额不能大于上一年的权益的两倍", "提示");
                return;
            }
            if (mesbox.ShowMessage("选择确认办理短期贷款", "提示") == DialogResult.OK)
            {
                PubVar.sloan.shortDateTime = "第" + PubVar.year + "年";
                PubVar.sloan.shortLoan = "短期贷款（1年）";
                PubVar.sloan.shortLoanAmount = Convert.ToDouble(comb_count.SelectedItem.ToString());
                PubVar.sloan.loan.AnnualInterest = 0.06f;
                PubVar.sloan.loan.LoanLimitRate = "上一年决策者权益的两倍";
                PubVar.sloan.loan.YearLimit = 1;
                PubVar.Fund += Convert.ToDouble(comb_count.SelectedItem.ToString());
                PubVar.loanS += Convert.ToDouble(comb_count.SelectedItem.ToString());
                Program.Forms.frmMain.lbl_Sloan.Text = PubVar.loanS.ToString() + "百万";
                if (PubVar.loanS > 0)
                {
                    PubVar.t_diaoyong = 9;
                    Program.Forms.frmMain.p_jinbi.Left = 410;
                    Program.Forms.frmMain.p_jinbi.Top = 130;
                    Program.Forms.frmMain.timer2.Interval = 100;
                    Program.Forms.frmMain.timer2.Start();

                }



                this.Close();
            }
        }

        private void Form_ShortLoan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            lbl_rights.Text = PubVar.closing[PubVar.year - 1].Anl_rightsT.ToString();
            lab_LoandateTime.Text = PubVar.year.ToString();
            lab_MaxLoan.Text = (PubVar.closing[PubVar.year-1].Anl_rightsT * 2).ToString();
            for (int i = 1; i <= Convert.ToDouble(lbl_rights.Text) / 10; i++)
            {
                comb_count.Items.Add((i * 20).ToString());
            }
        }
    }
}
