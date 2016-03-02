namespace ERPChess
{
    partial class frmSplash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_AddString = new DevComponents.DotNetBar.LabelX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.prgX = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lbl_Vertion = new DevComponents.DotNetBar.LabelX();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_Info = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // lbl_AddString
            // 
            this.lbl_AddString.Location = new System.Drawing.Point(56, 138);
            this.lbl_AddString.Name = "lbl_AddString";
            this.lbl_AddString.Size = new System.Drawing.Size(282, 23);
            this.lbl_AddString.TabIndex = 0;
            this.lbl_AddString.Text = "添加正在加载的项目";
            this.lbl_AddString.UseWaitCursor = true;
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reflectionLabel1.Location = new System.Drawing.Point(30, 12);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(368, 54);
            this.reflectionLabel1.TabIndex = 1;
            this.reflectionLabel1.Text = "<b><font size=\"+2\"><i></i><font color=\"#B02B2C\">新疆电力公司管理人员模拟决策系统</font></font></b" +
                ">";
            this.reflectionLabel1.UseWaitCursor = true;
            // 
            // prgX
            // 
            this.prgX.BackColor = System.Drawing.Color.Transparent;
            this.prgX.Location = new System.Drawing.Point(13, 166);
            this.prgX.Name = "prgX";
            this.prgX.Size = new System.Drawing.Size(397, 23);
            this.prgX.TabIndex = 2;
            this.prgX.Text = "进度条";
            this.prgX.UseWaitCursor = true;
            this.prgX.Value = 1;
            // 
            // lbl_Vertion
            // 
            this.lbl_Vertion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Vertion.Location = new System.Drawing.Point(153, 68);
            this.lbl_Vertion.Name = "lbl_Vertion";
            this.lbl_Vertion.Size = new System.Drawing.Size(99, 23);
            this.lbl_Vertion.TabIndex = 3;
            this.lbl_Vertion.Text = "版本号";
            this.lbl_Vertion.UseWaitCursor = true;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbl_Info
            // 
            this.lbl_Info.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Info.Location = new System.Drawing.Point(12, 88);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(397, 44);
            this.lbl_Info.TabIndex = 4;
            this.lbl_Info.Text = "由于下一步骤涉及计时竞拍项目，为了保证公平公正，必\r\n须等待所有决策者准备完毕才可以进行下一步";
            this.lbl_Info.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lbl_Info.UseWaitCursor = true;
            this.lbl_Info.Visible = false;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 204);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.lbl_Vertion);
            this.Controls.Add(this.prgX);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.lbl_AddString);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.LabelX lbl_AddString;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        public DevComponents.DotNetBar.Controls.ProgressBarX prgX;
        private DevComponents.DotNetBar.LabelX lbl_Vertion;
        public System.Windows.Forms.Timer timer;
        private DevComponents.DotNetBar.LabelX lbl_Info;
    }
}