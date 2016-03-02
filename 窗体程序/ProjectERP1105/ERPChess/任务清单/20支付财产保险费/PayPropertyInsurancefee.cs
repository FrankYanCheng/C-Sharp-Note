﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LSGO.PresentationLayer;

namespace ERPChess
{
    public partial class PayPropertyInsurancefee : LSGOfrmBasement
    {
        public PayPropertyInsurancefee(frmMain parent)
        {
            InitializeComponent();
            this.dataGridViewX1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.RowCount = 1;
            PubVar.valueguarsanttee = 0;
            par = parent;
        }
        frmMain par;
        private int Getguarranttee()
        {
            double dua=0;
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                dua += Program.factory.IEquipment[i].MachineType / 100;
            }
            return (int)(Math.Round(dua));
        }
        private void PayPropertyInsurancefee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            int gua = Getguarranttee();
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Fund);
            //this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.coalValueUse);
            //this.dataGridViewX1.Rows[0].Cells[2].Value = gua;
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.Tdevicevalue);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.Tdevicevalue * 0.006);
            PubVar.Fund -= PubVar.Tdevicevalue * 0.006;
            //PubVar.valueguarsanttee = gua;
            PubVar.valueguarsanttee = PubVar.Tdevicevalue * 0.006;
            this.dataGridViewX1.Rows[0].Cells[3].Value = Math.Round(PubVar.Fund);
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            PubVar.t_diaoyong = 17;

            par.timer2.Interval = 100;
            par.timer2.Start();
            this.Close();
        }

        private void PayPropertyInsurancefee_FormClosed(object sender, FormClosedEventArgs e)
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
