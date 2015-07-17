namespace CropWatchField
{
    partial class ChlorophyllRetrievalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChlorophyllRetrievalForm));
            this.label5 = new System.Windows.Forms.Label();
            this.dT_RSData = new System.Windows.Forms.DateTimePicker();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_chtableinpath = new System.Windows.Forms.Button();
            this.listViewImage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_ChImageOutPath = new System.Windows.Forms.TextBox();
            this.btn_ChImageOutPath = new System.Windows.Forms.Button();
            this.txt_ImageInputpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_ImageInputpath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_chtableinpath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_OpenOutPutpath = new System.Windows.Forms.Button();
            this.btn_Down_CCD = new System.Windows.Forms.Button();
            this.btn_Up_CCD = new System.Windows.Forms.Button();
            this.btn_ImageRefer_Inputpath = new System.Windows.Forms.Button();
            this.txt_ImageRefer_Inputpath = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.cbx_CropType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 89;
            this.label5.Text = "请选择影像过境时间";
            // 
            // dT_RSData
            // 
            this.dT_RSData.Location = new System.Drawing.Point(146, 289);
            this.dT_RSData.Name = "dT_RSData";
            this.dT_RSData.Size = new System.Drawing.Size(170, 21);
            this.dT_RSData.TabIndex = 88;
            this.dT_RSData.Value = new System.DateTime(2014, 3, 12, 11, 28, 49, 0);
            // 
            // pictureBox4
            // 
            this.pictureBox4.ErrorImage = null;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 291);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 14);
            this.pictureBox4.TabIndex = 87;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            // 
            // btn_chtableinpath
            // 
            this.btn_chtableinpath.Image = ((System.Drawing.Image)(resources.GetObject("btn_chtableinpath.Image")));
            this.btn_chtableinpath.Location = new System.Drawing.Point(651, 27);
            this.btn_chtableinpath.Name = "btn_chtableinpath";
            this.btn_chtableinpath.Size = new System.Drawing.Size(26, 24);
            this.btn_chtableinpath.TabIndex = 81;
            this.btn_chtableinpath.UseVisualStyleBackColor = true;
            this.btn_chtableinpath.Click += new System.EventHandler(this.btn_chtableinpath_Click);
            // 
            // listViewImage
            // 
            this.listViewImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewImage.FullRowSelect = true;
            this.listViewImage.GridLines = true;
            this.listViewImage.Location = new System.Drawing.Point(19, 155);
            this.listViewImage.Name = "listViewImage";
            this.listViewImage.Size = new System.Drawing.Size(627, 123);
            this.listViewImage.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewImage.TabIndex = 80;
            this.listViewImage.UseCompatibleStateImageBehavior = false;
            this.listViewImage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "                                                已添加文件";
            this.columnHeader1.Width = 634;
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 320);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 14);
            this.pictureBox3.TabIndex = 78;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 14);
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            // 
            // txt_ChImageOutPath
            // 
            this.txt_ChImageOutPath.Enabled = false;
            this.txt_ChImageOutPath.Location = new System.Drawing.Point(17, 336);
            this.txt_ChImageOutPath.Name = "txt_ChImageOutPath";
            this.txt_ChImageOutPath.Size = new System.Drawing.Size(628, 21);
            this.txt_ChImageOutPath.TabIndex = 72;
            // 
            // btn_ChImageOutPath
            // 
            this.btn_ChImageOutPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_ChImageOutPath.Image")));
            this.btn_ChImageOutPath.Location = new System.Drawing.Point(652, 333);
            this.btn_ChImageOutPath.Name = "btn_ChImageOutPath";
            this.btn_ChImageOutPath.Size = new System.Drawing.Size(26, 24);
            this.btn_ChImageOutPath.TabIndex = 75;
            this.btn_ChImageOutPath.UseVisualStyleBackColor = true;
            this.btn_ChImageOutPath.Click += new System.EventHandler(this.btn_ChImageOutPath_Click);
            // 
            // txt_ImageInputpath
            // 
            this.txt_ImageInputpath.Location = new System.Drawing.Point(18, 118);
            this.txt_ImageInputpath.Name = "txt_ImageInputpath";
            this.txt_ImageInputpath.Size = new System.Drawing.Size(627, 21);
            this.txt_ImageInputpath.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 69;
            this.label3.Text = "输出文件夹";
            // 
            // btn_delete
            // 
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.Location = new System.Drawing.Point(652, 155);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(26, 24);
            this.btn_delete.TabIndex = 77;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_ImageInputpath
            // 
            this.btn_ImageInputpath.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImageInputpath.Image")));
            this.btn_ImageInputpath.Location = new System.Drawing.Point(651, 118);
            this.btn_ImageInputpath.Name = "btn_ImageInputpath";
            this.btn_ImageInputpath.Size = new System.Drawing.Size(26, 24);
            this.btn_ImageInputpath.TabIndex = 76;
            this.btn_ImageInputpath.UseVisualStyleBackColor = true;
            this.btn_ImageInputpath.Click += new System.EventHandler(this.btn_ImageInputpath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "输入CCD影像";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 85;
            this.label1.Text = "输入查找表";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(311, 378);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 84;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(422, 378);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 82;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(692, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(211, 391);
            this.richTextBox1.TabIndex = 74;
            this.richTextBox1.Text = "\n\n     输入已建立成功的查找表，\n  根据建立查找表时使用的数据\n  类型输入CCD数据,生成冠层叶\n  绿素含量分布图。";
            // 
            // txt_chtableinpath
            // 
            this.txt_chtableinpath.Location = new System.Drawing.Point(18, 27);
            this.txt_chtableinpath.Name = "txt_chtableinpath";
            this.txt_chtableinpath.Size = new System.Drawing.Size(627, 21);
            this.txt_chtableinpath.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(726, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 19);
            this.label4.TabIndex = 71;
            this.label4.Text = "冠层叶绿素反演";
            // 
            // btn_OpenOutPutpath
            // 
            this.btn_OpenOutPutpath.Location = new System.Drawing.Point(533, 377);
            this.btn_OpenOutPutpath.Name = "btn_OpenOutPutpath";
            this.btn_OpenOutPutpath.Size = new System.Drawing.Size(112, 23);
            this.btn_OpenOutPutpath.TabIndex = 90;
            this.btn_OpenOutPutpath.Text = "打开输出文件夹";
            this.btn_OpenOutPutpath.UseVisualStyleBackColor = true;
            this.btn_OpenOutPutpath.Click += new System.EventHandler(this.btn_OpenOutPutpath_Click);
            // 
            // btn_Down_CCD
            // 
            this.btn_Down_CCD.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down_CCD.Image")));
            this.btn_Down_CCD.Location = new System.Drawing.Point(652, 228);
            this.btn_Down_CCD.Name = "btn_Down_CCD";
            this.btn_Down_CCD.Size = new System.Drawing.Size(26, 22);
            this.btn_Down_CCD.TabIndex = 110;
            this.btn_Down_CCD.UseVisualStyleBackColor = true;
            this.btn_Down_CCD.Click += new System.EventHandler(this.btn_Down_CCD_Click);
            // 
            // btn_Up_CCD
            // 
            this.btn_Up_CCD.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up_CCD.Image")));
            this.btn_Up_CCD.Location = new System.Drawing.Point(652, 190);
            this.btn_Up_CCD.Name = "btn_Up_CCD";
            this.btn_Up_CCD.Size = new System.Drawing.Size(26, 22);
            this.btn_Up_CCD.TabIndex = 109;
            this.btn_Up_CCD.UseVisualStyleBackColor = true;
            this.btn_Up_CCD.Click += new System.EventHandler(this.btn_Up_CCD_Click);
            // 
            // btn_ImageRefer_Inputpath
            // 
            this.btn_ImageRefer_Inputpath.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImageRefer_Inputpath.Image")));
            this.btn_ImageRefer_Inputpath.Location = new System.Drawing.Point(650, 71);
            this.btn_ImageRefer_Inputpath.Name = "btn_ImageRefer_Inputpath";
            this.btn_ImageRefer_Inputpath.Size = new System.Drawing.Size(26, 24);
            this.btn_ImageRefer_Inputpath.TabIndex = 114;
            this.btn_ImageRefer_Inputpath.UseVisualStyleBackColor = true;
            this.btn_ImageRefer_Inputpath.Click += new System.EventHandler(this.btn_ImageRefer_Inputpath_Click);
            // 
            // txt_ImageRefer_Inputpath
            // 
            this.txt_ImageRefer_Inputpath.Location = new System.Drawing.Point(16, 74);
            this.txt_ImageRefer_Inputpath.Name = "txt_ImageRefer_Inputpath";
            this.txt_ImageRefer_Inputpath.Size = new System.Drawing.Size(627, 21);
            this.txt_ImageRefer_Inputpath.TabIndex = 113;
            // 
            // pictureBox5
            // 
            this.pictureBox5.ErrorImage = null;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(1, 54);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(15, 14);
            this.pictureBox5.TabIndex = 112;
            this.pictureBox5.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 111;
            this.label6.Text = "输入作物分布影像";
            // 
            // pictureBox6
            // 
            this.pictureBox6.ErrorImage = null;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(371, 291);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(15, 14);
            this.pictureBox6.TabIndex = 117;
            this.pictureBox6.TabStop = false;
            // 
            // cbx_CropType
            // 
            this.cbx_CropType.FormattingEnabled = true;
            this.cbx_CropType.Location = new System.Drawing.Point(470, 289);
            this.cbx_CropType.Name = "cbx_CropType";
            this.cbx_CropType.Size = new System.Drawing.Size(101, 20);
            this.cbx_CropType.TabIndex = 116;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(387, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 115;
            this.label7.Text = "选择作物类型\r\n";
            // 
            // ChlorophyllRetrievalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 416);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.cbx_CropType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_ImageRefer_Inputpath);
            this.Controls.Add(this.txt_ImageRefer_Inputpath);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Down_CCD);
            this.Controls.Add(this.btn_Up_CCD);
            this.Controls.Add(this.btn_OpenOutPutpath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dT_RSData);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_chtableinpath);
            this.Controls.Add(this.listViewImage);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_ChImageOutPath);
            this.Controls.Add(this.btn_ChImageOutPath);
            this.Controls.Add(this.txt_ImageInputpath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_ImageInputpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txt_chtableinpath);
            this.Name = "ChlorophyllRetrievalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChlorophyllRetrievalForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dT_RSData;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_chtableinpath;
        private System.Windows.Forms.ListView listViewImage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_ChImageOutPath;
        private System.Windows.Forms.Button btn_ChImageOutPath;
        private System.Windows.Forms.TextBox txt_ImageInputpath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_ImageInputpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txt_chtableinpath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_OpenOutPutpath;
        private System.Windows.Forms.Button btn_Down_CCD;
        private System.Windows.Forms.Button btn_Up_CCD;
        private System.Windows.Forms.Button btn_ImageRefer_Inputpath;
        private System.Windows.Forms.TextBox txt_ImageRefer_Inputpath;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ComboBox cbx_CropType;
        private System.Windows.Forms.Label label7;
    }
}