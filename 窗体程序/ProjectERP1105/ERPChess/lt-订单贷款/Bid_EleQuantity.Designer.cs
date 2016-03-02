namespace ERPChess
{
    partial class Bid_EleQuantity
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
            this.lab_title = new DevComponents.DotNetBar.LabelX();
            this.lab_infor = new DevComponents.DotNetBar.LabelX();
            this.lab_Amount = new DevComponents.DotNetBar.LabelX();
            this.lab_UnitPrice = new DevComponents.DotNetBar.LabelX();
            this.lab_Total = new DevComponents.DotNetBar.LabelX();
            this.lab_PayDay = new DevComponents.DotNetBar.LabelX();
            this.lab_GroupNum = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.btn_OK = new DevComponents.DotNetBar.ButtonX();
            this.btn_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.textBox_UnitPrice = new System.Windows.Forms.TextBox();
            this.labelX_time = new DevComponents.DotNetBar.LabelX();
            this.timer_time = new System.Windows.Forms.Timer(this.components);
            this.timer_color = new System.Windows.Forms.Timer(this.components);
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.lab_PayDay1 = new DevComponents.DotNetBar.LabelX();
            this.lab_Group = new DevComponents.DotNetBar.LabelX();
            this.lab_Year = new DevComponents.DotNetBar.LabelX();
            this.lab_BidNum = new DevComponents.DotNetBar.LabelX();
            this.lab_Total1 = new DevComponents.DotNetBar.LabelX();
            this.lab_Amount1 = new DevComponents.DotNetBar.LabelX();
            this.lbl_isNitric = new DevComponents.DotNetBar.LabelX();
            this.lbl_ISO = new DevComponents.DotNetBar.LabelX();
            this.lbl_infor = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // lab_title
            // 
            this.lab_title.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_title.ForeColor = System.Drawing.Color.Black;
            this.lab_title.Location = new System.Drawing.Point(3, 4);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(248, 38);
            this.lab_title.TabIndex = 0;
            this.lab_title.Text = "工商业及其他竞价订单";
            this.lab_title.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lab_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lab_title_MouseDown);
            this.lab_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lab_title_MouseMove);
            // 
            // lab_infor
            // 
            // 
            // 
            // 
            this.lab_infor.BackgroundStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.lab_infor.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.ControlText;
            this.lab_infor.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lab_infor.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ControlText;
            this.lab_infor.BackgroundStyle.BorderBottomWidth = 1;
            this.lab_infor.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lab_infor.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lab_infor.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lab_infor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_infor.ForeColor = System.Drawing.Color.Black;
            this.lab_infor.Location = new System.Drawing.Point(-1, 47);
            this.lab_infor.Name = "lab_infor";
            this.lab_infor.Size = new System.Drawing.Size(295, 31);
            this.lab_infor.TabIndex = 1;
            this.lab_infor.Text = "第    年  单号 ";
            this.lab_infor.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lab_Amount
            // 
            this.lab_Amount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Amount.ForeColor = System.Drawing.Color.Black;
            this.lab_Amount.Location = new System.Drawing.Point(87, 89);
            this.lab_Amount.Name = "lab_Amount";
            this.lab_Amount.Size = new System.Drawing.Size(155, 23);
            this.lab_Amount.TabIndex = 2;
            this.lab_Amount.Text = "需求量：    亿度";
            // 
            // lab_UnitPrice
            // 
            this.lab_UnitPrice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_UnitPrice.ForeColor = System.Drawing.Color.Black;
            this.lab_UnitPrice.Location = new System.Drawing.Point(87, 122);
            this.lab_UnitPrice.Name = "lab_UnitPrice";
            this.lab_UnitPrice.Size = new System.Drawing.Size(155, 23);
            this.lab_UnitPrice.TabIndex = 3;
            this.lab_UnitPrice.Text = "单价：      元/度";
            // 
            // lab_Total
            // 
            this.lab_Total.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Total.ForeColor = System.Drawing.Color.Black;
            this.lab_Total.Location = new System.Drawing.Point(87, 151);
            this.lab_Total.Name = "lab_Total";
            this.lab_Total.Size = new System.Drawing.Size(155, 23);
            this.lab_Total.TabIndex = 4;
            this.lab_Total.Text = "金额：      百万";
            // 
            // lab_PayDay
            // 
            this.lab_PayDay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_PayDay.ForeColor = System.Drawing.Color.Black;
            this.lab_PayDay.Location = new System.Drawing.Point(87, 180);
            this.lab_PayDay.Name = "lab_PayDay";
            this.lab_PayDay.Size = new System.Drawing.Size(155, 23);
            this.lab_PayDay.TabIndex = 5;
            this.lab_PayDay.Text = "账期：       年";
            // 
            // lab_GroupNum
            // 
            this.lab_GroupNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_GroupNum.ForeColor = System.Drawing.Color.Black;
            this.lab_GroupNum.Location = new System.Drawing.Point(13, 87);
            this.lab_GroupNum.Name = "lab_GroupNum";
            this.lab_GroupNum.Size = new System.Drawing.Size(68, 125);
            this.lab_GroupNum.TabIndex = 6;
            this.lab_GroupNum.Text = "第\r\n\r\n\r\n\r\n组\r\n";
            this.lab_GroupNum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX8.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.ControlText;
            this.labelX8.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.WindowText;
            this.labelX8.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX8.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.BackgroundStyle.BorderLeftColor = System.Drawing.SystemColors.WindowText;
            this.labelX8.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX8.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.BackgroundStyle.BorderRightColor = System.Drawing.SystemColors.WindowText;
            this.labelX8.BackgroundStyle.BorderRightWidth = 1;
            this.labelX8.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX8.Location = new System.Drawing.Point(-11, 216);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(305, 36);
            this.labelX8.TabIndex = 7;
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_OK.Location = new System.Drawing.Point(52, 275);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "提交";
            this.btn_OK.Click += new System.EventHandler(this.buttonX_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Cancel.Location = new System.Drawing.Point(167, 275);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "放弃";
            this.btn_Cancel.Click += new System.EventHandler(this.buttonX_Cancel_Click);
            // 
            // textBox_UnitPrice
            // 
            this.textBox_UnitPrice.Location = new System.Drawing.Point(132, 122);
            this.textBox_UnitPrice.Name = "textBox_UnitPrice";
            this.textBox_UnitPrice.Size = new System.Drawing.Size(52, 21);
            this.textBox_UnitPrice.TabIndex = 10;
            // 
            // labelX_time
            // 
            this.labelX_time.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_time.Location = new System.Drawing.Point(237, 4);
            this.labelX_time.Name = "labelX_time";
            this.labelX_time.Size = new System.Drawing.Size(49, 39);
            this.labelX_time.TabIndex = 12;
            this.labelX_time.Text = "30";
            this.labelX_time.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // timer_time
            // 
            this.timer_time.Interval = 1000;
            this.timer_time.Tick += new System.EventHandler(this.timer_time_Tick);
            // 
            // timer_color
            // 
            this.timer_color.Tick += new System.EventHandler(this.timer_color_Tick);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX3.BackgroundStyle.BorderLeftColor = System.Drawing.SystemColors.ControlText;
            this.labelX3.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX3.Location = new System.Drawing.Point(293, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(10, 310);
            this.labelX3.TabIndex = 14;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(300, 13);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 15;
            this.labelX4.Text = "订单结果:";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(300, 42);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(169, 262);
            this.rtbInfo.TabIndex = 16;
            this.rtbInfo.TabStop = false;
            this.rtbInfo.Text = "";
            // 
            // lab_PayDay1
            // 
            this.lab_PayDay1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_PayDay1.Location = new System.Drawing.Point(132, 180);
            this.lab_PayDay1.Name = "lab_PayDay1";
            this.lab_PayDay1.Size = new System.Drawing.Size(52, 23);
            this.lab_PayDay1.TabIndex = 17;
            this.lab_PayDay1.Text = "0";
            this.lab_PayDay1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lab_Group
            // 
            this.lab_Group.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Group.Location = new System.Drawing.Point(32, 137);
            this.lab_Group.Name = "lab_Group";
            this.lab_Group.Size = new System.Drawing.Size(27, 23);
            this.lab_Group.TabIndex = 18;
            this.lab_Group.Text = "10";
            this.lab_Group.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lab_Year
            // 
            this.lab_Year.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Year.Location = new System.Drawing.Point(109, 48);
            this.lab_Year.Name = "lab_Year";
            this.lab_Year.Size = new System.Drawing.Size(27, 23);
            this.lab_Year.TabIndex = 19;
            this.lab_Year.Text = "0";
            this.lab_Year.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lab_BidNum
            // 
            this.lab_BidNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_BidNum.Location = new System.Drawing.Point(209, 48);
            this.lab_BidNum.Name = "lab_BidNum";
            this.lab_BidNum.Size = new System.Drawing.Size(61, 23);
            this.lab_BidNum.TabIndex = 20;
            this.lab_BidNum.Text = "0";
            this.lab_BidNum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lab_Total1
            // 
            this.lab_Total1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Total1.Location = new System.Drawing.Point(132, 151);
            this.lab_Total1.Name = "lab_Total1";
            this.lab_Total1.Size = new System.Drawing.Size(52, 23);
            this.lab_Total1.TabIndex = 21;
            this.lab_Total1.Text = "0";
            this.lab_Total1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lab_Amount1
            // 
            this.lab_Amount1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Amount1.Location = new System.Drawing.Point(149, 87);
            this.lab_Amount1.Name = "lab_Amount1";
            this.lab_Amount1.Size = new System.Drawing.Size(33, 23);
            this.lab_Amount1.TabIndex = 22;
            this.lab_Amount1.Text = "0";
            this.lab_Amount1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_isNitric
            // 
            this.lbl_isNitric.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_isNitric.ForeColor = System.Drawing.Color.Black;
            this.lbl_isNitric.Location = new System.Drawing.Point(52, 223);
            this.lbl_isNitric.Name = "lbl_isNitric";
            this.lbl_isNitric.Size = new System.Drawing.Size(95, 23);
            this.lbl_isNitric.TabIndex = 23;
            this.lbl_isNitric.Text = "脱硫、脱销";
            // 
            // lbl_ISO
            // 
            this.lbl_ISO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ISO.ForeColor = System.Drawing.Color.Black;
            this.lbl_ISO.Location = new System.Drawing.Point(158, 223);
            this.lbl_ISO.Name = "lbl_ISO";
            this.lbl_ISO.Size = new System.Drawing.Size(93, 23);
            this.lbl_ISO.TabIndex = 24;
            this.lbl_ISO.Text = "ISO9000";
            this.lbl_ISO.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_infor
            // 
            this.lbl_infor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_infor.ForeColor = System.Drawing.Color.Red;
            this.lbl_infor.Location = new System.Drawing.Point(3, 254);
            this.lbl_infor.Name = "lbl_infor";
            this.lbl_infor.Size = new System.Drawing.Size(283, 18);
            this.lbl_infor.TabIndex = 25;
            this.lbl_infor.Text = "由于您的条件不符合，您不能参与该订单的竞拍";
            this.lbl_infor.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Bid_EleQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 316);
            this.Controls.Add(this.lbl_infor);
            this.Controls.Add(this.lbl_ISO);
            this.Controls.Add(this.lbl_isNitric);
            this.Controls.Add(this.lab_Amount1);
            this.Controls.Add(this.lab_Total1);
            this.Controls.Add(this.lab_BidNum);
            this.Controls.Add(this.lab_Year);
            this.Controls.Add(this.lab_Group);
            this.Controls.Add(this.lab_PayDay1);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX_time);
            this.Controls.Add(this.textBox_UnitPrice);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.lab_GroupNum);
            this.Controls.Add(this.lab_PayDay);
            this.Controls.Add(this.lab_Total);
            this.Controls.Add(this.lab_UnitPrice);
            this.Controls.Add(this.lab_Amount);
            this.Controls.Add(this.lab_infor);
            this.Controls.Add(this.lab_title);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bid_EleQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bid_EleQuantity";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Bid_EleQuantity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lab_title;
        private DevComponents.DotNetBar.LabelX lab_infor;
        private DevComponents.DotNetBar.LabelX lab_Amount;
        private DevComponents.DotNetBar.LabelX lab_UnitPrice;
        private DevComponents.DotNetBar.LabelX lab_Total;
        private DevComponents.DotNetBar.LabelX lab_PayDay;
        private DevComponents.DotNetBar.LabelX lab_GroupNum;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ButtonX btn_OK;
        private DevComponents.DotNetBar.ButtonX btn_Cancel;
        public System.Windows.Forms.TextBox textBox_UnitPrice;
        private DevComponents.DotNetBar.LabelX labelX_time;
        public System.Windows.Forms.Timer timer_time;
        private System.Windows.Forms.Timer timer_color;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        public System.Windows.Forms.RichTextBox rtbInfo;
        private DevComponents.DotNetBar.LabelX lab_PayDay1;
        private DevComponents.DotNetBar.LabelX lab_Year;
        private DevComponents.DotNetBar.LabelX lab_Group;
        private DevComponents.DotNetBar.LabelX lab_BidNum;
        private DevComponents.DotNetBar.LabelX lab_Total1;
        private DevComponents.DotNetBar.LabelX lab_Amount1;
        private DevComponents.DotNetBar.LabelX lbl_isNitric;
        private DevComponents.DotNetBar.LabelX lbl_ISO;
        private DevComponents.DotNetBar.LabelX lbl_infor;
    }
}