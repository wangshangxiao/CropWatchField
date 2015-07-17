namespace CropWatchField
{
    partial class ChlorophyllFindtableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChlorophyllFindtableForm));
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cbx_CCDType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_chtableOutPutpath = new System.Windows.Forms.TextBox();
            this.btn_chtableOutPutpath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_OpenOutPutpath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(264, 130);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 36;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(167, 130);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 35;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(5, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 14);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(440, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 32;
            this.label3.Text = "建立查找表";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(393, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(174, 188);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "\n\n   根据CCD数据的类型\n   建立对应的查找表";
            // 
            // cbx_CCDType
            // 
            this.cbx_CCDType.FormattingEnabled = true;
            this.cbx_CCDType.Location = new System.Drawing.Point(18, 42);
            this.cbx_CCDType.Name = "cbx_CCDType";
            this.cbx_CCDType.Size = new System.Drawing.Size(101, 20);
            this.cbx_CCDType.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "选择数据类型\r\n";
            // 
            // txt_chtableOutPutpath
            // 
            this.txt_chtableOutPutpath.Location = new System.Drawing.Point(18, 91);
            this.txt_chtableOutPutpath.Name = "txt_chtableOutPutpath";
            this.txt_chtableOutPutpath.Size = new System.Drawing.Size(321, 21);
            this.txt_chtableOutPutpath.TabIndex = 27;
            // 
            // btn_chtableOutPutpath
            // 
            this.btn_chtableOutPutpath.Image = ((System.Drawing.Image)(resources.GetObject("btn_chtableOutPutpath.Image")));
            this.btn_chtableOutPutpath.Location = new System.Drawing.Point(356, 88);
            this.btn_chtableOutPutpath.Name = "btn_chtableOutPutpath";
            this.btn_chtableOutPutpath.Size = new System.Drawing.Size(31, 24);
            this.btn_chtableOutPutpath.TabIndex = 28;
            this.btn_chtableOutPutpath.UseVisualStyleBackColor = true;
            this.btn_chtableOutPutpath.Click += new System.EventHandler(this.btn_chtableOutPutpath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "输出查找表";
            // 
            // btn_OpenOutPutpath
            // 
            this.btn_OpenOutPutpath.Location = new System.Drawing.Point(228, 164);
            this.btn_OpenOutPutpath.Name = "btn_OpenOutPutpath";
            this.btn_OpenOutPutpath.Size = new System.Drawing.Size(111, 23);
            this.btn_OpenOutPutpath.TabIndex = 37;
            this.btn_OpenOutPutpath.Text = "打开输出文件夹";
            this.btn_OpenOutPutpath.UseVisualStyleBackColor = true;
            this.btn_OpenOutPutpath.Click += new System.EventHandler(this.btn_OpenOutPutpath_Click);
            // 
            // ChlorophyllFindtableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 196);
            this.Controls.Add(this.btn_OpenOutPutpath);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cbx_CCDType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_chtableOutPutpath);
            this.Controls.Add(this.btn_chtableOutPutpath);
            this.Controls.Add(this.label2);
            this.Name = "ChlorophyllFindtableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "建立查找表_叶绿素含量";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cbx_CCDType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_chtableOutPutpath;
        private System.Windows.Forms.Button btn_chtableOutPutpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_OpenOutPutpath;
    }
}