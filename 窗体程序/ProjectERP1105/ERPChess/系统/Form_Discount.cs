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
    public partial class Form_Discount : Office2007Form
    {
        public Form_Discount()
        {
            InitializeComponent();
            slider.Maximum = ((int)(PubVar.RaccountList[0] + PubVar.RaccountList[1] + PubVar.RaccountList[2] + PubVar.RaccountList[3] + PubVar.RaccountList[4])/8)*7;
        }

        private double totalAccount = 0;
        ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
        private int lastValue = 0;
        private void Form_Discount_Load(object sender, EventArgs e)
        {
            dgv.Rows[0].Cells[0].Value = "单位（百万元）";

            dgv.Rows[0].Cells[1].Value = PubVar.RaccountList[0];
            dgv.Rows[0].Cells[2].Value = PubVar.RaccountList[1];
            dgv.Rows[0].Cells[3].Value = PubVar.RaccountList[2];
            dgv.Rows[0].Cells[4].Value = PubVar.RaccountList[3];
            dgv.Rows[0].Cells[5].Value = PubVar.RaccountList[4];
            for (int i = 0; i < 5; i++)
            {
                totalAccount += PubVar.RaccountList[i];
            }
            if (totalAccount == 0)
            {
                text_Damount.Enabled = false;
                text_Dcost.Enabled = false;
                slider.Enabled = false;
            }
        }

        private void slider_ValueChanged(object sender, EventArgs e)
        {
            if (slider.Value % 7 != 0)
            {
                if (lastValue < slider.Value)
                {
                    lastValue = slider.Value;
                    slider.Value += 1;
                }
                else if (lastValue > slider.Value)
                {
                    lastValue = slider.Value;
                    slider.Value -= 1;
                }
            }
            lastValue = slider.Value;
            text_Damount.Text = slider.Value.ToString();
            text_Dcost.Text = (slider.Value / 7).ToString();
            text_Damount.Refresh();
            text_Dcost.Refresh();
        }
        private delegate void cash_refresh(double fund);
        private void newCash(double fund)
        {
            if (Program.Forms.frmMain.lbl_Cash.InvokeRequired)
            {
                cash_refresh cash = newCash;
                Program.Forms.frmMain.lbl_Cash.Invoke(cash);
            }
            else
            {
                Program.Forms.frmMain.lbl_Cash.Text = fund.ToString();
                Program.Forms.frmMain.lbl_Cash.Refresh();
            }
        }
        private void newRaccount(double Raccount)
        {
            if (Program.Forms.frmMain.lbl_Raccount4.InvokeRequired)
            {
                cash_refresh account = newRaccount;
                Program.Forms.frmMain.lbl_Raccount4.Invoke(account);
            }
            else
            {
                Program.Forms.frmMain.lbl_Raccount4.Text = Raccount.ToString()+"百万";
                Program.Forms.frmMain.lbl_Raccount4.Refresh();
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(text_Damount.Text);
            Program.factory.RAccount.Clear();
            Account account;
            if (temp*8/7 == PubVar.RaccountList[4] + PubVar.RaccountList[3] + PubVar.RaccountList[2] + PubVar.RaccountList[1] + PubVar.RaccountList[0])
            {
                PubVar.RaccountList[4] = 0;
                PubVar.RaccountList[3] = 0;
                PubVar.RaccountList[2] = 0;
                PubVar.RaccountList[1] = 0;
                PubVar.RaccountList[0] = 0;
                PubVar.Fund += temp;
            }
            else if (temp*8/7 > PubVar.RaccountList[4] + PubVar.RaccountList[3] + PubVar.RaccountList[2] + PubVar.RaccountList[1])
            {
                PubVar.RaccountList[0] = PubVar.RaccountList[0] - (temp*8/7 - (PubVar.RaccountList[4] + PubVar.RaccountList[3] + PubVar.RaccountList[2] + PubVar.RaccountList[1]));
                PubVar.RaccountList[4] = 0;
                PubVar.RaccountList[3] = 0;
                PubVar.RaccountList[2] = 0;
                PubVar.RaccountList[1] = 0;
                PubVar.Fund += temp;
            }
            else if (temp * 8 / 7 > PubVar.RaccountList[4] + PubVar.RaccountList[3] + PubVar.RaccountList[2])
            {
                PubVar.RaccountList[1] = PubVar.RaccountList[1] - (temp * 8 / 7 - (PubVar.RaccountList[4] + PubVar.RaccountList[3] + PubVar.RaccountList[2]));
                PubVar.RaccountList[4] = 0;
                PubVar.RaccountList[3] = 0;
                PubVar.RaccountList[2] = 0;
                PubVar.Fund += temp;
            }
            else if (temp * 8 / 7 > PubVar.RaccountList[4] + PubVar.RaccountList[3])
            {
                PubVar.RaccountList[2] = PubVar.RaccountList[2] - (temp * 8 / 7 - (PubVar.RaccountList[4] + PubVar.RaccountList[3]));
                PubVar.RaccountList[4] = 0;
                PubVar.RaccountList[3] = 0;
                PubVar.Fund += temp;
            }
            else if (temp * 8 / 7 > PubVar.RaccountList[4])
            {
                PubVar.RaccountList[3] = PubVar.RaccountList[3] - (temp * 8 / 7 - (PubVar.RaccountList[4]));
                PubVar.RaccountList[4] = 0;
                PubVar.Fund += temp;
            }
            else if (temp * 8 / 7 < PubVar.RaccountList[4])
            {
                PubVar.RaccountList[4] = PubVar.RaccountList[4] - temp * 8 / 7;
                PubVar.Fund += temp;
            }
            newCash(PubVar.Fund);
            newRaccount(PubVar.RaccountList[0] + PubVar.RaccountList[1] + PubVar.RaccountList[2] + PubVar.RaccountList[3] + PubVar.RaccountList[4]);
            PubVar.accountR = PubVar.RaccountList[0] + PubVar.RaccountList[1] + PubVar.RaccountList[2] + PubVar.RaccountList[3] + PubVar.RaccountList[4];

            #region//重新分配Program.factory.RAccount
            account = new Account();
            account.YearLimit = 1;
            account.Fund = PubVar.RaccountList[0];
            Program.factory.RAccount.Add(account);

            account = new Account();
            account.YearLimit = 2;
            account.Fund = PubVar.RaccountList[1];
            Program.factory.RAccount.Add(account);

            account = new Account();
            account.YearLimit = 3;
            account.Fund = PubVar.RaccountList[2];
            Program.factory.RAccount.Add(account);

            account = new Account();
            account.YearLimit = 4;
            account.Fund = PubVar.RaccountList[3];
            Program.factory.RAccount.Add(account);

            account = new Account();
            account.YearLimit = 5;
            account.Fund = PubVar.RaccountList[4];
            Program.factory.RAccount.Add(account);
            #endregion
            //贴现费用的记录，包括手续费和所得的现金
            PubVar.discount += temp / 7;
            this.Close();
        }

        //private void text_Damount_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double temp = Convert.ToDouble(text_Damount.Text);
        //        if (temp > slider.Maximum)
        //        {
        //            text_Damount.Text = slider.Maximum.ToString();
        //            text_Dcost.Text = (temp / 7).ToString();
        //            slider.Value = 100;
        //        }
        //        else if (temp < 0)
        //        {
        //            text_Damount.Text = "0";
        //            text_Dcost.Text = "0";
        //            slider.Value = 0;
        //        }
        //        else
        //        {
        //            slider.Value = (int)Math.Round(temp * 100 / slider.Maximum);
        //        }
        //        slider.Refresh();
        //    }
        //    catch
        //    {
        //        mesbox.ShowMessage("贴现金额框仅能输入7的倍数的数字","系统提示");
        //    }
        //}

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
