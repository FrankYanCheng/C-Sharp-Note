using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LSGO.PresentationLayer;
using DevComponents.DotNetBar;

namespace ERPChess
{
    public partial class frmLogin : LSGOfrmBasement
    {
        public frmLogin()
        {
            

            InitializeComponent();
        }
        bool closeOrstart = false;
        private void Button_Click(object sender, EventArgs e)
        {
            ButtonX btn = (ButtonX)sender;
            ILSGOfrmTipBox mesbox = new LSGOfrmErrorMessageBox();
            
            switch (btn.Name)
            {
                case "btnLogin":
                    if (this.txtPlayerName.Text == "")
                    {
                        mesbox.ShowMessage("请您决策者名称！", "系统提示");
                        return;
                    }
                    if (txtKey.Text == "")
                    {
                        mesbox.ShowMessage("请您输入密码！", "系统提示");
                        return;
                    }
                    if (txtKey.Text != "xjdl")
                    {
                        mesbox.ShowMessage("您输入的密码错误！", "系统提示");
                        return;
                    }
                    closeOrstart = true;
                    if (this.txtPlayerName.Text.Trim() == PubVar.ConstOrder.ToString())
                    {
                        //ILSGOfrmTipBox mesbox = new LSGOfrmErrorMessageBox();
                        mesbox.ShowMessage("换个名称吧！", "系统提示");
                        return;
                    }
                    if (this.txtPlayerName.Text.Trim() == "")
                    {
                        //ILSGOfrmTipBox mesbox = new LSGOfrmErrorMessageBox();
                        mesbox.ShowMessage("请输入一个名字！", "系统提示");
                        return;
                    }
                    PubVar.PlayerName = this.txtPlayerName.Text.Trim().ToString();
                    Program.Forms.frmLogin.Close();
                    break;
                case "btnCancle":
                    Environment.Exit(0);
                    break;
            }
            // 你用主板自带的串口号是COM1
            Power_Control pc = new Power_Control("COM1");
            pc.Open();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!closeOrstart)
            {
                Environment.Exit(0);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           


        }
    }
}
