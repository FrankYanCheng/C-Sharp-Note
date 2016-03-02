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
    public partial class Form_SLoan : LSGOfrmBasement
    {
        public Form_SLoan()
        {
            InitializeComponent();
            
        }
        
        private void but_OK_Click(object sender, EventArgs e)
        {
            ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
            if (checkBoxX1.Checked == false)
            {
                mesbox.ShowMessage("请认真阅读办理贷款规则","提示");
                return;
            }
            this.Visible = false;
            Form_ShortLoan frm = new Form_ShortLoan();
            frm.ShowDialog();
            this.Close();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_SLoan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
