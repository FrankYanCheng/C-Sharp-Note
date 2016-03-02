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
    public partial class Depreciation : DevComponents.DotNetBar.Office2007Form
    {
        public Depreciation(frmMain parent)
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
            par.p_jinbi.Left = 250;
            par.p_jinbi.Top = 380;
            PubVar.t_diaoyong = 15;
            par.timer2.Interval = 100;
            par.timer2.Start();
            this.Close();
        }

        private void Depreciation_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            PubVar.depreciation = PubVar.Tdevicevalueyuan * 0.05;
            PubVar.depreciationtotal += PubVar.depreciation;
            PubVar.Tdevicevalue = PubVar.Tdevicevalueyuan - PubVar.depreciationtotal;
            this.dataGridViewX1.Rows[0].Cells[0].Value = Math.Round(PubVar.Tdevicevalueyuan);
            this.dataGridViewX1.Rows[0].Cells[1].Value = Math.Round(PubVar.depreciationtotal);
            this.dataGridViewX1.Rows[0].Cells[2].Value = Math.Round(PubVar.Tdevicevalue);
            this.dataGridViewX1.Rows[0].Cells[3].Value = Math.Round(PubVar.depreciation);
            
        }
    }
}