using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace GGChatClient
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            this.AcceptButton = btnEntry;
        }
        private string account;
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string nickname;
        public  string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        Socket ClientCon = null;
        byte[] data = new byte[1024 * 1024 * 2];//异步字节组大小
        int size = 1024 * 1024 * 2;
        delegate void AsyncDelegate();//声明委托，用于异步调用
        /// <summary>
        /// 连接回调方法
        /// </summary>
        /// <param name="iar"></param>
        void connect(IAsyncResult iar)
        {
          Socket ClientCon=(Socket)iar.AsyncState;
          try
          {
              ClientCon.EndConnect(iar);
              string sqlAccount = "SqlEntryClientAccount*" + txtAccount.Text.Trim();//赋值给sqlAccount账号以确定密码
              byte[] messagebyte = Encoding.UTF8.GetBytes(sqlAccount);//将信息转化为字节组
              ClientCon.BeginSend(messagebyte, 0, messagebyte.Length, SocketFlags.None, new AsyncCallback(SendData), ClientCon);

          }
          catch
          {

          }

        }
        /// <summary>
        /// 发送方法
        /// </summary>
        /// <param name="iar"></param>
        void SendData(IAsyncResult iar)
        {
            Socket ClientConw= (Socket)iar.AsyncState;
            int sendsize=ClientConw.EndSend(iar);
           ClientConw.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), ClientConw);


        }
       static int testing = 0;//判断是否结束调用
       static string k;
        /// <summary>
        /// 赋值方法
        /// </summary>
        /// <param name="name">给Nickname赋值，用于不同线程之间</param>
    
        /// <summary>
        /// 接受方法
        /// </summary>
        /// <param name="iar"></param>
         void  ReceiveData(IAsyncResult iar)
        {
            try
            {
                Socket ClientCon = (Socket)iar.AsyncState;
                int rec = ClientCon.EndReceive(iar);
                string gg = System.Text.Encoding.UTF8.GetString(data, 0, rec);
                if (gg.Contains("SqlEntryClientPasswordBack*"))//传回密码
                {
                    int i = gg.IndexOf('*');
                    int j = gg.Length;//获取字符串长度
                    int t = gg.IndexOf('*', i + 1);//查找第二个*的位置
                    Password = gg.Substring(i + 1, t - i - 1).Trim();//获取密码
                   string name = gg.Substring(t + 1, j - t - 1).Trim();//获取昵称
                   Nickname = name;
                    if (Password == txtPad.Text.Trim())//从服务端传送来的密码与文本框中的配对成功，可以进入下一个界面
                    {
                     
                       testing= 1;

                    }
                }

                if (gg.Contains("SqlEntryClientPasswordBackWrong*"))
                {
                    MessageBox.Show("输入的信息有误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                   
                }


              
            }
            catch
            {
               
                
            }
        }
        /// <summary>
        /// 用于异步等待的方法
        /// </summary>
       void open()
       {
           while (true)
           {
               if (testing == 1)
               {
                 
                   break;
               }
           }

       }
        /// <summary>
        /// 调用异步等待的线程
        /// </summary>
       void EntryThread()
       {
           Thread start = new Thread(open);
           start.IsBackground = true;
           start.Start();
       }
        private void btnEntry_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress Address = IPAddress.Parse(txtIP.Text);
                IPEndPoint endpoint = new IPEndPoint(Address, int.Parse(txtEndPoint.Text.Trim()));
                ClientCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientCon.BeginConnect(endpoint, new AsyncCallback(connect), ClientCon);
                AsyncDelegate caller = new AsyncDelegate(EntryThread);//异步调用，调入消息方法
                IAsyncResult result = caller.BeginInvoke(null,null);//开始执行，并阻塞其他线程
                caller.EndInvoke(result);
                Client start = new Client(this);//准备开启窗体
                start.Nickname = Nickname;//给新窗体中的文本框附昵称
                start.Ip = txtIP.Text.Trim();
                start.Endpoint = txtEndPoint.Text.Trim();
                start.Show();
             
              
            }
            catch
            {
                MessageBox.Show("与服务端的连接未成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetFormcs fg = new ForgetFormcs();//生成一个忘记页面的界面
            fg.Account = txtAccount.Text.Trim();//将用户名赋给忘记界面
            fg.Ip = txtIP.Text.Trim();//将IP和端口传给它
            fg.Endpoint = txtEndPoint.Text.Trim();
            fg.Show();  //显示页面
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Ip = txtIP.Text.Trim();
            register.Endpoint = txtEndPoint.Text.Trim();
            register.Show();
           
        }
    }
}
