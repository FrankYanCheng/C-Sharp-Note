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
//using LSGO.DataLinkLayer.DBControl.MisDBControl;

namespace ERPChess
{
    public partial class MoneyNeedPay : LSGOfrmBasement
    {
        public MoneyNeedPay(frmMain parent)
        {
            par = parent;
            //初始化购电成本
            PubVar.mbc_Ele = 0;
            InitializeComponent();
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.RowCount = PubVar.BidEleResult.Count;
        }

        frmMain par;


        /// <summary>
        /// 根据不同的年限给相应的记录该年限的字段加上账款
        /// </summary>
        /// <param name="yearLimit">年限</param>
        /// <param name="fund">金额总数</param>
        private void UpdateAccount(List<double> list, int yearLimit, double fund)
        {
            if (yearLimit == 1)
            {
                list[0] += fund;
            }
            else if (yearLimit == 2)
            {
                list[1] += fund;
            }
            else if (yearLimit == 3)
            {
                list[2] += fund;
            }
            else if (yearLimit == 4)
            {
                list[3] += fund;
            }
            else if (yearLimit == 5)
            {
                list[4] += fund;
            }
        }









        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            double paccount = 0;
            double goudian = 0;//购电费
            for (int i = 0; i < PubVar.BidEleResult.Count; i++)
            {
                if (PubVar.BidEleResult[i].YearLimit != 0)//将有账期的支出加入应付账款
                    paccount += PubVar.BidEleResult[i].Amount * 0.2564*100;
                Account account = new Account();
                account.Fund = PubVar.BidEleResult[i].Amount * 0.2564*100;
                account.YearLimit = PubVar.BidEleResult[i].YearLimit;
                if (PubVar.BidEleResult[i].YearLimit != 0)//将有账期的支出加入应付账款
                    Program.factory.PAccount.Add(account);
                PubVar.mbc_Ele += PubVar.BidEleResult[i].Amount * 0.2564 * 100;
                if (PubVar.BidEleResult[i].YearLimit == 0)
                {
                    goudian += PubVar.BidEleResult[i].Amount * 0.2564 * 100;
                    PubVar.Fund -= PubVar.BidEleResult[i].Amount * 0.2564 * 100;
                }
                UpdateAccount(PubVar.PaccountList, PubVar.BidEleResult[i].YearLimit, PubVar.BidEleResult[i].Amount * 0.2564 * 100);
            }

            double[] a = new double[5];
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
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            PubVar.t_diaoyong = 11;
            
            par.timer2.Interval = 100;
            par.timer2.Start();
            par.l_goudian.Text = Math.Round(PubVar.mbc_Ele).ToString() + "百万";
            PubVar.accountP += paccount;
           // PubVar.tatolCost += PubVar.ElePay;
            this.Close();
        }

        private void MoneyNeedPay_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            for (int i = 0; i < PubVar.BidEleResult.Count; i++)
            {
                this.dataGridViewX1.Rows[i].Cells[0].Value = (i + 1).ToString();
                this.dataGridViewX1.Rows[i].Cells[4].Value = PubVar.BidEleResult[i].YearLimit;
                this.dataGridViewX1.Rows[i].Cells[3].Value = PubVar.BidEleResult[i].Amount*0.2564*100;
                this.dataGridViewX1.Rows[i].Cells[2].Value = "0.2564";
                this.dataGridViewX1.Rows[i].Cells[1].Value = PubVar.BidEleResult[i].Amount;

                
                
            }
        }
    }
}
