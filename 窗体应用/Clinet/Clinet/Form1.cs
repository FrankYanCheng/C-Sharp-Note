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

namespace Clinet
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
            txtView.AppendText(a + "\r\n");
        }
        Socket client = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
           client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(txtIP.Text.Trim());
            IPEndPoint endpoint = new IPEndPoint(address, Convert.ToInt32(txtPort.Text));
            client.Connect(endpoint);
            message("客户端连接");
            Thread thread = new Thread(Receive);
            thread.IsBackground = true;
            thread.Start();
        }
        void Receive()
        {
            while (true)
            {
                byte[] SetMessage = new byte[1024 * 1024 * 2];
                int length=client.Receive(SetMessage);
                string Message = Encoding.UTF8.GetString(SetMessage,0,length);
                message("服务器说："+Message);
            }
        }

    }
}
