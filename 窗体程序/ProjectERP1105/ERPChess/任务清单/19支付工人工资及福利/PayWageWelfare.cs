using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ERPChess
{
    public partial class PayWageWelfare : Office2007Form
    {
        public PayWageWelfare(frmMain parent)
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.RowCount = 1;
            par = parent;
        }
        frmMain par;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            PubVar.t_diaoyong = 16;

            par.timer2.Interval = 100;
            par.timer2.Start();
            this.Close();
        }

        private void PayWageWelfare_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round((50 * Math.Pow(1.05, PubVar.year - 1)));//每人5万，共1000人，每年合计50百万
            PubVar.Fund -= 50 * Math.Pow(1.05, PubVar.year - 1);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.Fund);
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
            }
        }

        private void PayWageWelfare_FormClosed(object sender, FormClosedEventArgs e)
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
