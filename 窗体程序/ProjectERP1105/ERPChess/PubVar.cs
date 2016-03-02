using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPLibrary;

namespace ERPChess
{
    public class PubVar
    {
        ///<sammury>
        ///记录timer2调用
        ///</sammury>
        public static int shebei = 0;
        ///<sammury>
        ///记录timer2调用
        ///</sammury>
        public static double L_ljj = 0;
        ///<sammury>
        ///记录timer2调用
        ///</sammury>
        public static int t_diaoyong = 0;
        ///<sammury>
        ///记录决策者考试得分
        ///</sammury>
        public static int PlayerScore = 0;
        ///<sammury>
        ///记录决策者考试得分
        ///</sammury>
        public static int Score = 0;
        ///<sammury>
        ///记录决策者信息
        ///</sammury>
        public static bool live = true;
        //public List<PlayerInfo> PlayerLst;//用来记录所有决策者的信息
        /// <summary>
        /// 安全费
        /// </summary>
        public static double Security = 0;
        /// <summary>
        /// 罚款
        /// </summary>
        public static double temp = 0;
        /// <summary>
        /// 上一年的总收入
        /// </summary>
        public static double inCome = 0;
        /// <summary>
        /// 记录每年应付款
        /// </summary>
        public static double outPay = 0;
        ///<summary>
        ///电网负荷约束
        /// </summary>
        public static double ddys = 4.73;
        ///<summary>
        ///总营业成本
        /// </summary>
        public static double tatolCost=0;
        ///<summary>
        ///购电成本
        /// </summary>
        public static double mbc_Ele = 0;
        /// <summary>
        /// 记录决策者的总分
        /// </summary>
        public static List<double> scoreList;
        /// <summary>
        /// total points 总分
        /// </summary>
        public static List<TP> tp = new List<TP>();
        /// <summary>
        /// 当organ关闭时判断是关闭还是开始系统
        /// </summary>
        public static bool closeOrstart = false;
        /// <summary>
        /// 从数据库读取决策者权益
        /// </summary>
        public static List<TP1> computerRights = new List<TP1>();
        #region//回家添加
        /// <summary>
        /// 所有决策者总分
        /// </summary>
        public static List<totalPoint> totalpoint = new List<totalPoint>();
        /// <summary>
        /// 主程序路径
        /// </summary>
        public static string StartupPath = string.Empty;
        public static List<int> listInt = new List<int>();
        #endregion
        public static int mark = -1;
        /// <summary>
        /// 贴现费用
        /// </summary>
        public static double discount = 0;
        #region//通信信息
        /// <summary>
        /// 判断在建立游戏时是否按了关闭按钮，保证关闭后能把系统关闭
        /// </summary>
        public static bool isClose = false;
        /// <summary>
        /// 0代表加载数据时，1代表等待决策者时
        /// </summary>
        public static int SplashType = 0;
        /// <summary>
        /// 如果当前是客户端，用该属性保存添加的服务器的IP地址
        /// </summary>
        public static string JoinIp = "";
        public static string YXID = "";
        /// <summary>
        /// 记录是服务器还是客户端，0服务器，1客户端
        /// </summary>
        public static int identify = -1;
        #endregion
        /// <summary>
        /// 加载窗体信息
        /// </summary>
        public static string addString = string.Empty;
        public static List<Result> closing;
        /// <summary>
        /// 脱硫硝耗材
        /// </summary>
        public static double SNCost = 0;
        /// <summary>
        /// 微油点火
        /// </summary>
        public static double littleOilfire = 0;
        /// <summary>
        /// 财产保险费
        /// </summary>
        public static double valueguarsanttee = 0;
        #region//订单
        public static int count = 0;
        /// <summary>
        /// 记录竞拍的第几次
        /// </summary>
        public static int countth = 0;
        /// <summary>
        /// 记录获奖订单信息
        /// </summary>
        public static List<string> listBidResult = new List<string>();
        /// <summary>
        /// 记录一年的电量订单，不管有无竞拍成功，入库使用
        /// </summary>
        public static List<Bill> BidEResult = new List<Bill>();
        /// <summary>
        /// 记录一年的燃煤订单，不管有无竞拍成功，入库使用
        /// </summary>
        public static List<Bill> BidCResult = new List<Bill>();
        /// <summary>
        /// 记录电量竞拍订单
        /// </summary>
        public static List<Bill> BidEleResult = new List<Bill>();
        /// <summary>
        /// 记录燃煤竞拍订单
        /// </summary>
        public static List<Bill> bidCoalResult = new List<Bill>();
        /// <summary>
        /// 记录一次竞价的临时链表，通信层根据订单结果使用
        /// </summary>
        public static Bill TempBill;
        ///<summary>
        ///存储售电销售量（新增加）
        ///</summary>
        public static double DdZl = 0;
        ///<summary>
        ///存储售电销售额（新增加）
        /// </summary>
        public static double DdZe = 0;
        /// <summary>
        /// 存储从数据库中加载的容量订单
        /// </summary>
        public static List<BillAdd> CapEleBillAdd = new List<BillAdd>();
        /// <summary>
        /// 存储从数据库中加载的电量订单
        /// </summary>
        public static List<BillAdd> ComEleBillAdd = new List<BillAdd>();
        /// <summary>
        /// 存储从数据库中加载的燃煤订单
        /// </summary>
        public static List<BillAdd> CoalBillAdd = new List<BillAdd>();
        /// <summary>
        /// 从数据库选出今年的电量订单，发给客户端
        /// </summary>
        public static List<BillAdd> billThisYear = new List<BillAdd>();
        /// <summary>
        /// 从数据库选出今年的容量订单
        /// </summary>
        public static List<BillAdd> RbillThisYear = new List<BillAdd>();
        /// <summary>
        /// 5个子项，记录不同年限的金额
        /// </summary>
        public static List<double> PaccountList;
        /// <summary>
        /// 5个子项，记录不同年限的金额
        /// </summary>
        public static List<double> RaccountList;
        #endregion
        #region//贷款
        /// <summary>
        /// 记录长期贷款，不管有无
        /// </summary>
        public static LoanList lloan = new LoanList();
        /// <summary>
        /// 记录短期贷款，不管有无
        /// </summary>
        public static ShortLoanList sloan = new ShortLoanList();
        /// <summary>
        /// 记录长期贷款，有则记录
        /// </summary>
        public static List<LongLoanList> longloanlist = new List<LongLoanList>();
        /// <summary>
        /// 上一年的短期贷款利息费
        /// </summary>
        public static double AnnualInterestS = 0;
        #endregion
        #region//剩余的原材料数量
        /// <summary>
        /// 燃煤剩余量，由14改为0，修改
        /// </summary>
        public static double coal = 0;
        /// <summary>
        /// 今年燃煤消耗量
        /// </summary>
        public static double coalUse = 0;
        /// <summary>
        /// 今年燃煤消耗
        /// </summary>
        public static double coalValueUse = 0;
        /// <summary>
        /// 今年燃煤存货价值，由70改为0，修改
        /// </summary>
        public static double coalValueLeft = 0;
        /// <summary>
        /// 今年燃油费
        /// </summary>
        public static double oiluse = 0;
        /// <summary>
        /// 今年折旧值
        /// </summary>
        public static double depreciation = 0;
        /// <summary>
        /// 累计折旧109,修改增加
        /// </summary>
        public static double depreciationtotal = 109;
        public static double ISOCost = 0;
        /// <summary>
        /// 在建资产
        /// </summary>
        public static double ValueOnBuilding = 0;
        /// <summary>
        /// 设备原值，增加
        /// </summary>
        public static double Tdevicevalueyuan = 594;
        /// <summary>
        /// 新建设备，增加
        /// </summary>
        public static double Tdevicevaluexin = 0;
        /// <summary>
        /// 设备价值，修改
        /// </summary>
        public static double Tdevicevalue = 485;
        /// <summary>
        /// 今年售电收入
        /// </summary>
        public static double EleIncome = 0;
        /// <summary>
        /// 所购燃煤平均价格，由500改为0，修改
        /// </summary>
        public static double coalPrice = 0;
        /// <summary>
        /// 燃油剩余量
        /// </summary>
        public static double oil = 0;
        /// <summary>
        /// 材料剩余量
        /// </summary>
        public static double row = 0;
        /// <summary>
        /// 水剩余量
        /// </summary>
        public static double water = 0;
        #endregion
        #region//系统信息
        /// <summary>
        /// 公司名称
        /// </summary>
        public static string CompanyName = "新疆电力公司";
        /// <summary>
        /// 决策者
        /// </summary>
        public static string Actor = "actor";
        /// <summary>
        /// 当前时间
        /// </summary>
        public static int year = 1;
        #endregion
        #region//财产信息
        /// <summary>
        /// 决策者流动资金,由85改为158，修改
        /// </summary>
        public static double Fund = 158;
        ///// <summary>
        ///// 固定资产原值
        ///// </summary>
        //public static double totalOriginalValue=1070;
        ///// <summary>
        ///// 固定资产净值
        ///// </summary>
        //public static double totalPureValue = 485;
        /// <summary>
        /// 主窗体-应收账款，由0改为22，修改
        /// </summary>
        public static double accountR = 22;
        public static double Cc_mbc_repair = 0;
        /// <summary>
        /// 主窗体-应付账款，由0改为25，修改
        /// </summary>
        public static double accountP = 25;
        /// <summary>
        /// 主窗体-短期贷款，由34改为65，修改
        /// </summary>
        public static double loanS = 65;
        /// <summary>
        /// 主窗体-长期贷款，由200改为75，修改
        /// </summary>
        public static double loanL = 75;
        #endregion
        #region//生产资格
        /// <summary>
        /// 是否已经拥有30w生产资格
        /// </summary>
        public static bool IsHave30w = true;
        /// <summary>
        /// 是否已经拥有60w生产资格
        /// </summary>
        public static bool IsHave60w = false;
        /// <summary>
        /// 是否已经拥有100w生产资格
        /// </summary>
        public static bool IsHave100w = false;
        #endregion
        #region//认证证书
        /// <summary>
        /// 是否有ISO9000证书
        /// </summary>
        public static bool IsHaveISO9000 = false;
        /// <summary>
        /// 是否有ISO14000证书
        /// </summary>
        public static bool IsHaveISO14000 = false;
        /// <summary>
        /// 是否有ISO18000证书
        /// </summary>
        public static bool IsHaveISO18000 = false;
        /// <summary>
        /// 是否有Security证书
        /// </summary>
        public static bool IsHaveSecurity = true ;
        /// <summary>
        /// 是否有脱硫硝证书
        /// </summary>
        public static bool IsHaveNitric = false;
        public static int equipment_10kw = 0;
        public static int equipment_30kw = 0;
        public static int equipment_60kw = 0;
        public static int equipment_100kw = 0;
        #endregion
        #region//2010.12.18 张正义
        /// <summary>
        /// 无约束电量产量
        /// </summary>
        public static double proEleNOQue = 0;
        /// <summary>
        /// 脱硫硝电量产量
        /// </summary>
        public static double proEleNoSN = 0;
        /// <summary>
        /// 售电收入
        /// </summary>
        public static double EleBidincome = 0;
        #endregion
        #region 正义2012/11/11
        /// <summary>
        /// 记录用户个数
        /// </summary>
        public static int playCount = 0;

        #endregion
        #region 苑文楠 添加代码
        /// <summary>
        /// 发送订单时间，隔3秒后显示一个窗口，单位秒
        /// </summary>
        public static int SendBillShowTime = 5;
        /// <summary>
        /// 发送订单关闭时间，显示2秒后关闭窗口，单位秒
        /// </summary>
        public static int SendBillCloseTime = 10;

        public static string PlayerName;//当前游戏决策者姓名
        public static string ConstOrder = "LSGOTeam";//系统指令，发送服务器名称即当前决策者信息时，用此名称，决策者不可设定此为决策者名称
        #endregion
        #region 系统注册信息
        /// <summary>
        /// 表示软件是否注册
        /// </summary>
        public static bool IsRegistration = false;
        /// <summary>
        /// 用户ID
        /// </summary>
        public static string UserID;
        /// <summary>
        /// 读取到的用户注册码
        /// </summary>
        public static string RegistrationID = string.Empty;
        #endregion
    }
    //回家修改
    public class TP
    {
        public string playerName = string.Empty;
        public double[] rigth = new double[10];
        public double[] profit = new double[10];
        public double totalPoint = 0;
    }
    public class TP1
    {
        public int playerName = 0;
        public int yearID = 0;
        public double right = 0;
        public double profit = 0;
    }
    public class totalPoint
    {
        public string playerName = string.Empty;
        public double totalpoint = 0;
        public string createTime = string.Empty;
    }
}
