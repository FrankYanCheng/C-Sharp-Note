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
    public partial class FrmCommiteProduct : LSGOfrmBasement
    {
        
        public FrmCommiteProduct(frmMain parent)
        {
            ///初始化每年的售电收入为0；
            PubVar.EleBidincome = 0;
            InitializeComponent();
            par = parent;
           
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
        double raccount = 0;
        double shouru = 0;//订单总额
        private void btnNext_Click(object sender, EventArgs e)
        {
            //double leftE = Double.Parse(lblLeftINSN.Text) + Double.Parse(lblLeftNOSN.Text);
            ILSGOfrmTipBox messagebox = new LSGOfrmInforMessageBox(MessageBoxButtons.OKCancel);
            
            Pubfun.UpdataCoalBill(PubVar.coalUse);
            PubVar.DdZl = 0;
            //PubVar.temp = 0;
            
            if (PubVar.BidEleResult[0].IsCommite != true || PubVar.BidEleResult[1].IsCommite != true || PubVar.BidEleResult[2].IsCommite != true)
            {
                MessageBox.Show("您的基础电量订单还没有交货，请返回并完成交货！");
                return;
            }
            for (int i =PubVar.BidEleResult.Count-1; i >=0 ; i--)
            {
                if (PubVar.BidEleResult[i].IsCommite)
                {
                    if (PubVar.BidEleResult[i].YearLimit != 0)//将有账期的收入加入应收账款
                        raccount += PubVar.BidEleResult[i].Sum;
                    shouru += PubVar.BidEleResult[i].Sum;
                    PubVar.DdZl += PubVar.BidEleResult[i].Amount;
                    Account account = new Account();
                    account.Fund = PubVar.BidEleResult[i].Sum;
                    account.YearLimit = PubVar.BidEleResult[i].YearLimit;
                    if (PubVar.BidEleResult[i].YearLimit != 0)//将有账期的收入加入应收账款
                        Program.factory.RAccount.Add(account);
                    UpdateAccount(PubVar.RaccountList, PubVar.BidEleResult[i].YearLimit, PubVar.BidEleResult[i].Sum);
                }
                else
                {
                    PubVar.BidEleResult.RemoveAt(i);
                    PubVar.temp += 10;
                    PubVar.Fund -= 10;
                }
            }
            double [] a=new double[5];
            for (int i = 0; i < 5; i++)
                a[i] = 0;
            for (int i = 0; i < 5; i++)
            {
                //for (int j = 0; j < PubVar.BidEleResult.Count; j++)
                //{
                    a[i] = PubVar.RaccountList[i];
                    //if (PubVar.BidEleResult[j].YearLimit == i)
                    //    a[i] += PubVar.BidEleResult[j].Sum;
                    
                //}
 
            }
            
            par.lbl_Raccount1.Text = Math.Round(a[0]).ToString() + "百万";
            par.lbl_Raccount2.Text = Math.Round(a[1]).ToString() + "百万";
            par.lbl_Raccount3.Text = Math.Round(a[2]).ToString() + "百万";
            par.lbl_Raccount4.Text = Math.Round(a[3]).ToString() + "百万";
            PubVar.t_diaoyong = 10;
            par.p_jinbi.Left = 260;
            par.p_jinbi.Top = 400;
            par.timer2.Interval = 100;
            par.timer2.Start();
            PubVar.accountR += raccount;
            this.Close();
        }

        private void FrmCommiteProduct_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.dataGridViewX1.RowCount = PubVar.BidEleResult.Count;
            for (int i = 0; i < PubVar.BidEleResult.Count; i++)
            {
                this.dataGridViewX1.Rows[i].Cells[0].Value = (i+1).ToString();
                this.dataGridViewX1.Rows[i].Cells[4].Value = PubVar.BidEleResult[i].YearLimit;
                this.dataGridViewX1.Rows[i].Cells[3].Value = Math.Round(PubVar.BidEleResult[i].Sum);
                this.dataGridViewX1.Rows[i].Cells[2].Value = PubVar.BidEleResult[i].Amount;
                this.dataGridViewX1.Rows[i].Cells[1].Value = PubVar.BidEleResult[i].Price;
                
                this.dataGridViewX1.Rows[i].Cells[5].Value = "未提交";
                //this.dataGridViewX1.Rows[i].Cells[6].Selected = true;
                this.comboBoxEx1.Items.Add(new ComboBoxItem(i.ToString(), (i + 1).ToString()));
            }
        }

        private void btnCommittee_Click(object sender, EventArgs e)
        {
            double dlys = PubVar.ddys;
            if (select == -1)
            {
                ILSGOfrmTipBox message = new LSGOfrmInforMessageBox();
                message.ShowMessage("请先选择订单", "错误提示");
                return;
            }
            this.comboBoxEx1.Text = "";
            if (PubVar.BidEleResult[select].IsCertificate)
            {
                if (PubVar.BidEleResult[select].CertificateType == CerficateType.ISO14000)
                {
                    if (PubVar.IsHaveISO14000 == false)
                    {
                        MessageBox.Show("此订单需要ISO1400资格");
                        return;
                    }
                }
                if (PubVar.BidEleResult[select].CertificateType == CerficateType.ISO9000)
                {
                    if (PubVar.IsHaveISO9000 == false)
                    {
                        MessageBox.Show("此订单需要ISO900资格");
                        return;
                    }
                }
                if (PubVar.BidEleResult[select].CertificateType == CerficateType.ISO18000)
                {
                    if (PubVar.IsHaveISO18000 == false)
                    {
                        MessageBox.Show("此订单需要ISO18000资格");
                        return;
                    }
                }
                if (PubVar.BidEleResult[select].CertificateType == CerficateType.Security)
                {
                    if (PubVar.IsHaveSecurity == false)
                    {
                        MessageBox.Show("此订单需要安全认证资格");
                        return;
                    }
                }
            }
            if (dlys < PubVar.BidEleResult[select].Amount)
            {
                MessageBox.Show("您的电网已经不足以向客户提交足够电量，由于违约，您将被罚款10百万元！");
                //PubVar.BidEleResult.RemoveAt(select);
                return;
 
            }
            
            
            //账期和售电收入什么关系
            PubVar.BidEleResult[select].IsCommite = true;
            PubVar.EleBidincome += PubVar.BidEleResult[select].Sum;
            dlys -= PubVar.BidEleResult[select].Amount;//增加在交货过程中出现的无法完成订单的惩罚情况
            if(PubVar.BidEleResult[select].YearLimit==0)//现金增加
            PubVar.Fund += PubVar.BidEleResult[select].Sum;
            this.dataGridViewX1.Rows[select].Cells[5].Value = "已提交";
            this.comboBoxEx1.Items.RemoveAt(sindex);
            select = -1;
            this.Refresh();
        }
        private int select=-1;
        private int sindex;
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sindex = this.comboBoxEx1.SelectedIndex;
            select = Int32.Parse(this.comboBoxEx1.Items[sindex].ToString().Trim()) - 1;
        }

        

    }
}
