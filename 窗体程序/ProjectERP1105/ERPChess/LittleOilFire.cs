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
    public partial class LittleOilFire : Office2007Form
    {
        public LittleOilFire()
        {
            PubVar.littleOilfire = 0;
            InitializeComponent();
            this.dataGridViewX1.RowCount = 9;
        }

        private void LittleOilFire_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                string str = "第" + (i + 1).ToString() + "机位";
                this.dataGridViewX1.Rows[i].Cells["device_Position"].Value = str;
            }
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                this.dataGridViewX1.Rows[Program.factory.IEquipment[i].Position].Cells[1].Value = Program.factory.IEquipment[i].MachineType.ToString();
                this.dataGridViewX1.Rows[Program.factory.IEquipment[i].Position].Cells[2].Value = Program.factory.IEquipment[i].UseOil ? "无" : "有";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dataGridViewX1.Rows.Count; k++)
            {
                DataGridViewCheckBoxCell check = dataGridViewX1.Rows[k].Cells[3] as DataGridViewCheckBoxCell;
                if (check.Value != null)
                {
                    //找到第K行被选中
                    if ((bool)check.Value)
                    {
                        for (int i = 0; i < Program.factory.IEquipment.Count; i++)
                        {
                            //找到第几个设备被选中
                            if (Program.factory.IEquipment[i].Position == k)
                            {
                                if (Program.factory.IEquipment[i].UseOil == true)
                                {
                                    Program.factory.IEquipment[i].SetinvestOlie();
                                    PubVar.Fund -= 4;
                                    PubVar.littleOilfire += 4;
                                }
                            }
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
