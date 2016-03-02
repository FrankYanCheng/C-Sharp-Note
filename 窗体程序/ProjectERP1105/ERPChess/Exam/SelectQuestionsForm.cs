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
    /// 试题选择窗体
    /// </summary>
    public partial class SelectQuestionsForm : Form
    {
        public SelectQuestionsForm()
        {
            InitializeComponent();
            
        }
        
        // 窗体加载时，将科目从数据库中读取出来显示在组合框中
        private void SelectQuestionsForm_Load(object sender, EventArgs e)
        {
            cboSubjects.SelectedItem = 0;
            string strsql = "select * from Subject";
            //修改
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
                MessageBox.Show("加载课程科目信息失败!", "新疆电网管理人员决策考试系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                DBHelper.connection.Close();
               
            }
        }

        // 放弃答题，退出应用程序
        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要放弃此次答题测试吗？考试得分将记入决策最后得分，请慎重！", "新疆电网管理人员决策考试系统", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                
                //par.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
                //par.l_qita.Text = Math.Round(PubVar.temp).ToString() + "百万";
                
                this.Close();
            }
        }

        // 单击“开始答题”按钮
        private void btnBegin_Click(object sender, EventArgs e)
        {
            //cboSubjects.SelectedIndex = 0;
            if (cboSubjects.SelectedIndex == -1)
            {
                MessageBox.Show("请选择科目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSubjects.Focus();                
            }
            else
            {
                // 获得选中科目的Id
                int subjectId = GetSubjectId();

                // 该科目问题总数
                int allQuestionCount = GetQuestionCount(subjectId);

                // 指定所有问题数组的长度                
                QuizHelper.allQuestionIds = new int[allQuestionCount];

                // 指定记录问题是否选中的数组的长度
                QuizHelper.selectedStates = new bool[allQuestionCount];

                // 为所有问题数组元素赋值
                SetAllQuestionIds(subjectId);

                // 抽题
                SetSelectedQuestionIds();

                // 取出标准答案
                SetRightAnswers();

                // 剩余时间为20分钟
                QuizHelper.remainSeconds = 240;

                // 将学生答案数组初始化
                for (int i = 0; i < QuizHelper.studentAnswers.Length; i++)
                {
                    QuizHelper.studentAnswers[i] = "未回答";
                }

                // 打开答题窗体
                AnswerQuestionForm answerQuestion = new AnswerQuestionForm();
                answerQuestion.MdiParent = this.MdiParent;
                answerQuestion.Show();
                this.Close();
            }
        }

        // 获得对应科目的题目的总数
        private static int GetQuestionCount(int subjectId)
        {
            //TODO:获得对应科目的题目的总数,尚未实现
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

        // 获得科目的Id
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

        // 获得某科目所有问题的Id
        private void SetAllQuestionIds(int subjectId)
        {
            //TODO:获得某科目所有问题的Id,尚未实现
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

        // 抽取试题
        private void SetSelectedQuestionIds()
        {
            //抽取试题,尚未实现
            Random random = new Random();
            int questionIndex = 0; //随机产生问题的索引值
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

        // 取出试题的标准答案
        private void SetRightAnswers()
        {
            //TODO:取出试题的标准答案,尚未实现 
            for (int i = 0; i < QuizHelper.selectedQuestionIds.Length; i++)
            {
                int questionId = QuizHelper.selectedQuestionIds[i];
                QuizHelper.correctAnswers[i] = this.GetAnswerByQuestionId(questionId);

            }
        }
        /// <summary>
        /// 根据题目编号得题目答案
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