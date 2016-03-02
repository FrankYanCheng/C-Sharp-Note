using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPLibrary
{
    public partial class IPBox : UserControl
    {
        private string iP;
        public string IP
        {
            get
            {
                iP = textBox1.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text;
                return iP;
            }
        }

        public IPBox()
        {
            InitializeComponent();
        }

        public bool IsNum(string str)
        {
            char[] zf = str.ToCharArray();
            for (int i = 0; i < zf.Length; i++)
            {
                if (!(Convert.ToByte(zf[i]) >= 48 && Convert.ToByte(zf[i]) <= 57))
                    return false;
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && IsNum(textBox1.Text) && int.Parse(textBox1.Text) > 255)
            {
                MessageBox.Show("IP只能输入0~255之间的数,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "";
            }
            else if (IsNum(textBox1.Text) && (textBox1.Text.Length >= 3))
                textBox2.Focus();
            else if ((textBox1.Text.Length > 1) && IsNum(textBox1.Text.Substring(0, textBox1.Text.Length - 1)) && textBox1.Text.Contains("."))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                textBox2.Focus();
            }
            else if (!(IsNum(textBox1.Text)))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && IsNum(textBox2.Text) && int.Parse(textBox2.Text) > 255)
            {
                MessageBox.Show("IP只能输入0~255之间的数,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Text = "";
            }
            else if (IsNum(textBox2.Text) && (textBox2.Text.Length >= 3))
                textBox3.Focus();
            else if ((textBox2.Text.Length > 1) && IsNum(textBox2.Text.Substring(0, textBox2.Text.Length - 1)) && textBox2.Text.Contains("."))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox3.Focus();
            }
            else if (!(IsNum(textBox2.Text)))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox3.Text != "") && IsNum(textBox3.Text) && int.Parse(textBox3.Text) > 255)
            {
                MessageBox.Show("IP只能输入0~255之间的数,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Text = "";
            }
            else if (IsNum(textBox3.Text) && (textBox3.Text.Length >= 3))
                textBox4.Focus();
            else if ((textBox3.Text.Length > 1) && IsNum(textBox3.Text.Substring(0, textBox3.Text.Length - 1)) && textBox3.Text.Contains("."))
            {
                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1);
                textBox4.Focus();
            }
            else if (!(IsNum(textBox3.Text)))
            {
                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1);
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox4.Text != "") && IsNum(textBox4.Text) && int.Parse(textBox4.Text) > 255)
            {
                MessageBox.Show("IP只能输入0~255之间的数,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Text = "";
            }
            else if (!(IsNum(textBox4.Text)))
            {
                textBox4.Text = textBox4.Text.Substring(0, textBox4.Text.Length - 1);
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }
    }
}
