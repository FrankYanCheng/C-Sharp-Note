namespace ERPChess
{
    partial class Form_loan1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_loan1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.but_OK = new DevComponents.DotNetBar.ButtonX();
            this.but_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(2, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(502, 357);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Location = new System.Drawing.Point(2, 380);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(184, 23);
            this.checkBoxX1.TabIndex = 1;
            this.checkBoxX1.Text = "我已阅读贷款规则和注意事项\r\n";
            // 
            // but_OK
            // 
            this.but_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.but_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.but_OK.Location = new System.Drawing.Point(319, 380);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(75, 23);
            this.but_OK.TabIndex = 2;
            this.but_OK.Text = "办理贷款";
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.but_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.but_Cancel.Location = new System.Drawing.Point(420, 379);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(75, 23);
            this.but_Cancel.TabIndex = 3;
            this.but_Cancel.Text = "不办理贷款";
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // Form_loan1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 425);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form_loan1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "办理贷款";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX but_OK;
        private DevComponents.DotNetBar.ButtonX but_Cancel;
    }
}