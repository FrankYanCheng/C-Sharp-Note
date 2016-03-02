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
    public partial class Form_BuyConference : LSGOfrmBasement
    {
        public Form_BuyConference()
        {
            InitializeComponent();
        }
        ILSGOfrmTipBox mesBox = new LSGOfrmInforMessageBox();
        private void buttonX1_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        private void Form_BuyConference_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkBoxX1.Checked != false)
            {
                PubVar.SplashType = 1;
                Program.factory.Bill.BillType = BillType.Shopping;
                PubVar.count = 0;
                PubVar.countth = 0;
                PubVar.billThisYear.Clear();
                BillAdd billAdd;
                //初始化订单数
                for (int i = 0; i < PubVar.CoalBillAdd.Count; i++)
                {
                    if (PubVar.CoalBillAdd[i].year == PubVar.year)
                    {
                        billAdd = new BillAdd();
                        billAdd.amount = PubVar.CoalBillAdd[i].amount;
                        billAdd.billNum = PubVar.CoalBillAdd[i].billNum;
                        billAdd.yearLimit = PubVar.CoalBillAdd[i].yearLimit;
                        PubVar.billThisYear.Add(billAdd);
                        PubVar.count++;
                    }
                }
                string order = MessageType.ComEleFrm.ToString() + "//" + MessageType.ReadyCom.ToString() + "//" + PubVar.PlayerName;
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
                Program.Forms.frmSplash = new frmSplash();
                Program.Forms.frmSplash.Show();
            }
        }

        private void Form_BuyConference_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBoxX1.Checked == false)
            {
                mesBox.ShowMessage("请认真阅读竞价规则和注意事项！", "提示");
                Form_BuyConference frm = new Form_BuyConference();
                frm.Show();
            }
        }
    }
}
