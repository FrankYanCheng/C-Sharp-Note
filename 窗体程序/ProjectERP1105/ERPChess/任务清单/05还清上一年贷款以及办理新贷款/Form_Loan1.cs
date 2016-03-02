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
    public partial class Form_loan1 : LSGOfrmBasement
    {
        public Form_loan1()
        {
            InitializeComponent();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form_LongLoan frm = new Form_LongLoan();
            frm.ShowDialog();
            this.Close();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
