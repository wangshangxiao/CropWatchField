namespace CropWatchField
{
    partial class YieldHistogramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YieldHistogramForm));
            this.TextBox_CropPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_YieldPath = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.listView_Crop = new System.Windows.Forms.ListView();
            this.columnHeaderHigh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Yield = new System.Windows.Forms.ListView();
            this.columnHeaderLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbx_Method = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_N = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_Gauss = new System.Windows.Forms.Panel();
            this.panel_Percent = new System.Windows.Forms.Panel();
            this.txt_Percent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBar_Percent = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_HistPara1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar_Interval = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBox_OutputPath = new System.Windows.Forms.TextBox();
            this.btn_OpenOutputPath = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Down_Crop = new System.Windows.Forms.Button();
            this.btn_Up_Crop = new System.Windows.Forms.Button();
            this.btn_Down_Yield = new System.Windows.Forms.Button();
            this.btn_Up_Yield = new System.Windows.Forms.Button();
            this.btn_delete_Crop = new System.Windows.Forms.Button();
            this.btn_delete_Yield = new System.Windows.Forms.Button();
            this.btn_InPutFile_Crop = new System.Windows.Forms.Button();
            this.btn_InPutFile_Yield = new System.Windows.Forms.Button();
            this.btn_OutputPath = new System.Windows.Forms.Button();
            this.panel_Gauss.SuspendLayout();
            this.panel_Percent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Percent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Interval)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox_CropPath
            // 
            this.TextBox_CropPath.Location = new System.Drawing.Point(351, 29);
            this.TextBox_CropPath.Name = "TextBox_CropPath";
            this.TextBox_CropPath.Size = new System.Drawing.Size(268, 21);
            this.TextBox_CropPath.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "作物分布影像文件";
            // 
            // TextBox_YieldPath
            // 
            this.TextBox_YieldPath.Location = new System.Drawing.Point(11, 29);
            this.TextBox_YieldPath.Name = "TextBox_YieldPath";
            this.TextBox_YieldPath.Size = new System.Drawing.Size(268, 21);
            this.TextBox_YieldPath.TabIndex = 41;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 40;
            this.Label1.Text = "产量文件";
            // 
            // listView_Crop
            // 
            this.listView_Crop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHigh});
            this.listView_Crop.FullRowSelect = true;
            this.listView_Crop.GridLines = true;
            this.listView_Crop.Location = new System.Drawing.Point(351, 67);
            this.listView_Crop.Name = "listView_Crop";
            this.listView_Crop.Size = new System.Drawing.Size(300, 210);
            this.listView_Crop.TabIndex = 48;
            this.listView_Crop.UseCompatibleStateImageBehavior = false;
            this.listView_Crop.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderHigh
            // 
            this.columnHeaderHigh.Text = "                  已添加文件";
            this.columnHeaderHigh.Width = 634;
            // 
            // listView_Yield
            // 
            this.listView_Yield.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLow});
            this.listView_Yield.FullRowSelect = true;
            this.listView_Yield.GridLines = true;
            this.listView_Yield.Location = new System.Drawing.Point(12, 67);
            this.listView_Yield.Name = "listView_Yield";
            this.listView_Yield.Size = new System.Drawing.Size(300, 210);
            this.listView_Yield.TabIndex = 47;
            this.listView_Yield.UseCompatibleStateImageBehavior = false;
            this.listView_Yield.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLow
            // 
            this.columnHeaderLow.Text = "                  已添加文件";
            this.columnHeaderLow.Width = 634;
            // 
            // cbx_Method
            // 
            this.cbx_Method.FormattingEnabled = true;
            this.cbx_Method.Location = new System.Drawing.Point(211, 319);
            this.cbx_Method.Name = "cbx_Method";
            this.cbx_Method.Size = new System.Drawing.Size(121, 20);
            this.cbx_Method.TabIndex = 55;
            this.cbx_Method.SelectedIndexChanged += new System.EventHandler(this.cbx_Method_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "归一化参数确定方法";
            // 
            // cbx_N
            // 
            this.cbx_N.FormattingEnabled = true;
            this.cbx_N.Location = new System.Drawing.Point(10, 36);
            this.cbx_N.Name = "cbx_N";
            this.cbx_N.Size = new System.Drawing.Size(110, 20);
            this.cbx_N.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "N";
            // 
            // panel_Gauss
            // 
            this.panel_Gauss.Controls.Add(this.label9);
            this.panel_Gauss.Controls.Add(this.cbx_N);
            this.panel_Gauss.Location = new System.Drawing.Point(355, 283);
            this.panel_Gauss.Name = "panel_Gauss";
            this.panel_Gauss.Size = new System.Drawing.Size(206, 60);
            this.panel_Gauss.TabIndex = 56;
            // 
            // panel_Percent
            // 
            this.panel_Percent.Controls.Add(this.txt_Percent);
            this.panel_Percent.Controls.Add(this.label8);
            this.panel_Percent.Controls.Add(this.label10);
            this.panel_Percent.Controls.Add(this.trackBar_Percent);
            this.panel_Percent.Controls.Add(this.label4);
            this.panel_Percent.Location = new System.Drawing.Point(355, 285);
            this.panel_Percent.Name = "panel_Percent";
            this.panel_Percent.Size = new System.Drawing.Size(209, 76);
            this.panel_Percent.TabIndex = 82;
            // 
            // txt_Percent
            // 
            this.txt_Percent.Location = new System.Drawing.Point(144, 32);
            this.txt_Percent.Name = "txt_Percent";
            this.txt_Percent.ReadOnly = true;
            this.txt_Percent.Size = new System.Drawing.Size(39, 21);
            this.txt_Percent.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 84;
            this.label8.Text = "95";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 83;
            this.label10.Text = "80";
            // 
            // trackBar_Percent
            // 
            this.trackBar_Percent.Location = new System.Drawing.Point(21, 27);
            this.trackBar_Percent.Name = "trackBar_Percent";
            this.trackBar_Percent.Size = new System.Drawing.Size(104, 45);
            this.trackBar_Percent.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "百分数(%)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "直方图组距";
            // 
            // txt_HistPara1
            // 
            this.txt_HistPara1.Location = new System.Drawing.Point(140, 319);
            this.txt_HistPara1.Name = "txt_HistPara1";
            this.txt_HistPara1.ReadOnly = true;
            this.txt_HistPara1.Size = new System.Drawing.Size(39, 21);
            this.txt_HistPara1.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 80;
            this.label7.Text = "50";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 79;
            this.label6.Text = "10";
            // 
            // trackBar_Interval
            // 
            this.trackBar_Interval.Location = new System.Drawing.Point(20, 315);
            this.trackBar_Interval.Name = "trackBar_Interval";
            this.trackBar_Interval.Size = new System.Drawing.Size(104, 45);
            this.trackBar_Interval.TabIndex = 78;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 85;
            this.label11.Text = "输出路径";
            // 
            // TextBox_OutputPath
            // 
            this.TextBox_OutputPath.Location = new System.Drawing.Point(11, 382);
            this.TextBox_OutputPath.Name = "TextBox_OutputPath";
            this.TextBox_OutputPath.Size = new System.Drawing.Size(608, 21);
            this.TextBox_OutputPath.TabIndex = 84;
            // 
            // btn_OpenOutputPath
            // 
            this.btn_OpenOutputPath.Location = new System.Drawing.Point(552, 423);
            this.btn_OpenOutputPath.Name = "btn_OpenOutputPath";
            this.btn_OpenOutputPath.Size = new System.Drawing.Size(99, 23);
            this.btn_OpenOutputPath.TabIndex = 88;
            this.btn_OpenOutputPath.Text = "打开输出路径";
            this.btn_OpenOutputPath.UseVisualStyleBackColor = true;
            this.btn_OpenOutputPath.Click += new System.EventHandler(this.btn_OpenOutputPath_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(455, 423);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(58, 23);
            this.btn_Cancel.TabIndex = 87;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(358, 423);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(58, 23);
            this.btn_OK.TabIndex = 86;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Down_Crop
            // 
            this.btn_Down_Crop.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down_Crop.Image")));
            this.btn_Down_Crop.Location = new System.Drawing.Point(656, 127);
            this.btn_Down_Crop.Name = "btn_Down_Crop";
            this.btn_Down_Crop.Size = new System.Drawing.Size(26, 24);
            this.btn_Down_Crop.TabIndex = 96;
            this.btn_Down_Crop.UseVisualStyleBackColor = true;
            this.btn_Down_Crop.Click += new System.EventHandler(this.btn_Down_Crop_Click);
            // 
            // btn_Up_Crop
            // 
            this.btn_Up_Crop.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up_Crop.Image")));
            this.btn_Up_Crop.Location = new System.Drawing.Point(656, 97);
            this.btn_Up_Crop.Name = "btn_Up_Crop";
            this.btn_Up_Crop.Size = new System.Drawing.Size(26, 24);
            this.btn_Up_Crop.TabIndex = 95;
            this.btn_Up_Crop.UseVisualStyleBackColor = true;
            this.btn_Up_Crop.Click += new System.EventHandler(this.btn_Up_Crop_Click);
            // 
            // btn_Down_Yield
            // 
            this.btn_Down_Yield.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down_Yield.Image")));
            this.btn_Down_Yield.Location = new System.Drawing.Point(319, 127);
            this.btn_Down_Yield.Name = "btn_Down_Yield";
            this.btn_Down_Yield.Size = new System.Drawing.Size(26, 24);
            this.btn_Down_Yield.TabIndex = 94;
            this.btn_Down_Yield.UseVisualStyleBackColor = true;
            this.btn_Down_Yield.Click += new System.EventHandler(this.btn_Down_Yield_Click);
            // 
            // btn_Up_Yield
            // 
            this.btn_Up_Yield.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up_Yield.Image")));
            this.btn_Up_Yield.Location = new System.Drawing.Point(319, 97);
            this.btn_Up_Yield.Name = "btn_Up_Yield";
            this.btn_Up_Yield.Size = new System.Drawing.Size(26, 24);
            this.btn_Up_Yield.TabIndex = 93;
            this.btn_Up_Yield.UseVisualStyleBackColor = true;
            this.btn_Up_Yield.Click += new System.EventHandler(this.btn_Up_Yield_Click);
            // 
            // btn_delete_Crop
            // 
            this.btn_delete_Crop.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_Crop.Image")));
            this.btn_delete_Crop.Location = new System.Drawing.Point(656, 67);
            this.btn_delete_Crop.Name = "btn_delete_Crop";
            this.btn_delete_Crop.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_Crop.TabIndex = 92;
            this.btn_delete_Crop.UseVisualStyleBackColor = true;
            this.btn_delete_Crop.Click += new System.EventHandler(this.btn_delete_Crop_Click);
            // 
            // btn_delete_Yield
            // 
            this.btn_delete_Yield.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_Yield.Image")));
            this.btn_delete_Yield.Location = new System.Drawing.Point(318, 67);
            this.btn_delete_Yield.Name = "btn_delete_Yield";
            this.btn_delete_Yield.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_Yield.TabIndex = 91;
            this.btn_delete_Yield.UseVisualStyleBackColor = true;
            this.btn_delete_Yield.Click += new System.EventHandler(this.btn_delete_Yield_Click);
            // 
            // btn_InPutFile_Crop
            // 
            this.btn_InPutFile_Crop.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_Crop.Image")));
            this.btn_InPutFile_Crop.Location = new System.Drawing.Point(624, 27);
            this.btn_InPutFile_Crop.Name = "btn_InPutFile_Crop";
            this.btn_InPutFile_Crop.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile_Crop.TabIndex = 90;
            this.btn_InPutFile_Crop.UseVisualStyleBackColor = true;
            this.btn_InPutFile_Crop.Click += new System.EventHandler(this.btn_InPutFile_Crop_Click);
            // 
            // btn_InPutFile_Yield
            // 
            this.btn_InPutFile_Yield.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_Yield.Image")));
            this.btn_InPutFile_Yield.Location = new System.Drawing.Point(285, 27);
            this.btn_InPutFile_Yield.Name = "btn_InPutFile_Yield";
            this.btn_InPutFile_Yield.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile_Yield.TabIndex = 89;
            this.btn_InPutFile_Yield.UseVisualStyleBackColor = true;
            this.btn_InPutFile_Yield.Click += new System.EventHandler(this.btn_InPutFile_Yield_Click);
            // 
            // btn_OutputPath
            // 
            this.btn_OutputPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutputPath.Image")));
            this.btn_OutputPath.Location = new System.Drawing.Point(656, 379);
            this.btn_OutputPath.Name = "btn_OutputPath";
            this.btn_OutputPath.Size = new System.Drawing.Size(26, 24);
            this.btn_OutputPath.TabIndex = 97;
            this.btn_OutputPath.UseVisualStyleBackColor = true;
            this.btn_OutputPath.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // YieldHistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 458);
            this.Controls.Add(this.btn_OutputPath);
            this.Controls.Add(this.btn_Down_Crop);
            this.Controls.Add(this.btn_Up_Crop);
            this.Controls.Add(this.btn_Down_Yield);
            this.Controls.Add(this.btn_Up_Yield);
            this.Controls.Add(this.btn_delete_Crop);
            this.Controls.Add(this.btn_delete_Yield);
            this.Controls.Add(this.btn_InPutFile_Crop);
            this.Controls.Add(this.btn_InPutFile_Yield);
            this.Controls.Add(this.btn_OpenOutputPath);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TextBox_OutputPath);
            this.Controls.Add(this.txt_HistPara1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar_Interval);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel_Gauss);
            this.Controls.Add(this.panel_Percent);
            this.Controls.Add(this.cbx_Method);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView_Crop);
            this.Controls.Add(this.listView_Yield);
            this.Controls.Add(this.TextBox_CropPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_YieldPath);
            this.Controls.Add(this.Label1);
            this.Name = "YieldHistogramForm";
            this.Text = "产量直方图";
            this.panel_Gauss.ResumeLayout(false);
            this.panel_Gauss.PerformLayout();
            this.panel_Percent.ResumeLayout(false);
            this.panel_Percent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Percent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Interval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_CropPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_YieldPath;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ListView listView_Crop;
        private System.Windows.Forms.ColumnHeader columnHeaderHigh;
        private System.Windows.Forms.ListView listView_Yield;
        private System.Windows.Forms.ColumnHeader columnHeaderLow;
        private System.Windows.Forms.ComboBox cbx_Method;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_N;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel_Gauss;
        private System.Windows.Forms.Panel panel_Percent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_HistPara1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar_Interval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Percent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBar_Percent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBox_OutputPath;
        private System.Windows.Forms.Button btn_OpenOutputPath;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Down_Crop;
        private System.Windows.Forms.Button btn_Up_Crop;
        private System.Windows.Forms.Button btn_Down_Yield;
        private System.Windows.Forms.Button btn_Up_Yield;
        private System.Windows.Forms.Button btn_delete_Crop;
        private System.Windows.Forms.Button btn_delete_Yield;
        private System.Windows.Forms.Button btn_InPutFile_Crop;
        private System.Windows.Forms.Button btn_InPutFile_Yield;
        private System.Windows.Forms.Button btn_OutputPath;
    }
}