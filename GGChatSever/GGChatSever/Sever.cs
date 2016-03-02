using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
namespace GGChatSever
{
    public partial class Sever : Form
    {
        private EntryForm f1;
        public Sever(EntryForm f)
        {
            InitializeComponent();
            f1 = f;
            f1.Hide();//隐藏登录窗体
            TextBox.CheckForIllegalCrossThreadCalls = false;//多线程关闭文本框的检查
            this.ControlBox = false;//取消关闭按钮
            AcceptButton = btnSend;
        }
        void Message(string a)
        {

            txtMain.AppendText(DateTime.Now.ToString() + "\r\n" + a + "\r\n");
        }
        private string nickname;
        public string Nickname//昵称属性,已经获得值
        {
            get { return nickname; }
            set { nickname = value; }
        }
        private string account;
        public string Account//账户属性
        {
            get { return account; }
            set { account = value; }
        }
        private void Sever_Load(object sender, EventArgs e)//生成页面时自动获取本机的IP地址
        {
            GetIp get = new GetIp();
            IP.Text = get.getIp();
            txtAccount.Text = Account.Trim();
            txtNickName.Text = Nickname.Trim();
   
        }
       
        Socket Watch = null;
        void OpenThread()//绑定端口以后开的线程，用于监听
        {
            Thread begin = new Thread(Accept);//开启线程监听
            begin.IsBackground = true;
            begin.Start();
        }
        delegate void AsyncDelegate();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress address = IPAddress.Parse(IP.Text);//获取IP地址
                Watch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//确定套接字的各种属性
                IPEndPoint endpoint = new IPEndPoint(address, Convert.ToInt32(EndPoint.Text));//绑定IP地址和端口
                Watch.Bind(endpoint);//用套接字进行绑定
                Watch.Listen(1000);//确定挂起的套接字监听长度
                Message("服务端已开启");
                //下面的异步调用是用于对监听及接受的线程，因为如果登录成功的话，发送的端口会有所不一样。所以可以让它先执行完，成功的话
                //就可以进行下面一步，普通用于沟通的步骤
                //AsyncDelegate caller = new AsyncDelegate(OpenThread);//异步调用，调入消息方法
                //IAsyncResult result = caller.BeginInvoke(null, null);//开始执行，并阻塞其他线程
                //caller.EndInvoke(result);
                //MessageBox.Show("异步成功");
                OpenThread();//开始监听接受
            }
            catch
            {
                MessageBox.Show("套接字已存在，请另开辟端口");
            }
        }

        Socket con = null;//创建监听套接字
        Dictionary<string, Socket> DicClientSocket = new Dictionary<string, Socket>();//数据字典，存储客户端的信息和所对应的套接字
        Dictionary<string, Thread> DicClientThread = new Dictionary<string, Thread>();//存储客户端的IP地址和线程一一对应
        Dictionary<string, string> DicListNickNameIP = new Dictionary<string, string>();//存放昵称对应的IP
        //数据字典存放客户端的信息
        Dictionary<string, string> DicClientAccount = new Dictionary<string, string>();//客户端的IP和端口信息配合账户
        Dictionary<string, string> DicClientNickName = new Dictionary<string, string>();//客户端的昵称

      
        void Accept()//监听方法
        {

            while (true)
            {
                con = Watch.Accept();
                ParameterizedThreadStart receive = new ParameterizedThreadStart(Receive);//创建带参数的多线程
                Thread re = new Thread(receive);
                DicClientThread.Add(con.RemoteEndPoint.ToString(), re);//向字典中添加线程的方法，以便于在后边移除
                re.Start(con);
            }          
            
        }
        Socket recon = null;//用于接收消息的套接字
        void dic(string endpoint, string nickname)//向数据字典中写入昵称和端口的配对，并且要更新客户端的列表
        {
            DicClientNickName.Add(endpoint, nickname);
            DicListNickNameIP.Add(nickname, endpoint);
            DicClientSocket.Add(endpoint, recon);
            try
            {

                StringBuilder aboart=new StringBuilder();//将信息分开
                aboart.Append("listbox12321^"+Nickname.Trim()+"!"+ IP.Text.Trim()+":"+EndPoint.Text.Trim() +"*");
              
                for (int i= 0; i < ClientList.Items.Count; i++)
                {
                  
                         aboart.Append(ClientList.Items[i]+ "!" + endpoint + "*");
     
                }                
                byte[] ByteMessage = Encoding.UTF8.GetBytes(aboart.ToString());//将字符打包成字节发送
                foreach (string c in ClientList.Items)
                {
                    DicClientSocket[DicListNickNameIP[c]].Send(ByteMessage);//向指定的客户端发送信息
                }
            }
            catch
            {

            }
            

        }
        void clearmessage(string remote)
        {
            try
            {
                StringBuilder ClearClient = new StringBuilder();
                ClearClient.Append("listboxclearing^" + DicClientNickName[remote]);
                byte[] Messageclear = Encoding.UTF8.GetBytes(ClearClient.ToString());
                DicListNickNameIP.Remove(ClientList.Text);//清除昵称IP数据字典
                ClientList.Items.Remove(DicClientNickName[remote]);
                foreach (string item in ClientList.Items)
                {
                    DicClientSocket[DicListNickNameIP[item]].Send(Messageclear);
                }
                for (int i = 0; i < ClientList.Items.Count; i++)//防止有空项，去除空项
                {
                    if (ClientList.Items[i] == null)
                    {
                        ClientList.Items.Remove(ClientList.Items[i]);
                    }

                }
            }
            catch
            {
               
            }
        }//用于退出时发送的消息
        void clear()//数据字典的清除和listbox中的清除,并且给客户端更新信息
        {
            try
            {
                string remote = recon.RemoteEndPoint.ToString();
                clearmessage(remote);
                DicClientNickName.Remove(recon.RemoteEndPoint.ToString());//清除数据字典的昵称信息
                DicClientSocket.Remove(recon.RemoteEndPoint.ToString());//清除套接字        
            }
            catch
            {
             
            }
        }
        void Receive(object con)
        {
          
            while (true)
            {
                byte[] message = new byte[1024 * 1024*2];//确定一个2兆的字节组
                string ka;
                try
                {
                    recon = con as Socket;
                    int Count = recon.Receive(message);
                    string gg = Encoding.UTF8.GetString(message, 0, Count);
                    ka = recon.RemoteEndPoint.ToString();
                    if (gg.Contains("SqlEntryClientAccount*") || gg.Contains("SqlForgetClientAnswer*") || gg.Contains("SqlRegisterClienttxtShowA*") || gg.Contains("SqlRegisterClienttxtNickName*") || gg.Contains("SqlRegisterClienttxtRegister*") || gg.Contains("SqlClientStart*"))
                    {
                        #region 关于客户端登入界面发送账号传回密码信息
                        if (gg.Contains("SqlEntryClientAccount*"))//客户端登录，给客户端查找目的账号密码，登入界面
                        {
                            try
                            {
                                int i = gg.IndexOf('*');
                                int j = gg.Length;
                                string ClientAccount = gg.Substring(i + 1, j - i - 1).Trim();
                                string ipendpoint = recon.RemoteEndPoint.ToString();//获取客户端的IP地址和端口
                                string ip = ipendpoint;
                                SqlEntry dic = new SqlEntry(ClientAccount);
                                dic.NickName(ClientAccount);
                                string MessageEntryPasswordSend = "SqlEntryClientPasswordBack*" + dic.Password.Trim() + "*" + dic.Nickname.Trim();//发送客户端的信息（密码和昵称）
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageEntryPasswordSend);//将字符打包成字节发送
                                recon.Send(ByteMessage);//向指定的客户端发送信息
                            }
                            catch
                            {
                                string MessageEntryPasswordSend = "SqlEntryClientPasswordBackWrong*";
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageEntryPasswordSend);//将字符打包成字节发送
                                recon.Send(ByteMessage);//向指定的客户端发送信息
                                return;
                            }

                        }
                        #endregion
                        #region 关于客户端忘记密码界面的数据传输
                        if (gg.Contains("SqlForgetClientAnswer*"))
                        {
                            try
                            {
                                int i = gg.IndexOf('*');
                                int j = gg.Length;
                                string ClientAccount = gg.Substring(i + 1, j - i - 1).Trim();
                                SqlForget sf = new SqlForget();//获取密保的所有信息
                                sf.SeekQuestion(ClientAccount);
                                sf.SeekAnswer(ClientAccount);
                                sf.SeekQuestion(ClientAccount);
                                sf.SeekPassword(ClientAccount);

                                string MessageEntryPasswordSend = "SqlForgetClientBack*" + sf.Question1.Trim() + "*" + sf.Answer1.Trim() + "*" + sf.Password.Trim();//发送客户端的密保信息
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageEntryPasswordSend);//将字符打包成字节发送
                                recon.Send(ByteMessage);//向指定的客户端发送信息
                            }
                            catch
                            {
                                return;
                            }
                        }

                        #endregion
                        #region 客户端关于注册界面的数据传输
                        if (gg.Contains("SqlRegisterClienttxtShowA*"))//注册界面验证客户端账号是否存在
                        {
                            try
                            {
                                int i = gg.IndexOf('*');
                                int j = gg.Length;
                                string ClientAccount = gg.Substring(i + 1, j - i - 1).Trim();
                                SqlRegister reg = new SqlRegister();//获取账号信息
                                reg.SearchAccount(ClientAccount);
                                if (reg.Account != null)
                                {
                                    string MessageRegisterAccount = "SqlRegisterClienttxtShowABack*";//如果账号存在则发送账号信息
                                    byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegisterAccount);//将字符打包成字节发送
                                    recon.Send(ByteMessage);
                                }
                                else
                                {
                                    string MessageRegisterAccount = "SqlRegisterClienttxtShowABackWrong*";//如果账号存在则发送账号信息
                                    byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegisterAccount);//将字符打包成字节发送
                                    recon.Send(ByteMessage);//向指定的客户端发送信息
                                }
                            }
                            catch
                            {

                                string MessageRegisterAccount = "SqlRegisterClienttxtShowABackWrong*";//如果账号存在则发送账号信息
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegisterAccount);//将字符打包成字节发送
                                recon.Send(ByteMessage);//向指定的客户端发送信息
                                return;

                            }
                        }
                        if (gg.Contains("SqlRegisterClienttxtNickName*"))//注册界面验证客户端昵称是否存在
                        {
                            try
                            {
                                int i = gg.IndexOf('*');
                                int j = gg.Length;
                                string ClientNickName = gg.Substring(i + 1, j - i - 1).Trim();
                                SqlRegister reg = new SqlRegister();//获取账号信息
                                reg.SearchNickName(ClientNickName);
                                if (reg.Nickname != null)
                                {
                                    string MessageRegisterNickName = "SqlRegisterClienttxtNickNameBack*";//如果昵称存在则发送账号信息
                                    byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegisterNickName);//将字符打包成字节发送
                                    recon.Send(ByteMessage);
                                }
                                else
                                {
                                    string MessageRegisterNickName = "SqlRegisterClienttxtNickNameBackWrong*";//如果昵称不存在则发送账号信息
                                    byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegisterNickName);//将字符打包成字节发送
                                    recon.Send(ByteMessage);//向指定的客户端发送信息
                                }

                            }
                            catch
                            {

                                string MessageRegisterNickName = "SqlRegisterClienttxtNickNameBackWrong*";//如果昵称不存在则发送账号信息
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegisterNickName);//将字符打包成字节发送
                                recon.Send(ByteMessage);//向指定的客户端发送信息
                                return;
                            }
                        }
                        if (gg.Contains("SqlRegisterClienttxtRegister*"))//注册界面验证客户端昵称是否存在
                        {
                            try
                            {
                                int i = gg.IndexOf('*');
                                int j = gg.IndexOf('*', i + 1);
                                int q = gg.IndexOf('*', j + 1);
                                int w = gg.IndexOf('*', q + 1);
                                int t = gg.IndexOf('*', w + 1);
                                int l = gg.Length;
                                string ClientAccount = gg.Substring(i + 1, j - i - 1).Trim();
                                string ClientNickName = gg.Substring(j + 1, q - j - 1).Trim();
                                string ClientPassWord = gg.Substring(q + 1, w - q - 1).Trim();
                                string ClientQuestion = gg.Substring(w + 1, t - w - 1).Trim();
                                string ClientAnswer = gg.Substring(t + 1, l - t - 1).Trim();
                                SqlRegister reg = new SqlRegister();//获取账号信息
                                reg.Register(ClientAccount, ClientNickName, ClientPassWord, ClientQuestion, ClientAnswer);

                                string MessageRegister = "SqlRegisterClienttxtRegisterBack*";//如果注册成功则发送账号信息
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegister);//将字符打包成字节发送
                                recon.Send(ByteMessage);


                            }
                            catch
                            {

                                string MessageRegister = "SqlRegisterClienttxtRegisterBackWrong*";//如果登入不成功则发送错误信息
                                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageRegister);//将字符打包成字节发送
                                recon.Send(ByteMessage);//向指定的客户端发送信息
                                return;
                            }
                        }
                        #endregion
                        #region 在主窗体中添加消息
                        if (gg.Contains("SqlClientStart*"))//向listbox中添加昵称信息
                        {

                            int i = gg.IndexOf('*');
                            int j = gg.IndexOf(':');
                            int k = gg.Length;
                            string nickname = gg.Substring(i + 1, j - i - 1).Trim();
                            string saying = gg.Substring(j + 1, k - j - 1);
                            string combinesaying = nickname + ":" + saying;
                            if (ClientList.Items.Contains(nickname))
                            {
                                Message(combinesaying);
                                string MessageSend = "MainShow*^" + combinesaying;//选择要发送的信息
                                byte[] clientsendall = Encoding.UTF8.GetBytes(MessageSend);

                                foreach (string s in ClientList.Items)//将客户端发送的消息发送给所有人
                                {
                                    if (s != nickname)
                                        DicClientSocket[DicListNickNameIP[s].Trim()].Send(clientsendall);

                                }
                            }
                            else
                            {
                                ClientList.Items.Add(nickname);
                                dic(recon.RemoteEndPoint.ToString(), nickname);
                            }
                        }
                        #endregion
                    }
                    else//传输文件
                    {

                        try
                        {
                            if (checSendFile.Checked == true)
                            {
                                string savename = txtSaveName.Text.Trim();
                                FileStream write = new FileStream(savename, FileMode.Create);
                                write.Write(message, 0, Count);
                                MessageBox.Show("保存成功", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                write.Close();
                            }
                            if (checkSendAll.Checked == true&&checSendFile.Checked==true)
                            {
                                foreach (string c in ClientList.Items)
                                {
                                    if(c!=DicClientNickName[recon.RemoteEndPoint.ToString()])
                                    DicClientSocket[DicListNickNameIP[c].Trim()].Send(message);//所有客户端发送信息

                                }
                            }
                        }

                        catch
                        {

                        }
                    }
                }
             

                catch//退出的话便消除所在的信息
                {
                    clear();
                    return;
                }
             
            }
        }//接受消息的方法

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string MessageSend = "MainShow*^" + Nickname + ";" + txtSend.Text;//选择要发送的信息
                string messagesend = Nickname + ";" + txtSend.Text;
                txtSend.Text = null;//发送窗口为空
  
                byte[] ByteMessage = Encoding.UTF8.GetBytes(MessageSend);//将字符打包成字节发送
                if(checkSendAll.Checked==true&&checSendFile.Checked==false)
                {
                    Message(messagesend);//向主窗体中增加发送的信息
                foreach (string c in ClientList.Items)
                {
                    DicClientSocket[DicListNickNameIP[c].Trim()].Send(ByteMessage);//向指定的客户端发送信息
                  
                }
                }
                if (checSendFile.Checked == false && checkSendAll.Checked == false)
                {
                    Message(messagesend);//向主窗体中增加发送的信息
                    DicClientSocket[DicListNickNameIP[ClientList.Text].Trim()].Send(ByteMessage);
                }
                if (checkSendAll.Checked == false && checSendFile.Checked==true)//发送文件
              {
                  string  txtsendfilepath = null;
                    OpenFileDialog open = new OpenFileDialog();
                    open.Title = "请选择要发送的文件";
                    open.ShowReadOnly = true;
                    open.Filter = "所有文件类型|*.*|图片(*.jpg)|*.jpg|图片(*.jpg)|*.jpg|影片(*.RMVB)|*.RMVB|影片(*.MKV)|*.MKV";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        txtsendfilepath= open.FileName;
                    }
                    using (FileStream file = new FileStream(txtsendfilepath, FileMode.Open))
                    {
                        byte[] send = new byte[1024 * 1024 * 2];
                        int s = file.Read(send, 0, send.Length);
                        byte[] sendmessage = new byte[s];
                        Buffer.BlockCopy(send, 0, sendmessage, 0, s);
                        DicClientSocket[DicListNickNameIP[ClientList.Text].Trim()].Send(sendmessage);
                    }
                }
                if (checkSendAll.Checked == true && checSendFile.Checked == true)//群发文件
                {
                    string txtsendfilepath = null;
                    OpenFileDialog open = new OpenFileDialog();
                    open.Title = "请选择要发送的文件";
                    open.ShowReadOnly = true;
                    open.Filter = "所有文件类型|*.*|图片(*.jpg)|*.jpg|图片(*.jpg)|*.jpg|影片(*.RMVB)|*.RMVB|影片(*.MKV)|*.MKV";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        txtsendfilepath = open.FileName;
                    }
                    using (FileStream file = new FileStream(txtsendfilepath, FileMode.Open))
                    {
                        byte[] send = new byte[1024 * 1024 * 2];
                        int s = file.Read(send, 0, send.Length);
                        byte[] sendmessage = new byte[s];
                        Buffer.BlockCopy(send, 0, sendmessage, 0, s);
                        foreach (string c in ClientList.Items)
                        {
                            DicClientSocket[DicListNickNameIP[c].Trim()].Send(sendmessage);//向指定的客户端发送信息

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选择要发送的对象", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();//关闭程序，结束进程，避免进程依然存在
        }

    }
}
