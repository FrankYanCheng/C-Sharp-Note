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
    public partial class Certification : LSGOfrmBasement
    {
        public Certification(frmMain parent)
        {
            InitializeComponent();
            PubVar.ISOCost = 0;
            par = parent;
        }
        frmMain par;
        private void buttonX_Sure_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                Program.factory.CerficateSecurity.Invesment(ref PubVar.Fund);
                PubVar.ISOCost += 1;
            }
            if (checkBox3.Checked)
            {
                Program.factory.Cerficate18000.Invesment(ref PubVar.Fund);
                PubVar.ISOCost += 1;
            }
            if (checkBox1.Checked)
            {
                Program.factory.Cerficate14000.Invesment(ref PubVar.Fund);
                PubVar.ISOCost += 1;
            }
            if (checkBox2.Checked)
            {
                Program.factory.Certificate9000.Invesment(ref PubVar.Fund);
                PubVar.ISOCost += 1;
            }
            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString();
            PubVar.t_diaoyong = 13;
            par.timer2.Interval = 100;
            par.timer2.Start();
            ///资格认证显示
            par.pictureBox11.Visible = false;
            par.pictureBox12.Visible = false;
            par.pictureBox13.Visible = false;
            par.pictureBox14.Visible = false;
            par.pictureBox15.Visible = false;
            par.pictureBox16.Visible = false;
            par.pictureBox17.Visible = false;
            par.pictureBox18.Visible = false;
            par.pictureBox19.Visible = false;
            par.pictureBox20.Visible = false;
            par.pictureBox21.Visible = false;
            par.pictureBox22.Visible = false;
            par.pictureBox23.Visible = false;
            par.pictureBox24.Visible = false;
            if (4-Program.factory.CerficateSecurity.MoneyProgress.Count >= 1)
                par.pictureBox11.Visible = true;
            if (4-Program.factory.CerficateSecurity.MoneyProgress.Count >= 2)
                par.pictureBox12.Visible = true;
            if (4-Program.factory.CerficateSecurity.MoneyProgress.Count >= 3)
                par.pictureBox13.Visible = true;
            if (4-Program.factory.CerficateSecurity.MoneyProgress.Count >= 4)
                par.pictureBox14.Visible = true;

            if (4-Program.factory.Cerficate18000.MoneyProgress.Count >= 1)
                par.pictureBox15.Visible = true;
            if (4-Program.factory.Cerficate18000.MoneyProgress.Count >= 2)
                par.pictureBox16.Visible = true;
            if (4-Program.factory.Cerficate18000.MoneyProgress.Count >= 3)
                par.pictureBox17.Visible = true;
            if (4-Program.factory.Cerficate18000.MoneyProgress.Count >= 4)
                par.pictureBox18.Visible = true;
            if (4-Program.factory.Cerficate14000.MoneyProgress.Count >= 1)
                par.pictureBox19.Visible = true;
            if (4-Program.factory.Cerficate14000.MoneyProgress.Count >= 2)
                par.pictureBox20.Visible = true;
            if (4-Program.factory.Cerficate14000.MoneyProgress.Count >= 3)
                par.pictureBox21.Visible = true;
            if (4-Program.factory.Cerficate14000.MoneyProgress.Count >= 4)
                par.pictureBox22.Visible = true;
            if (2-Program.factory.Certificate9000.MoneyProgress.Count >= 1)
                par.pictureBox23.Visible = true;
            if (2-Program.factory.Certificate9000.MoneyProgress.Count >= 2)
                par.pictureBox24.Visible = true;


            this.Close();
        }

        private void button_Romove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Certification_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            Cerficate cerficat = new Cerficate(CerficateType.Security);
                if (1 == 0)

            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.RowCount = 6;

            this.dataGridViewX1.Rows[0].Cells["certificate_Type"].Value = "总投资";
            this.dataGridViewX1.Rows[1].Cells["certificate_Type"].Value = "每年需要投资";
            this.dataGridViewX1.Rows[2].Cells["certificate_Type"].Value = "共需投资年数";
            this.dataGridViewX1.Rows[3].Cells["certificate_Type"].Value = "已经投入年数";
            this.dataGridViewX1.Rows[4].Cells["certificate_Type"].Value = "剩余投入年数";
            this.dataGridViewX1.Rows[5].Cells["certificate_Type"].Value = "是否获得该项资格认证";



            this.dataGridViewX1.Rows[0].Cells["Security"].Value = "4百万";
            this.dataGridViewX1.Rows[1].Cells["Security"].Value = "1百万";
            this.dataGridViewX1.Rows[2].Cells["Security"].Value = "4年";
            this.dataGridViewX1.Rows[4].Cells["Security"].Value = Program.factory.CerficateSecurity.MoneyProgress.Count;
            this.dataGridViewX1.Rows[3].Cells["Security"].Value = Program.factory.CerficateSecurity.BuildTime - Program.factory.CerficateSecurity.MoneyProgress.Count;
            if (Program.factory.CerficateSecurity.Canuse)
            {
                this.dataGridViewX1.Rows[5].Cells["Security"].Value = "是";
                this.checkBox4.Enabled = false;
                PubVar.IsHaveSecurity = true;
            }
            else
            {
                this.dataGridViewX1.Rows[5].Cells["Security"].Value = "否";
            }

            this.dataGridViewX1.Rows[0].Cells["ISO9000"].Value = "2百万";
            this.dataGridViewX1.Rows[1].Cells["ISO9000"].Value = "1百万";
            this.dataGridViewX1.Rows[2].Cells["ISO9000"].Value = "2年";
            this.dataGridViewX1.Rows[4].Cells["ISO9000"].Value = Program.factory.Certificate9000.MoneyProgress.Count; 
            this.dataGridViewX1.Rows[3].Cells["ISO9000"].Value = Program.factory.Certificate9000.BuildTime - Program.factory.Certificate9000.MoneyProgress.Count;
            if (Program.factory.Certificate9000.Canuse)
            {
                this.dataGridViewX1.Rows[5].Cells["ISO9000"].Value = "是";
                this.checkBox2.Enabled = false;
                PubVar.IsHaveISO9000 = true;
            }
            else
            {
                this.dataGridViewX1.Rows[5].Cells["ISO9000"].Value = "否";
            }


            this.dataGridViewX1.Rows[0].Cells["ISO14000"].Value = "4百万";
            this.dataGridViewX1.Rows[1].Cells["ISO14000"].Value = "1百万";
            this.dataGridViewX1.Rows[2].Cells["ISO14000"].Value = "4年";
            this.dataGridViewX1.Rows[4].Cells["ISO14000"].Value = Program.factory.Cerficate14000.MoneyProgress.Count;
            this.dataGridViewX1.Rows[3].Cells["ISO14000"].Value = Program.factory.Cerficate14000.BuildTime - Program.factory.Cerficate14000.MoneyProgress.Count;
            if (Program.factory.Cerficate14000.Canuse)
            {
                this.dataGridViewX1.Rows[5].Cells["ISO14000"].Value = "是";
                this.checkBox1.Enabled = false;
                PubVar.IsHaveISO14000 = true;
            }
            else
            {
                this.dataGridViewX1.Rows[5].Cells["ISO14000"].Value = "否";
            }



            this.dataGridViewX1.Rows[0].Cells["ISO18000"].Value = "4百万";
            this.dataGridViewX1.Rows[1].Cells["ISO18000"].Value = "1百万";
            this.dataGridViewX1.Rows[2].Cells["ISO18000"].Value = "4年";
            this.dataGridViewX1.Rows[4].Cells["ISO18000"].Value = Program.factory.Cerficate18000.MoneyProgress.Count;
            this.dataGridViewX1.Rows[3].Cells["ISO18000"].Value = Program.factory.Cerficate18000.BuildTime - Program.factory.Cerficate18000.MoneyProgress.Count;
            if (Program.factory.Cerficate18000.Canuse)
            {
                this.dataGridViewX1.Rows[5].Cells["ISO18000"].Value = "是";
                this.checkBox3.Enabled = false;
                PubVar.IsHaveISO18000 = true;
            }
            else
            {
                this.dataGridViewX1.Rows[5].Cells["ISO18000"].Value = "否";
            }



            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
            }
        }

        private void Certification_FormClosed(object sender, FormClosedEventArgs e)
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
