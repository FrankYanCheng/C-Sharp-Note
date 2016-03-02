using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GGChatSever
{
    public partial class EntryForm : Form
    {
        
        public EntryForm()
        {
            InitializeComponent();
            this.AcceptButton = btnEntry;
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            try//检查登录信息是否正确
            {
                SqlEntry con = new SqlEntry(this.txtAccount.Text);
                if (con.Password.Trim() == txtPad.Text.Trim())
                {
                    Sever Start = new Sever(this);//新建一个服务器窗体
                    con.NickName(this.txtAccount.Text);//查找账号所对应的昵称
                    Start.Nickname = con.Nickname.Trim();//将登录界面所查找到的昵称传给服务器界面
                    Start.Account = txtAccount.Text.Trim();//服务器界面获取账号信息
                    Start.Show();

                }
            }
            catch
            {
                MessageBox.Show("输入的信息有误,请重新输入","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm re = new RegisterForm();//新建一个注册界面
            re.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetForm fg = new ForgetForm();//新建一个忘记密码界面
            fg.Show();
            
        }
    }
}
