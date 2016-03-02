namespace ERPChess
{
    partial class Form_SLoan
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.but_OK = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.but_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 22);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(737, 210);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "短期贷款\n短期贷款的方格代表一个年度，即可完成新短期贷款的办理业务。（贷款利率为6%每年支付。）";
            // 
            // but_OK
            // 
            this.but_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.but_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.but_OK.Location = new System.Drawing.Point(449, 347);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 31);
            this.but_OK.TabIndex = 1;
            this.but_OK.Text = "办理贷款";
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Location = new System.Drawing.Point(63, 347);
            this.checkBoxX1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(237, 31);
            this.checkBoxX1.TabIndex = 2;
            this.checkBoxX1.Text = "我已阅读办理短期贷款规则";
            // 
            // but_Cancel
            // 
            this.but_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.but_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.but_Cancel.Location = new System.Drawing.Point(623, 347);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 31);
            this.but_Cancel.TabIndex = 3;
            this.but_Cancel.Text = "不办理贷款";
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(31, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 235);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // Form_SLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.but_OK);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form_SLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短期贷款";
            this.Load += new System.EventHandler(this.Form_SLoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevComponents.DotNetBar.ButtonX but_OK;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX but_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}