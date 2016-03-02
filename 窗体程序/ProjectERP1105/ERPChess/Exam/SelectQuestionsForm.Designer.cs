namespace MySchool
{
    partial class SelectQuestionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectQuestionsForm));
            this.lblSubjects = new System.Windows.Forms.Label();
            this.cboSubjects = new System.Windows.Forms.ComboBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnGiveUp = new System.Windows.Forms.Button();
            this.picDescription = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpDescription = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDescription)).BeginInit();
            this.grpDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubjects
            // 
            this.lblSubjects.AutoSize = true;
            this.lblSubjects.Font = new System.Drawing.Font("宋体", 12F);
            this.lblSubjects.Location = new System.Drawing.Point(95, 113);
            this.lblSubjects.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubjects.Name = "lblSubjects";
            this.lblSubjects.Size = new System.Drawing.Size(40, 16);
            this.lblSubjects.TabIndex = 0;
            this.lblSubjects.Text = "科目";
            // 
            // cboSubjects
            // 
            this.cboSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubjects.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSubjects.FormattingEnabled = true;
            this.cboSubjects.Location = new System.Drawing.Point(175, 109);
            this.cboSubjects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSubjects.Name = "cboSubjects";
            this.cboSubjects.Size = new System.Drawing.Size(419, 22);
            this.cboSubjects.TabIndex = 1;
            // 
            // btnBegin
            // 
            this.btnBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin.Location = new System.Drawing.Point(445, 352);
            this.btnBegin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(100, 37);
            this.btnBegin.TabIndex = 7;
            this.btnBegin.Text = "开始答题";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGiveUp.Location = new System.Drawing.Point(602, 352);
            this.btnGiveUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(100, 37);
            this.btnGiveUp.TabIndex = 8;
            this.btnGiveUp.Text = "放弃";
            this.btnGiveUp.UseVisualStyleBackColor = true;
            this.btnGiveUp.Click += new System.EventHandler(this.btnGiveUp_Click);
            // 
            // picDescription
            // 
            this.picDescription.Image = ((System.Drawing.Image)(resources.GetObject("picDescription.Image")));
            this.picDescription.Location = new System.Drawing.Point(189, 16);
            this.picDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picDescription.Name = "picDescription";
            this.picDescription.Size = new System.Drawing.Size(32, 32);
            this.picDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDescription.TabIndex = 9;
            this.picDescription.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(240, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "“三集”、“五大”综合考试";
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(53, 25);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(665, 141);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "1.所有题目均为单项选择题。\r\n2.题量为20题，每题5分。\r\n3.答题时间为4分钟。\r\n每年结束都要进行三集五大快速答题，成绩计入得分，祝你好运！\r\n";
            // 
            // grpDescription
            // 
            this.grpDescription.Controls.Add(this.lblDescription);
            this.grpDescription.Font = new System.Drawing.Font("宋体", 12F);
            this.grpDescription.Location = new System.Drawing.Point(16, 147);
            this.grpDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDescription.Size = new System.Drawing.Size(747, 189);
            this.grpDescription.TabIndex = 11;
            this.grpDescription.TabStop = false;
            this.grpDescription.Text = "说明";
            // 
            // SelectQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.grpDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDescription);
            this.Controls.Add(this.btnGiveUp);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.cboSubjects);
            this.Controls.Add(this.lblSubjects);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SelectQuestionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试题选择";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectQuestionsForm_FormClosed);
            this.Load += new System.EventHandler(this.SelectQuestionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDescription)).EndInit();
            this.grpDescription.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubjects;
        private System.Windows.Forms.ComboBox cboSubjects;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnGiveUp;
        private System.Windows.Forms.PictureBox picDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grpDescription;
    }
}