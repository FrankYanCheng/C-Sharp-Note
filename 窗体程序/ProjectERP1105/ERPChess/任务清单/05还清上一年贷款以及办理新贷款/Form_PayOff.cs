using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ERPLibrary;
using LSGO.PresentationLayer;

namespace ERPChess
{
    public partial class Form_PayOff : LSGOfrmBasement
    {
        public Form_PayOff()
        {
            InitializeComponent();
        }
        
        double c4 = 0, c5 = 0,c6=0,c7=0;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            PubVar.Fund = PubVar.Fund - PubVar.L_ljj - c6 - c7;
            Program.Forms.frmMain.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万"; ;
            PubVar.t_diaoyong = 6;
            Program.Forms.frmMain.timer2.Interval = 100;
            Program.Forms.frmMain.timer2.Start();

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
            //PubVar.Fund = PubVar.Fund  - c6 - c7;
            
            //par.timer3.Interval = 100;
            //par.timer3.Start();

            
            
            this.Visible = false;
            
            


            if (PubVar.Fund >= 0)
            {
                
                //frmLoan frm = new frmLoan();
                //frm.ShowDialog();
            }
           /* else
            {
                GameOver.gameOver();
            }*/
            this.Close();
        }

        private void Form_PayOff_Load(object sender, EventArgs e)
        {
            PubVar.L_ljj = 0;
            this.ControlBox = false;
            PubVar.AnnualInterestS = 0;
            dgvX_1.RowCount = 15;
            //double c4 = 0, c5 = 0;
             if (PubVar.longloanlist != null)
            {
                for (int i = PubVar.longloanlist.Count - 1; i >= 0; i--)
                {
                    if (PubVar.longloanlist[i].longLoanAmount != 0)
                    {
                        PubVar.longloanlist[i].payOffyear--;
                        dgvX_1.Rows[i].Cells[0].Value = "有";
                        dgvX_1.Rows[i].Cells[1].Value = PubVar.longloanlist[i].longDateTime;
                        dgvX_1.Rows[i].Cells[2].Value = PubVar.longloanlist[i].longLoan;
                        dgvX_1.Rows[i].Cells[3].Value = PubVar.longloanlist[i].longLoanAmount;
                        
                        //c4 = (PubVar.longloanlist[i].longLoanAmount - PubVar.longloanlist[i].payadd) * 0.066;//有错误
                        c4 = (PubVar.longloanlist[i].save) * 0.066;
                        dgvX_1.Rows[i].Cells[4].Value = Math.Round(c4);
                        PubVar.longloanlist[i].save -= PubVar.longloanlist[i].longLoanAmount / PubVar.longloanlist[i].loan.YearLimit;
                        dgvX_1.Rows[i].Cells[5].Value = Math.Round(PubVar.longloanlist[i].longLoanAmount / PubVar.longloanlist[i].loan.YearLimit);
                        c5 = PubVar.longloanlist[i].longLoanAmount / PubVar.longloanlist[i].loan.YearLimit;
                        
                        PubVar.longloanlist[i].payadd += (c4 + c5);
                        PubVar.longloanlist[i].AnnualInterest = c4;
                        //PubVar.Fund = PubVar.Fund - c4 - c5;
                        PubVar.L_ljj += c4 + c5;
                        if (PubVar.longloanlist[i].payOffyear == 0)
                        {
                            PubVar.longloanlist.Remove(PubVar.longloanlist[i]);
                            PubVar.loanL -= PubVar.longloanlist[i].longLoanAmount;
                        }
                        else
                        {
                            PubVar.loanL -= PubVar.longloanlist[i].longLoanAmount / PubVar.longloanlist[i].loan.YearLimit;
                        }
                        
 
                    }
                    
                   
                }
            }
            else
            {
                dgvX_1.Rows[0].Cells[0].Value = "无";
            }
             if (PubVar.loanS == 0)
            {
                dgvX_2.Rows[0].Cells[0].Value = "无";
            }
            else
            {
                dgvX_2.Rows[0].Cells[0].Value = "有";
                dgvX_2.Rows[0].Cells[1].Value = PubVar.sloan.shortDateTime;
                dgvX_2.Rows[0].Cells[2].Value = PubVar.sloan.shortLoan;
                dgvX_2.Rows[0].Cells[3].Value = PubVar.sloan.shortLoanAmount;
                dgvX_2.Rows[0].Cells[4].Value = Math.Round(PubVar.sloan.shortLoanAmount*0.06);
                c6 = PubVar.sloan.shortLoanAmount * 0.06;
                dgvX_2.Rows[0].Cells[5].Value = PubVar.sloan.shortLoanAmount;
                c7 = PubVar.sloan.shortLoanAmount;
                PubVar.AnnualInterestS = PubVar.sloan.shortLoanAmount * 0.06;
                //PubVar.Fund = PubVar.Fund - c6 - c7;
                PubVar.sloan = new ShortLoanList();
                PubVar.loanS = 0;
                 
            }
        }

        private void Form_PayOff_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PubVar.Fund < 0)
            {
                string order = MessageType.totalPoint.ToString() + "//" + PubVar.PlayerName + "//" + GameOver.total_Points().ToString();
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
                GameOver.gameOver();
            }
        }
    }
}
