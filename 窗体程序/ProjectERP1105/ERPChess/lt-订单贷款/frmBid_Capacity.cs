﻿using System;
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
    public partial class frmBid_Capacity : LSGOfrmBasement
    {
        public frmBid_Capacity()
        {
            InitializeComponent();
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            if (PubVar.countth == PubVar.RbillThisYear.Count)
            {
                PubVar.countth = 0;
                double temp = Convert.ToDouble(lbl_yearlimit.Text);
                string Order = MessageType.ComEleFrm.ToString() + "//" + MessageType.ReadyCom.ToString();
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));
                PubVar.SplashType = 1;//设置Splash窗体的显示样式，当前为等待其他决策者
                Program.Forms.frmSplash = new frmSplash();
                Program.Forms.frmSplash.Show();
                this.Close();
            }
            else
            {
                Program.Forms.frmCapacity = new frmBid_Capacity();
                Program.Forms.frmCapacity.Show();
                this.Close();
            }
        }

        private void frmBid_Capacity_Load(object sender, EventArgs e)
        {
            if (PubVar.RbillThisYear[PubVar.countth].price == 0.42)
                labelX_Name.Text = "居民用电订单";
            if (PubVar.RbillThisYear[PubVar.countth].price == 0.44)
                labelX_Name.Text = "工商业及其他用电订单";
            if (PubVar.RbillThisYear[PubVar.countth].price == 0.26)
                labelX_Name.Text = "农业用电订单";
            lbl_num.Text = (PubVar.countth + 1).ToString() + "/" + PubVar.RbillThisYear.Count;
            lbl_amount.Text = PubVar.RbillThisYear[PubVar.countth].amount.ToString();
            lbl_price.Text = PubVar.RbillThisYear[PubVar.countth].price.ToString();
            lbl_sum.Text = PubVar.RbillThisYear[PubVar.countth].sum.ToString();
            lbl_yearlimit.Text = PubVar.RbillThisYear[PubVar.countth].yearLimit.ToString();
            PubVar.countth++;
        }
        Point mousePoint;//移动窗口使用
        private void labelX_Name_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SetBounds(this.Location.X + e.X - mousePoint.X, this.Location.Y + e.Y - mousePoint.Y, this.Width, this.Height);
            }
        }

        private void labelX_Name_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
    }
}
