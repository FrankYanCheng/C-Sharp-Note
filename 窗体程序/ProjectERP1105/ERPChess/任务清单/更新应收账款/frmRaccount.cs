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

namespace ERPChess
{
    public partial class frmRaccount : Office2007Form
    {
        public frmRaccount(frmMain parent)
        {
            InitializeComponent();
            par = parent;
        }
        frmMain par;
        private void btn_OK_Click(object sender, EventArgs e)
        {
            PubVar.t_diaoyong = 4;
            par.timer2.Interval = 100;
            par.timer2.Start();
            
            this.Close();
        }
        private void frmRaccount_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            dgv.Rows[0].Cells[0].Value = "单位（百万元）";
            dgv.Rows[0].Cells[1].Value = PubVar.RaccountList[0];
            dgv.Rows[0].Cells[2].Value = PubVar.RaccountList[1];
            dgv.Rows[0].Cells[3].Value = PubVar.RaccountList[2];
            dgv.Rows[0].Cells[4].Value = PubVar.RaccountList[3];
            dgv.Rows[0].Cells[5].Value = PubVar.RaccountList[4];
            Account account = new Account();
            PubVar.inCome+= account.UpdateAccount(Program.factory.RAccount, AccountType.Received, ref PubVar.Fund);
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                PubVar.RaccountList[i] = 0;
            }
            if (Program.factory.RAccount != null)
            {
                for (int k = Program.factory.RAccount.Count-1; k >= 0; k--)
                {
                    if (Program.factory.RAccount[k].YearLimit == 1)
                    {
                        PubVar.RaccountList[0] += Program.factory.RAccount[k].Fund;
                    }
                    else if (Program.factory.RAccount[k].YearLimit == 2)
                    {
                        PubVar.RaccountList[1] += Program.factory.RAccount[k].Fund;
                    }
                    else if (Program.factory.RAccount[k].YearLimit == 3)
                    {
                        PubVar.RaccountList[2] += Program.factory.RAccount[k].Fund;
                    }
                    else if (Program.factory.RAccount[k].YearLimit == 4)
                    {
                        PubVar.RaccountList[3] += Program.factory.RAccount[k].Fund;
                    }
                }
            }
            dgv2.Rows[0].Cells[0].Value = "单位（百万元）";
            dgv2.Rows[0].Cells[1].Value = PubVar.RaccountList[0];
            dgv2.Rows[0].Cells[2].Value = PubVar.RaccountList[1];
            dgv2.Rows[0].Cells[3].Value = PubVar.RaccountList[2];
            dgv2.Rows[0].Cells[4].Value = PubVar.RaccountList[3];
            dgv2.Rows[0].Cells[5].Value = PubVar.RaccountList[4];
            double cash = 0;
            for (int i = 0; i < 5; i++)
            {
                cash += PubVar.RaccountList[i];
            }
            PubVar.accountR = cash;
        }
    }
}
