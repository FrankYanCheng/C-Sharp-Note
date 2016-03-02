using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
namespace GGChatClient
{
    public partial class ForgetFormcs : Form
    {
        public ForgetFormcs()
        {
            InitializeComponent();
            this.AcceptButton = btnForget;
        }
        private string account;
        public string Account//获取账号
        {
            get { return account; }
            set { account = value; }
        }
        private string ip;//获取服务器的IP地址
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string endpoint;//绑定的端口
        public string Endpoint
        {
            get { return endpoint; }
            set { endpoint = value; }
        }
        private string question;//问题
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
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        delegate void fgdelegate();
        Socket ClientCon = null;
        void receive()//接受方法
        {
            while (true)
            {
                byte[] remessage = new byte[1024 * 1024 * 2];
                int k = ClientCon.Receive(remessage);
                string gg = System.Text.Encoding.UTF8.GetString(remessage, 0, k);
                try
                {
                    if (gg.Contains("SqlForgetClientBack*"))//传回来的信息
                    {
                        int i = gg.IndexOf('*');
                        int j = gg.IndexOf('*', i + 1);
                        int q = gg.IndexOf('*', j + 1);
                        int z = gg.Length;
                        Question = gg.Substring(i + 1, j - i - 1).Trim();
                        txtQuestion.Text = Question;
                        Answer = gg.Substring(j + 1, q - j - 1).Trim();
                        Password = gg.Substring(q + 1, z - q - 1).Trim();
                        break;
                    }
                }
                catch
                {
                    MessageBox.Show("该账户不存在", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnForget_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Trim() == Answer)
            {
                MessageBox.Show("密码是" + Password.Trim()+ "下次不要忘记了哦", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("回答错误！", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ForgetFormcs_Load(object sender, EventArgs e)
        {
            txtAccount.Text = Account;
        }
        void receivethread()//装载了接收方法线程的方法，用于异步调用
        {
            Thread th = new Thread(receive);
            th.IsBackground = true;
            th.Start();
        }
        private void btnGetQuestion_Click(object sender, EventArgs e)
        {
            try
            {

                IPAddress Address = IPAddress.Parse(Ip);
                IPEndPoint endpoint = new IPEndPoint(Address, int.Parse(Endpoint.Trim()));
                ClientCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientCon.Connect(endpoint);//绑定端口，进行连接
                string sqlAccount = "SqlForgetClientAnswer*" + txtAccount.Text.Trim();//赋值给sqlAccount账号以确定密保问题
                byte[] messagebyte = Encoding.UTF8.GetBytes(sqlAccount);//将信息转化为字节组
                ClientCon.Send(messagebyte);//发送
                fgdelegate caller = new fgdelegate(receivethread);//阻塞其他线程，直到方法结束
                IAsyncResult result= caller.BeginInvoke(null, null);
                 caller.EndInvoke(result);
                txtQuestion.Text= Question;
                EntryForm F = new EntryForm();
            
            }
            catch
            {
                MessageBox.Show("与服务器连接未成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
