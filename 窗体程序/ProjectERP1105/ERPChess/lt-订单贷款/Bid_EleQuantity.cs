using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.WinForms;
using ERPLibrary;
using LSGO.PresentationLayer;

namespace ERPChess
{
    public partial class Bid_EleQuantity : LSGOfrmBasement
    {
        public Bid_EleQuantity()
        {
            InitializeComponent();
        }
        ILSGOfrmTipBox mesfrm = new LSGOfrmInforMessageBox(MessageBoxButtons.OKCancel);
        ILSGOfrmTipBox mesfrm1 = new LSGOfrmInforMessageBox();
        bool isNitric=false;
        bool isISO=false;
        private delegate void ShowReslut(string str);
        private void ShowBidReslut(string str)
        {
            if (this.rtbInfo.InvokeRequired)
            {
                ShowReslut show = ShowBidReslut;
                this.rtbInfo.Invoke(show, str);
            }
            else
            {
                this.rtbInfo.Text = str;
                this.rtbInfo.Refresh();
            }
        }
       
        /// <summary>
        /// 确定订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">梁添添加 2012-10-12 12：27</param>
        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_UnitPrice.Text == "" && Convert.ToDouble(textBox_UnitPrice.Text) <= 0)
                {
                    mesfrm1.ShowMessage("竞拍价格不能为空或者小于等于0", "提示");
                    return;
                }
                if(PubVar.ddys < Program.factory.Bill.Amount)//电网容量与订单
                {
                    mesfrm1.ShowMessage(" 您的电网已经不能负荷此次的订单，请放弃此次订单。请注意认真计算年的电网容量和订单之间的关系", "提示");
                    return;
                }
                
                if (mesfrm.ShowMessage("选择确认进行竞拍，选择取消退出竞拍", "提示") == DialogResult.OK)
                {
                    PubVar.countth++;
                    if (Program.factory.Bill.BillType == BillType.Bid)
                    {
                        lab_Total1.Text = Math.Round((Convert.ToDouble(textBox_UnitPrice.Text) * 100 * Program.factory.Bill.Amount)).ToString();
                    }
                    else
                    {
                        lab_Total1.Text = Math.Round((Convert.ToDouble(textBox_UnitPrice.Text) / 100 * Program.factory.Bill.Amount)).ToString();
                    }
                    textBox_UnitPrice.Text = (Convert.ToDouble(textBox_UnitPrice.Text)).ToString("#0.000");

                    TempBill();
                    
                    PubVar.TempBill.Price = Convert.ToDouble(textBox_UnitPrice.Text);//订单单价
                    PubVar.TempBill.Sum = Math.Round((Convert.ToDouble(lab_Total1.Text)));//订单总价
                    //PubVar.ddys -= Program.factory.Bill.Amount;//电网负荷约束
                    
                    //PubVar.DdZl += PubVar.TempBill.Amount;//订单总量增加
                    //PubVar.DdZe += PubVar.TempBill.Sum;//订单总额增加
                    timer_time.Stop();
                    string Order = MessageType.ComEleFrm.ToString() + "//" + MessageType.CommitResult.ToString() + "//" + PubVar.PlayerName + "//" + PubVar.TempBill.Price.ToString();
                    Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));
                    btn_Cancel.Enabled = false;
                    btn_OK.Enabled = false;
                } 
            }
            catch
            {
                mesfrm1.ShowMessage("输入有误！", "提示");
            }
        }
        private void TempBill()
        {
            PubVar.TempBill = new Bill();
            PubVar.TempBill.Amount = Convert.ToDouble(lab_Amount1.Text);//需求量
            PubVar.TempBill.BillNum = Program.factory.Bill.BillNum;//订单号
            PubVar.TempBill.BillGroupNum = Convert.ToInt32(lab_Group.Text);//订单组号
            PubVar.TempBill.YearLimit = Convert.ToInt32(lab_PayDay1.Text);//账期
            PubVar.TempBill.IsNitric = isNitric;
            PubVar.TempBill.IsCertificate = isISO;
            PubVar.TempBill.BillType = Program.factory.Bill.BillType;
            PubVar.TempBill.GetTime = PubVar.year;

            if (PubVar.TempBill.BillType == BillType.Bid)
            {
                if (PubVar.TempBill.IsCertificate)
                {
                    string str = lbl_ISO.Text;
                    if (str == "ISO9000")
                    {
                        PubVar.TempBill.CertificateType = CerficateType.ISO9000;
                    }
                    else if (str == "ISO140000")
                    {
                        PubVar.TempBill.CertificateType = CerficateType.ISO14000;
                    }
                    if (str == "ISO18000")
                    {
                        PubVar.TempBill.CertificateType = CerficateType.ISO18000;
                    }
                    else if (str == "Security")
                    {
                        PubVar.TempBill.CertificateType = CerficateType.Security;
                    }
                }
            }
        }
        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            PubVar.countth++;
            timer_time.Stop();
            TempBill();
            string Order = MessageType.ComEleFrm.ToString() + "//" + MessageType.CommitResult.ToString() + "//" + PubVar.PlayerName + "//0";
            Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));
            btn_Cancel.Enabled = false;
            btn_OK.Enabled = false;
            this.textBox_UnitPrice.Enabled = false;
        }
        /// <summary>
        /// 控制时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param></param>
        private void timer_time_Tick(object sender, EventArgs e)
        {
            labelX_time.Text = (Convert.ToInt32(labelX_time.Text) - 1).ToString();
            if (Convert.ToInt32(labelX_time.Text) <= 10)
            {
                timer_color.Start();
            }
            if (Convert.ToInt32(labelX_time.Text) <= 0)
            {
                timer_time.Stop();
                textBox_UnitPrice.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_OK.Enabled = false;
                //mesfrm.ShowMessage("本次竞拍时间到，系统默认放弃该订单，请决策者经行下一次订单竞拍", "提示");
                PubVar.countth++;//单号增加
                TempBill();
                string Order = MessageType.ComEleFrm.ToString() + "//" + MessageType.CommitResult.ToString() + "//" + PubVar.PlayerName + "//0";
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));
            }
            this.Refresh();
        }
        /// <summary>
        /// 控制颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_color_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(labelX_time.Text) <= 0)
                timer_color.Stop();
            Random ran = new Random();
            int r = ran.Next(50, 255);
            int g = ran.Next(50, 255);
            int b = ran.Next(50, 255);
            labelX_time.ForeColor = Color.FromArgb(r, g, b);
        }
        /// <summary>
        /// 加载这个窗体的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bid_EleQuantity_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.factory.Bill.BillType == BillType.Shopping)
                {
                    loadShoppingType();
                }
                billReceive();
                if (PubVar.year == 1)
                    buttonX_Cancel_Click(sender, e);
                timer_time.Start();
                lab_Amount1.Text = Program.factory.Bill.Amount.ToString();
                lab_PayDay1.Text = Program.factory.Bill.YearLimit.ToString();
                lab_Group.Text = Program.factory.Bill.BillGroupNum.ToString();
                lab_BidNum.Text = Program.factory.Bill.BillNum + "/" + PubVar.count.ToString();
                lab_Year.Text = PubVar.year.ToString();

                
                if (PubVar.listBidResult != null)
                    for (int i = 0; i < PubVar.listBidResult.Count; i++)
                    {
                        rtbInfo.Text += PubVar.listBidResult[i];
                    }
            }
            catch (Exception ex)
            {
                mesfrm1.ShowMessage(ex.Message, "提示");
            }
            
        }
        private void billReceive()
        {
            lbl_infor.Text = "";
            Program.factory.Bill.Amount = PubVar.billThisYear[PubVar.countth].amount;
            Program.factory.Bill.YearLimit = PubVar.billThisYear[PubVar.countth].yearLimit;
            Program.factory.Bill.BillGroupNum = 1;
            Program.factory.Bill.BillNum = PubVar.billThisYear[PubVar.countth].billNum;
            isNitric = PubVar.billThisYear[PubVar.countth].isNitric;
            isISO = PubVar.billThisYear[PubVar.countth].isISO;
            if (isISO)
            {
                lbl_ISO.Text = PubVar.billThisYear[PubVar.countth].cerficateType.ToString();
                lbl_ISO.Visible = true;
                string str = lbl_ISO.Text;
                if (str == "ISO9000" && !PubVar.IsHaveISO9000)
                {
                    btn_OK.Enabled = false;
                    lbl_infor.Text = "由于您的条件不符合，您不能参与该订单的竞拍!";
                }
                else if (str == "ISO14000" && !PubVar.IsHaveISO14000)
                {
                    btn_OK.Enabled = false;
                    lbl_infor.Text = "由于您的条件不符合，您不能参与该订单的竞拍!";
                }
                if (str == "ISO18000" && !PubVar.IsHaveISO18000)
                {
                    btn_OK.Enabled = false;
                    lbl_infor.Text = "由于您的条件不符合，您不能参与该订单的竞拍!";
                }
                if (str == "Security" && !PubVar.IsHaveSecurity)
                {
                    btn_OK.Enabled = false;
                    lbl_infor.Text = "由于您的条件不符合，您不能参与该订单的竞拍!";
                }
            }
            else
            {
                lbl_ISO.Visible = false;
            }
            if (isNitric)
            {
                lbl_isNitric.Visible = true;
                if (!PubVar.IsHaveNitric)
                {
                    btn_OK.Enabled = false;
                    lbl_infor.Text = "由于您的条件不符合，您不能参与该订单的竞拍!";
                }
            }
            else
            {
                lbl_isNitric.Visible = false;   
            }
            
        }
        /// <summary> 
        /// 购物订单的载入
        /// </summary>
        private void loadShoppingType()
        {
            this.lab_title.Text = "燃煤订单";
            this.lab_Amount.Text = "需求量：    万吨";
            this.lab_UnitPrice.Text = "单价：      元/吨";
        }

        Point mousePoint;//移动窗口使用
        private void lab_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SetBounds(this.Location.X + e.X - mousePoint.X, this.Location.Y + e.Y - mousePoint.Y, this.Width, this.Height);
            }
        }

        private void lab_title_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
    }
}
