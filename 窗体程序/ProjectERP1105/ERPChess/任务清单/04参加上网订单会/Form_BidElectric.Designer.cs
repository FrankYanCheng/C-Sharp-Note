namespace ERPChess
{
    partial class Form_BidElectric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BidElectric));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.but_OK = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(774, 348);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBoxX1.Location = new System.Drawing.Point(129, 384);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(245, 34);
            this.checkBoxX1.TabIndex = 1;
            this.checkBoxX1.Text = "我已阅读竞价规则和注意事项";
            // 
            // but_OK
            // 
            this.but_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.but_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.but_OK.Font = new System.Drawing.Font("宋体", 12F);
            this.but_OK.Location = new System.Drawing.Point(630, 384);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(75, 32);
            this.but_OK.TabIndex = 2;
            this.but_OK.Text = "下一步";
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 373);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // Form_BidElectric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.checkBoxX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_BidElectric";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参加电量订单会";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_BidElectric_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_BidElectric_FormClosed);
            this.Load += new System.EventHandler(this.Form_BidElectric_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.ButtonX but_OK;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}