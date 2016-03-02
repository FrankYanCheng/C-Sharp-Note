using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERPChess;

namespace MySchool
{
    public partial class QuizResultForm : Form
    {
        public QuizResultForm()
        {
            InitializeComponent();
            //par1 = parent1;
        }
        //AnswerQuestionForm par1;
        // �˳�Ӧ�ó���
        private void btnExit_Click(object sender, EventArgs e)
        {
            //PubVar.Fund -= (80 - PubVar.Score);
            //PubVar.temp += (80 - PubVar.Score);
            //Program.Forms.frmMain.lbl_Cash.Text= Math.Round(PubVar.Fund).ToString() + "����";
            //Program.Forms.frmMain.l_qita.Text = Math.Round(PubVar.temp).ToString() + "����";
            
            this.Close();
        }

        // ��ʾ����
        private void QuizResultForm_Load(object sender, EventArgs e)
        {
            l_koufen.Text = "";
            this.ControlBox = false; 
            int correctNum = 0;
            for (int i = 0; i < QuizHelper.questionNum; i++)
            {
                if (QuizHelper.studentAnswers[i] == QuizHelper.correctAnswers[i])
                {
                    correctNum++;
                }
            }

            int score = correctNum * 100 / QuizHelper.questionNum;
            PubVar.PlayerScore += score;
            lblMark.Text = score.ToString() + "��";
            

            lblStudentScoreStrip.Width = lblFullMarkStrip.Width * score / 100;

            if (score < 80)
            {
                lblComment.Text = "֪ʶ���յĻ������ο�!";
                l_koufen.Text="�����Ե��ۼƵ÷�Ϊ��"+PubVar.PlayerScore.ToString()+"��";
                lblStudentScoreStrip.BackColor = Color.Red;
                picFace.Image = ilFaces.Images[0];
            }
            
            else if (score >= 80 && score < 100)
            {
                lblComment.Text = "����������������!";
                l_koufen.Text = "�����Ե��ۼƵ÷�Ϊ��" + PubVar.PlayerScore.ToString() + "��";
                lblStudentScoreStrip.BackColor = Color.CornflowerBlue;
                picFace.Image = ilFaces.Images[2];
            }
            else if (score == 100)
            {

                lblComment.Text = "̫�����ˣ�����ε�������!";
                l_koufen.Text = "�����Ե��ۼƵ÷�Ϊ��" + PubVar.PlayerScore.ToString() + "��";
                lblStudentScoreStrip.BackColor = Color.Green;
                picFace.Image = ilFaces.Images[3];
            }
        }
    }
}