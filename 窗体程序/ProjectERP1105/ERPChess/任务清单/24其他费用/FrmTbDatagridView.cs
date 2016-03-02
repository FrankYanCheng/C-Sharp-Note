using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ERPChess
{
    public partial class FrmTbDatagridView : DevComponents.DotNetBar.Office2007Form
    {
        public FrmTbDatagridView()
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTbDatagridView_Load(object sender, EventArgs e)
        {
            this.dataGridViewX1.RowCount = 1;
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.coalValueUse * 0.23);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.SNCost);
            int temp = 0;
            for (int i = 0; i < PubVar.BidEleResult.Count; i++)
            {
                if (PubVar.BidEleResult[i].IsCommite == false)
                {
                    temp++;
                }
            }
            PubVar.temp += temp;
            this.dataGridViewX1.Rows[0].Cells[3].Value = temp;

            PubVar.Fund -=  temp;
            this.dataGridViewX1.Rows[0].Cells[4].Value = Math.Round(PubVar.Fund);
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
            }
        }

        private void FrmTbDatagridView_FormClosed(object sender, FormClosedEventArgs e)
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