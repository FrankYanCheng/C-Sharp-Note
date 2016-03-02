namespace ERPChess
{
    partial class frmBid_Capacity
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
            this.labelX_Name = new DevComponents.DotNetBar.LabelX();
            this.labelX_OrderNum = new DevComponents.DotNetBar.LabelX();
            this.lbl_a = new DevComponents.DotNetBar.LabelX();
            this.lbl_p = new DevComponents.DotNetBar.LabelX();
            this.lbl_tt = new DevComponents.DotNetBar.LabelX();
            this.lbl_day = new DevComponents.DotNetBar.LabelX();
            this.labelX_GroupNum = new DevComponents.DotNetBar.LabelX();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.lbl_yearlimit = new DevComponents.DotNetBar.LabelX();
            this.lbl_price = new DevComponents.DotNetBar.LabelX();
            this.lbl_sum = new DevComponents.DotNetBar.LabelX();
            this.lbl_amount = new DevComponents.DotNetBar.LabelX();
            this.lbl_num = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX_Name
            // 
            this.labelX_Name.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_Name.ForeColor = System.Drawing.Color.Black;
            this.labelX_Name.Location = new System.Drawing.Point(1, 3);
            this.labelX_Name.Name = "labelX_Name";
            this.labelX_Name.Size = new System.Drawing.Size(290, 34);
            this.labelX_Name.TabIndex = 0;
            this.labelX_Name.Text = "非竞价电量订单";
            this.labelX_Name.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX_Name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelX_Name_MouseDown);
            this.labelX_Name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelX_Name_MouseMove);
            // 
            // labelX_OrderNum
            // 
            // 
            // 
            // 
            this.labelX_OrderNum.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelX_OrderNum.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.labelX_OrderNum.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX_OrderNum.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ControlText;
            this.labelX_OrderNum.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX_OrderNum.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX_OrderNum.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX_OrderNum.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX_OrderNum.CommandParameter = "";
            this.labelX_OrderNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_OrderNum.ForeColor = System.Drawing.Color.Black;
            this.labelX_OrderNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelX_OrderNum.Location = new System.Drawing.Point(-1, 31);
            this.labelX_OrderNum.Name = "labelX_OrderNum";
            this.labelX_OrderNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX_OrderNum.SingleLineColor = System.Drawing.SystemColors.ControlText;
            this.labelX_OrderNum.Size = new System.Drawing.Size(290, 29);
            this.labelX_OrderNum.TabIndex = 1;
            this.labelX_OrderNum.Text = "第一年   单号";
            this.labelX_OrderNum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_a
            // 
            this.lbl_a.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_a.ForeColor = System.Drawing.Color.Black;
            this.lbl_a.Location = new System.Drawing.Point(71, 74);
            this.lbl_a.Name = "lbl_a";
            this.lbl_a.Size = new System.Drawing.Size(153, 23);
            this.lbl_a.TabIndex = 2;
            this.lbl_a.Text = "需求量：     亿度";
            // 
            // lbl_p
            // 
            this.lbl_p.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_p.ForeColor = System.Drawing.Color.Black;
            this.lbl_p.Location = new System.Drawing.Point(71, 105);
            this.lbl_p.Name = "lbl_p";
            this.lbl_p.Size = new System.Drawing.Size(162, 23);
            this.lbl_p.TabIndex = 3;
            this.lbl_p.Text = "单价：     元/度";
            // 
            // lbl_tt
            // 
            this.lbl_tt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tt.ForeColor = System.Drawing.Color.Black;
            this.lbl_tt.Location = new System.Drawing.Point(71, 133);
            this.lbl_tt.Name = "lbl_tt";
            this.lbl_tt.Size = new System.Drawing.Size(182, 26);
            this.lbl_tt.TabIndex = 4;
            this.lbl_tt.Text = "金额：         百万元";
            // 
            // lbl_day
            // 
            this.lbl_day.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_day.ForeColor = System.Drawing.Color.Black;
            this.lbl_day.Location = new System.Drawing.Point(72, 165);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(152, 23);
            this.lbl_day.TabIndex = 5;
            this.lbl_day.Text = "账期:        年";
            // 
            // labelX_GroupNum
            // 
            this.labelX_GroupNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_GroupNum.ForeColor = System.Drawing.Color.Black;
            this.labelX_GroupNum.Location = new System.Drawing.Point(8, 73);
            this.labelX_GroupNum.Name = "labelX_GroupNum";
            this.labelX_GroupNum.Size = new System.Drawing.Size(60, 115);
            this.labelX_GroupNum.TabIndex = 6;
            this.labelX_GroupNum.Text = "第\r\n  \r\n\r\n组";
            this.labelX_GroupNum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ok.Location = new System.Drawing.Point(105, 221);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "确认";
            this.btn_ok.Click += new System.EventHandler(this.btn_Click);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelX8.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile;
            this.labelX8.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ControlText;
            this.labelX8.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX8.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.CommandParameter = "";
            this.labelX8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelX8.Location = new System.Drawing.Point(-3, 200);
            this.labelX8.Name = "labelX8";
            this.labelX8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX8.SingleLineColor = System.Drawing.SystemColors.ControlText;
            this.labelX8.Size = new System.Drawing.Size(300, 10);
            this.labelX8.TabIndex = 8;
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_yearlimit
            // 
            this.lbl_yearlimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_yearlimit.ForeColor = System.Drawing.Color.Black;
            this.lbl_yearlimit.Location = new System.Drawing.Point(131, 162);
            this.lbl_yearlimit.Name = "lbl_yearlimit";
            this.lbl_yearlimit.Size = new System.Drawing.Size(39, 23);
            this.lbl_yearlimit.TabIndex = 9;
            this.lbl_yearlimit.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_price
            // 
            this.lbl_price.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_price.ForeColor = System.Drawing.Color.Black;
            this.lbl_price.Location = new System.Drawing.Point(120, 103);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(39, 23);
            this.lbl_price.TabIndex = 10;
            this.lbl_price.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_sum
            // 
            this.lbl_sum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sum.ForeColor = System.Drawing.Color.Black;
            this.lbl_sum.Location = new System.Drawing.Point(120, 132);
            this.lbl_sum.Name = "lbl_sum";
            this.lbl_sum.Size = new System.Drawing.Size(70, 23);
            this.lbl_sum.TabIndex = 11;
            this.lbl_sum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_amount
            // 
            this.lbl_amount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_amount.ForeColor = System.Drawing.Color.Black;
            this.lbl_amount.Location = new System.Drawing.Point(136, 71);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(39, 23);
            this.lbl_amount.TabIndex = 12;
            this.lbl_amount.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_num
            // 
            this.lbl_num.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_num.ForeColor = System.Drawing.Color.Black;
            this.lbl_num.Location = new System.Drawing.Point(208, 34);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(45, 23);
            this.lbl_num.TabIndex = 13;
            this.lbl_num.Text = "1/6";
            this.lbl_num.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmBid_Capacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.lbl_num);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.lbl_sum);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.lbl_yearlimit);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.labelX_GroupNum);
            this.Controls.Add(this.lbl_day);
            this.Controls.Add(this.lbl_tt);
            this.Controls.Add(this.lbl_p);
            this.Controls.Add(this.lbl_a);
            this.Controls.Add(this.labelX_OrderNum);
            this.Controls.Add(this.labelX_Name);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBid_Capacity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bid_Capacity";
            this.Load += new System.EventHandler(this.frmBid_Capacity_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX_Name;
        private DevComponents.DotNetBar.LabelX labelX_OrderNum;
        private DevComponents.DotNetBar.LabelX lbl_a;
        private DevComponents.DotNetBar.LabelX lbl_p;
        private DevComponents.DotNetBar.LabelX lbl_tt;
        private DevComponents.DotNetBar.LabelX lbl_day;
        private DevComponents.DotNetBar.LabelX labelX_GroupNum;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX lbl_yearlimit;
        private DevComponents.DotNetBar.LabelX lbl_price;
        private DevComponents.DotNetBar.LabelX lbl_sum;
        private DevComponents.DotNetBar.LabelX lbl_amount;
        private DevComponents.DotNetBar.LabelX lbl_num;
    }
}