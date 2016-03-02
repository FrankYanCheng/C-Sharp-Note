namespace ERPChess
{
    partial class Certification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Certification));
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.certificate_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Security = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISO9000 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISO14000 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISO18000 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonX_Sure = new DevComponents.DotNetBar.ButtonX();
            this.button_Romove = new DevComponents.DotNetBar.ButtonX();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.ColumnHeadersHeight = 35;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.certificate_Type,
            this.Security,
            this.ISO9000,
            this.ISO14000,
            this.ISO18000});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 30;
            this.dataGridViewX1.Size = new System.Drawing.Size(794, 178);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // certificate_Type
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.certificate_Type.DefaultCellStyle = dataGridViewCellStyle1;
            this.certificate_Type.HeaderText = "资格认证";
            this.certificate_Type.Name = "certificate_Type";
            this.certificate_Type.Width = 155;
            // 
            // Security
            // 
            this.Security.HeaderText = "安全生产证书";
            this.Security.Name = "Security";
            this.Security.Width = 155;
            // 
            // ISO9000
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ISO9000.DefaultCellStyle = dataGridViewCellStyle2;
            this.ISO9000.HeaderText = "ISO 9000";
            this.ISO9000.Name = "ISO9000";
            this.ISO9000.Width = 155;
            // 
            // ISO14000
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ISO14000.DefaultCellStyle = dataGridViewCellStyle3;
            this.ISO14000.HeaderText = "ISO 14000";
            this.ISO14000.Name = "ISO14000";
            this.ISO14000.Width = 155;
            // 
            // ISO18000
            // 
            this.ISO18000.HeaderText = "ISO 18000";
            this.ISO18000.Name = "ISO18000";
            this.ISO18000.Width = 155;
            // 
            // buttonX_Sure
            // 
            this.buttonX_Sure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Sure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Sure.Location = new System.Drawing.Point(506, 382);
            this.buttonX_Sure.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX_Sure.Name = "buttonX_Sure";
            this.buttonX_Sure.Size = new System.Drawing.Size(100, 31);
            this.buttonX_Sure.TabIndex = 1;
            this.buttonX_Sure.Text = "确定";
            this.buttonX_Sure.Click += new System.EventHandler(this.buttonX_Sure_Click);
            // 
            // button_Romove
            // 
            this.button_Romove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Romove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Romove.Location = new System.Drawing.Point(643, 381);
            this.button_Romove.Margin = new System.Windows.Forms.Padding(4);
            this.button_Romove.Name = "button_Romove";
            this.button_Romove.Size = new System.Drawing.Size(100, 31);
            this.button_Romove.TabIndex = 2;
            this.button_Romove.Text = "取消";
            this.button_Romove.Click += new System.EventHandler(this.button_Romove_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(447, 349);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 20);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "投资ISO14000";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(297, 349);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(115, 20);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "投资ISO9000";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(20, 342);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(105, 31);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "今年投资选项";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(604, 349);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(123, 20);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "投资ISO18000";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(133, 349);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(123, 20);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "投资安全生产";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 138);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(788, 113);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // Certification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_Romove);
            this.Controls.Add(this.buttonX_Sure);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Certification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "证书投入";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Certification_FormClosed);
            this.Load += new System.EventHandler(this.Certification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonX_Sure;
        private DevComponents.DotNetBar.ButtonX button_Romove;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn certificate_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Security;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISO9000;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISO14000;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISO18000;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}