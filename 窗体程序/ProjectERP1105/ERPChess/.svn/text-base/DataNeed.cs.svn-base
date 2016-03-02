using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPLibrary;

namespace ERPChess
{
    public class DataNeed
    {
        private double Fund ;
        private double coal;
        public DataNeed()
        {
            this.Fund = 0;
            this.coal = 0;
        }
        /// <summary>
        /// 创建还原点
        /// </summary>
        public void BuildPoint()
        {
            this.Fund = PubVar.Fund;
            this.coal = PubVar.coal;
        }
        public void BackToPoint()
        {
            PubVar.Fund = this.Fund;
            PubVar.coal = this.coal;
        }
    }
}
