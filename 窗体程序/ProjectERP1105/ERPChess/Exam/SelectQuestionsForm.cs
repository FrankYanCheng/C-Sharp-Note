using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using ERPChess;
namespace MySchool
{
    /// <summary>
    /// ����ѡ����
    /// </summary>
    public partial class SelectQuestionsForm : Form
    {
        public SelectQuestionsForm()
        {
            InitializeComponent();
            
        }
        
        // �������ʱ������Ŀ�����ݿ��ж�ȡ������ʾ����Ͽ���
        private void SelectQuestionsForm_Load(object sender, EventArgs e)
        {
            cboSubjects.SelectedItem = 0;
            string strsql = "select * from Subject";
            //�޸�
            OleDbCommand comm = new OleDbCommand(strsql, DBHelper.connection);
            OleDbDataReader dr  =null;
            try
            {
                DBHelper.connection.Open();
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                cboSubjects.Items.Clear();
                while (dr.Read())
                {
                    Subject subject = new Subject();
                    subject.SubjectId = (int)dr[0];
                    subject.SubjectName = dr[1].ToString();
                    cboSubjects.Items.Add(subject);
                }
            }
            catch
            {
                MessageBox.Show("���ؿγ̿�Ŀ��Ϣʧ��!", "�½�����������Ա���߿���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                DBHelper.connection.Close();
               
            }
        }

        // �������⣬�˳�Ӧ�ó���
        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("��ȷ��Ҫ�����˴δ�������𣿿��Ե÷ֽ�����������÷֣������أ�", "�½�����������Ա���߿���ϵͳ", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                
                //par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "����";
                //par.l_qita.Text = Math.Round(PubVar.temp).ToString() + "����";
                
                this.Close();
            }
        }

        // ��������ʼ���⡱��ť
        private void btnBegin_Click(object sender, EventArgs e)
        {
            //cboSubjects.SelectedIndex = 0;
            if (cboSubjects.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ���Ŀ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSubjects.Focus();                
            }
            else
            {
                // ���ѡ�п�Ŀ��Id
                int subjectId = GetSubjectId();

                // �ÿ�Ŀ��������
                int allQuestionCount = GetQuestionCount(subjectId);

                // ָ��������������ĳ���                
                QuizHelper.allQuestionIds = new int[allQuestionCount];

                // ָ����¼�����Ƿ�ѡ�е�����ĳ���
                QuizHelper.selectedStates = new bool[allQuestionCount];

                // Ϊ������������Ԫ�ظ�ֵ
                SetAllQuestionIds(subjectId);

                // ����
                SetSelectedQuestionIds();

                // ȡ����׼��
                SetRightAnswers();

                // ʣ��ʱ��Ϊ20����
                QuizHelper.remainSeconds = 240;

                // ��ѧ���������ʼ��
                for (int i = 0; i < QuizHelper.studentAnswers.Length; i++)
                {
                    QuizHelper.studentAnswers[i] = "δ�ش�";
                }

                // �򿪴��ⴰ��
                AnswerQuestionForm answerQuestion = new AnswerQuestionForm();
                answerQuestion.MdiParent = this.MdiParent;
                answerQuestion.Show();
                this.Close();
            }
        }

        // ��ö�Ӧ��Ŀ����Ŀ������
        private static int GetQuestionCount(int subjectId)
        {
            //TODO:��ö�Ӧ��Ŀ����Ŀ������,��δʵ��
           // return -1;
            string strsql = "select count(*) from Question where SubjectId=" + subjectId;
            OleDbCommand comm = new OleDbCommand(strsql, DBHelper.connection);
            try
            {
                DBHelper.connection.Open();
                return (int)comm.ExecuteScalar();
               
            }
            catch(Exception ex)
            {
                throw ex;
               
            }
            finally
            {
                DBHelper.connection.Close();
            }
        }

        // ��ÿ�Ŀ��Id
        private int GetSubjectId()
        {
           
            object item = cboSubjects.SelectedItem;
            if (item != null)
            {
                Subject subject = item as Subject;
                return subject.SubjectId;
            }
            else
                return -1;
            
        }

        // ���ĳ��Ŀ���������Id
        private void SetAllQuestionIds(int subjectId)
        {
            //TODO:���ĳ��Ŀ���������Id,��δʵ��
            string strsql = "select QuestionId from Question where subjectId=" + subjectId;
            OleDbCommand comm = new OleDbCommand(strsql, DBHelper.connection);
            OleDbDataReader dr = null;
            try
            {
                DBHelper.connection.Open();
                dr = comm.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    QuizHelper.allQuestionIds[i] = (int)dr[0];
                    QuizHelper.selectedStates[i] = false;
                    i++;
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            { 
               dr.Close();
                DBHelper.connection.Close();
            }
        }

        // ��ȡ����
        private void SetSelectedQuestionIds()
        {
            //��ȡ����,��δʵ��
            Random random = new Random();
            int questionIndex = 0; //����������������ֵ
            int i = 0;
            while (i < QuizHelper.questionNum)
            {
                questionIndex = random.Next(QuizHelper.allQuestionIds.Length);
                if (QuizHelper.selectedStates[questionIndex] == false)
                {
                    QuizHelper.selectedQuestionIds[i] = QuizHelper.allQuestionIds[questionIndex];
                    QuizHelper.selectedStates[questionIndex] = true;
                    i++;
                }
            }
                  
        }

        // ȡ������ı�׼��
        private void SetRightAnswers()
        {
            //TODO:ȡ������ı�׼��,��δʵ�� 
            for (int i = 0; i < QuizHelper.selectedQuestionIds.Length; i++)
            {
                int questionId = QuizHelper.selectedQuestionIds[i];
                QuizHelper.correctAnswers[i] = this.GetAnswerByQuestionId(questionId);

            }
        }
        /// <summary>
        /// ������Ŀ��ŵ���Ŀ��
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        private string GetAnswerByQuestionId(int questionId)
        {
            string strsql = "select Answer from Question where questionId=" + questionId;
            OleDbCommand comm = new OleDbCommand(strsql, DBHelper.connection);
            try
            {
                DBHelper.connection.Open();
                return comm.ExecuteScalar().ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                DBHelper.connection.Close();
            }
        }

        private void SelectQuestionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PubVar.year == 11)
            {
                //Thread.Sleep(200);
                //double totalPoints = 0;
                //totalPoints = GameOver.total_Points();
                string order = MessageType.totalPoint.ToString() + "//" + PubVar.PlayerName + "//" + GameOver.total_Points().ToString();
                Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(order));
                GameOver.gameOver();
            }
        }

        
    }
}