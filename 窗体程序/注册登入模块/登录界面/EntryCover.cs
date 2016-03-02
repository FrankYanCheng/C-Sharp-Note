using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Entry
{
    public partial class EntryCover : Form
    {
        public EntryCover()
        {
            InitializeComponent();
        }

        #region 登入界面触发的事件
        #region 注册链接触发事件
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterCover Form2 = new RegisterCover();
            Form2.Show();
            
        }
        #endregion
        #region 忘记密码链接触发的事件
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetCodeCover Form3 = new ForgetCodeCover();
            Form3.Show();

        }
        #endregion
        #region 验证码代码
        /// <summary>
        /// string yzm;得到的4个随机数存储
        /// </summary>
        string yzm;
        private string yanzheng() //生成4个随机字符
        {
            string str = "abcdefghigklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string fh = "";    //记录随机产生的符号
            Random rd = new Random();
            int index = 0;
            for (int i = 1; i <= 4; i++)
            {
                index = rd.Next(0, 62);
                fh += str[index].ToString();
            }
            yzm = fh.ToLower();//大小写转换，均可读
            return fh;
        }
       
       //将上面的随机字符画到一个Bitmap图片中
        private Bitmap draw(string fh)
        {
            Bitmap bm = new Bitmap(60, 30);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.FromArgb(192, 192, 255));
            g.DrawString(fh, new Font("Arial Black", 12), new SolidBrush(Color.Red), 1, 1);
            //以下干扰线
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x1 = rd.Next(bm.Width);
                int x2 = rd.Next(bm.Width);
                int y1 = rd.Next(bm.Height);
                int y2 = rd.Next(bm.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            return bm;
        }
        //单击picturebox控件更新随机码
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Bitmap bm = this.draw(this.yanzheng());
            pictureBox2.BackgroundImage = bm;
            pictureBox2.Size = bm.Size;
        }
        //载入时显现第一幅验证码
        private void EntryCover_Load(object sender, EventArgs e)
        {
            Bitmap bm = this.draw(this.yanzheng());
            pictureBox2.BackgroundImage = bm;
            pictureBox2.Size = bm.Size;
        }
        #endregion
        #region 点击登入按钮时发生的事件
        private void btnqueding_Click(object sender, EventArgs e)
        {
            txtcode.Text = txtcode.Text.ToLower();//转换成小写
            SqlAccount a = new SqlAccount(txtname.Text);
            if (txtcode.Text != yzm)
                MessageBox.Show("验证码输入错误", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (a.search == txtpassword.Text && txtcode.Text == yzm)
                MessageBox.Show("登入成功", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else//输入错误进行重绘
            {
                MessageBox.Show("请输入正确的用户名和密码", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = null;
                Bitmap bm = this.draw(this.yanzheng());
                pictureBox2.BackgroundImage = bm;
                pictureBox2.Size = bm.Size;
            }
        }
        #endregion
        #endregion

    }
}
