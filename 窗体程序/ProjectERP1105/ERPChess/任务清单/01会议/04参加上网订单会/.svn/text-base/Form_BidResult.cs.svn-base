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
    public partial class Form_BidResult : Office2007Form
    {
        public Form_BidResult()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_BidResult_Load(object sender, EventArgs e)
        {
            dataGridViewX1.RowCount = 5;
            dataGridViewX1.Rows[0].Cells[0].Value = "订单号";
            dataGridViewX1.Rows[1].Cells[0].Value = "单价（元/度）";
            dataGridViewX1.Rows[2].Cells[0].Value = "需求量（亿度）";
            dataGridViewX1.Rows[3].Cells[0].Value = "账期（年）";
            dataGridViewX1.Rows[4].Cells[0].Value = "订单总额";
            for (int i = 1; i < PubVar.BidEleResult.Count; i++)
            {
                dataGridViewX1.Rows[0].Cells[i].Value = PubVar.BidEleResult[i - 1].BillNum;
                dataGridViewX1.Rows[1].Cells[i].Value = PubVar.BidEleResult[i - 1].Price;
                dataGridViewX1.Rows[2].Cells[i].Value = PubVar.BidEleResult[i - 1].Amount;
                dataGridViewX1.Rows[3].Cells[i].Value = PubVar.BidEleResult[i - 1].YearLimit;
                dataGridViewX1.Rows[4].Cells[i].Value = PubVar.BidEleResult[i - 1].Sum;
            }
        }
    }
}
