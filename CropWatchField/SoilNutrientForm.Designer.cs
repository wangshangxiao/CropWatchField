namespace CropWatchField
{
    partial class SoilNutrientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoilNutrientForm));
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.dT_RSData = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_InPutFile_lat = new System.Windows.Forms.Button();
            this.txt_inputfile_HJccd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btn_OutPutFile_bio = new System.Windows.Forms.Button();
            this.txt_outfilepath_O = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_InPutfile_HJ = new System.Windows.Forms.Button();
            this.txt_inputfile_landclass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(646, 274);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 25;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(547, 274);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 24;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.dT_RSData);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_InPutFile_lat);
            this.splitContainer1.Panel1.Controls.Add(this.txt_inputfile_HJccd);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox5);
            this.splitContainer1.Panel1.Controls.Add(this.btn_OutPutFile_bio);
            this.splitContainer1.Panel1.Controls.Add(this.txt_outfilepath_O);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox4);
            this.splitContainer1.Panel1.Controls.Add(this.btn_InPutfile_HJ);
            this.splitContainer1.Panel1.Controls.Add(this.txt_inputfile_landclass);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(960, 252);
            this.splitContainer1.SplitterDistance = 747;
            this.splitContainer1.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 70;
            this.label5.Text = "请选择影像过境时间";
            // 
            // dT_RSData
            // 
            this.dT_RSData.Location = new System.Drawing.Point(192, 75);
            this.dT_RSData.Name = "dT_RSData";
            this.dT_RSData.Size = new System.Drawing.Size(170, 21);
            this.dT_RSData.TabIndex = 69;
            this.dT_RSData.Value = new System.DateTime(2014, 3, 12, 0, 0, 0, 0);
            this.dT_RSData.ValueChanged += new System.EventHandler(this.dT_RSData_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // btn_InPutFile_lat
            // 
            this.btn_InPutFile_lat.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_lat.Image")));
            this.btn_InPutFile_lat.Location = new System.Drawing.Point(679, 23);
            this.btn_InPutFile_lat.Name = "btn_InPutFile_lat";
            this.btn_InPutFile_lat.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile_lat.TabIndex = 67;
            this.btn_InPutFile_lat.UseVisualStyleBackColor = true;
            this.btn_InPutFile_lat.Click += new System.EventHandler(this.btn_InPutFile_lat_Click);
            // 
            // txt_inputfile_HJccd
            // 
            this.txt_inputfile_HJccd.Location = new System.Drawing.Point(50, 23);
            this.txt_inputfile_HJccd.Name = "txt_inputfile_HJccd";
            this.txt_inputfile_HJccd.Size = new System.Drawing.Size(623, 21);
            this.txt_inputfile_HJccd.TabIndex = 66;
            this.txt_inputfile_HJccd.Text = "D:\\share\\Hongxingtest\\wxf\\text_data\\in_hj\\20100523.tif";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 65;
            this.label6.Text = "输入环境星影像";
            // 
            // pictureBox5
            // 
            this.pictureBox5.ErrorImage = null;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(38, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(15, 14);
            this.pictureBox5.TabIndex = 64;
            this.pictureBox5.TabStop = false;
            // 
            // btn_OutPutFile_bio
            // 
            this.btn_OutPutFile_bio.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutPutFile_bio.Image")));
            this.btn_OutPutFile_bio.Location = new System.Drawing.Point(679, 204);
            this.btn_OutPutFile_bio.Name = "btn_OutPutFile_bio";
            this.btn_OutPutFile_bio.Size = new System.Drawing.Size(26, 24);
            this.btn_OutPutFile_bio.TabIndex = 54;
            this.btn_OutPutFile_bio.UseVisualStyleBackColor = true;
            this.btn_OutPutFile_bio.Click += new System.EventHandler(this.btn_OutPutFile_bio_Click);
            // 
            // txt_outfilepath_O
            // 
            this.txt_outfilepath_O.Enabled = false;
            this.txt_outfilepath_O.Location = new System.Drawing.Point(50, 204);
            this.txt_outfilepath_O.Name = "txt_outfilepath_O";
            this.txt_outfilepath_O.Size = new System.Drawing.Size(623, 21);
            this.txt_outfilepath_O.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 52;
            this.label11.Text = "输出路径";
            // 
            // pictureBox4
            // 
            this.pictureBox4.ErrorImage = null;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(38, 189);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 14);
            this.pictureBox4.TabIndex = 51;
            this.pictureBox4.TabStop = false;
            // 
            // btn_InPutfile_HJ
            // 
            this.btn_InPutfile_HJ.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutfile_HJ.Image")));
            this.btn_InPutfile_HJ.Location = new System.Drawing.Point(679, 146);
            this.btn_InPutfile_HJ.Name = "btn_InPutfile_HJ";
            this.btn_InPutfile_HJ.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutfile_HJ.TabIndex = 15;
            this.btn_InPutfile_HJ.UseVisualStyleBackColor = true;
            this.btn_InPutfile_HJ.Click += new System.EventHandler(this.btn_InPutfile_HJ_Click);
            // 
            // txt_inputfile_landclass
            // 
            this.txt_inputfile_landclass.Location = new System.Drawing.Point(50, 146);
            this.txt_inputfile_landclass.Name = "txt_inputfile_landclass";
            this.txt_inputfile_landclass.Size = new System.Drawing.Size(623, 21);
            this.txt_inputfile_landclass.TabIndex = 14;
            this.txt_inputfile_landclass.Text = "D:\\share\\Hongxingtest\\wxf\\text_data\\model\\hx_crop_class6.tif";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "输入作物分布图";
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(38, 131);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 14);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(209, 252);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "土壤养分：  \n      输入\n        裸土期环境星影像\n        输入裸土分布图\n      输出 \n        农田土壤养分分布图";
            // 
            // SoilNutrientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 313);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SoilNutrientForm";
            this.Text = "土壤养分监测";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_InPutFile_lat;
        private System.Windows.Forms.TextBox txt_inputfile_HJccd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btn_OutPutFile_bio;
        private System.Windows.Forms.TextBox txt_outfilepath_O;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_InPutfile_HJ;
        private System.Windows.Forms.TextBox txt_inputfile_landclass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dT_RSData;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}