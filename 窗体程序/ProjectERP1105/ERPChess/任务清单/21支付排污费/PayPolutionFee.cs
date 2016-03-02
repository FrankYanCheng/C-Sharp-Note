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
    public partial class PayPolutionFee : LSGOfrmBasement
    {
        public PayPolutionFee()
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PayPolutionFee_Load(object sender, EventArgs e)
        {
            this.textBoxX1.Text = "按燃煤费用的2%的比例支付排污费";
            this.dataGridViewX1.RowCount = 1;
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.coalValueUse);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.coalValueUse * 0.02);
            PubVar.Fund -= Math.Round(PubVar.coalValueUse * 0.02);
            this.dataGridViewX1.Rows[0].Cells[3].Value = Math.Round(PubVar.Fund);
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
            }
        }

        private void PayPolutionFee_FormClosed(object sender, FormClosedEventArgs e)
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
