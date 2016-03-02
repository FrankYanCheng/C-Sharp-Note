using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using LSGO.PresentationLayer;
using System.Data.OleDb;
using LSGO.DataLinkLayer;
using LSGO.DataLinkLayer.Tool;


namespace ERPChess
{
    public partial class Form_Register : Office2007Form
    {
        public Form_Register()
        {
            InitializeComponent();
        }

        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            LSGOCodeB code = new LSGOCodeB();
            string temp = code.Cipher(PubVar.UserID);
            if (this.tb_RegisterID.Text.Trim() == temp)
            {
                try
                {
                    string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Computer1.mdb";
                    OleDbConnection connection = new OleDbConnection(con);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string sql = "UPDATE Register SET RegisterID ='" + temp + "'";
                    OleDbCommand command = new OleDbCommand(sql, connection);
                    command.ExecuteNonQuery();
                    ILSGOfrmTipBox message = new LSGOfrmInforMessageBox();
                    message.ShowMessage("注册成功", "提示");
                }
                catch
                {
                    ILSGOfrmTipBox message = new LSGOfrmInforMessageBox();
                    message.ShowMessage("注册失败", "提示");
                    return;
                }
                Program.Forms.frmMain.lbregister.Text = "已注册版本";
                this.buttonX_OK.Enabled = false;
                PubVar.IsRegistration = true;
                this.tb_RegisterID.Enabled = false;
            }
            else
            {
                ILSGOfrmTipBox message = new LSGOfrmInforMessageBox();
                message.ShowMessage("输入的注册码错误", "提示");
            }
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {
            this.tb_UserID.Text = PubVar.UserID;
            if (PubVar.IsRegistration)
            {
                this.buttonX_OK.Enabled = false;
                this.tb_RegisterID.Text = PubVar.RegistrationID;
                this.tb_RegisterID.Enabled = false;
            }
        }

        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
