﻿ using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ERPLibrary;

namespace ERPChess
{
    public partial class frmPaccount : Office2007Form
    {
        public frmPaccount(frmMain parent)
        {
            InitializeComponent();
            par = parent;
        }
        frmMain par;
        private void frmPaccount_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            dgv.Rows[0].Cells[0].Value = "单位（百万元）";
            dgv.Rows[0].Cells[1].Value = Math.Round(PubVar.PaccountList[0]);
            dgv.Rows[0].Cells[2].Value = Math.Round(PubVar.PaccountList[1]);
            dgv.Rows[0].Cells[3].Value = Math.Round(PubVar.PaccountList[2]);
            dgv.Rows[0].Cells[4].Value = Math.Round(PubVar.PaccountList[3]);
            dgv.Rows[0].Cells[5].Value = Math.Round(PubVar.PaccountList[4]);
            Account account = new Account();
            PubVar.outPay += account.UpdateAccount(Program.factory.PAccount, AccountType.Pay, ref PubVar.Fund);
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                PubVar.PaccountList[i] = 0;
            }
            if (Program.factory.PAccount != null)
            {
                for (int k = Program.factory.PAccount.Count-1; k >= 0; k--)
                {
                    if (Program.factory.PAccount[k].YearLimit == 1)
                    {
                        PubVar.PaccountList[0] += Program.factory.PAccount[k].Fund;
                    }
                    else if (Program.factory.PAccount[k].YearLimit == 2)
                    {
                        PubVar.PaccountList[1] += Program.factory.PAccount[k].Fund;
                    }
                    else if (Program.factory.PAccount[k].YearLimit == 3)
                    {
                        PubVar.PaccountList[2] += Program.factory.PAccount[k].Fund;
                    }
                    else if (Program.factory.PAccount[k].YearLimit == 4)
                    {
                        PubVar.PaccountList[3] += Program.factory.PAccount[k].Fund;
                    }
                }
            }
            dgv2.Rows[0].Cells[0].Value = "单位（百万元）";
            dgv2.Rows[0].Cells[1].Value = Math.Round(PubVar.PaccountList[0]);
            dgv2.Rows[0].Cells[2].Value = Math.Round(PubVar.PaccountList[1]);
            dgv2.Rows[0].Cells[3].Value = Math.Round(PubVar.PaccountList[2]);
            dgv2.Rows[0].Cells[4].Value = Math.Round(PubVar.PaccountList[3]);
            dgv2.Rows[0].Cells[5].Value = Math.Round(PubVar.PaccountList[4]);
            double cash = 0;
            for (int i = 0; i < 5; i++)
            {
                cash += PubVar.PaccountList[i];
            }
            PubVar.accountP = Math.Round(cash);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            PubVar.t_diaoyong = 5;
            par.timer2.Interval = 100;
            par.timer2.Start();
            

            this.Close();
        }

        private void frmPaccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PubVar.Fund < 0)
            {
                GameOver.gameOver();
            }
        }
    }
}
