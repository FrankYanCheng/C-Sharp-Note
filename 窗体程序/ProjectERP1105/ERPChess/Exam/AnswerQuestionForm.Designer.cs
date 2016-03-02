﻿namespace MySchool
{
    partial class AnswerQuestionForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnswerQuestionForm));
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblQuestionDetails = new System.Windows.Forms.Label();
            this.tmrCostTime = new System.Windows.Forms.Timer(this.components);
            this.rdoOptionA = new System.Windows.Forms.RadioButton();
            this.rdoOptionB = new System.Windows.Forms.RadioButton();
            this.rdoOptionC = new System.Windows.Forms.RadioButton();
            this.rdoOptionD = new System.Windows.Forms.RadioButton();
            this.btnAnswerCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQuestion.Location = new System.Drawing.Point(31, 25);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(56, 14);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "问题1：";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnswer.Location = new System.Drawing.Point(31, 239);
            this.lblAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(49, 14);
            this.lblAnswer.TabIndex = 2;
            this.lblAnswer.Text = "答案：";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(227, 379);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(312, 36);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "下一题";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimer.Location = new System.Drawing.Point(607, 16);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(142, 27);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuestionDetails
            // 
            this.lblQuestionDetails.BackColor = System.Drawing.Color.White;
            this.lblQuestionDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuestionDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblQuestionDetails.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQuestionDetails.Location = new System.Drawing.Point(35, 53);
            this.lblQuestionDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionDetails.Name = "lblQuestionDetails";
            this.lblQuestionDetails.Size = new System.Drawing.Size(714, 167);
            this.lblQuestionDetails.TabIndex = 7;
            // 
            // tmrCostTime
            // 
            this.tmrCostTime.Interval = 1000;
            this.tmrCostTime.Tick += new System.EventHandler(this.tmrCostTime_Tick);
            // 
            // rdoOptionA
            // 
            this.rdoOptionA.AutoSize = true;
            this.rdoOptionA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoOptionA.Location = new System.Drawing.Point(111, 236);
            this.rdoOptionA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoOptionA.Name = "rdoOptionA";
            this.rdoOptionA.Size = new System.Drawing.Size(39, 18);
            this.rdoOptionA.TabIndex = 8;
            this.rdoOptionA.TabStop = true;
            this.rdoOptionA.Tag = "A";
            this.rdoOptionA.Text = "A.";
            this.rdoOptionA.UseVisualStyleBackColor = true;
            this.rdoOptionA.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // rdoOptionB
            // 
            this.rdoOptionB.AutoSize = true;
            this.rdoOptionB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoOptionB.Location = new System.Drawing.Point(111, 268);
            this.rdoOptionB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoOptionB.Name = "rdoOptionB";
            this.rdoOptionB.Size = new System.Drawing.Size(39, 18);
            this.rdoOptionB.TabIndex = 9;
            this.rdoOptionB.TabStop = true;
            this.rdoOptionB.Tag = "B";
            this.rdoOptionB.Text = "B.";
            this.rdoOptionB.UseVisualStyleBackColor = true;
            this.rdoOptionB.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // rdoOptionC
            // 
            this.rdoOptionC.AutoSize = true;
            this.rdoOptionC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoOptionC.Location = new System.Drawing.Point(111, 300);
            this.rdoOptionC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoOptionC.Name = "rdoOptionC";
            this.rdoOptionC.Size = new System.Drawing.Size(39, 18);
            this.rdoOptionC.TabIndex = 10;
            this.rdoOptionC.TabStop = true;
            this.rdoOptionC.Tag = "C";
            this.rdoOptionC.Text = "C.";
            this.rdoOptionC.UseVisualStyleBackColor = true;
            this.rdoOptionC.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // rdoOptionD
            // 
            this.rdoOptionD.AutoSize = true;
            this.rdoOptionD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoOptionD.Location = new System.Drawing.Point(111, 332);
            this.rdoOptionD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoOptionD.Name = "rdoOptionD";
            this.rdoOptionD.Size = new System.Drawing.Size(39, 18);
            this.rdoOptionD.TabIndex = 11;
            this.rdoOptionD.TabStop = true;
            this.rdoOptionD.Tag = "D";
            this.rdoOptionD.Text = "D.";
            this.rdoOptionD.UseVisualStyleBackColor = true;
            this.rdoOptionD.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // btnAnswerCard
            // 
            this.btnAnswerCard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAnswerCard.Location = new System.Drawing.Point(607, 381);
            this.btnAnswerCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnswerCard.Name = "btnAnswerCard";
            this.btnAnswerCard.Size = new System.Drawing.Size(137, 31);
            this.btnAnswerCard.TabIndex = 12;
            this.btnAnswerCard.Text = "交卷";
            this.btnAnswerCard.UseVisualStyleBackColor = true;
            this.btnAnswerCard.Click += new System.EventHandler(this.btnAnswerCard_Click);
            // 
            // AnswerQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.btnAnswerCard);
            this.Controls.Add(this.rdoOptionD);
            this.Controls.Add(this.rdoOptionC);
            this.Controls.Add(this.rdoOptionB);
            this.Controls.Add(this.rdoOptionA);
            this.Controls.Add(this.lblQuestionDetails);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AnswerQuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "回答问题";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AnswerQuestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblQuestionDetails;
        private System.Windows.Forms.Timer tmrCostTime;
        private System.Windows.Forms.RadioButton rdoOptionA;
        private System.Windows.Forms.RadioButton rdoOptionB;
        private System.Windows.Forms.RadioButton rdoOptionC;
        private System.Windows.Forms.RadioButton rdoOptionD;
        private System.Windows.Forms.Button btnAnswerCard;
    }
}