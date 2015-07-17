namespace CropWatchField
{
    partial class WaterFindtableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaterFindtableForm));
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_WatertableOutpath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OpenOutPutpath = new System.Windows.Forms.Button();
            this.txt_WatertableOutpath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(280, 77);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 31;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(181, 77);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 30;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(439, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "建立查找表";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(408, 11);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(178, 128);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "\n\n";
            // 
            // btn_WatertableOutpath
            // 
            this.btn_WatertableOutpath.Image = ((System.Drawing.Image)(resources.GetObject("btn_WatertableOutpath.Image")));
            this.btn_WatertableOutpath.Location = new System.Drawing.Point(361, 27);
            this.btn_WatertableOutpath.Name = "btn_WatertableOutpath";
            this.btn_WatertableOutpath.Size = new System.Drawing.Size(31, 24);
            this.btn_WatertableOutpath.TabIndex = 26;
            this.btn_WatertableOutpath.UseVisualStyleBackColor = true;
            this.btn_WatertableOutpath.Click += new System.EventHandler(this.btn_WatertableOutpath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "输出文件夹";
            // 
            // btn_OpenOutPutpath
            // 
            this.btn_OpenOutPutpath.Location = new System.Drawing.Point(245, 115);
            this.btn_OpenOutPutpath.Name = "btn_OpenOutPutpath";
            this.btn_OpenOutPutpath.Size = new System.Drawing.Size(110, 24);
            this.btn_OpenOutPutpath.TabIndex = 32;
            this.btn_OpenOutPutpath.Text = "打开输出文件夹";
            this.btn_OpenOutPutpath.UseVisualStyleBackColor = true;
            this.btn_OpenOutPutpath.Click += new System.EventHandler(this.btn_OpenOutPutpath_Click);
            // 
            // txt_WatertableOutpath
            // 
            this.txt_WatertableOutpath.Location = new System.Drawing.Point(27, 30);
            this.txt_WatertableOutpath.Name = "txt_WatertableOutpath";
            this.txt_WatertableOutpath.Size = new System.Drawing.Size(328, 21);
            this.txt_WatertableOutpath.TabIndex = 89;
            // 
            // WaterFindtableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 155);
            this.Controls.Add(this.txt_WatertableOutpath);
            this.Controls.Add(this.btn_OpenOutPutpath);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_WatertableOutpath);
            this.Controls.Add(this.label1);
            this.Name = "WaterFindtableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "建立查找表_水分";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_WatertableOutpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OpenOutPutpath;
        private System.Windows.Forms.TextBox txt_WatertableOutpath;

    }
}