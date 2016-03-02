using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class ElectricEquipment : IEquipment
    {
        public ElectricEquipment(int EquipmentType,int Position, int year)
        {
            this.machineYear = year;//设备建造时间
            this.machineType = EquipmentType;
            this.moneyProgress = new Queue<double>();
            this.position = Position;
            switch (EquipmentType)
            {
                
                case 30:
                    this.MachineName = "0拖1拖3";
                    this.price = 112;
                    this.generateEnergy = 2.37;
                    //this.moneyProgress.Enqueue(400);
                    //this.moneyProgress.Enqueue(200);
                    this.consumeCoal = 330;
                    this.consumeTotalCoal = 30;
                    this.nitricEquiment = new NitricEquipment(30);
                    this.valueLeft = 25;
                    break;
                case 60:
                    this.MachineName = "1拖2拖6";
                    this.price = 594;
                    this.generateEnergy = 4.73;
                    //this.moneyProgress.Enqueue(900);
                    //this.moneyProgress.Enqueue(300);
                    this.consumeCoal = 300;
                    this.consumeTotalCoal = 80;
                    this.nitricEquiment = new NitricEquipment(60);
                    this.valueLeft = 50;
                    break;
                
                default: throw new Exception("设备类型参数传入错误");
            }
        }
        private int position;
        public int Position
        {
            get
            {
                return position;
            }
        }
        private bool useOil=true;
        private bool investOlie = false;
        public bool UseOil
        {
            get
            {
                return this.useOil;
            }
        }
        public void SetUseOli()
        {
            if (this.investOlie == true)
            {
                this.useOil = false;
            }
            else
            {
                this.useOil = true;
            }
        }
        public void SetinvestOlie()
        {
            this.investOlie = true;
        }
        private double generateEnergy;
        public double GeneratedEnergy
        {
            get
            {
                return generateEnergy;
            }
            set { generateEnergy = value; }
        }
        private double consumeCoal;
        public double ConsumeCoal
        {
            get
            {
                return this.consumeCoal;
            }
        }
        private double consumeTotalCoal;
        public double ConsumeTotalCoal
        {
            get
            {
                return this.consumeTotalCoal;
            }
        }
        private double price;
        public double Price
        {
            get
            {
                return this.price;
            }
        }
        private double valueLeft;
        public double ValueLeft
        {
            get { return valueLeft; }
            set { valueLeft = value; }
        }
        private bool canuse;
        public bool Canuse
        {
            get { return canuse; }
            set { canuse = value; }
        }
        private Queue<double> moneyProgress;
        public Queue<double> MoneyProgress
        {
            get
            {
                return this.moneyProgress;
            }
        }
        private int machineYear;
        public int MachineYear
        {
            get { return this.machineYear; }
        }

        private string machineName;//设备类型，新添加
        public string MachineName
        {
            get { return machineName; }
            set { machineName = value; }
        }

        private int machineType;
        public int MachineType
        {
            get
            {
                return this.machineType;
            }
        }
        /// <summary>
        /// 报废机组
        /// </summary>
        /// <param name="cash"></param>
        /// <param name="totalOrigionValue"></param>
       /* public void Discard(ref double found,ref double Tdevicevalue)
        {
            if (this.canuse == true)
            {
                Tdevicevalue -= this.valueLeft;
                found += this.valueLeft;
                if (this.nitricEquiment.Canuse)
                {
                    Tdevicevalue -= this.nitricEquiment.ValueLeft;
                    found += this.nitricEquiment.ValueLeft;
                }
            }
            else
            {
                throw new Exception("机组投资未完成无法折现");
            }
        }
         */
        /// <summary>
        /// 对设备进行投资
        /// </summary>
        /// <param name="cash"></param>
        public void Investment(ref double cash, ref double Tdevicevalueyuan, ref double Tdevicevalue)
        {
            
               cash-=this.price;
               Tdevicevalueyuan += this.price;
               Tdevicevalue += this.price;

                    
        }
        private int k = 0;
        /// <summary>
        /// 判断是否结束投资&&设备是否可用
        /// </summary>
        /// <returns></returns>
        public void IsEndInvestment()
        {
            if (this.moneyProgress.Count > 0)
            {
                this.canuse = false;
            }
            else
            {
                this.canuse = true;
            }
        }
        private NitricEquipment nitricEquiment;
        public NitricEquipment NitricEquipment
        {
            get
            {
                return this.nitricEquiment;
            }
            set
            {
                this.nitricEquiment = value;
            }
        }
    }

    public interface IEquipment
    {
        double Price
        {
            get;
        }

        Queue<double> MoneyProgress
        {
            get;
        }
        int MachineType
        {
            get;
        }

        void Investment(ref double cash, ref double Tdevicevalueyuan, ref double Tdevicevalue);
    }
}
