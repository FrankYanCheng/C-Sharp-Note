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
    public partial class Form_ShowRanking : Office2007Form
    {
        public Form_ShowRanking()
        {
            InitializeComponent();
            this.dgv1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Form_ShowRanking_Load(object sender, EventArgs e)
        {
            dgv1.RowCount = 17;
            for (int i = 0; i < 6; i++)
            {
                dgv1.Columns[i + 1].HeaderText = PubVar.tp[i].playerName;
            }
            for (int i = 0; i < PubVar.year - 1; i++)
            {
                //回家修改
                dgv1.Rows[i].Cells[0].Value = "第" + (i + 1).ToString() + "年";
                for (int j = 0; j < 6; j++)
                {
                    dgv1.Rows[i].Cells[j + 1].Value = PubVar.tp[j].rigth[i] + "/" + PubVar.tp[j].profit[i];
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
