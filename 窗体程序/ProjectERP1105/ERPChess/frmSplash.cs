using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ERPChess
{
    public partial class frmSplash : Office2007Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.lbl_Vertion.Text = "Vertion 1.0";
            if (PubVar.SplashType == 0)
            {
                timer.Start();
            }
            if (PubVar.SplashType == 1)
            {
                lbl_Info.Visible = true;
                lbl_AddString.Text = "正在等待其他决策者的准备，请稍候...";
                prgX.Visible = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            prgX.Value += 3;
            if (prgX.Value ==100)
            {
                timer.Stop();
                //this.Dispose();
            }
        }
    }
}
