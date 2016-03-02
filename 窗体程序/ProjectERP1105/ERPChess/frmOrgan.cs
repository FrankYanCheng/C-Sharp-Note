using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LSGO.PresentationLayer;
using LSGO.DataLinkLayer.NetControl;
using System.Net;
using DevComponents.DotNetBar;
using System.IO;
using System.Timers;
using System.Net.Sockets;
using System.Threading;
using DevComponents.DotNetBar.Controls;
using System.Data.OleDb;

namespace ERPChess
{
    public partial class frmOrgan : LSGOfrmBasement
    {
        private List<PictureBox> PicBoxLst;
        private List<GroupPanel> GrpLst;
        Point mousePoint;
        public frmOrgan()
        {
            InitializeComponent();
        }
        private void frmOrgan_Load(object sender, EventArgs e)
        {
            PicBoxLst = new List<PictureBox>();
            GrpLst = new List<GroupPanel>();
            PicBoxLst.Add(pic_0);
            PicBoxLst.Add(pic_1);
            PicBoxLst.Add(pic_2);
            PicBoxLst.Add(pic_3);
            PicBoxLst.Add(pic_4);
            PicBoxLst.Add(pic_5);
            ChangePic("pic_0", "2.jpg");
            grp_0.Text = PubVar.PlayerName;

            GrpLst = new List<GroupPanel>();
            GrpLst.Add(grp_0);
            GrpLst.Add(grp_1);
            GrpLst.Add(grp_2);
            GrpLst.Add(grp_3);
            GrpLst.Add(grp_4);
            GrpLst.Add(grp_5);
            this.grp_0.Text = PubVar.PlayerName.ToString();
            this.lblIP.Text = Program.client.IP_Address.ToString();
        }

        /*主键生成器，生成游戏ID单例类*/
        public class IdentityGenerator
        {
            static long lastIdentity = 0;
            static IdentityGenerator o = new IdentityGenerator();
            public static IdentityGenerator getInstanse()
            {
                if (o != null)
                    return o;
                else
                    return new IdentityGenerator();
            }
            public string NextIdentity()
            {
                long idint = DateTime.Now.Ticks - new DateTime(2013, 7, 1).Ticks;

                while (lastIdentity >= idint)
                {
                    idint++;
                }
                lastIdentity = idint;

                return idint.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 梁添 2012-10-26 修改
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonX btn = (ButtonX)sender;
                switch (btn.Name)
                {
                    case "btnCreate":

                        //modify by tianxin 发起者服务器端生成游戏ID
                        OleDbConnection cn = ERPLibrary.DataAClass.getInstanse().getDAO();
                        try
                        {

                            //string sql = "select YXID from yxxxb where FQZIP = '" + Program.server.IP_Address + "' and YXYXBZ = 'Y'";
                            //OleDbCommand cmd = new OleDbCommand(sql, cn);
                            cn.Open();
                            string sqlb = "UPDATE yxxxb set YXYXBZ = 'N' where FQZIP = '" + Program.server.IP_Address + "' and YXYXBZ = 'Y'";
                            OleDbCommand cmdb = new OleDbCommand(sqlb, cn);

                            cmdb.ExecuteNonQuery();
                            //OleDbDataReader result = cmd.ExecuteReader();

                            //if (!result.Read())
                            //{
                            string yxid = IdentityGenerator.getInstanse().NextIdentity();
                            string sql1 = "INSERT INTO yxxxb (YXID,FQRYMC,FQZIP,YXYXBZ,YXSJ) " +
                                          "VALUES ('" + yxid + "','" + PubVar.PlayerName + "','" + Program.server.IP_Address + "','Y','" + DateTime.Now.ToString() + "')";
                            OleDbCommand cmd1 = new OleDbCommand(sql1, cn);

                            cmd1.ExecuteNonQuery();
                            PubVar.YXID = yxid;

                            //}
                            //else
                            //{

                            //    ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                            //    mesbox.ShowMessage("该终端已经作为服务器且有游戏正在运行，不能再次创建游戏！", "提示");
                            //    break;
                            //}
                            //result.Close();
                        }
                        catch (Exception ex)
                        {
                            ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                            mesbox.ShowMessage(ex.Message, "提示");
                        }
                        finally
                        {
                            cn.Close();
                        }
                        //end

                        PubVar.identify = 0;
                        Program.server.ServerServerName = PubVar.PlayerName;
                        Program.server.ServerHost = new NetServerHost(CallbackThreadType.ctIOThread, Program.server.socketService);
                        Program.server.creator = Program.server.ServerHost.AddListener("Server", new IPEndPoint(IPAddress.Parse(Program.server.IP_Address), Int32.Parse(Program.server.Port)));
                        Program.server.ServerNet = new ServerFacade(Program.server.ServerHost, Program.server.creator, new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
                        Program.server.ServerNet.Start();

                        string JoinIp1 = Program.client.IP_Address;
                        Program.client.ClientServerName = PubVar.PlayerName;
                        Program.client.ClientHost = new NetClientHost(CallbackThreadType.ctIOThread, Program.client.socketService);
                        Program.client.creator = Program.client.ClientHost.AddConnector("Client", new IPEndPoint(IPAddress.Parse(JoinIp1), Int32.Parse(Program.client.Port)));
                        Program.client.ClientNet = new ClientFacade(Program.client.ClientHost, Program.client.creator, new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
                        Program.client.ClientNet.Start();

                        SetTextInfo("已经建立游戏，正等待决策者进入！" + "\r\n");
                        this.btnJoin.Enabled = false;
                        this.ipBox1.Enabled = false;
                        this.btnCreate.Enabled = false;
                        this.btnStartGame.Enabled = true;
                        break;
                    case "btnJoin":

                        PubVar.identify = 1;
                        string JoinIp = ipBox1.IP.ToString();

                        //modify by tianxin 客户端取游戏ID
                        OleDbConnection cna = ERPLibrary.DataAClass.getInstanse().getDAO();
                        try
                        {
                            cna.Open();
                            string sqla = "select YXID from yxxxb where FQZIP = '" + JoinIp + "' and YXYXBZ = 'Y'";
                            DataSet mydataset = new DataSet();
                            OleDbDataAdapter myadapter = new OleDbDataAdapter(sqla, cna);
                            myadapter.Fill(mydataset, "yxxxb");
                            PubVar.YXID = mydataset.Tables[0].Rows[0][0].ToString();
                        }
                        catch (Exception ex)
                        {
                            ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                            mesbox.ShowMessage(ex.Message, "提示");
                        }
                        finally
                        {
                            cna.Close();
                        }
                        //end

                        Program.client.ClientServerName = PubVar.PlayerName;
                        Program.client.ClientHost = new NetClientHost(CallbackThreadType.ctIOThread, Program.client.socketService);
                        Program.client.creator = Program.client.ClientHost.AddConnector("Client", new IPEndPoint(IPAddress.Parse(JoinIp), Int32.Parse(Program.client.Port)));
                        Program.client.ClientNet = new ClientFacade(Program.client.ClientHost, Program.client.creator, new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
                        Program.client.ClientNet.Start();
                        this.btnCreate.Enabled = false;
                        this.btnJoin.Enabled = false;
                        this.ipBox1.Enabled = false;
                        break;
                    case "btnStartGame":
                        PubVar.closeOrstart = true;
                        if (PubVar.identify == 0)//服务器发送指令
                        {
                            //回家修改
                            if (PubVar.playCount < 6)
                            {
                                List<int> list = new List<int>();
                                //Random random = new Random();
                                for (int i = 0; i < 6 - PubVar.playCount; i++)
                                {
                                    int d = i + 1;//random.Next(1, 7);
                                    list.Add(d);
                                }
                                string order = MessageType.computerCount.ToString();
                                for (int i = 0; i < 6 - PubVar.playCount; i++)
                                {
                                    order += "//" + list[i].ToString();
                                }
                                Program.server.ServerNet.BeginSend(Encoding.Unicode.GetBytes(order));
                            }
                            else
                            {
                                PubVar.closeOrstart = true;
                                string Order = MessageType.frmOrgan.ToString() + "//" + MessageType.btnStartGame.ToString();
                                Program.server.ServerNet.BeginSend(Encoding.Unicode.GetBytes(Order));//梁添2012-10-26 添加代码
                            }
                        }
                        Program.players = new ERPLibrary.players(6 - PubVar.playCount);
                        //Program.players = new ERPLibrary.players(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                mesbox.ShowMessage(ex.Message, "提示");
            }
        }

        #region 方法

        /// <summary>
        /// 改变PictureBox中的图片
        /// </summary>
        /// <param name="pb">控件名</param>
        /// <param name="picName">图片名称</param>
        public void ChangePic(string PicBoxName, string picName)
        {
            PictureBox pb = GetPicBox(PicBoxName);
            string WorkPath = Environment.CurrentDirectory.ToString();
            string FilePath = Environment.CurrentDirectory.ToString() + "\\" + picName.ToString();
            if (File.Exists(FilePath))
            {
                pb.Image = Image.FromFile(FilePath);
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 改变GroupPanel中的图片
        /// </summary>
        /// <param name="GrpName">控件名</param>
        /// <param name="TextName">显示文字</param>
        public void ChangeGrp(string GrpName, string TextName)
        {
            try
            {
                GroupPanel pb = GetGrp(GrpName);
                SetTextGrp(pb.Name.ToString(), TextName.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }
        private delegate void SetTextDelet1(string Name, string text);
        private void SetTextGrp(string GrpName,string str)
        {
            if (this.txtBox_Info.InvokeRequired)
            {
                SetTextDelet1 DelSet = new SetTextDelet1(SetTextGrp);
                if (GrpName == "grp_0")
                {
                    this.grp_0.Invoke(DelSet, new object[] { GrpName, str });
                }
                if (GrpName == "grp_1")
                {
                    this.grp_1.Invoke(DelSet, new object[] { GrpName, str });
                }
                if (GrpName == "grp_2")
                {
                    this.grp_2.Invoke(DelSet, new object[] { GrpName, str });
                }
                if (GrpName == "grp_3")
                {
                    this.grp_3.Invoke(DelSet, new object[] { GrpName, str });
                }
                if (GrpName == "grp_4")
                {
                    this.grp_4.Invoke(DelSet, new object[] { GrpName, str });
                }
                if (GrpName == "grp_5")
                {
                    this.grp_5.Invoke(DelSet, new object[] { GrpName, str });
                } 
            }
            else
            {
                if (GrpName == "grp_0")
                {
                    this.grp_0.Text = str;
                }
                if (GrpName == "grp_1")
                {
                    this.grp_1.Text = str;
                }
                if (GrpName == "grp_2")
                {
                    this.grp_2.Text = str;
                }
                if (GrpName == "grp_3")
                {
                    this.grp_3.Text = str;
                }
                if (GrpName == "grp_4")
                {
                    this.grp_4.Text = str;
                }
                if (GrpName == "grp_5")
                {
                    this.grp_5.Text = str;
                } 
            }
        }

        private delegate void SetTextDele(string str);
        private void SetTextInfo(string str)
        {
            if (this.txtBox_Info.InvokeRequired)
            {
                SetTextDele DelSet = new SetTextDele(SetTextInfo);
                this.txtBox_Info.Invoke(DelSet, new object[] { str });
            }
            else
            {
                if (this.txtBox_Info.Text.Length > 2900)
                    this.txtBox_Info.Text = string.Empty;
                this.txtBox_Info.AppendText(str);
            }
        }

        private GroupPanel GetGrp(string GrpName)
        {
            if (GrpLst != null)
            {
                foreach (GroupPanel grp in GrpLst)
                {
                    if (grp.Name == GrpName)
                    {
                        return grp;
                    }
                }
            }
            return null;
        }

        private PictureBox GetPicBox(string PicBoxName)
        {
            if (PicBoxLst != null)
            {
                foreach (PictureBox pb in PicBoxLst)
                {
                    if (pb.Name == PicBoxName)
                    {
                        return pb;
                    }
                }
            }
            return null;
        }

        #endregion

        private void groupPanel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SetBounds(this.Location.X + e.X - mousePoint.X, this.Location.Y + e.Y - mousePoint.Y, this.Width, this.Height);
            }
        }

        private void groupPanel3_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void frmOrgan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!PubVar.closeOrstart)
            {
                Environment.Exit(0);
            }
        }
    }
}
