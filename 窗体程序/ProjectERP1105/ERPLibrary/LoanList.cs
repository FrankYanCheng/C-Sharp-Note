using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPLibrary;


namespace ERPChess
{
    public class LoanList
    {
        /// <summary>
        /// 记录长期贷款的名称类型
        /// </summary>
        public string longLoan = string.Empty;
        /// <summary>
        /// 记录第几年有贷款
        /// </summary>
        public int year;
        /// <summary>
        /// 记录长期贷款时间
        /// </summary>
        public string longDateTime = string.Empty;
        /// <summary>
        /// 记录短期贷款时间
        /// </summary>
        public string shortDateTime = string.Empty;
        /// <summary>
        /// 记录短期贷款名称，登记、还款使用到
        /// </summary>
        public string shortLoan = string.Empty;
        ///// <summary>
        ///// 记录是否有长期贷款
        ///// </summary>
        //public bool isLongLoan = false;
        /// <summary>
        /// 实例化一个长期5或者15年贷款类型
        /// </summary>
        public ILoan loan = new Loan();
        /// <summary>
        /// 记录长期贷款额
        /// </summary>
        public double longLoanAmount = new double();
        /// <summary>
        /// 记录短期贷款额
        /// </summary>
        public double shortLoanAmount = new double();
    }
}
