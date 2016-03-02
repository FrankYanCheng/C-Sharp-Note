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
    public partial class Form_tex : LSGOfrmBasement
    {
        public Form_tex(frmMain parent)
        {
            InitializeComponent();
            par = parent;
        }

        private frmMain par;
        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            if (PubVar.closing[PubVar.year - 1].Pal_tax != 0.0)
            {
                PubVar.Fund = PubVar.Fund - PubVar.closing[PubVar.year - 1].Pal_tax;
                PubVar.t_diaoyong = 3;
                par.timer2.Interval = 100;
                par.timer2.Start();

            }

            PubVar.inCome = 0;
            PubVar.outPay = 0;
            this.Close();
        }

        private void Form_tex_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            PubVar.inCome = PubVar.inCome - PubVar.outPay;
            dataGridViewX1.Rows[0].Cells[0].Value = PubVar.closing[PubVar.year-1].Pal_profit;
            dataGridViewX1.Rows[0].Cells[1].Value = "利润总额的25%";
            if (PubVar.inCome < 0)
            {
                PubVar.inCome = 0;
            }
            dataGridViewX1.Rows[0].Cells[2].Value = PubVar.closing[PubVar.year-1].Pal_tax;
            //dataGridViewX1.Rows[0].Cells[3].Value = PubVar.closing[PubVar.year - 1].Pal_attach;
            //if (PubVar.closing[PubVar.year - 1].Pal_tax != 0.0)
            //{
            //    PubVar.Fund = PubVar.Fund - PubVar.closing[PubVar.year - 1].Pal_tax;
            //    PubVar.t_diaoyong = 3;
            //    par.timer2.Interval = 100;
            //    par.timer2.Start();
            //}
            
            //PubVar.inCome = 0;
            //PubVar.outPay = 0;
        }

        private void Form_tex_FormClosed(object sender, FormClosedEventArgs e)
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
