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
    /// 答题窗体
    /// </summary>
    public partial class AnswerQuestionForm : Form
    {
        public int questionIndex = 0;  // 当前的问题对应的数组索引

        public AnswerQuestionForm()
        {
            InitializeComponent();
            
        }
        

        // 窗体加载时，显示相应题目的信息
        private void AnswerQuestionForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false; 
            tmrCostTime.Start();   // 启动计时器
            
            GetQuestionDetails();  // 显示题目信息
            CheckOption();   　　　// 如果题目已经答过，让相应的选项选中 
            CheckBtnNext();  　    // 确定是否到了最后一题
        }

        // 确定“下一题”按钮应该显示的文字
        private void CheckBtnNext()
        {
            // 如果达到20题，就让“下一题”按钮的文字显示为“检查答案”
            if (questionIndex >= QuizHelper.selectedQuestionIds.Length - 1)
            {                
                btnNext.Text = "检查答案";
            }
        }
        
        // 单击“下一题”按钮时，为答案数组赋值，并显示下一题的信息
        private void btnNext_Click(object sender, EventArgs e)
        {
            // 如果没有到最后一题，就继续显示新题目信息
            if (questionIndex < QuizHelper.selectedQuestionIds.Length - 1)
            {
                questionIndex++;
                
                GetQuestionDetails();  // 显示试题信息
                CheckOption();         // 如果题目已经答过，让相应的选项选中    
                CheckBtnNext(); 　     // 确定是否到了最后一题
            }
            else  // 否则，打开答题卡窗体
            {
                OpenAnswerCard();
            }
        }       

        // 打开答题卡窗体
        private void OpenAnswerCard()
        {
            AnswerCardForm answerCardForm = new AnswerCardForm();
            answerCardForm.MdiParent = this.MdiParent;
            answerCardForm.Show();
            this.Close();
        }

        // 计时器事件
        private void tmrCostTime_Tick(object sender, EventArgs e)
        {
            int minute;   // 当前的分钟
            int second;   // 秒

            // 如果还有剩余时间，就显示剩余的分钟和秒数
            if (QuizHelper.remainSeconds > 0)
            {
                QuizHelper.remainSeconds--; 
                minute = QuizHelper.remainSeconds / 60;
                second = QuizHelper.remainSeconds % 60;
                lblTimer.Text = string.Format("{0:00}:{1:00}", minute, second);                             
            }
            // 否则，就提示交卷
            else 
            {
                tmrCostTime.Stop();
                MessageBox.Show("时间到了，该交卷了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QuizResultForm quizResultForm = new QuizResultForm();
                quizResultForm.MdiParent = this.MdiParent;
                quizResultForm.Show();
                this.Close();
            }
        }
  
        // 选项单选按钮的单击事件处理，选择答案时，记录答案
        private void rdoOption_Click(object sender, EventArgs e)
        {
            QuizHelper.studentAnswers[questionIndex] = ((RadioButton)sender).Tag.ToString();
        }

        // 单击“答题卡”按钮时，打开答题卡窗体
        private void btnAnswerCard_Click(object sender, EventArgs e)
        {
            OpenAnswerCard();
        }

        // 根据问题的Id，显示题目的详细信息
        public void GetQuestionDetails()
        {
            lblQuestion.Text = string.Format("问题{0}", questionIndex + 1);
            string strsql = "select Question,OptionA,OptionB,OptionC,OptionD from Question where questionId=" + QuizHelper.selectedQuestionIds[questionIndex];
            OleDbCommand comm = new OleDbCommand(strsql, DBHelper.connection);
            OleDbDataReader dr = null;
            try
            {
                DBHelper.connection.Open();
                dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    lblQuestionDetails.Text = dr["Question"].ToString();
                    rdoOptionA.Text = string.Format("A.{0}", dr["OptionA"].ToString());
                    rdoOptionB.Text = string.Format("B.{0}", dr["OptionB"].ToString());
                    rdoOptionC.Text = string.Format("C:{0}", dr["OptionC"].ToString());
                    rdoOptionD.Text = string.Format("D:{0}", dr["OptionD"].ToString());
                }
                dr.Close();
            }
            catch
            { 
                
            }
            finally
            {
               
                DBHelper.connection.Close();

            }
        }

        // 如果已经答了题目，选中相应的选项
        private void CheckOption()
        {
            switch (QuizHelper.studentAnswers[questionIndex])
            {
                case "A":
                    rdoOptionA.Checked = true;
                    break;
                case "B":
                    rdoOptionB.Checked = true;
                    break;
                case "C":
                    rdoOptionC.Checked = true;
                    break;
                case "D":
                    rdoOptionD.Checked = true;
                    break;
                default:
                    rdoOptionA.Checked = false;
                    rdoOptionB.Checked = false;
                    rdoOptionC.Checked = false;
                    rdoOptionD.Checked = false;
                    break;
            }
        }
      
    }
}