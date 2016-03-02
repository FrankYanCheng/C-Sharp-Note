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

namespace GGChatClient
{
    public partial class Client : Form
    {
        private EntryForm f1;
        public Client(EntryForm f)
        {
            f1 = f;
            f.Hide();
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;//多线程关闭文本框的检查
            this.ControlBox = false;
            AcceptButton = btnSend;
        }
        private string nickname;
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }//获得昵称属性
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
        Socket ClientCon = null;
        /// <summary>
        /// 输入在文本框中的信息
        /// </summary>
        /// <param name="k"></param>
        void message(string k)//消息方法
        {
            txtMain.AppendText(DateTime.Now.ToString() + "\r\n" + k + "\r\n");
        }
        Dictionary<string, string> DicListNickNameIP = new Dictionary<string, string>();//存放昵称对应的IP
        Dictionary<string, string> DicClientNickName = new Dictionary<string, string>();//客户端的昵称
        void dic(string nickname, string endpoint)//字典方法
        {

            for (int i = 0; i < listBox1.Items.Count; i++)//防止有空项，去除空项
            {
                if (listBox1.Items[i] == null)
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                }

            }
            DicClientNickName.Add(endpoint,nickname);
            DicListNickNameIP.Add(nickname, endpoint);
        }
        void addlist(string name)//listbox中的添加方法
        {
            try
            {
                listBox1.Items.Add(name);
            }
            catch
            {
            }
        }
        void removedic(string nickname)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)//防止有空项，去除空项
            {
                if (listBox1.Items[i] == null)
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                }

            }
            DicClientNickName.Remove(DicListNickNameIP[nickname]);
            DicListNickNameIP.Remove(nickname);
        }//清除字典方法
        void removelist(string name)
        {
            try
            {
                listBox1.Items.Remove(name);
            }
            catch
            {
                message("删除错误");
            }
        }

        void Mainmessage(string mes)//用于添加昵称
        {
            try
            {
                listBox1.Items.Clear();
                int ff = mes.IndexOf('^');
                string start = mes.Substring(ff + 1, mes.Length - ff - 1).Trim();
                string[] Astart = start.Split('*');//获取一串昵称和终结点
                string[] Cstart = new string[2];
                for (int i = 0; i < Astart.Length; i++)
                {
                    string Bstart = Astart[i].Trim();
                    int gf = Bstart.IndexOf("!");
                    Cstart[0] = Bstart.Substring(0, gf);
                    Cstart[1] = Bstart.Substring(gf + 1, Bstart.Length - gf - 1);
                    addlist(Cstart[0]);
                    dic(Cstart[0], Cstart[1]);//数据字典中添加昵称和对应的端口IP
                  
                }
            }
            catch
            {
               
                return;
            }
        }
        void receive()//接受方法
        {
            while (true)
            {
                try
                {
                    byte[] recMessage = new byte[1024 * 1024*2];
                    int k = ClientCon.Receive(recMessage);
                    string mes = Encoding.UTF8.GetString(recMessage, 0, k);
                    if (mes.Contains("MainShow*^") || mes.Contains("listbox12321^") || mes.Contains("listboxclearing^"))
                    {
                        
                        if (mes.Contains("MainShow*^"))
                        {
                            int rt = mes.IndexOf("^");
                            string mess = mes.Substring(rt + 1, mes.Length - rt - 1);
                            message(mess);
                        }
                        if (mes.Contains("listbox12321^"))//向listbox中添加昵称和数据字典
                        {
                            try
                            {
                                Mainmessage(mes);
                            }
                            catch
                            {
                                return;
                            }

                        }
                        if (mes.Contains("listboxclearing^"))
                        {

                            int g = mes.IndexOf("^");
                            string cat = mes.Substring(g + 1, mes.Length - 1).Trim();//获取要去除的昵称
                            removelist(cat);//进行删除
                            removedic(cat);
                        }
                    }
                    else//文件的传输
                    {
                        try
                        {
                            if (checkfile.Checked == true)
                            {
                                string savename = txtSaveName.Text.Trim();
                                FileStream write = new FileStream(savename, FileMode.Create);
                                write.Write(recMessage, 0,k);
                                MessageBox.Show("保存成功", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                write.Close();
                            }
                            }
                    
                        catch 
                        {
                            return;
                        }
                    }
                

                
                }


                catch(Exception e) 
                {
                    MessageBox.Show(e.ToString());
                    
                    return;
                }
                
            }
        }
        private void Client_Load(object sender, EventArgs e)
        {
            try
            {
                txtNickName.Text = Nickname;
                IPAddress Address = IPAddress.Parse(Ip);
                IPEndPoint endpoint = new IPEndPoint(Address, int.Parse(Endpoint.Trim()));
                ClientCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientCon.Connect(endpoint);//绑定端口，进行连接
                string sendmessage = "SqlClientStart*" + txtNickName.Text.Trim() + ":" + "test";
                byte[] messagebyte = Encoding.UTF8.GetBytes(sendmessage);
                ClientCon.Send(messagebyte);//在生成窗体的时候发送任意信息给服务端，用于注册
                Thread beginreceive = new Thread(receive);
                beginreceive.IsBackground = true;
                beginreceive.Start();
            }
            catch
            {
                MessageBox.Show("与服务器连接断开", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)//发送消息
        {
            try
            {
                if (checkfile.Checked == false)
                {
                    string sendmessage = "SqlClientStart*" + txtNickName.Text.Trim() + ":" + txtSend.Text;
                    string mes = txtNickName.Text.Trim() + ":" + txtSend.Text;
                    byte[] messagebyte = Encoding.UTF8.GetBytes(sendmessage);
                    ClientCon.Send(messagebyte);
                    message(mes);
                    txtSend.Text = null;
                }
                if (checkfile.Checked == true)//传输文件
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
                        ClientCon.Send(sendmessage);
                    }

                }
            }
            catch
            {
                message("服务端中断, 消息未发送成功");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
