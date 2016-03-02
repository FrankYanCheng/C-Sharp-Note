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
    public partial class PayFactoryElectricFee : LSGOfrmBasement
    {
        public PayFactoryElectricFee(frmMain parent)
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.RowCount = 1;
            par = parent;
        }
        frmMain par;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString();
            PubVar.t_diaoyong = 14;
            par.timer2.Interval = 100;
            par.timer2.Start();
            this.Close();
        }

        private void PayFactoryElectricFee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            PubVar.EleIncome = pal_sale();
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.EleIncome);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.EleIncome*0.08);

            PubVar.Fund -= PubVar.EleIncome * 0.08;
            this.dataGridViewX1.Rows[0].Cells[3].Value = Math.Round( PubVar.Fund);
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
                Application.Exit();
            }
        }
        private double pal_sale()
        {
            double temp = 0;
            if (PubVar.BidEleResult != null)
            {
                for (int i = 0; i < PubVar.BidEleResult.Count; i++)
                {
                    if (PubVar.BidEleResult[i].IsCommite)
                    {
                        temp += PubVar.BidEleResult[i].Sum;
                    }
                }
            }
            return temp;
        }

        private void PayFactoryElectricFee_FormClosed(object sender, FormClosedEventArgs e)
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
