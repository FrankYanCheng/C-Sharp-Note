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
    public partial class FrmStartProduce : LSGOfrmBasement
    {
        double[] eletricQuality;
        public FrmStartProduce()
        {
            InitializeComponent();
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEletric.RowCount = 1;
            this.dataGridViewX2.RowCount = 9;
            this.dgvEletric.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < 9; i++)
            {
                string str = "第" + (i + 1).ToString() + "机位";
                this.dataGridViewX2.Rows[i].Cells[0].Value = str;
                this.dataGridViewX2.Rows[i].Cells[1].Value = "机位为空";
            }
            eletricQuality = new double[6];
            for (int i = 0; i < PubVar.BidEleResult.Count; i++)
            {
                if (PubVar.BidEleResult[i].IsNitric)
                {
                    if (PubVar.BidEleResult[i].IsCertificate)
                    {
                        switch (PubVar.BidEleResult[i].CertificateType)
                        {
                            case ERPLibrary.CerficateType.ISO9000:
                                eletricQuality[4] += PubVar.BidEleResult[i].Amount;
                                break;
                            case ERPLibrary.CerficateType.ISO14000:
                                eletricQuality[5] += PubVar.BidEleResult[i].Amount;
                                break;
                            default:
                                throw new Exception("证书类型传递错误");
                        }
                    }
                    else
                    {
                        eletricQuality[1] += PubVar.BidEleResult[i].Amount;
                    }
                }
                else
                {
                    if (PubVar.BidEleResult[i].IsCertificate)
                    {
                        switch (PubVar.BidEleResult[i].CertificateType)
                        {
                            case ERPLibrary.CerficateType.ISO9000:
                                eletricQuality[2] += PubVar.BidEleResult[i].Amount;
                                break;
                            case ERPLibrary.CerficateType.ISO14000:
                                eletricQuality[3] += PubVar.BidEleResult[i].Amount;
                                break;
                            default:
                                throw new Exception("证书类型传递错误");
                        }
                    }
                    else
                    {
                        eletricQuality[0] += PubVar.BidEleResult[i].Amount;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                this.dgvEletric.Rows[0].Cells[i].Value = eletricQuality[i];
            }
            this.lblCoalLeft.Text = PubVar.coal.ToString();
            for (int i = 0; i < 9; i++)
            {
                this.dataGridViewX2.Rows[i].Cells[5].ReadOnly = true;
            }
            if (PubVar.IsHaveISO14000)
            {
                this.lbISO14000.Text = "已获得ISO14000资格认证";
            }
            else
            {
                this.lbISO14000.Text = "未获得ISO14000资格认证";
            }
            if (PubVar.IsHaveISO9000)
            {
                this.lbISO9000.Text = "已获得ISO9000资格认证";
            }
            else
            {
                this.lbISO9000.Text = "未获得ISO9000资格认证";
            }
            //创建还原点
            //备份现金、燃煤、电量订单
            Program.dttemp.BuildPoint();
        }

        private void FrmStartProduce_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.factory.IEquipment.Count; i++)
            {
                if (Program.factory.IEquipment[i].MoneyProgress.Count < 2)
                {
                    if (Program.factory.IEquipment[i].Canuse)
                    {
                        this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[1].Value = "已完工";
                        
                        this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[5].ReadOnly = false;
                    }
                    else
                    {
                        this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[1].Value = "在建";
                    }
                }
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[5].Value = (0.000).ToString();
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[3].Value = Program.factory.IEquipment[i].GeneratedEnergy;
                this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[4].Value = Program.factory.IEquipment[i].ConsumeTotalCoal;
                if (Program.factory.IEquipment[i].NitricEquipment.Canuse)
                {
                    this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[2].Value = "是";
                }
                else
                {
                    this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[2].Value = "否";
                }
                if (Program.factory.IEquipment[i].UseOil)
                {
                    this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[6].Value = "无";
                }
                else
                {
                    this.dataGridViewX2.Rows[Program.factory.IEquipment[i].Position].Cells[6].Value = "有";
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PubVar.proEleNOQue = 0;
            PubVar.proEleNoSN = 0;
            PubVar.coalUse = 0;
            PubVar.oiluse = 0;
            PubVar.SNCost = 0;
            ILSGOfrmTipBox message = new LSGOfrmInforMessageBox();
            double coalUse = 0;
            double eleNoSN = 0;
            double eleInSN = 0;
            double sncost = 0;
            try
            {
                for (int k = 0; k < Program.factory.IEquipment.Count; k++)
                {
                    double temp;
                    try
                    {
                        string str = (string)this.dataGridViewX2.Rows[Program.factory.IEquipment[k].Position].Cells[5].Value;
                        if (str.Trim() == "")
                        {
                            message.ShowMessage("产量不能为空", "提示");
                            return;
                        }
                        temp = Convert.ToDouble(this.dataGridViewX2.Rows[Program.factory.IEquipment[k].Position].Cells[5].Value);
                        if (temp < 0)
                        {
                            message.ShowMessage("产量不能为负", "提示");
                            return;
                        }
                    }
                    catch
                    {
                        message.ShowMessage("输入错误", "提示");
                        return;
                    }
                    if (Program.factory.IEquipment[k].Canuse)
                    {
                        //脱硫硝电量产量
                        if (Program.factory.IEquipment[k].NitricEquipment.Canuse)
                        {
                            if (temp > Program.factory.IEquipment[k].GeneratedEnergy)
                            {
                                message.ShowMessage("输入机组产量无法实现", "提示");
                                return;
                            }
                            coalUse += temp / Program.factory.IEquipment[k].GeneratedEnergy * Program.factory.IEquipment[k].ConsumeTotalCoal;
                            if (Program.factory.IEquipment[k].UseOil)
                            {
                                PubVar.oiluse += temp / Program.factory.IEquipment[k].GeneratedEnergy * Program.factory.IEquipment[k].ConsumeTotalCoal * PubVar.coalPrice * 0.01 / 100;
                            }
                            eleNoSN += temp;
                            if (temp > 0)
                            {
                                sncost += 3;
                            }
                        }
                        //没有脱硫硝电量产量
                        else
                        {
                            if (temp > Program.factory.IEquipment[k].GeneratedEnergy)
                            {
                                message.ShowMessage("输入机组产量无法实现", "提示");
                                return;
                            }
                            coalUse += temp / Program.factory.IEquipment[k].GeneratedEnergy * Program.factory.IEquipment[k].ConsumeTotalCoal;
                            if (Program.factory.IEquipment[k].UseOil)
                            {
                                PubVar.oiluse += temp / Program.factory.IEquipment[k].GeneratedEnergy * Program.factory.IEquipment[k].ConsumeTotalCoal * PubVar.coalPrice * 0.01 / 100;
                            }
                            eleInSN += temp;
                        }
                    }
                }
                message.ShowMessage("生产所需燃煤量为" + ((int)coalUse).ToString() + "万吨，生产所需的燃油为" + ((int)(PubVar.oiluse)).ToString(), "提示");
                if (coalUse > PubVar.coal)
                {
                    message.ShowMessage("生产所需燃煤量大于燃煤储存量无法生产，请重新输入产量", "提示");
                    return;
                }
                coalUse = Math.Round(coalUse);
                PubVar.proEleNOQue = eleInSN;
                PubVar.proEleNoSN = eleNoSN;
                PubVar.coalUse += coalUse;
                PubVar.coal -= coalUse;
                PubVar.SNCost = sncost;
                Pubfun.UseCoal(coalUse);
                //扣除水费
                double t = PubVar.coalValueUse * 0.006;
                PubVar.Fund -= Math.Round(PubVar.coalValueUse * 0.006);
                //扣除材料费
                PubVar.Fund -= Math.Round(PubVar.coalValueUse * 0.035);
                //扣除油费
                PubVar.Fund -= Math.Round(PubVar.oiluse);
            }
            catch (Exception ex)
            {
                ILSGOfrmTipBox messagebox = new LSGOfrmInforMessageBox();
                messagebox.ShowMessage(ex.Message, "错误提示");
                return;
            }
            this.Dispose();
        }
    }
}
