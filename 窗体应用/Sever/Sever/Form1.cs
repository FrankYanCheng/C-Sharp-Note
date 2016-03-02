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

namespace Sever
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        void message(string a)
        {
            txtView.AppendText(a+"\r\n");
        }
        Socket Watch = null;
        Socket con = null;
        private void btnOpenSever_Click(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(txtIP.Text.Trim());
            IPEndPoint endpoint = new IPEndPoint(address,Convert.ToInt32(txtPort.Text));
            Watch = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            Watch.Bind(endpoint);
            Watch.Listen(1000);
            message("服务器连接成功！");
            Thread thread = new Thread(accept);
            thread.IsBackground = true;
            thread.Start();
           
        }
        Dictionary<string,Socket> sf=new Dictionary<string,Socket>();
        void accept()
        {
            while (true)
            {
                con = Watch.Accept();
                sf.Add(con.RemoteEndPoint.ToString(),con);
                message("客户端连接成功"+con.RemoteEndPoint.ToString());
                listBox1.Items.Add(con.RemoteEndPoint.ToString());
            }
        }
      
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] sendMessage = System.Text.Encoding.UTF8.GetBytes(txtMessage.Text);
            string k=listBox1.Text;
            sf[k].Send(sendMessage);
            message("我说："+txtMessage.Text);
            txtMessage.Text = null;
        }
     
    }
}
