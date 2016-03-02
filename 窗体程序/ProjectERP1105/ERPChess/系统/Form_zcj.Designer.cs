namespace ERPChess
{
    partial class Form_zcj
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
            this.dgg = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgg)).BeginInit();
            this.SuspendLayout();
            // 
            // dgg
            // 
            this.dgg.AllowSorting = false;
            this.dgg.AlternatingBackColor = System.Drawing.Color.Silver;
            this.dgg.BackColor = System.Drawing.Color.White;
            this.dgg.BackgroundColor = System.Drawing.Color.Gold;
            this.dgg.CaptionBackColor = System.Drawing.Color.Maroon;
            this.dgg.CaptionFont = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgg.CaptionForeColor = System.Drawing.Color.Gold;
            this.dgg.CaptionText = "光 荣 榜";
            this.dgg.DataMember = "";
            this.dgg.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgg.ForeColor = System.Drawing.Color.Red;
            this.dgg.GridLineColor = System.Drawing.Color.Red;
            this.dgg.HeaderBackColor = System.Drawing.Color.Gold;
            this.dgg.HeaderFont = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgg.HeaderForeColor = System.Drawing.Color.Red;
            this.dgg.LinkColor = System.Drawing.Color.Maroon;
            this.dgg.Location = new System.Drawing.Point(55, 12);
            this.dgg.Name = "dgg";
            this.dgg.ParentRowsBackColor = System.Drawing.Color.Silver;
            this.dgg.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dgg.PreferredColumnWidth = 90;
            this.dgg.ReadOnly = true;
            this.dgg.RowHeaderWidth = 5;
            this.dgg.SelectionBackColor = System.Drawing.Color.Maroon;
            this.dgg.SelectionForeColor = System.Drawing.Color.White;
            this.dgg.Size = new System.Drawing.Size(316, 334);
            this.dgg.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "退  出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 418);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgg);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "光荣榜";
            this.Load += new System.EventHandler(this.Form_zcj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dgg;
        private System.Windows.Forms.Button button1;


    }
}