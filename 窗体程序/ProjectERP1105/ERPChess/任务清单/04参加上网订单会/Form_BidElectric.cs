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
    public partial class Form_BidElectric : LSGOfrmBasement
    {
        public Form_BidElectric()
        {
            InitializeComponent();
        }
        ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == false)
            {
                mesbox.ShowMessage("请仔细阅读竞价规则和注意事项", "提示");
                return;
            }
            this.Close();
        }

        private void Form_BidElectric_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkBoxX1.Checked == true)
            {
                PubVar.SplashType = 1;
                Program.factory.Bill.BillType = BillType.Bid;
                PubVar.count = 0;
                PubVar.countth = 0;
                PubVar.billThisYear.Clear();
                PubVar.RbillThisYear.Clear();
                BillAdd billAdd;
                //初始化订单数
                for (int i = 0; i < PubVar.ComEleBillAdd.Count; i++)
                {
                    if (PubVar.ComEleBillAdd[i].year == PubVar.year)
                    {
                        billAdd = new BillAdd();
                        billAdd.amount = PubVar.ComEleBillAdd[i].amount;
                        billAdd.billNum = PubVar.ComEleBillAdd[i].billNum;
                        billAdd.yearLimit = PubVar.ComEleBillAdd[i].yearLimit;
                        billAdd.isNitric = PubVar.ComEleBillAdd[i].isNitric;
                        billAdd.isISO = PubVar.ComEleBillAdd[i].isISO;
                        PubVar.billThisYear.Add(billAdd);
                        PubVar.count++;
                    }
                }
                for (int i = 0; i < PubVar.CapEleBillAdd.Count; i++)
                {
                    if (PubVar.CapEleBillAdd[i].year == PubVar.year)
                    {
                        billAdd = new BillAdd();
                        billAdd.amount = PubVar.CapEleBillAdd[i].amount;
                        billAdd.billNum = PubVar.CapEleBillAdd[i].billNum;
                        billAdd.yearLimit = PubVar.CapEleBillAdd[i].yearLimit;
                        billAdd.price = PubVar.CapEleBillAdd[i].price;
                        billAdd.sum = PubVar.CapEleBillAdd[i].sum;
                        PubVar.RbillThisYear.Add(billAdd);

                        Bill bill = new Bill();
                        bill.Amount = billAdd.amount;
                        bill.BillNum = billAdd.billNum;
                        bill.YearLimit = billAdd.yearLimit;
                        bill.Price = billAdd.price;
                        bill.Sum = billAdd.sum;
                        PubVar.BidEleResult.Add(bill);
                    }
                }
                if (PubVar.RbillThisYear.Count == 0)
                {
                    //string Order = MessageType.ComEleFrm.ToString() + "//" + MessageType.ReadyCom.ToString();
                    //Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));
                    ////PubVar.SplashType = 1;//设置Splash窗体的显示样式，当前为等待其他决策者

                    string order = MessageType.ComEleFrm.ToString() + "//" + MessageType.ReadyCom.ToString() + "//" + PubVar.PlayerName;
                    Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));

                    Program.Forms.frmSplash = new frmSplash();
                    Program.Forms.frmSplash.Show();
                }
                else
                {
                    Program.Forms.frmCapacity = new frmBid_Capacity();
                    Program.Forms.frmCapacity.Show();
                }
            }
        }

        private void Form_BidElectric_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBoxX1.Checked == false)
            {
                mesbox.ShowMessage("请仔细阅读竞价规则和注意事项", "提示");
                Form_BidElectric frm = new Form_BidElectric();
                frm.Show();
            }
        }

        private void Form_BidElectric_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        
    }
}
