using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GGChatSever
{
   /// <summary>
   /// 获取本地IP地址的类
   /// </summary>
   public  class GetIp
    {
        public string getIp()
       {
           string k = null;
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
          return k = AddressIP;
        }
    }
}
