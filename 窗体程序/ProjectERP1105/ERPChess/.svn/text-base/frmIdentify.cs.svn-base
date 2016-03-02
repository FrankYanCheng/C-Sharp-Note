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

namespace ERPChess
{
    public partial class frmIdentify : Office2007Form
    {
        public frmIdentify()
        {
            InitializeComponent();
        }
        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                PubVar.identify = 1;
                PubVar.JoinIp = ipBox1.IP.ToString();
                Program.Forms.frmIdentify.Hide();
            }
            catch(Exception ex)
            {
                ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                mesbox.ShowMessage(ex.Message,"提示");
            }
        }
        private void btnxCreate_Click(object sender, EventArgs e)
        {
            PubVar.identify = 0;
            this.Dispose();
        }

        private void btnxClick(object sender, EventArgs e)
        {
            ButtonX btn = (ButtonX)sender;
            switch (btn.Name)
            {
                case "btnJoin":
                    try
                    {
                        PubVar.identify = 1;
                        PubVar.JoinIp = ipBox1.IP.ToString();
                        Program.Forms.frmIdentify.Hide();
                    }
                    catch (Exception ex)
                    {
                        ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
                        mesbox.ShowMessage(ex.Message, "提示");
                    }
                    break;
                case "btnxCreate":
                    PubVar.identify = 0;
                    this.Dispose();
                    break;
                default: throw new Exception("ERROR");
            }
        }
    }
}
