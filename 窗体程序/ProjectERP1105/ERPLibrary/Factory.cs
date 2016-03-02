using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class Factory
    {
        public Factory()
        {
            rowMaterial = new List<RowMaterial>();
            iLoan = new List<ILoan>();
            pAccount = new List<Account>();
            rAccount = new List<Account>();
            iEquipment = new List<ElectricEquipment>();
            comprehensiveCost = new ComprehensiveCost();
            cerficateSecurity = new Cerficate(CerficateType.Security);
            cerficate18000 = new Cerficate(CerficateType.ISO18000);
            cerficate14000 = new Cerficate(CerficateType.ISO14000);
            certificate9000 = new Cerficate(CerficateType.ISO9000);
            bill = new Bill();
            accountType = new AccountType();
            #region//初始化设备
            ElectricEquipment electricEquiment1 = new ElectricEquipment(60,0,0);
            /*ElectricEquipment electricEquiment2 = new ElectricEquipment(10,1);
            ElectricEquipment electricEquiment3 = new ElectricEquipment(10,2);
            ElectricEquipment electricEquiment4 = new ElectricEquipment(10,3);
            ElectricEquipment electricEquiment5 = new ElectricEquipment(10,4);*/
            iEquipment.Add(electricEquiment1);
            /*iEquipment.Add(electricEquiment2);
            iEquipment.Add(electricEquiment3);
            iEquipment.Add(electricEquiment4);
            iEquipment.Add(electricEquiment5);*/
            #endregion
        }
        /// <summary>
        /// 原材料
        /// </summary>
        private List<RowMaterial> rowMaterial;
        /// <summary>
        /// 贷款
        /// </summary>
        private List<ILoan> iLoan;
        /// <summary>
        /// 应付账款
        /// </summary>
        private List<Account> pAccount;
        /// <summary>
        /// 应收账款
        /// </summary>
        private List<Account> rAccount;
        /// <summary>
        /// 设备（电机和脱硫硝）
        /// </summary>
        private List<ElectricEquipment> iEquipment;
        /// <summary>
        /// 综合业务
        /// </summary>
        private ComprehensiveCost comprehensiveCost;
        /// <summary>
        /// 安全生产证书
        /// </summary>
        private Cerficate cerficateSecurity;

        public Cerficate CerficateSecurity
        {
            get
            {
                return cerficateSecurity;
            }
            set
            {
                cerficateSecurity = value;
            }
        }
        /// <summary>
        /// 证书18000
        /// </summary>
        private Cerficate cerficate18000;

        public Cerficate Cerficate18000
        {
            get
            {
                return cerficate18000;
            }
            set
            {
                cerficate18000 = value;
            }
        }
        /// <summary>
        /// 证书14000
        /// </summary>
        private Cerficate cerficate14000;

        public Cerficate Cerficate14000
        {
            get
            {
                return cerficate14000;
            }
            set
            {
                cerficate14000 = value;
            }
        }
        /// <summary>
        /// 证书9000
        /// </summary>
        private Cerficate certificate9000;

        public Cerficate Certificate9000
        {
            get 
            {
                return certificate9000; 
            }
            set
            {
                certificate9000 = value; 
            }
        }
        /// <summary>
        /// 订单
        /// </summary>
        private Bill bill;
        /// <summary>
        /// 账款类型
        /// </summary>
        private AccountType accountType;

        public List<RowMaterial> RowMaterial
        {
            get
            {
                return rowMaterial;
            }
            set
            {
                rowMaterial = value;
            }
        }

        public List<ILoan> ILoan
        {
            get
            {
                return iLoan;
            }
            set
            {
                iLoan = value;
            }
        }
        /// <summary>
        /// 应付账款统计
        /// </summary>
        public List<Account> PAccount
        {
            get
            {
                return pAccount;
            }
            set
            {
                pAccount = value;
            }
        }
        /// <summary>
        /// 应收账款统计
        /// </summary>
        public List<Account> RAccount
        {
            get
            {
                return rAccount;
            }
            set
            {
                rAccount = value;
            }
        }
        public List<ElectricEquipment> IEquipment
        {
            get
            {
                return iEquipment;
            }
            set
            {
                iEquipment = value;
            }
        }

        public ComprehensiveCost ComprehensiveCost
        {
            get
            {
                return comprehensiveCost;
            }
            set
            {
                comprehensiveCost = value;
            }
        }

        public Bill Bill
        {
            get
            {
                return bill;
            }
            set
            {
                bill=value;
            }
        }

        public AccountType AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
    }
}
