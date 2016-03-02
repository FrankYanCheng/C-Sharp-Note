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
    public partial class Form_Bid : Office2007Form
    {
        public Form_Bid()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == false)
            {
                ILSGOfrmTipBox mesForm = new LSGOfrmInforMessageBox();
                mesForm.ShowMessage("请仔细阅读竞价规则以及注意事项", "提示");
                return;
            }
            Bid_Capacity frm = new Bid_Capacity();
            frm.Show();
            this.Close();
        }
    }
}
