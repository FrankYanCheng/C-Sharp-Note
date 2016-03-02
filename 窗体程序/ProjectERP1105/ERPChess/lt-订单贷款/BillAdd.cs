using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPLibrary;

namespace ERPChess
{
    public class BillAdd
    {
        /// <summary>
        /// 第几年的订单
        /// </summary>
        public int year=0;
        /// <summary>
        /// 订单号
        /// </summary>
        public int billNum = 0;
        /// <summary>
        /// 订单的需求量
        /// </summary>
        public double amount = 0;//将整形改成双精度，修改
        public double price = 0;
        public double sum = 0;
        /// <summary>
        /// 订单的年限
        /// </summary>
        public int yearLimit = 0;
        /// <summary>
        /// 是否需要脱硫硝
        /// </summary>
        public bool isNitric = false;
        /// <summary>
        /// 是否需要ISO认证
        /// </summary>
        public bool isISO = false;
        public CerficateType cerficateType;
    }
}
