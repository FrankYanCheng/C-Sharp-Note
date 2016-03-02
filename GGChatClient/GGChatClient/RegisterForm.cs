using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GGChatClient
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        #region 客户端所需的信息
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
        private string question;

        public string Question
        {
            get { return question; }
            set { question = value; }
        }
        private string answer;

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        #endregion
        private string ip;
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string endpoint;
        public string Endpoint
        {
            get { return endpoint; }
            set { endpoint = value; }
        }
        ClientMessage clientmessage = new ClientMessage();
        Socket ClientCon = null;
        void receiveAccount()
        {
          
            while (true)
            {
                byte[] remessage = new byte[1024 * 1024 * 2];
                int k = ClientCon.Receive(remessage);
                string gg = System.Text.Encoding.UTF8.GetString(remessage, 0, k);
                try
                {
                    if (gg.Contains("SqlRegisterClienttxtShowABack*"))//在服务端查到该信息
                    {
                        txtShowA.Text = "账号已注册";
                    }

                    if (gg.Contains("SqlRegisterClienttxtShowABackWrong*"))
                    {
                        txtShowA.Text = "账号可以使用";
                        //break;//节省资源，避免一直消耗资源

                    }
                }
                catch
                {
                }

             
            }
        }//接受检测账号是否已注册的方法
        void receiveNickName()//接受检测昵称是否存在的方法
        {
           
            while (true)
            {
                byte[] remessage = new byte[1024 * 1024];
                int k = ClientCon.Receive(remessage);
                string gg = System.Text.Encoding.UTF8.GetString(remessage, 0, k);
                try
                {
                 
                    if (gg.Contains("SqlRegisterClienttxtNickNameBack*"))//在服务端查到该信息
                    {
                        txtShow.Text = "昵称已存在";
                    }

                    if (gg.Contains("SqlRegisterClienttxtNickNameBackWrong*"))
                    {
                        txtShow.Text = "昵称可以使用";
                 

                    }
                }
                catch
                {
                }

                }

            }
        //接受检测账号是否已注册的方法
        void receiveRegister()
        {
            while (true)
            {
                
                byte[] remessage = new byte[1024 * 1024];
                int k = ClientCon.Receive(remessage);
                string gg = System.Text.Encoding.UTF8.GetString(remessage, 0, k).Trim();
                 if (gg.Contains("SqlRegisterClienttxtRegisterBack*"))//在服务端查到该信息
                    {
                       
                        MessageBox.Show("注册成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    }

                    if (gg.Contains("SqlRegisterClienttxtRegisterWrong*"))
                    {
                        MessageBox.Show("注册失败，请重新", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtShowA.Text == "账号可以使用" && txtShow.Text == "昵称可以使用"&&txtAccount.Text!=null&&txtNickName.Text!=null)
            {
                if (txtPad.Text == txtRePad.Text)
                {

                    IPAddress Address = IPAddress.Parse(Ip);
                    IPEndPoint endpoint = new IPEndPoint(Address, int.Parse(Endpoint.Trim()));
                    ClientCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ClientCon.Connect(endpoint);//绑定端口，进行连接
                    string sqlAccount = "SqlRegisterClienttxtRegister*" + txtAccount.Text.Trim() + "*" + txtNickName.Text.Trim() + "*" + txtPad.Text.Trim() + "*" + txtQuestion.Text.Trim() + "*" + txtAnswer.Text.Trim();//发送注册信息
                    byte[] messagebyte = Encoding.UTF8.GetBytes(sqlAccount);//将信息转化为字节组
                    ClientCon.Send(messagebyte);//发送
                    Thread AccountThread = new Thread(receiveRegister);
                    AccountThread.IsBackground = true;
                    AccountThread.Start();
                }
                else
                {
                    MessageBox.Show("密码输入不正确", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请先确保账号和昵称未被使用", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void txtShow_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void txtAccountTest_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress Address = IPAddress.Parse(Ip);
                IPEndPoint endpoint = new IPEndPoint(Address, int.Parse(Endpoint.Trim()));
                ClientCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientCon.Connect(endpoint);//绑定端口，进行连接
                string sqlAccount = "SqlRegisterClienttxtShowA*" + txtAccount.Text.Trim();//发送账号
                byte[] messagebyte = Encoding.UTF8.GetBytes(sqlAccount);//将信息转化为字节组
                ClientCon.Send(messagebyte);//发送
                Thread AccountThread = new Thread(receiveAccount);
                AccountThread.IsBackground = true;
                AccountThread.Start();
            }
            catch
            {
                 MessageBox.Show("输入的信息有误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//检测账号是否可用

        private void txtNickTest_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress Address = IPAddress.Parse(Ip);
                IPEndPoint endpoint = new IPEndPoint(Address, int.Parse(Endpoint.Trim()));
                ClientCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientCon.Connect(endpoint);//绑定端口，进行连接
                string sqlNickname = "SqlRegisterClienttxtNickName*" + txtNickName.Text.Trim();//发送昵称信息           
                byte[] messagebyte = Encoding.UTF8.GetBytes(sqlNickname);//将信息转化为字节组
                ClientCon.Send(messagebyte);//发送
                Thread AccountThread = new Thread(receiveNickName);
                AccountThread.IsBackground = true;
                AccountThread.Start();
            }
            catch
            {
                MessageBox.Show("输入的信息有误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
