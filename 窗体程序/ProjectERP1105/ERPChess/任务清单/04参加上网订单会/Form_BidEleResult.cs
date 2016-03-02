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

namespace ERPChess
{
    public partial class Form_BidEleResult : LSGOfrmBasement
    {
        public Form_BidEleResult()
        {
            InitializeComponent();
        }

        private void Form_BidEleResult_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            Program.Forms.frmMain.step++;
            dataGridViewX1.RowCount = PubVar.BidEleResult.Count;
            //dataGridViewX1.Rows[0].Cells[0].Value = "订单号";
            //dataGridViewX1.Rows[1].Cells[0].Value = "单价（元/度）";
            //dataGridViewX1.Rows[2].Cells[0].Value = "数量（亿度）";
            //dataGridViewX1.Rows[3].Cells[0].Value = "账期（年度）";
            //dataGridViewX1.Rows[4].Cells[0].Value = "订单总额";
            if (PubVar.BidEleResult != null)
            {

                dataGridViewX1.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Gray;
                dataGridViewX1.Rows[2].DefaultCellStyle.BackColor = Color.Gray;
                for (int i = 0; i < PubVar.BidEleResult.Count; i++)
                {
                    dataGridViewX1.Rows[i].Cells[0].Value = PubVar.BidEleResult[i].BillNum;
                    dataGridViewX1.Rows[i].Cells[1].Value = PubVar.BidEleResult[i].Price;
                    dataGridViewX1.Rows[i].Cells[2].Value = PubVar.BidEleResult[i].Amount;
                    
                    dataGridViewX1.Rows[i].Cells[3].Value = PubVar.BidEleResult[i].YearLimit;
                    dataGridViewX1.Rows[i].Cells[4].Value = PubVar.BidEleResult[i].Sum;
                }
            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        delegate void step();
        private void nextStep()
        {
            if (Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].InvokeRequired)
            {
                step s = nextStep;
                Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Invoke(s);
            }
            else
            {
                Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Enabled = true;
                Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Refresh();
            }
        }
        private void refreshMain()
        {
            if (Program.Forms.frmMain.lbl_CurState.InvokeRequired)
            {
                step s = refreshMain;
                Program.Forms.frmMain.lbl_CurState.Invoke(s);
            }
            else
            {
                Program.Forms.frmMain.lbl_CurState.Text = "正在决策：第" + PubVar.year.ToString() + "年 第" + Program.Forms.frmMain.step.ToString() + "步 " + Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Text;
                Program.Forms.frmMain.lbl_CurState.Refresh();
            }
        }
        private void Form_BidEleResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            nextStep();
            refreshMain();
        }
    }
}
