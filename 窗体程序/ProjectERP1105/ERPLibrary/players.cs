using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPChess;

namespace ERPLibrary
{
    public class players
    {
        private List<player> playersList;
        public players(int k)
        {
            try
            {
                playersList = new List<player>();
                for (int i = 0; i < k; i++)
                {
                    player tplayer = new player(i+1);
                    playersList.Add(tplayer);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 参加竞价上网订单会
        /// </summary>
        public string p06BidForEle(double BillPrice)
        {
            int pct = playersList.Count;
            int k = 0;
            double small = BillPrice;
            string result = string.Empty;
            if (pct > 0)
            {
                Random rd = new Random();
                double temp = 0.3 + 0.5 * rd.NextDouble();
                if (temp < small)
                {
                    k = rd.Next(1, pct);
                    small = temp;
                }
            }
            result = k.ToString() + small.ToString();
            return result;
        }
        /// <summary>
        /// 参加电煤采购订货会
        /// </summary>
        public string p09BidForCoal(double billprice)
        {
            int pct = playersList.Count;
            string result = string.Empty;
            int k = 0;
            double max = billprice;
            if (pct > 0)
            {
                Random rd = new Random();
                double temp = 450 + 300 * rd.NextDouble();
                if (temp > max)
                {
                    k = rd.Next(1, pct);
                    max = temp;
                }
            }
            result = k.ToString() + max.ToString();
            return result;
        }
        public void DeletePlayer(int k)
        {
            try
            {
                int pct = playersList.Count;
                if (pct > k - 1)
                {
                    this.playersList.RemoveAt(k);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
