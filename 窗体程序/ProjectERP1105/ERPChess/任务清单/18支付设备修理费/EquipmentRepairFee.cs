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
    public partial class EquipmentRepairFee : LSGOfrmBasement
    {
        public EquipmentRepairFee(frmMain parent)
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
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            PubVar.t_diaoyong = 18;

            par.timer2.Interval = 100;
            par.timer2.Start();
            this.Close();
        }

        private void EquipmentRepairFee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.Tdevicevalue);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.Tdevicevalue * 0.07);
            PubVar.Cc_mbc_repair = PubVar.Tdevicevalue * 0.07;
            PubVar.Fund -= PubVar.Tdevicevalue * 0.07;
            this.dataGridViewX1.Rows[0].Cells[3].Value = Math.Round(PubVar.Fund);
            
        }

        private void EquipmentRepairFee_FormClosed(object sender, FormClosedEventArgs e)
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
