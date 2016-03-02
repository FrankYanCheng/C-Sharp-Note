using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ERPLibrary;
using System.Threading;
using LSGO.DataLinkLayer.NetControl;
using LSGO.DataLinkLayer.Net;
using LSGO.PresentationLayer;
using System.Net;
using System.Net.Sockets;

namespace ERPChess
{
    static class Program
    {
        /// <summary>
        /// 实例化一个工厂
        /// </summary>
        public static Factory factory = new Factory();
        private static ApplicationContext context;
        public static FormRunList Forms;
        public static players players;
        public static DataNeed dttemp = new DataNeed();
        /// <summary>
        /// 通信层
        /// </summary>
        public static Server server;
        public static Client client;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            //实例化窗口列表
            Forms = new FormRunList();
            server = new Server();
            client = new Client();          
            InitialFormList();
            InitialLoan();

            Forms.frmLogin.ShowDialog();
            Forms.frmOrgan.ShowDialog();
            //加载程序
            Forms.frmSplash.Show();
            context = new ApplicationContext();
            Application.Idle += new EventHandler(Application_Idle);
            Application.Run(context);
        }
        private static void Application_Idle(object sender, EventArgs e)
        {
            if (context.MainForm == null)
            {
                Application.Idle -= new EventHandler(Application_Idle);
                Program.Forms.frmMain = new frmMain();
                Program.Forms.frmMain.ShowDialog();
            }
        }
        public static void InitialFormList()
        {
            Forms.frmLogin = new frmLogin();
            Forms.frmOrgan = new frmOrgan();
            Forms.frmSplash = new frmSplash();
        }
        public static void InitialLoan()
        {
            LongLoanList lloan = new LongLoanList();
            lloan.longDateTime = "第0年";
            lloan.longLoan = "长期贷款10年";
            lloan.longLoanAmount = 75;
            lloan.loan.YearLimit = 10;
            lloan.loan.AnnualInterest = 0.066;
            lloan.payOffyear = 10;
            lloan.save = 75;

            PubVar.longloanlist.Add(lloan);
            PubVar.sloan.shortDateTime = "第0年";
            PubVar.sloan.shortLoan = "短期贷款1年";
            PubVar.sloan.shortLoanAmount = 65;
            PubVar.sloan.loan.AnnualInterest = 0.06;
            PubVar.sloan.loan.YearLimit = 1;

            Account account = new ERPLibrary.Account();
            account.Fund = 22;//应收账款？由100改为22，修改
            account.YearLimit = 3;
            factory.RAccount.Add(account);
            //factory.CerficateSecurity.Canuse = true;
            //factory.CerficateSecurity.BuildTime = 2;


            PubVar.RaccountList = new List<double>(5);
            for (int i = 0; i < 5; i++)
            {
                PubVar.RaccountList.Add(0);
            }
            PubVar.RaccountList[2] = 22;//应收账款？由100改为22，修改
            //
            //增加应付账款
            Account account1 = new ERPLibrary.Account();
            account1.Fund = 25;//应付账款？由100改为22，修改
            account1.YearLimit = 3;
            factory.PAccount.Add(account1);
            PubVar.PaccountList = new List<double>(5);
            for (int i = 0; i < 5; i++)
            {
                PubVar.PaccountList.Add(0);
            }
            PubVar.PaccountList[2] = 25;//应付账款？由100改为25，修改
        }
    }
}
