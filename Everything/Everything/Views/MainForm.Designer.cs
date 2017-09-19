namespace Everything.Views
{
    partial class MainForm
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
            this.CBDrives = new System.Windows.Forms.ComboBox();
            this.BTFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBLastUsn = new System.Windows.Forms.TextBox();
            this.TBResult = new System.Windows.Forms.TextBox();
            this.TBLastFrn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBDrives
            // 
            this.CBDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDrives.FormattingEnabled = true;
            this.CBDrives.Location = new System.Drawing.Point(158, 15);
            this.CBDrives.Name = "CBDrives";
            this.CBDrives.Size = new System.Drawing.Size(129, 20);
            this.CBDrives.TabIndex = 0;
            // 
            // BTFind
            // 
            this.BTFind.Location = new System.Drawing.Point(364, 49);
            this.BTFind.Name = "BTFind";
            this.BTFind.Size = new System.Drawing.Size(109, 55);
            this.BTFind.TabIndex = 1;
            this.BTFind.Text = "查找 [○-]";
            this.BTFind.UseVisualStyleBackColor = true;
            this.BTFind.Click += new System.EventHandler(this.BTFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择磁盘：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "上次最后 USN 数值：";
            // 
            // TBLastUsn
            // 
            this.TBLastUsn.Location = new System.Drawing.Point(158, 49);
            this.TBLastUsn.Name = "TBLastUsn";
            this.TBLastUsn.Size = new System.Drawing.Size(129, 21);
            this.TBLastUsn.TabIndex = 4;
            this.TBLastUsn.Text = "0";
            this.TBLastUsn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBLastUsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBLastUsn_KeyPress);
            // 
            // TBResult
            // 
            this.TBResult.Location = new System.Drawing.Point(14, 118);
            this.TBResult.Multiline = true;
            this.TBResult.Name = "TBResult";
            this.TBResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBResult.Size = new System.Drawing.Size(597, 427);
            this.TBResult.TabIndex = 5;
            // 
            // TBLastFrn
            // 
            this.TBLastFrn.Location = new System.Drawing.Point(158, 83);
            this.TBLastFrn.Name = "TBLastFrn";
            this.TBLastFrn.Size = new System.Drawing.Size(129, 21);
            this.TBLastFrn.TabIndex = 7;
            this.TBLastFrn.Text = "0";
            this.TBLastFrn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBLastFrn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBLastFrn_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "上次最后文件编号：";
            // 
            // BTLine
            // 
            this.BTLine.Location = new System.Drawing.Point(502, 49);
            this.BTLine.Name = "BTLine";
            this.BTLine.Size = new System.Drawing.Size(109, 55);
            this.BTLine.TabIndex = 8;
            this.BTLine.Text = "分割线 [---]";
            this.BTLine.UseVisualStyleBackColor = true;
            this.BTLine.Click += new System.EventHandler(this.BTLine_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 557);
            this.Controls.Add(this.BTLine);
            this.Controls.Add(this.TBLastFrn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBResult);
            this.Controls.Add(this.TBLastUsn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTFind);
            this.Controls.Add(this.CBDrives);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBDrives;
        private System.Windows.Forms.Button BTFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBLastUsn;
        private System.Windows.Forms.TextBox TBResult;
        private System.Windows.Forms.TextBox TBLastFrn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTLine;
    }
}