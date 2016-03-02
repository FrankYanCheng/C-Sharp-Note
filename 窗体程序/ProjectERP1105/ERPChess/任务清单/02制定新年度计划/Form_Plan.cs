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

namespace ERPChess
{
    public partial class Form_Plan : LSGOfrmBasement
    {
        public Form_Plan(frmMain parent)
        {
            InitializeComponent();
            par=parent;
            
        }
        private frmMain par;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            double SecurityPay = 0, k = 0;
            
            SecurityPay = Convert.ToDouble(this.textBox1.Text);


            if (SecurityPay == 0.0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Program.factory.CerficateSecurity.MoneyProgress.Enqueue(1);
                }
                Program.factory.CerficateSecurity.Canuse = false;
                MessageBox.Show("由于您没有进行的安全生产投入，出现了安全生产事故，将被吊销安全生产证书，并被罚款10百万元！");
                PubVar.Fund -= 10;
                par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString()+"百万";
                PubVar.t_diaoyong = 1;
                par.timer2.Interval = 50;
                par.timer2.Start();

                ///资格认证初始化
                ///
                par.pictureBox11.Visible = false;
                par.pictureBox12.Visible = false;
                par.pictureBox13.Visible = false;
                par.pictureBox14.Visible = false;

                if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 1)
                    par.pictureBox11.Visible = true;
                if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 2)
                    par.pictureBox12.Visible = true;
                if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 3)
                    par.pictureBox13.Visible = true;
                if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 4)
                    par.pictureBox14.Visible = true;
                

            }
            else
            {
                
                PubVar.Security = Math.Round(SecurityPay);
                if (SecurityPay > 0 && SecurityPay < Math.Round(PubVar.Tdevicevalueyuan * 0.03 * 2))
                {
                    int t = Convert.ToInt32(PubVar.Tdevicevalueyuan * 0.03 * 2);
                    k = (PubVar.Tdevicevalueyuan * 0.03 * 2) - SecurityPay;
                    k = t - k / (PubVar.Tdevicevalueyuan * 0.03 * 2) * t;
                    t = Convert.ToInt32(k);
                    Random random = new Random();
                    int r = random.Next(0, t);
                    if (r == 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Program.factory.CerficateSecurity.MoneyProgress.Enqueue(1);
                        }
                        Program.factory.CerficateSecurity.Canuse = false;
                        MessageBox.Show("由于您的安全生产投入资金投入量较低，出现了安全生产事故，将被吊销安全生产证书，并被罚款10百万元！");
                        PubVar.Fund -= 10 + Math.Round(SecurityPay);
                        PubVar.temp += 10;
                        par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString();
                        PubVar.t_diaoyong = 2;
                        par.timer2.Interval = 50;
                        par.timer2.Start();
                        ///资格认证初始化
                        ///
                        par.pictureBox11.Visible = false;
                        par.pictureBox12.Visible = false;
                        par.pictureBox13.Visible = false;
                        par.pictureBox14.Visible = false;
                        
                        if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 1)
                            par.pictureBox11.Visible = true;
                        if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 2)
                            par.pictureBox12.Visible = true;
                        if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 3)
                            par.pictureBox13.Visible = true;
                        if (4 - Program.factory.CerficateSecurity.MoneyProgress.Count >= 4)
                            par.pictureBox14.Visible = true;

                        
                    }
                    else
                    {
                        PubVar.t_diaoyong = 2;
                        PubVar.Fund -= Math.Round(SecurityPay);

                        par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                        par.timer2.Interval = 50;
                        par.timer2.Start();
                        
                        

                    }
                    
                }
                else if (SecurityPay >= Math.Round(PubVar.Tdevicevalueyuan * 0.03 * 2))
                {
                    PubVar.Fund -= Math.Round(SecurityPay);
                    //PubVar.Security = Math.Round(SecurityPay);
                    par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                    PubVar.t_diaoyong = 2;
                    par.timer2.Interval = 50;
                    par.timer2.Start();
                    this.Close();
                }
            }
                
            this.Close();
        }

        private void Form_Plan_Load(object sender, EventArgs e)
        {
            PubVar.Security = 0;
            PubVar.temp = 0;
            this.ControlBox = false; 
            this.textBox1.Text = "0";
        }

        private void Form_Plan_FormClosed(object sender, FormClosedEventArgs e)
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
