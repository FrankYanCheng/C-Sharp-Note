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
    public partial class ForgetForm : Form
    {
        public ForgetForm()
        {
            InitializeComponent();
            this.AcceptButton = btnForget;
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text != null)
            {
                try
                {
                    fg.SeekQuestion(txtAccount.Text.Trim());//根据账号信息查找问题
                    fg.SeekPassword(txtAccount.Text.Trim());//查找密码
                    fg.SeekAnswer(txtAccount.Text.Trim());//查找答案
                    if (fg.Answer1.Trim() == txtAnswer.Text.Trim())
                    {
                        MessageBox.Show("密码是" + fg.Password.Trim() + "下次不要忘记了哦", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                catch
                {
                    MessageBox.Show("信息输入有误", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("信息输入有误", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        SqlForget fg = new SqlForget();//声明寻找密码的方法
        private void txtGetQuestion_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text != null)
            {
                try
                {
                    fg.SeekQuestion(txtAccount.Text.Trim());
                    txtQuestion.Text = fg.Question1.Trim();
                }
                catch
                {
                    MessageBox.Show("账号信息不正确", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("回答问题不能为空", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
