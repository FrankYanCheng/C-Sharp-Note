using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using LSGO.PresentationLayer;
namespace ERPChess
{
    public partial class frm_Hero : Office2007Form
    {
        public frm_Hero()
        {
            InitializeComponent();
            name = new string[4];
            name[0] = "������";
            name[1] = "������";
            name[2] = "��߼�¼��";
            name[3] = "����ʱ�䣺";
        }
        string[] name;
        private void frm_Hero_Load(object sender, EventArgs e)
        {
            if (PubVar.totalpoint != null && PubVar.totalpoint.Count!=0)
            {
                dgv1.RowCount = PubVar.totalpoint.Count;
                for (int i = 0; i < PubVar.totalpoint.Count; i++)
                {
                    dgv1.Rows[i].Cells[0].Value = PubVar.totalpoint[i].playerName;
                    dgv1.Rows[i].Cells[2].Value = PubVar.totalpoint[i].totalpoint;
                    dgv1.Rows[i].Cells[3].Value = PubVar.totalpoint[i].createTime;
                }
                SortPlayer();
            }
        }

        //private void btn_search_Click(object sender, EventArgs e)
        //{
        //    ILSGOfrmTipBox mesbox = new LSGOfrmInforMessageBox();
        //    int temp = 0;
        //    if (text_search.Text.Trim() != "")
        //    {
        //        for (int i = 0; i < dgv1.RowCount; i++)
        //        {
        //            if (dgv1.Rows[i].Cells[0].Value.ToString() == text_search.Text)
        //            {
        //                dgv1.Rows[i].Selected = true;
        //                temp++;
        //                AddTextToLabels(dgv1.Rows[i], label1, label2, label3, label4);
        //            }
        //            else
        //            {
        //                dgv1.Rows[i].Selected = false;
        //            }
        //        }
        //        if (temp == 0)
        //        {
        //            mesbox.ShowMessage("�����ڸþ����ߣ���ȷ��������ȷ������\n��Ӣ�����ִ�Сд��", "��ʾ");
        //            text_search.Text = "";
        //        }
        //    }
        //    else
        //    {
        //        mesbox.ShowMessage("�����������������", "��ʾ");
        //        text_search.Text = "";
        //    }
        //}
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //�Ծ����߽�������
        private void SortPlayer()
        {
            int count = PubVar.totalpoint.Count;
            int i;
            for (i = 0; i < count-1; i++)
             {
                for(int j=i+1;j<count;j++)
                {
                    if((double)dgv1 .Rows[i].Cells [2].Value<(double)dgv1 .Rows [j].Cells [2].Value)
                    {
                        object str = dgv1.Rows[i].Cells[0].Value;
                        object t1 = dgv1.Rows[i].Cells[2].Value;
                        object t2 = dgv1.Rows[i].Cells[3].Value;
                        dgv1 .Rows [i].Cells[0].Value  =dgv1.Rows [j].Cells[0].Value  ;
                        dgv1 .Rows [i].Cells[2].Value =dgv1.Rows [j].Cells[2].Value  ;
                        dgv1 .Rows [i].Cells[3].Value  =dgv1.Rows [j].Cells[3].Value  ;
                        dgv1 .Rows [j].Cells[0].Value  =str  ;
                        dgv1 .Rows [j].Cells[2].Value  =t1 ;
                        dgv1 .Rows [j].Cells[3].Value  =t2 ;
                    }
                }
                    dgv1 .Rows [i].Cells [1].Value =i+1;      
            }
            dgv1.Rows[i].Cells[1].Value = i + 1;
        }
        //��label�������Textֵ
        private void AddTextToLabels(DataGridViewRow row, params Label[] lables)
        {
            int n = lables.Length;
            for (int i = 0; i < n; i++)
                lables[i].Text = name[i] + row.Cells[i].Value.ToString();
            //���ۺϷ���label���������
            double t = (double)row.Cells[2].Value;
            if (t < 6000)
                label5.Text = "�ۺϷ�:" + "������";
            else if (t <= 8000)
                label5.Text = "�ۺϷ�:" + (Math.Round(t/100)).ToString();
            else if (t <10000)
                label5.Text = "�ۺϷ�:" + (Math.Round(80+(t-8000)/200)).ToString();
            else
                label5.Text = "�ۺϷ�:" + 95.ToString();
        }
        int k = -1;
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            k = dgv1.CurrentCell.RowIndex;
            dgv1.Rows[k].Selected = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (k == -1)
            {
                MessageBox.Show("����ѡ��һ�����ݣ�");
                return;
            }            
            AddTextToLabels(dgv1.Rows[k], label1, label2, label3, label4);
            dgv1.Rows[k].Selected = false;
            k = -1;
        }

    }
}