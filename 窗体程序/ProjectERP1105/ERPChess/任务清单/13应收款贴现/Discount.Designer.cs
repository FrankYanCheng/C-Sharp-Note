namespace ERPChess
{
    partial class Discount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DiscountList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimePayLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeToMoney = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DiscountList,
            this.TotalPayTime,
            this.TimePayLeft,
            this.moneyLost,
            this.DiscountLeft,
            this.ChangeToMoney});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(13, 9);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(765, 336);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(469, 368);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(100, 31);
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "确定";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(602, 368);
            this.buttonX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(100, 31);
            this.buttonX2.TabIndex = 2;
            this.buttonX2.Text = "取消";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(273, 379);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 20);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "全选";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DiscountList
            // 
            this.DiscountList.HeaderText = "应收款";
            this.DiscountList.Name = "DiscountList";
            this.DiscountList.Width = 120;
            // 
            // TotalPayTime
            // 
            this.TotalPayTime.HeaderText = "总账期";
            this.TotalPayTime.Name = "TotalPayTime";
            this.TotalPayTime.Width = 120;
            // 
            // TimePayLeft
            // 
            this.TimePayLeft.HeaderText = "剩余还账日期";
            this.TimePayLeft.Name = "TimePayLeft";
            this.TimePayLeft.Width = 160;
            // 
            // moneyLost
            // 
            this.moneyLost.HeaderText = "变现费用";
            this.moneyLost.Name = "moneyLost";
            this.moneyLost.Width = 120;
            // 
            // DiscountLeft
            // 
            this.DiscountLeft.HeaderText = "变现剩余";
            this.DiscountLeft.Name = "DiscountLeft";
            this.DiscountLeft.Width = 120;
            // 
            // ChangeToMoney
            // 
            this.ChangeToMoney.HeaderText = "贴现";
            this.ChangeToMoney.Name = "ChangeToMoney";
            this.ChangeToMoney.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChangeToMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChangeToMoney.Width = 120;
            // 
            // Discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 422);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "应收款";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountList;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPayTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimePayLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountLeft;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChangeToMoney;
    }
}