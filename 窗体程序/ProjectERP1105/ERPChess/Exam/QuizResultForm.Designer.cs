namespace MySchool
{
    partial class QuizResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizResultForm));
            this.lblStudentScore = new System.Windows.Forms.Label();
            this.lblStudentScoreStrip = new System.Windows.Forms.Label();
            this.lblFullMark = new System.Windows.Forms.Label();
            this.lblFullMarkStrip = new System.Windows.Forms.Label();
            this.lbl100 = new System.Windows.Forms.Label();
            this.lblMark = new System.Windows.Forms.Label();
            this.picFace = new System.Windows.Forms.PictureBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.ilFaces = new System.Windows.Forms.ImageList(this.components);
            this.l_koufen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStudentScore
            // 
            this.lblStudentScore.AutoSize = true;
            this.lblStudentScore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStudentScore.Location = new System.Drawing.Point(40, 256);
            this.lblStudentScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentScore.Name = "lblStudentScore";
            this.lblStudentScore.Size = new System.Drawing.Size(77, 14);
            this.lblStudentScore.TabIndex = 0;
            this.lblStudentScore.Text = "你的得分：";
            // 
            // lblStudentScoreStrip
            // 
            this.lblStudentScoreStrip.BackColor = System.Drawing.Color.Red;
            this.lblStudentScoreStrip.Location = new System.Drawing.Point(136, 249);
            this.lblStudentScoreStrip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentScoreStrip.Name = "lblStudentScoreStrip";
            this.lblStudentScoreStrip.Size = new System.Drawing.Size(133, 31);
            this.lblStudentScoreStrip.TabIndex = 1;
            // 
            // lblFullMark
            // 
            this.lblFullMark.AutoSize = true;
            this.lblFullMark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFullMark.Location = new System.Drawing.Point(72, 307);
            this.lblFullMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullMark.Name = "lblFullMark";
            this.lblFullMark.Size = new System.Drawing.Size(49, 14);
            this.lblFullMark.TabIndex = 2;
            this.lblFullMark.Text = "满分：";
            // 
            // lblFullMarkStrip
            // 
            this.lblFullMarkStrip.BackColor = System.Drawing.Color.Green;
            this.lblFullMarkStrip.Location = new System.Drawing.Point(136, 300);
            this.lblFullMarkStrip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullMarkStrip.Name = "lblFullMarkStrip";
            this.lblFullMarkStrip.Size = new System.Drawing.Size(400, 31);
            this.lblFullMarkStrip.TabIndex = 3;
            // 
            // lbl100
            // 
            this.lbl100.AutoSize = true;
            this.lbl100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl100.Location = new System.Drawing.Point(557, 307);
            this.lbl100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl100.Name = "lbl100";
            this.lbl100.Size = new System.Drawing.Size(42, 14);
            this.lbl100.TabIndex = 4;
            this.lbl100.Text = "100分";
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMark.Location = new System.Drawing.Point(557, 260);
            this.lblMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(0, 14);
            this.lblMark.TabIndex = 5;
            this.lblMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picFace
            // 
            this.picFace.Location = new System.Drawing.Point(132, 16);
            this.picFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(128, 128);
            this.picFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFace.TabIndex = 6;
            this.picFace.TabStop = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblComment.Location = new System.Drawing.Point(335, 93);
            this.lblComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(0, 19);
            this.lblComment.TabIndex = 7;
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(593, 368);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 31);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ilFaces
            // 
            this.ilFaces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFaces.ImageStream")));
            this.ilFaces.TransparentColor = System.Drawing.Color.Transparent;
            this.ilFaces.Images.SetKeyName(0, "face1.png");
            this.ilFaces.Images.SetKeyName(1, "face2.png");
            this.ilFaces.Images.SetKeyName(2, "face3.png");
            this.ilFaces.Images.SetKeyName(3, "face4.png");
            // 
            // l_koufen
            // 
            this.l_koufen.AutoSize = true;
            this.l_koufen.Font = new System.Drawing.Font("宋体", 12F);
            this.l_koufen.Location = new System.Drawing.Point(312, 189);
            this.l_koufen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_koufen.Name = "l_koufen";
            this.l_koufen.Size = new System.Drawing.Size(40, 16);
            this.l_koufen.TabIndex = 9;
            this.l_koufen.Text = "扣分";
            // 
            // QuizResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.l_koufen);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.picFace);
            this.Controls.Add(this.lblMark);
            this.Controls.Add(this.lbl100);
            this.Controls.Add(this.lblFullMarkStrip);
            this.Controls.Add(this.lblFullMark);
            this.Controls.Add(this.lblStudentScoreStrip);
            this.Controls.Add(this.lblStudentScore);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "QuizResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "答题结果";
            this.Load += new System.EventHandler(this.QuizResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentScore;
        private System.Windows.Forms.Label lblStudentScoreStrip;
        private System.Windows.Forms.Label lblFullMark;
        private System.Windows.Forms.Label lblFullMarkStrip;
        private System.Windows.Forms.Label lbl100;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList ilFaces;
        private System.Windows.Forms.Label l_koufen;
    }
}