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
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// 注册窗口
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void txtNickName_TextChanged(object sender, EventArgs e)//判断昵称是否已存在的显示文本
        {
            SeekNick(txtNickName.Text.Trim());
        }
        void SeekNick(string a)
        {
            SqlRegister re = new SqlRegister(a);//传入昵称，得到昵称
            try
            {
                if (re.Nickname.Trim() ==a)
                    txtShow.Text = "昵称已经存在";
            }
            catch
            {
                txtShow.Text = "昵称可以使用";
            }

        }//判断昵称是否已经存在的方法
        void SeekAccount(string a)//判断账号是否已经存在的方法
        {
            SqlRegister re = new SqlRegister();
            re.SearchAccount(a);//传入账号，得到账号
            try
            {
                if (re.Account.Trim() == a)
                    txtShowA.Text = "账号已经注册";
            }
            catch
            {
                txtShowA.Text = "账号可以使用";
            }
        }
        private void button1_Click(object sender, EventArgs e)//注册按钮
        {
            if (txtShow.Text == "昵称可以使用" && txtShowA.Text == "账号可以使用")
            {
                if (txtAccount.Text != null && txtAnswer.Text != null)
                    if (txtNickName.Text != null && txtPad != null && txtQuestion != null)
                        if (txtRePad.Text == txtPad.Text)
                        {
                            SqlRegister insert = new SqlRegister();//调取写入方法，将值传入数据库
                            insert.Register(txtAccount.Text.Trim(), txtNickName.Text.Trim(), txtPad.Text.Trim(), txtQuestion.Text.Trim(), txtAnswer.Text.Trim());
                            MessageBox.Show("注册成功", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();//关闭该窗体
                        }
                        else
                        {
                            MessageBox.Show("信息不能为空，请确认密码和重置密码是否相同", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
            }
          
           
        }
        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            SeekAccount(txtAccount.Text.Trim());
        }

        private void txtShowA_TextChanged(object sender, EventArgs e)
        {

        }//账号存在的显示文本

     
    }
}
