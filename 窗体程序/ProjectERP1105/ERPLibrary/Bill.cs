using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class Bill
    {
        public Bill()
        {
            amount = new double();
            price = new double();
            sum = new double();
            yearLimit = new int();
            billType = new BillType();
            billNum = new int();
            billGroupNum = new int();
            isNitric = false;
            isCertificate = false;
            certificateType = new CerficateType();
            isCommite = false;
        }
        bool isNitric;  
        bool isCertificate;     
        CerficateType certificateType; 
        double amount;
        double price;
        double sum;
        int yearLimit;
        BillType billType;
        int billNum;
        int billGroupNum;
        bool isCommite;
        int getTime;

        /// <summary>
        /// 获得订单的年份
        /// </summary>
        public int GetTime
        {
            get { return getTime; }
            set { getTime = value; }
        }

        /// <summary>
        ///标志是否已经提交 
        /// </summary>
        public bool IsCommite
        {
            get { return isCommite; }
            set { isCommite = value; }
        }

        /// <summary>
        /// 订单需求量
        /// </summary>
        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        /// <summary>
        /// 订单竞拍单价
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        /// <summary>
        /// 订单竞拍总价
        /// </summary>
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum=value;
            }
        }
        /// <summary>
        /// 订单账款年限
        /// </summary>
        public int YearLimit
        {
            get
            {
                return yearLimit;
            }
            set
            {
                yearLimit = value;
            }
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public BillType BillType
        {
            get
            {
                return billType;
            }
            set
            {
                billType = value;
            }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public int BillNum
        {
            get
            {
                return billNum;
            }
            set
            {
                billNum = value;
            }
        }
        /// <summary>
        /// 订单组号
        /// </summary>
        public int BillGroupNum
        {
            get
            {
                return billGroupNum;
            }
            set
            {
                billGroupNum = value;
            }
        }
        /// <summary>
        /// 电订单是否需要脱硫硝
        /// </summary>
        public bool IsNitric
        {
            get 
            {
                return isNitric;
            }
            set 
            {
                isNitric = value;
            }
        }
        /// <summary>
        /// 电订单是否有证书要求
        /// </summary>
        public bool IsCertificate
        {
            get 
            { 
                return isCertificate; 
            }
            set
            { 
                isCertificate = value;
            }
        }
        /// <summary>
        /// 订单证书要求类型
        /// </summary>
        public CerficateType CertificateType
        {
            get 
            { 
                return certificateType;
            }
            set 
            { 
                certificateType = value; 
            }
        }
    }
}
