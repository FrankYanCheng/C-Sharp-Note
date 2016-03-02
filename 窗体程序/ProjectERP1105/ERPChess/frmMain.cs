using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using LSGO.PresentationLayer;
using System.Data.OleDb;
using ERPLibrary;
using LSGO.DataLinkLayer.Tool;
using LSGO.DataLinkLayer;
using MySchool;

namespace ERPChess
{
    public partial class frmMain : LSGOfrmBasement
    {
        public List<LinkLabel> listLklb = new List<LinkLabel>();//装载步骤的linklable
        public int step = 1;//记录当前运行到第几步
        Point mousePoint;//移动窗口使用
        bool IsClick = false;
        Size tmp = new Size();
        Point point;
        public frmMain()
        {
            InitializeComponent();
            connection();
            timer1.Start();
            Initialize();
            SetIsRegistion();
            InitialComputer();
            this.lblName.Text = PubVar.PlayerName;
            for (int i = 1; i < listLklb.Count; i++)
            {
                listLklb[i].Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void SetIsRegistion()
        {
            Register();
            GetUserID();
            LSGOCodeB code = new LSGOCodeB();
            string temp=code.Cipher(PubVar.UserID);
            if (temp == PubVar.RegistrationID)
            {
                PubVar.IsRegistration = true;
                this.lbregister.Text = "已注册版本";
            }
        }
        /// <summary>
        /// 读取RegistrationID
        /// </summary>
        /// <param name="bl"></param>
        private void Register()
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Computer1.mdb";
            OleDbConnection connection = new OleDbConnection(con);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "SELECT RegisterID FROM Register";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    PubVar.RegistrationID = reader[0].ToString();
                    break;
                }
            }
        }
        /// <summary>
        /// 获得UserID
        /// </summary>
        private void GetUserID()
        {
            SystemOperating sys = new SystemOperating();
            List<string> temp = sys.GetMainBoardID();
            string result=string.Empty;
            for (int k = 0; k < temp.Count;k++)
            {
                result += temp[k];
            }
            LSGOCodeB code = new LSGOCodeB();
            PubVar.UserID = code.Cipher(result);
        }
        /// <summary>
        ///系统初始化
        /// </summary>
        private void Initialize()
        {
            listLklb.Add(linkLabel1);
            listLklb.Add(linkLabel2);
            listLklb.Add(linkLabel5);
            listLklb.Add(linkLabel3);
            listLklb.Add(linkLabel4);
            listLklb.Add(linkLabel6);
            listLklb.Add(linkLabel7);
            listLklb.Add(linkLabel8);
            listLklb.Add(linkLabel11);
            listLklb.Add(linkLabel13);
            listLklb.Add(linkLabel9);
            //listLklb.Add(linkLabel14);
            listLklb.Add(linkLabel15);
            listLklb.Add(linkLabel17);
            listLklb.Add(linkLabel23);
            listLklb.Add(linkLabel19);
            listLklb.Add(linkLabel20);
            listLklb.Add(linkLabel18);
            listLklb.Add(linkLabel24);
            listLklb.Add(linkLabel26);
            listLklb.Add(linkLabel10);
            listLklb.Add(linkLabel27);
        }
        private void InitialComputer()
        {
            TP tp;
            for (int i = 0; i < 6 - PubVar.playCount; i++)
            {
                tp = new TP();
                tp.playerName = "computer" + (i + 1).ToString();
                PubVar.tp.Add(tp);
                for (int j = 0; j < PubVar.computerRights.Count; j++)
                {
                    if (PubVar.computerRights[j].playerName == PubVar.listInt[i])
                    {
                        PubVar.tp[i + PubVar.playCount].profit[PubVar.computerRights[j].yearID - 1] = PubVar.computerRights[j].profit;
                        PubVar.tp[i + PubVar.playCount].rigth[PubVar.computerRights[j].yearID - 1] = PubVar.computerRights[j].right;
                    }
                }
            }
        }
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PubVar.year = 9;
            if (PubVar.year <11)//2年结束
            {
                Form frm;
                int yea = PubVar.year;
                switch (step)
                {
                    case 1: frm = new Form_chushi(this);

                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 30;
                        }
                        break;
                    case 2: frm = new Form_Plan(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 55;
                        }
                        break;
                    case 3: frm = new Form_tex(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 80;
                        }
                        break;
                    case 4: frm = new frmRaccount(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step ++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 105;
                        }
                        break;
                    case 5: frm = new frmPaccount(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 130;
                        }
                        break;
                    
                    case 6: frm = new Form_BidElectric();
                        frm.Show();
                        listLklb[step - 1].Enabled = false;
                        pictureBox1.Top = 155;
                        break;
                    case 7: frm = new Form_PayOff();
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 180;
                        }
                        break;
                    case 8: frm = new frmLoan();
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 205;
                        }
                        break;
                    
                    
                    case 9: frm = new FormBuildNew(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 230;
                        }
                        break;
                   
                    case 10: frm = new FrmCommiteProduct(this);
                        listLklb[step - 1].Enabled = false;
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 255;
                        }

                        break;

                    case 11: frm = new MoneyNeedPay(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top =280;
                        }
                        break;
                    
                    case 12: frm = new Certification(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 305;
                        }
                        break;
                    case 13: frm = new PayFactoryElectricFee(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 330;
                        }
                        break;
                    //计提折旧
                    case 14: frm = new Depreciation(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 355;
                        }
                        break;
                        //工资和福利
                    case 15: frm = new PayWageWelfare(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 380;
                        }
                        break;

                    //支付财保费
                    case 16: frm = new PayPropertyInsurancefee(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 405;
                        }
                        break;
                    //设备维修
                    case 17: frm = new EquipmentRepairFee(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 430;
                        }
                        break;
                    
                    
                    //管理费用
                    case 18: frm = new EntrustOperation(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 455;
                        }
                        break;
                    
                    
                    //主营业务税及附加
                    case 19: frm = new MainWork(this);
                        frm.ShowDialog();
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 480;
                        }
                        break;
                    //关账
                    case 20: frm = new SelectQuestionsForm();
                        PubVar.mark = 0;
                        frm.ShowDialog();
                        lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                        l_qita.Text = Math.Round(PubVar.temp).ToString() + "百万";
                        if (step != 0)
                        {
                            listLklb[step - 1].Enabled = false;
                            step++;
                            listLklb[step - 1].Enabled = true;
                            pictureBox1.Top = 505;
                        }
                        break;
                    case 21: frm = new Form_ShowResult();
                        //PubVar.mark = 0;
                        listLklb[step - 1].Enabled = false;
                        frm.ShowDialog();
                        if (step == 0)
                        {
                            listLklb[0].Enabled = false;
                        }
                        else
                        {
                            step = 1;
                            listLklb[0].Enabled = true;
                            pictureBox1.Top = 5;
                        }
                        /*while (PubVar.IsRegistration == false)
                        {
                            ILSGOfrmTipBox message = new LSGOfrmInforMessageBox();
                            message.ShowMessage("你必须完成注册才能继续玩", "提示");
                            frm = new Form_Register();
                            frm.ShowDialog();
                        }*/
                        break;
                    default: throw new Exception("ERROR");
                }
                InforLoad();
            }
            else
            {
                MessageBox.Show("你已完成10年经营任务");
                listLklb[0].Enabled = false;
                string order = MessageType.totalPoint.ToString() + "//" + PubVar.PlayerName + "//" + GameOver.total_Points().ToString();
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
                GameOver.gameOver();

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SetBounds(this.Location.X + e.X - mousePoint.X, this.Location.Y + e.Y - mousePoint.Y, this.Width, this.Height);
            }
        }


        //modify by tianxin 更新游戏ID
        private void updateyxid()
        {

            OleDbConnection cnb = ERPLibrary.DataAClass.getInstanse().getDAO();
            try
            {
                string sqlb = "UPDATE yxxxb set YXYXBZ = 'N' where FQZIP = '" + Program.server.IP_Address + "' and YXYXBZ = 'Y'";
                OleDbCommand cmdb = new OleDbCommand(sqlb, cnb);
                cnb.Open();
                cmdb.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                mesbox.ShowMessage(ex.Message, "提示");
            }
            finally
            {
                cnb.Close();
            }



        }
        //end

        private void bubbleButton_Click(object sender, ClickEventArgs e)
        {
            BubbleButton bbtn = (BubbleButton)sender;
            Form frm;
            ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox(MessageBoxButtons.OKCancel);
            switch (bbtn.TooltipText)
            {
                case "退出": 
                    if (mesbox.ShowMessage("确定退出新疆电力公司管理人员模拟决策系统吗", "系统提示") == DialogResult.OK)
                    {
                        //PubVar.closeOrstart = true;
                        if (PubVar.closeOrstart == true)
                        {
                            if (PubVar.identify == 0) updateyxid();
                            string Order = "Quit" + "//" + PubVar.PlayerName.ToString() + "//" + MessageType.btnStartGame.ToString();
                            Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));
                            Application.Exit(); 
                        }
                        else
                            Application.Exit(); 
                }  
                    
                    break;
                case "系统注册": frm = new Form_Register(); frm.ShowDialog(); break;
                case "系统帮助": ; break;
                case "贴现": frm = new Form_Discount(); frm.ShowDialog(); break;
                case "变卖厂房": frm = new Form_SalePlant(); frm.ShowDialog(); break;
                case "购买厂房": frm = new Form_ByePlant(); frm.ShowDialog(); break;
                case "查看经营结果": PubVar.mark = 1; frm = new Form_ShowResult(); frm.ShowDialog(); break;
                case "查看经营业绩排名": frm = new Form_ShowRanking(); frm.ShowDialog(); break;
                case "查看英雄榜": frm = new  Form_pm();frm.ShowDialog() ; break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lbl_CurState.Location.X <= -69)
            {
                lbl_CurState.SetBounds(1103, lbl_CurState.Location.Y, lbl_CurState.Size.Width, lbl_CurState.Size.Height);
            }
            lbl_CurState.SetBounds(lbl_CurState.Location.X - 2, lbl_CurState.Location.Y, lbl_CurState.Size.Width, lbl_CurState.Size.Height);
            lbl_CurState.Refresh();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //金币初始
            p_jinbi.Visible = false;
            p_jinbi.Left = 260;
            p_jinbi.Top = 70;
            p_jinbi.Parent = pictureBox2;
            //认证初始
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            
            pictureBox25.Visible = false;
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;
            //BackgroundImage.Size=(1100,700);

            lbl_Cash.Parent = pictureBox2;
            lbl_Raccount4.Parent = pictureBox2;
            lbl_Raccount3.Parent = pictureBox2;
            lbl_Raccount2.Parent = pictureBox2;
            lbl_Raccount1.Parent = pictureBox2;
            lbl_Paccount4.Parent = pictureBox2;
            lbl_Paccount3.Parent = pictureBox2;
            lbl_Paccount2.Parent = pictureBox2;
            lbl_Paccount1.Parent = pictureBox2;
            lbl_Lloan.Parent = pictureBox2;
            lbl_Sloan.Parent = pictureBox2;
            
            pictureBox3.Parent = pictureBox2;
            pictureBox4.Parent = pictureBox2;
            pictureBox5.Parent = pictureBox2;
            pictureBox6.Parent = pictureBox2;
            pictureBox7.Parent = pictureBox2;
            pictureBox8.Parent = pictureBox2;
            pictureBox9.Parent = pictureBox2;
            pictureBox10.Parent = pictureBox2;


            l_anquan.Parent = pictureBox2;
            l_goudian.Parent = pictureBox2;
            l_guanli.Parent = pictureBox2;
            l_xiansun.Parent = pictureBox2;
            l_weixiu.Parent = pictureBox2;
            l_gongfu.Parent = pictureBox2;
            l_caibao.Parent = pictureBox2;
            l_zhejiu.Parent = pictureBox2;
            l_qita.Parent = pictureBox2;
            l_shuijin.Parent = pictureBox2;
            l_leiji.Parent = pictureBox2;
            l_cdlx.Parent = pictureBox2;
            l_ddlx.Parent = pictureBox2;
            l_yuanzhi.Parent = pictureBox2;
            l_zhejiu.Parent = pictureBox2;
            
            l_tiexian.Parent = pictureBox2;
            l_sbd.Parent = pictureBox2;
            l_fuhe.Parent = pictureBox2;
            label1.Parent = pictureBox2;
            label2.Parent = pictureBox2;
            label3.Parent = pictureBox2;
            label4.Parent = pictureBox2;
            label5.Parent = pictureBox2;
            label6.Parent = pictureBox2;
            label7.Parent = pictureBox2;
            label8.Parent = pictureBox2;
            label9.Parent = pictureBox2;
            label10.Parent = pictureBox2;
            pictureBox11.Parent = pictureBox2;
            pictureBox12.Parent = pictureBox2;
            pictureBox13.Parent = pictureBox2;
            pictureBox14.Parent = pictureBox2;
            pictureBox15.Parent = pictureBox2;
            pictureBox16.Parent = pictureBox2;
            pictureBox17.Parent = pictureBox2;
            pictureBox18.Parent = pictureBox2;
            pictureBox19.Parent = pictureBox2;
            pictureBox20.Parent = pictureBox2;
            pictureBox21.Parent = pictureBox2;
            pictureBox22.Parent = pictureBox2;
            pictureBox23.Parent = pictureBox2;
            pictureBox24.Parent = pictureBox2;

            pictureBox25.Parent = pictureBox2;
            pictureBox26.Parent = pictureBox2;
            pictureBox27.Parent = pictureBox2;

            lbl_Cash.BackColor = Color.Transparent;

            Bill bill = new Bill();
            bill.Amount = 14;
            bill.Price = 500;
            bill.Sum = bill.Amount*bill.Price/100;
            PubVar.bidCoalResult.Add(bill);

            InforLoad();
            Initial();
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void InforLoad()
        {
            





            //系统部分
            //lab_Company.Text = PubVar.CompanyName;
            //lab_Actor.Text = PubVar.Actor;
            //lab_CurTime.Text = "第" + PubVar.year.ToString() + "年";
            //财产部分
            //lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
            //lbl_Lloan.Text = Math.Round(PubVar.loanL).ToString()+"百万";
            //lbl_Sloan.Text = Math.Round(PubVar.loanS).ToString()+ "百万";

            //lbl_Raccount4.Text = Math.Round(PubVar.RaccountList[0] + PubVar.RaccountList[1] + PubVar.RaccountList[2] + PubVar.RaccountList[3] + PubVar.RaccountList[4]).ToString() + "百万";
            //lbl_Raccount4.Text = "22百万";
            //lbl_Paccount4.Text = Math.Round(PubVar.accountP).ToString()+"百万";
            //游动标签
            if (step == 0)
            {
                lbl_CurState.Text = "由于您的决策不当，企业倒闭！请继续努力";
            }
            else
            {
                lbl_CurState.Text = "正在决策：第" + PubVar.year + "年  第" + step + "步  " + listLklb[step - 1].Text;
            }
            int x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            for (int k = 0; k < Program.factory.IEquipment.Count; k++)
            {
                if (Program.factory.IEquipment[k].MachineType == 30 && Program.factory.IEquipment[k].Canuse == true)
                {
                    x1++;
                }
                if (Program.factory.IEquipment[k].MachineType == 60 && Program.factory.IEquipment[k].Canuse == true)
                {
                    x2++;
                }
                if (Program.factory.IEquipment[k].MachineType == 100 && Program.factory.IEquipment[k].Canuse == true)
                {
                    x3++;
                }
                if (Program.factory.IEquipment[k].MachineType == 100 && Program.factory.IEquipment[k].Canuse == true)
                {
                    x5++;
                }
            }
            for (int k = 0; k < Program.factory.IEquipment.Count; k++)
            {
                if (Program.factory.IEquipment[k].NitricEquipment.Canuse == true)
                {
                    x4++;
                }

            }
            if (x4 > 0)
            {
                PubVar.IsHaveNitric = true;
            }
            PubVar.equipment_10kw = x5;
            PubVar.equipment_30kw = x1;
            PubVar.equipment_60kw = x2;
            PubVar.equipment_100kw = x3;
            //PubVar.ddys = x1 * 2.37 + x2 * 4.73;
            //PubVar.ddys = 4.73;
            //新添
            //l_fuhe.Text = PubVar.ddys.ToString()+"亿千瓦时";
            //l_leiji.Text = "109百万" ;
            //l_yuanzhi.Text = "594百万";
            //label11.Text = PubVar.ddys.ToString() + "亿千瓦时";


            if (Program.factory.Certificate9000.Canuse)
            {
                pictureBox3.Visible = true;
                pictureBox10.Visible = false;
            }
            else
            {
                pictureBox3.Visible = false;
                pictureBox10.Visible = true;
            }
            if (Program.factory.Cerficate14000.Canuse)
            {
                pictureBox4.Visible = true;
                pictureBox9.Visible = false;
            }
            else
            {
                pictureBox4.Visible = false;
                pictureBox9.Visible = true;
            }
            if (Program.factory.Cerficate18000.Canuse)
            {
                
                pictureBox5.Visible = true;
                pictureBox8.Visible = false;
            }
            else
            {
                pictureBox5.Visible = false;
                pictureBox8.Visible = true;
            }
            if (Program.factory.CerficateSecurity.Canuse)
            {
                pictureBox6.Visible = true;
                pictureBox7.Visible = false;
            }
            else
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
            }
            
            
        }
        /// <summary>
        /// 初始化入库的订单和贷款，记录使用
        /// </summary>
        private void Initial()
        {
            Bill bidResult = new Bill();
            PubVar.BidEResult.Add(bidResult);
            PubVar.BidCResult.Add(bidResult);
            PubVar.scoreList = new List<double>(10);//修改为10年总成绩
            for (int i = 0; i < 10; i++)
            {
                PubVar.scoreList.Add(0);
            }
           
            LoanList loanList = new LoanList();
            PubVar.listBidResult = new List<string>();
            PubVar.closing = new List<Result>();
            InitialStatement();
        }
        private void InitialStatement()
        {
            Result result = new Result();
            double sss = 400;
            for (int i = 0; i < 4; i++)
                Program.factory.CerficateSecurity.Invesment(ref sss);
            //Program.factory.CerficateSecurity.Canuse = true;
            //Program.factory.CerficateSecurity.BuildTime = 4;
            //Program.factory.CerficateSecurity.MoneyProgress.Count = 0;

            result.Cc_fmt_attach = 2;//税金及附加，由0变2，修改1
            result.Cc_fmt_discount = 0;//贴现，看看
            result.Cc_fmt_insurance = 0;//财保费
            result.Cc_fmt_Linterest = 0;//长期利息费
            result.Cc_fmt_nitric = 0;//脱硫，iso，应保留iso
            result.Cc_fmt_powerRate = 0;//厂电费应无
            result.Cc_fmt_Sinterest = 0;//短期利息
            result.Cc_fmt_tax = 0;//所得税



            result.Cc_mbc_blowdown = 0;//排污费应无
            result.Cc_mbc_coal = 0;//燃煤应改为购电
            result.Cc_mbc_dep = 0;//折旧，应由10%变为5%
            result.Cc_mbc_entrust = 0;//委托运行费，应无
            result.Cc_mbc_material = 0;//材料费，应无
            result.Cc_mbc_oil = 0;//燃油，应无
            result.Cc_mbc_others = 0;//其他，应无
            result.Cc_mbc_repair = 0;//维修费
            result.Cc_mbc_water = 0;//水费，应无
            result.Cc_mbc_welfare = 0;//工福费，注意修改
            result.Cc_mbc_total = 0;//合计

            

            result.Cc_o_building = 0;//在建工程
            result.Cc_o_cash = 0;//现金
            result.Cc_o_Lloan = 0;//长期贷款
            result.Cc_o_Paccount = 0;//应付账款
            result.Cc_o_Raccount = 0;//应收账款
            result.Cc_o_saveCoal = 0;//存货，应无
            result.Cc_o_Sloan = 0;//短期贷款
            


            //损益表
            result.Pal_sale = 156;//售电收入，由267改为156，修改
            result.Pal_cost = 149;//主营业成本，由156改为149，修改
            result.Pal_attach = 2;//产品销售税金及附加，由3改为2，修改
            result.Pal_TBusProfit = 5;//主营业利润，由60改为5，修改
            result.Pal_financial = 5;//财务费用，由19改为5，修改
            result.Pal_busProfit = 0;//营业利润，由41改为0，修改
            result.Pal_profit = 0;//利润总额，由41改为0，修改
            result.Pal_tax = 0;//所得税，由10改为0，修改
            result.Pal_netProfit = 0;//净利润，由31改为0，修改

            
           
            //资产负债表
            //资产
            //流动资产
            result.Anl_proCash = 158;//现金，由85改为158，修改
            result.Anl_proRaccount = 22;//应收账款，由100改为22，修改
            result.Anl_proTLiquid = 180;//流动资产合计，由255改为180，修改
            //固定资产


            result.Anl_proTdevicevalueyuan = 594;//设备原值
            result.Anl_proDepreciationtotal = 109;//增加累计折旧为109
            result.Anl_proTdevicevalue = 485;//设备价值，由345改为485，修改
            result.Anl_proBuilding = 0;//在建工程
            result.Anl_proTSolid = 485;//固定资产合计，由345改为485，修改
            result.Anl_proTotal = 665;//资产总计，由600改为665，修改

            //负债及所有者权益

            result.Anl_debtSloan = 65;//短期贷款，由34改为65，（1年到期），修改
            result.Anl_debtPaccount = 25;//应付款，由0改为25，修改
            result.Anl_debtTax = 0;//应付税金，由10改为0，修改
            result.Anl_debtLloan = 75;//长期贷款，由200改为75，（10年到期），修改
           
            result.Anl_debtT = 165;//总负债，由244改为165，修改
            //权益
            result.Anl_rstock = 500;//股东资本，由300改为500，修改
            result.Anl_rprofitSave = 0;//利润留存，由25改为0，修改
            result.Anl_rNetprofit = 0;//本年净利，有31改为0，修改
            result.Anl_rightsT = 500;//所有者权益，由356改为500，修改
            result.Anl_rightsDebt = 665;//负债加权益，由600改为665
            //********************************************************
            result.Anl_proSave = 70;//存的是钱？
            result.Pal_manage = 13;//管理费用，应修改



            PubVar.closing.Add(result);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (!IsClick)
            //{
            //    tmp = pic.Size;
            //    point = pic.Location;
            //    PictrBxMaxMin temp = new PictrBxMaxMin(new PointF(0, 0), pic, 300);
            //    temp.PictureStretch();
            //    IsClick = true;
            //}
            //else
            //{
            //    pic.Location = point;
            //    pic.Size = tmp;
            //    IsClick = false;
            //}
        }
        #region//读取数据 梁添添加
        private delegate void AddStringDelegate(string str);//建立委托
        private void AddString(string str)
        {
            if (Program.Forms.frmSplash.lbl_AddString.InvokeRequired)
            {
                AddStringDelegate d = AddString;
                Program.Forms.frmSplash.lbl_AddString.Invoke(d, str);
            }
            else
            {
                Program.Forms.frmSplash.lbl_AddString.Text = str;
                Program.Forms.frmSplash.lbl_AddString.Refresh();
            }
        }
        ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
        public void connection()
        {      
            BillAdd billAdd = new BillAdd();
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Bill.mdb";
            OleDbConnection connection = new OleDbConnection(con);
            OleDbDataReader reader = default(OleDbDataReader);
            try
            {
                connection.Open();
                string sql = "select * from CapEleBill where year>=1 and year <=10 order by year,billnum";
                OleDbCommand command = new OleDbCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    billAdd = new BillAdd();
                    billAdd.year = int.Parse(reader["year"].ToString());
                    AddString("正在加载第"+billAdd.year+"年非竞价电量订单");
                    billAdd.amount = Convert.ToDouble(reader["amount"].ToString());//将amount改为double，修改
                    billAdd.billNum = int.Parse(reader["billNum"].ToString());
                    billAdd.yearLimit = int.Parse(reader["yearLimit"].ToString());
                    billAdd.price = Convert.ToDouble(reader["price"].ToString());
                    billAdd.sum = billAdd.price * billAdd.amount*100;
                    PubVar.CapEleBillAdd.Add(billAdd);
                }
                Program.Forms.frmSplash.prgX.Value += 30 ;
                reader.Close();
                command.CommandText = "select * from ComEleBill where year>=1 and year <=10 order by year,billnum";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    billAdd = new BillAdd();
                    billAdd.year = int.Parse(reader["year"].ToString());
                    AddString("正在加载第" + billAdd.year + "年电量订单");
                    billAdd.amount = Convert.ToDouble(reader["amount"].ToString());//将int类型的amount改为double，修改
                    billAdd.billNum = int.Parse(reader["billNum"].ToString());
                    billAdd.yearLimit = int.Parse(reader["yearLimit"].ToString());
                    billAdd.isNitric = (bool)reader["isNitric"];
                    billAdd.isISO = (bool)reader["isISO"];
                    //billAdd.cerficateType=(CerficateType)reader["CertificateType"];
                    PubVar.ComEleBillAdd.Add(billAdd);//加载电量订单
                }
                Program.Forms.frmSplash.prgX.Value += 30;
                reader.Close();
                command.CommandText = "select * from CoalBill";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    billAdd = new BillAdd();
                    billAdd.year = int.Parse(reader["year"].ToString());
                    //AddString("正在加载第" + billAdd.year + "年燃煤订单");
                    billAdd.amount = Convert.ToDouble(reader["amount"].ToString());//修改int类型amount为double，修改
                    billAdd.billNum = int.Parse(reader["billNum"].ToString());
                    billAdd.yearLimit = int.Parse(reader["yearLimit"].ToString());
                    PubVar.CoalBillAdd.Add(billAdd);
                }
                connect1();
                Program.Forms.frmSplash.prgX.Value = 100;
                Program.Forms.frmSplash.timer.Stop();
                Program.Forms.frmSplash.Close();
            }
            catch (Exception ex)
            {
                mesbox.ShowMessage(ex.Message, "提示");
            }
            finally
            {
                connection.Close();
            }
        }
        private void connect1()
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Computer1.mdb";
            PubVar.StartupPath = Application.StartupPath;
            OleDbConnection connection = new OleDbConnection(con);
            OleDbDataReader reader = default(OleDbDataReader);
            try
            {
                connection.Open();
                string sql = "select * from fit ";
                OleDbCommand command = new OleDbCommand(sql, connection);
                reader = command.ExecuteReader();
                TP1 tp;
                while (reader.Read())
                {
                    //回家修改
                    tp = new TP1();
                    tp.playerName = Convert.ToInt32((string)reader["playerID"]);
                    tp.yearID = Convert.ToInt32((string)reader["yearID"]);
                    tp.right = Convert.ToDouble((string)reader["right"]);
                    tp.profit = Convert.ToDouble((string)reader["profit"]);
                    PubVar.computerRights.Add(tp);
                }
                reader.Close();

                sql = "select * from Hero";
                totalPoint totalpoint;
                command.CommandText = sql;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totalpoint = new totalPoint();
                    totalpoint.playerName = (string)reader["playerName"];
                    totalpoint.totalpoint = Convert.ToDouble(Convert.ToString(reader["totalPoint"]));
                    totalpoint.createTime = (string)reader["createTime"];
                    PubVar.totalpoint.Add(totalpoint);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                mesbox.ShowMessage(ex.Message, "提示");
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (PubVar.t_diaoyong == 1)//安全罚款
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 27;
                p_jinbi.Top = p_jinbi.Top + 23;
                if (p_jinbi.Left == 800)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    PubVar.temp += 10;
                    l_qita.Text = PubVar.temp.ToString() + "百万";
                }
            }
            if (PubVar.t_diaoyong == 2)//安全投入
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 20;
                p_jinbi.Top = p_jinbi.Top + 1;
                if (p_jinbi.Left == 800)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    
                    l_qita.Text = PubVar.temp.ToString() + "百万";
                    l_anquan.Text = PubVar.Security.ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 3)//所得税
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 27;
                p_jinbi.Top = p_jinbi.Top + 25;
                if (p_jinbi.Left == 800)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_shuijin.Text = PubVar.closing[PubVar.year - 1].Pal_tax + "百万";
                    
                }
            }

            if (PubVar.t_diaoyong == 4)//应收账款
            {

                lbl_Raccount4.Top += 2;
                lbl_Raccount3.Top += 2;
                lbl_Raccount2.Top += 2;
                lbl_Raccount1.Top += 2;
                
                if (lbl_Raccount4.Top == 35)
                {
                    timer2.Stop();
                    lbl_Raccount4.Top = 11;
                    lbl_Raccount3.Top = 34;
                    lbl_Raccount2.Top = 60;
                    lbl_Raccount1.Top = 84;
                    double[] a = new double[5];//应付和应收

                    for (int i = 0; i < 5; i++)
                    {
                        a[i] = PubVar.RaccountList[i];
                    }

                    lbl_Raccount1.Text = Math.Round(a[0]).ToString() + "百万";
                    lbl_Raccount2.Text = Math.Round(a[1]).ToString() + "百万";
                    lbl_Raccount3.Text = Math.Round(a[2]).ToString() + "百万";
                    lbl_Raccount4.Text = Math.Round(a[3]).ToString() + "百万";
                    lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                    //lbl_Raccount1.Visible = false;
                    
                }
            }
            if (PubVar.t_diaoyong == 5)//应付账款
            {

                lbl_Paccount4.Top += 2;
                lbl_Paccount3.Top += 2;
                lbl_Paccount2.Top += 2;
                lbl_Paccount1.Top += 2;

                if (lbl_Paccount4.Top == 149)
                {
                    timer2.Stop();
                    lbl_Paccount4.Top = 125;
                    lbl_Paccount3.Top = 152;
                    lbl_Paccount2.Top = 175;
                    lbl_Paccount1.Top = 198;
                    double[] a = new double[5];//应付和应收
                    for (int i = 0; i < 5; i++)
                        a[i] = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        a[i] = PubVar.PaccountList[i];
                    }

                    lbl_Paccount1.Text = Math.Round(a[0]).ToString() + "百万";
                    lbl_Paccount2.Text = Math.Round(a[1]).ToString() + "百万";
                    lbl_Paccount3.Text = Math.Round(a[2]).ToString() + "百万";
                    lbl_Paccount4.Text = Math.Round(a[3]).ToString() + "百万";
                    lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                    //lbl_Raccount1.Visible = false;

                }
            }


            if (PubVar.t_diaoyong == 6)//长贷利息
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 22;
                p_jinbi.Top = p_jinbi.Top + 3;
                if (p_jinbi.Left == 480)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    if (PubVar.L_ljj != 0)
                    l_cdlx.Text = Math.Round(PubVar.L_ljj).ToString() + "百万";
                    lbl_Lloan.Text = Math.Round(PubVar.loanL).ToString() + "百万";
                    //lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                    lbl_Sloan.Text = "0百万";
                    if (Math.Round(PubVar.AnnualInterestS) != 0)
                        l_ddlx.Text = Math.Round(PubVar.AnnualInterestS).ToString() + "百万";
                    //frmLoan frm = new frmLoan(this);
                    //frm.ShowDialog();
                }
            }

            if (PubVar.t_diaoyong == 7)//短贷利息
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 16;
                p_jinbi.Top = p_jinbi.Top + 1;
                if (p_jinbi.Left == 580)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    
                }
            }

            

            

            if (PubVar.t_diaoyong == 8)//长贷
            {
                
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left -15;
                p_jinbi.Top = p_jinbi.Top + 5;
                if (p_jinbi.Left == 260)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                    

                }
            }

            if (PubVar.t_diaoyong == 9)//短贷
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left - 15;
                p_jinbi.Top = p_jinbi.Top -6;
                if (p_jinbi.Left == 260)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    //lbl_Sloan.Text = PubVar.loanS.ToString() + "百万";
                    lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 10)//交货
            {
                p_jinbi.Visible = true;
                
                p_jinbi.Top = p_jinbi.Top -= 33;
                if (p_jinbi.Top == 70)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;

                    lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 11)//购电
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left +55;
                p_jinbi.Top = p_jinbi.Top +9;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    
                }
            }

            if (PubVar.t_diaoyong == 12)//投资新设备
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 20;
                p_jinbi.Top = p_jinbi.Top + 1;
                if (p_jinbi.Left == 800)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_yuanzhi.Text = Math.Round(PubVar.Tdevicevalueyuan).ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 13)//认证
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 39;
                p_jinbi.Top = p_jinbi.Top + 18;
                if (p_jinbi.Left == 650)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    //l_anquan.Text = PubVar.Security.ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 14)//线损
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 55;
                p_jinbi.Top = p_jinbi.Top + 20;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_xiansun.Text = Math.Round(PubVar.EleIncome * 0.08).ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 15)//折旧
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 56;
                p_jinbi.Top = p_jinbi.Top + 10;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_leiji.Text = Math.Round(PubVar.depreciationtotal).ToString() + "百万";

                    l_zhejiu.Text = Math.Round(PubVar.depreciation).ToString() + "百万";
                }
            }

            if (PubVar.t_diaoyong == 16)//工福费
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 55;
                p_jinbi.Top = p_jinbi.Top + 30;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_gongfu.Text = Math.Round(50 * Math.Pow(1.05, PubVar.year - 1)).ToString() + "百万";
                }
            }


            if (PubVar.t_diaoyong == 17)//财保
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 55;
                p_jinbi.Top = p_jinbi.Top + 36;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_caibao.Text = Math.Round(PubVar.valueguarsanttee).ToString() + "百万";
                }
            }
            if (PubVar.t_diaoyong == 18)//维修
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 55;
                p_jinbi.Top = p_jinbi.Top + 25;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_weixiu.Text = Math.Round(PubVar.Cc_mbc_repair).ToString() + "百万";
                }
            }
            if (PubVar.t_diaoyong == 19)//管理费用
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 55;
                p_jinbi.Top = p_jinbi.Top + 14;
                if (p_jinbi.Left == 810)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_guanli.Text =  "5百万";
                }
            }
            if (PubVar.t_diaoyong == 20)//附加
            {
                p_jinbi.Visible = true;
                p_jinbi.Left = p_jinbi.Left + 27;
                p_jinbi.Top = p_jinbi.Top + 25;
                if (p_jinbi.Left == 800)
                {
                    timer2.Stop();
                    p_jinbi.Visible = false;
                    p_jinbi.Left = 260;
                    p_jinbi.Top = 70;
                    l_shuijin.Text = Math.Round(PubVar.closing[PubVar.year - 1].Pal_tax + PubVar.closing[PubVar.year].Cc_fmt_attach) + "百万";
                }
            }

            




        }

        


    }
}
