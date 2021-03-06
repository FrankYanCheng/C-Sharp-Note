﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPChess
{
    public class Pubfun
    {
        /// <summary>
        /// 根据消耗煤的数量计算今年没的消耗量和库存量
        /// </summary>
        /// <param name="coal">今年消耗的煤的数量</param>
        /// <returns>0 今年消耗的煤的价值</returns>
        /// <returns>1 煤的存货价值</returns>
        public static void UseCoal(double coal)
        {
            double[] result = new double[2];
            double coalJ = coal;
            int length = PubVar.bidCoalResult.Count;
            for (int i = 0; i < length; i++)
            {
                if (PubVar.bidCoalResult[i].Amount <= coalJ)
                {
                    coalJ -= PubVar.bidCoalResult[i].Amount;
                    result[0] += PubVar.bidCoalResult[i].Sum;
                }
                else
                {
                    if (coalJ > 0)
                    {
                        result[0] += Math.Round(coalJ * PubVar.bidCoalResult[i].Price / 100);
                        result[1] += (PubVar.bidCoalResult[i].Amount - coalJ) * PubVar.bidCoalResult[i].Price / 100;
                        coalJ = 0;
                    }
                    else
                    {
                        result[1] += PubVar.bidCoalResult[i].Sum;
                    }
                }
            }
            PubVar.coalValueUse = result[0];
        }
        /// <summary>
        /// 更新燃煤订单
        /// </summary>
        /// <param name="coal"></param>
        public static void UpdataCoalBill(double coal)
        {

            PubVar.coalValueLeft -= PubVar.coalValueUse;
            double coalJ = coal;
            int length = PubVar.bidCoalResult.Count;
            for (int i = 0; i < length; i++)
            {
                if (PubVar.bidCoalResult[i].Amount <= coalJ)
                {
                    coalJ -= PubVar.bidCoalResult[i].Amount;
                    PubVar.bidCoalResult.RemoveAt(i);
                    i--;
                    length--;
                }
                else
                {
                    if (coalJ > 0)
                    {
                        PubVar.bidCoalResult[i].Amount -= coalJ;
                        double temp = Math.Round(coalJ * PubVar.bidCoalResult[i].Price / 100);
                        PubVar.bidCoalResult[i].Sum = PubVar.bidCoalResult[i].Sum - temp;
                        coalJ = 0;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
