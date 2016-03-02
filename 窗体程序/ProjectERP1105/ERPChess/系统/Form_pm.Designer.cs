namespace ERPChess
{
    partial class Form_pm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dg1 = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dg1);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 326);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本次游戏排名";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(557, 288);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "退  出";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "查看总排行榜";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "查看单项评价图表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "导出成绩";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dg1
            // 
            this.dg1.AllowSorting = false;
            this.dg1.AlternatingBackColor = System.Drawing.Color.GhostWhite;
            this.dg1.BackColor = System.Drawing.Color.GhostWhite;
            this.dg1.BackgroundColor = System.Drawing.Color.Lavender;
            this.dg1.CaptionBackColor = System.Drawing.Color.RoyalBlue;
            this.dg1.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg1.CaptionForeColor = System.Drawing.Color.White;
            this.dg1.CaptionText = "排名表";
            this.dg1.DataMember = "";
            this.dg1.FlatMode = true;
            this.dg1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dg1.GridLineColor = System.Drawing.Color.RoyalBlue;
            this.dg1.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this.dg1.HeaderFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg1.HeaderForeColor = System.Drawing.Color.Lavender;
            this.dg1.LinkColor = System.Drawing.Color.Teal;
            this.dg1.Location = new System.Drawing.Point(1, 28);
            this.dg1.Name = "dg1";
            this.dg1.ParentRowsBackColor = System.Drawing.Color.Lavender;
            this.dg1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dg1.PreferredColumnWidth = 95;
            this.dg1.ReadOnly = true;
            this.dg1.RowHeaderWidth = 1;
            this.dg1.SelectionBackColor = System.Drawing.Color.Teal;
            this.dg1.SelectionForeColor = System.Drawing.Color.PaleGreen;
            this.dg1.Size = new System.Drawing.Size(683, 221);
            this.dg1.TabIndex = 4;
            // 
            // Form_pm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 363);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_pm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "排行榜";
            this.Load += new System.EventHandler(this.Form_pm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGrid dg1;
        private System.Windows.Forms.Button button4;

    }
}