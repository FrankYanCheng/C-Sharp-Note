using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ERPLibrary;
using LSGO.PresentationLayer;

namespace ERPChess
{
    public partial class FormBuildNew : LSGOfrmBasement
    {
        public FormBuildNew(frmMain parent)
        {
            InitializeComponent();
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            par = parent;
        }
        frmMain par;
        public int devicecount = Program.factory.IEquipment.Count;
        int x013 = PubVar.equipment_30kw, x126 = PubVar.equipment_60kw;
        private void FormBuildNew_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            PubVar.ddys = PubVar.equipment_30kw * 2.37 + PubVar.equipment_60kw * 4.73;
            if (x126 <= x013)
                this.radioButton1.Visible = false;
            else
                this.radioButton1.Visible = true;
            for (int k = 0; k < 9; k++)
            {
                bool bl = false;
                for (int i = 0; i <Program.factory.IEquipment.Count; i++)
                {
                    if (Program.factory.IEquipment[i].Position == k)
                    {
                        bl = true;
                        break;
                    }
                }
                if (bl == false)
                {
                    string str =(k+1).ToString();
                    //this.comboBoxEx1.Items.Add(new ComboBoxItem(k.ToString(),str));
                }
            }
            


            this.dataGridViewX2.Rows.Clear();
            this.dataGridViewX2.RowCount = 9;
            
            for (int i = 0; i < 9; i++)
            {
                string str = "设备" + (i + 1).ToString();
                this.dataGridViewX2.Rows[i].Cells["DeviceList"].Value = str;
            }
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[1].Value = Program.factory.IEquipment[i].MachineName.ToString();
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[2].Value = Program.factory.IEquipment[i].Price.ToString(); 
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[3].Value = "1年".ToString();
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[4].Value = Program.factory.IEquipment[i].GeneratedEnergy.ToString();
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[5].Value = Program.factory.IEquipment[i].MachineYear.ToString();
               

                if (Program.factory.IEquipment[i].MoneyProgress.Count > 0)
                {
                    this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[4].Value = Program.factory.IEquipment[i].MoneyProgress.Peek().ToString();
                }
                else
                {
                    this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[4].Value = "已完成投资";
                }
            }
        }
        bool Select_Type=false;
        
        private void buttonX1_Sure_Click(object sender, EventArgs e)
        {
            /*this.comboBoxEx1.Text = "";
            
            if (Select_Posotion == false)
            {
                MessageBox.Show("请选择设备位置");
                return;
            }*/
             if (Select_Type == false)
            {
                MessageBox.Show("请选择设备类型");
                return;
            }
            Program.factory.IEquipment.Add(new ElectricEquipment(type, Program.factory.IEquipment.Count ,PubVar.year));
            if (type == 30)
            {
                x013++;
                PubVar.shebei += 1;
            }
            if (type == 60)
            {
                x126++;
                PubVar.shebei += 3;
                
            }
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            FormBuildNew_Load(sender, e);
            Select_Type = false;
            

        }
        private int select;
        

        private void buttonX3_Cancle_Click(object sender, EventArgs e)
        {
            for (int k = devicecount; k < Program.factory.IEquipment.Count; k++)
            {
                Program.factory.IEquipment[k].Investment(ref PubVar.Fund, ref PubVar.Tdevicevalueyuan, ref PubVar.Tdevicevalue);
                
                //Program.factory.IEquipment[k].Investment(ref PubVar.Fund, ref PubVar.Tdevicevalue);
            }

            //动画

            if (PubVar.shebei == 1)
            {
                par.pictureBox26.Visible = true;
                PubVar.ddys = 2.37 + 4.73;
                

            }
            if (PubVar.shebei == 3)
            {
                par.pictureBox25.Visible = true;
                PubVar.ddys = 2*4.73;
            }
            if (PubVar.shebei == 4)
            {
                par.pictureBox26.Visible = true;
                par.pictureBox25.Visible = true;
                PubVar.ddys = 2.37 + 2*4.73;
            }
            if (PubVar.shebei == 5)
            {
                par.pictureBox26.Visible = true;
                par.pictureBox25.Visible = true;
                par.pictureBox27.Visible = true;
                PubVar.ddys = 2*2.37 + 2*4.73;
            }

            
            
           
            //PubVar.equipment_30kw = x1;
            //PubVar.equipment_60kw = x2;
            
            //PubVar.ddys = x1 * 2.37 + x2 * 4.73;
            par.l_fuhe.Text = PubVar.ddys.ToString() + "亿千瓦时";
            par.l_yuanzhi.Text = PubVar.Tdevicevalueyuan.ToString() + "百万";
            





            par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString();

            if (PubVar.Fund < 0)
            {
                string order = MessageType.totalPoint.ToString() + "//" + PubVar.PlayerName + "//" + GameOver.total_Points().ToString();
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
                GameOver.gameOver();
                PubVar.live = false;
                
            }
            this.Close();
        }
        private int type;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = 30;
            Select_Type = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = 60;
            Select_Type = true;
        }

        

        private void FormBuildNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (PubVar.Fund < 0)
            //{
            //    string order = MessageType.totalPoint.ToString() + "//" + PubVar.PlayerName + "//" + GameOver.total_Points().ToString();
            //    Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
            //    GameOver.gameOver();
            //    this.Close();
            //}
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            /*this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
           
            Select_Posotion = false;*/
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            //for (int k = devicecount; k < Program.factory.IEquipment.Count; k++)
            //{
               // if(this.dataGridViewX2.CurrentRow.Selected==true)
                    //this.dataGridViewX2.CurrentRow.re

            if (Program.factory.IEquipment.Count > devicecount)
            
            {
                
                /*int i=this.dataGridViewX2.CurrentRow.Index;
                Program.factory.IEquipment.RemoveAt(i);
                //this.dataGridViewX2.Rows.RemoveAt(i);
                this.dataGridViewX2.Rows.Clear();
                this.dataGridViewX2.Refresh();*/
                int i = Program.factory.IEquipment.Count-1;
                if (Program.factory.IEquipment[i].MachineType == 30)
                {
                    x013--;
                    PubVar.shebei -= 1;
                }
                else
                    if (Program.factory.IEquipment[i].MachineType == 60)
                    {
                        x126--;
                        PubVar.shebei -= 3;
                    }
                Program.factory.IEquipment.RemoveAt(i);
                //this.dataGridViewX2.Rows.RemoveAt(i);
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                FormBuildNew_Load(sender, e);
                Select_Type = false;
                
                
            }

        }
    }
}
