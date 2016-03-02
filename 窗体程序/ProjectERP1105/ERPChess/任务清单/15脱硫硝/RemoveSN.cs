﻿using System;
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
    public partial class RemoveSN : LSGOfrmBasement
    {
        public RemoveSN()
        {
            InitializeComponent();
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX1.RowCount = 9;
            this.dataGridViewX2.RowCount = 4;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveSN_Load(object sender, EventArgs e)
        {
            this.dataGridViewX2.Rows[0].Cells["devicemach_type"].Value = "总购价(百万)";
            this.dataGridViewX2.Rows[1].Cells["devicemach_type"].Value = "建造时间(年)";
            this.dataGridViewX2.Rows[2].Cells["devicemach_type"].Value = "每年耗材(百万)";

            this.dataGridViewX2.Rows[0].Cells["mach_30"].Value = "200";
            this.dataGridViewX2.Rows[1].Cells["mach_30"].Value = "1";
            this.dataGridViewX2.Rows[2].Cells["mach_30"].Value = "3";

            this.dataGridViewX2.Rows[0].Cells["mach_60"].Value = "200";
            this.dataGridViewX2.Rows[1].Cells["mach_60"].Value = "1";
            this.dataGridViewX2.Rows[2].Cells["mach_60"].Value = "3";

            this.dataGridViewX2.Rows[0].Cells["mach_100"].Value = "200";
            this.dataGridViewX2.Rows[1].Cells["mach_100"].Value = "1";
            this.dataGridViewX2.Rows[2].Cells["mach_100"].Value = "3";

            for (int i = 0; i < 9; i++)
            {
                string str = "第" + (i + 1).ToString() + "机位";
                this.dataGridViewX1.Rows[i].Cells["device_Position"].Value = str;
            }
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                this.dataGridViewX1.Rows[Program.factory.IEquipment[i].Position].Cells[1].Value = Program.factory.IEquipment[i].MachineType.ToString();
                this.dataGridViewX1.Rows[Program.factory.IEquipment[i].Position].Cells[2].Value = Program.factory.IEquipment[i].Canuse ? "是" : "否";
                if (Program.factory.IEquipment[i].NitricEquipment.Canuse)
                {
                    this.dataGridViewX1.Rows[Program.factory.IEquipment[i].Position].Cells[3].Value = "已完成";
                }
                else
                {
                    this.dataGridViewX1.Rows[Program.factory.IEquipment[i].Position].Cells[3].Value = "未投资";
                }
            }
            if (PubVar.Fund < 0)
            {
                Form_Fail frm = new Form_Fail();
                frm.ShowDialog();
                Application.Exit();
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                if (Program.factory.IEquipment[i].NitricEquipment.Canuse)
                {
                    Program.factory.IEquipment[i].NitricEquipment.Investment(ref PubVar.Fund, ref PubVar.Tdevicevalueyuan, ref PubVar.Tdevicevalue);
                }
            }
            for (int k = 0; k < dataGridViewX1.Rows.Count; k++)
            {
                DataGridViewCheckBoxCell check = dataGridViewX1.Rows[k].Cells[4] as DataGridViewCheckBoxCell;
                if (check.Value != null)
                {
                    //找到第K行被选中
                    if ((bool)check.Value)
                    {
                        bool bl = false;
                        for (int i = 0; i < Program.factory.IEquipment.Count; i++)
                        {
                            //找到第几个设备被选中
                            if (Program.factory.IEquipment[i].Position == k)
                            {
                                bl = true;
                                if (Program.factory.IEquipment[i].NitricEquipment.Canuse)
                                {
                                    ILSGOfrmTipBox messagebox = new LSGOfrmInforMessageBox();
                                    messagebox.ShowMessage("第" + k.ToString() + "台设备已经投资,虽然勾选但不会继续扣现金", "提示");
                                }
                                else
                                {
                                    Program.factory.IEquipment[i].NitricEquipment.Investment(ref PubVar.Fund, ref PubVar.Tdevicevalueyuan, ref PubVar.Tdevicevalue);
                                }
                            }
                        }
                        if (bl == false)
                        {
                            ILSGOfrmTipBox messagebox = new LSGOfrmInforMessageBox();
                            messagebox.ShowMessage("第" + k.ToString() + "个机位为空", "提示");
                            return;
                        }
                    }
                }
            }
            this.Visible = false;
            if (PubVar.year > 2)
            {
                LittleOilFire form = new LittleOilFire();
                form.ShowDialog();
            }
            this.Close();
        }

        private void RemoveSN_FormClosed(object sender, FormClosedEventArgs e)
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
