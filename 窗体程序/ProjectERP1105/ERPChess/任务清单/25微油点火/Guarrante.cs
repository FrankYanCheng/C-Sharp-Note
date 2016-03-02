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
    public partial class Guarrante : DevComponents.DotNetBar.Office2007Form
    {
        public Guarrante()
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guarrante_Load(object sender, EventArgs e)
        {
            this.dataGridViewX1.Rows[0].Cells[0].Value = PubVar.littleOilfire.ToString();
        }

        private void Guarrante_FormClosed(object sender, FormClosedEventArgs e)
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