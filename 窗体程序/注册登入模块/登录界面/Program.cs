using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Entry
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {  
            #region 对配置文件进行加密
            Configuration configue = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configue.ConnectionStrings.SectionInformation.ProtectSection(null);
            configue.Save(ConfigurationSaveMode.Full);
            #endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EntryCover());
        }
    }
}
