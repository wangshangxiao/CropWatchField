namespace CropWatchField
{
    partial class NDSI_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NDSI_Form));
            this.listView_CCD = new System.Windows.Forms.ListView();
            this.columnHeaderCCD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_IRS = new System.Windows.Forms.ListView();
            this.columnHeaderIRS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_CCDPath = new System.Windows.Forms.TextBox();
            this.textBox_IRSPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_InPutFile_IRS = new System.Windows.Forms.Button();
            this.btn_InPutFile_CCD = new System.Windows.Forms.Button();
            this.cbx_Method = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_OutPutPath = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Concel = new System.Windows.Forms.Button();
            this.btn_Delete_CCD = new System.Windows.Forms.Button();
            this.btn_Down_CCD = new System.Windows.Forms.Button();
            this.btn_Up_CCD = new System.Windows.Forms.Button();
            this.btn_Down_IRS = new System.Windows.Forms.Button();
            this.btn_Up_IRS = new System.Windows.Forms.Button();
            this.btn_Delete_IRS = new System.Windows.Forms.Button();
            this.btn_OutPutPath = new System.Windows.Forms.Button();
            this.btn_OpenOutPutPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_CCD
            // 
            this.listView_CCD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCCD});
            this.listView_CCD.FullRowSelect = true;
            this.listView_CCD.GridLines = true;
            this.listView_CCD.Location = new System.Drawing.Point(35, 89);
            this.listView_CCD.Name = "listView_CCD";
            this.listView_CCD.Size = new System.Drawing.Size(286, 207);
            this.listView_CCD.TabIndex = 6;
            this.listView_CCD.UseCompatibleStateImageBehavior = false;
            this.listView_CCD.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCCD
            // 
            this.columnHeaderCCD.Text = "                 已添加文件";
            this.columnHeaderCCD.Width = 634;
            // 
            // listView_IRS
            // 
            this.listView_IRS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIRS});
            this.listView_IRS.FullRowSelect = true;
            this.listView_IRS.GridLines = true;
            this.listView_IRS.Location = new System.Drawing.Point(381, 91);
            this.listView_IRS.Name = "listView_IRS";
            this.listView_IRS.Size = new System.Drawing.Size(286, 205);
            this.listView_IRS.TabIndex = 7;
            this.listView_IRS.UseCompatibleStateImageBehavior = false;
            this.listView_IRS.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIRS
            // 
            this.columnHeaderIRS.Text = "                 已添加文件";
            this.columnHeaderIRS.Width = 634;
            // 
            // textBox_CCDPath
            // 
            this.textBox_CCDPath.Location = new System.Drawing.Point(35, 38);
            this.textBox_CCDPath.Name = "textBox_CCDPath";
            this.textBox_CCDPath.Size = new System.Drawing.Size(255, 21);
            this.textBox_CCDPath.TabIndex = 0;
            // 
            // textBox_IRSPath
            // 
            this.textBox_IRSPath.Location = new System.Drawing.Point(381, 37);
            this.textBox_IRSPath.Name = "textBox_IRSPath";
            this.textBox_IRSPath.Size = new System.Drawing.Size(255, 21);
            this.textBox_IRSPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "CCD影像";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "IRS影像";
            // 
            // btn_InPutFile_IRS
            // 
            this.btn_InPutFile_IRS.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_IRS.Image")));
            this.btn_InPutFile_IRS.Location = new System.Drawing.Point(642, 36);
            this.btn_InPutFile_IRS.Name = "btn_InPutFile_IRS";
            this.btn_InPutFile_IRS.Size = new System.Drawing.Size(25, 23);
            this.btn_InPutFile_IRS.TabIndex = 4;
            this.btn_InPutFile_IRS.UseVisualStyleBackColor = true;
            this.btn_InPutFile_IRS.Click += new System.EventHandler(this.btn_InPutFile_IRS_Click);
            // 
            // btn_InPutFile_CCD
            // 
            this.btn_InPutFile_CCD.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_CCD.Image")));
            this.btn_InPutFile_CCD.Location = new System.Drawing.Point(296, 36);
            this.btn_InPutFile_CCD.Name = "btn_InPutFile_CCD";
            this.btn_InPutFile_CCD.Size = new System.Drawing.Size(25, 24);
            this.btn_InPutFile_CCD.TabIndex = 5;
            this.btn_InPutFile_CCD.UseVisualStyleBackColor = true;
            this.btn_InPutFile_CCD.Click += new System.EventHandler(this.btn_InPutFile_CCD_Click);
            // 
            // cbx_Method
            // 
            this.cbx_Method.FormattingEnabled = true;
            this.cbx_Method.Location = new System.Drawing.Point(35, 356);
            this.cbx_Method.Name = "cbx_Method";
            this.cbx_Method.Size = new System.Drawing.Size(160, 20);
            this.cbx_Method.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "识别雪盖的方法";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "输出路径";
            // 
            // textBox_OutPutPath
            // 
            this.textBox_OutPutPath.Location = new System.Drawing.Point(35, 417);
            this.textBox_OutPutPath.Name = "textBox_OutPutPath";
            this.textBox_OutPutPath.Size = new System.Drawing.Size(580, 21);
            this.textBox_OutPutPath.TabIndex = 11;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(329, 461);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(82, 28);
            this.btn_Ok.TabIndex = 12;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Concel
            // 
            this.btn_Concel.Location = new System.Drawing.Point(458, 461);
            this.btn_Concel.Name = "btn_Concel";
            this.btn_Concel.Size = new System.Drawing.Size(82, 28);
            this.btn_Concel.TabIndex = 13;
            this.btn_Concel.Text = "取消";
            this.btn_Concel.UseVisualStyleBackColor = true;
            this.btn_Concel.Click += new System.EventHandler(this.btn_Concel_Click);
            // 
            // btn_Delete_CCD
            // 
            this.btn_Delete_CCD.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete_CCD.Image")));
            this.btn_Delete_CCD.Location = new System.Drawing.Point(329, 92);
            this.btn_Delete_CCD.Name = "btn_Delete_CCD";
            this.btn_Delete_CCD.Size = new System.Drawing.Size(30, 26);
            this.btn_Delete_CCD.TabIndex = 14;
            this.btn_Delete_CCD.Text = " ";
            this.btn_Delete_CCD.UseVisualStyleBackColor = true;
            this.btn_Delete_CCD.Click += new System.EventHandler(this.btn_Delete_CCD_Click);
            // 
            // btn_Down_CCD
            // 
            this.btn_Down_CCD.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down_CCD.Image")));
            this.btn_Down_CCD.Location = new System.Drawing.Point(329, 156);
            this.btn_Down_CCD.Name = "btn_Down_CCD";
            this.btn_Down_CCD.Size = new System.Drawing.Size(30, 26);
            this.btn_Down_CCD.TabIndex = 15;
            this.btn_Down_CCD.UseVisualStyleBackColor = true;
            this.btn_Down_CCD.Click += new System.EventHandler(this.btn_Down_CCD_Click);
            // 
            // btn_Up_CCD
            // 
            this.btn_Up_CCD.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up_CCD.Image")));
            this.btn_Up_CCD.Location = new System.Drawing.Point(329, 124);
            this.btn_Up_CCD.Name = "btn_Up_CCD";
            this.btn_Up_CCD.Size = new System.Drawing.Size(30, 26);
            this.btn_Up_CCD.TabIndex = 16;
            this.btn_Up_CCD.UseVisualStyleBackColor = true;
            this.btn_Up_CCD.Click += new System.EventHandler(this.btn_Up_CCD_Click);
            // 
            // btn_Down_IRS
            // 
            this.btn_Down_IRS.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down_IRS.Image")));
            this.btn_Down_IRS.Location = new System.Drawing.Point(675, 156);
            this.btn_Down_IRS.Name = "btn_Down_IRS";
            this.btn_Down_IRS.Size = new System.Drawing.Size(30, 26);
            this.btn_Down_IRS.TabIndex = 17;
            this.btn_Down_IRS.UseVisualStyleBackColor = true;
            this.btn_Down_IRS.Click += new System.EventHandler(this.btn_Down_IRS_Click);
            // 
            // btn_Up_IRS
            // 
            this.btn_Up_IRS.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up_IRS.Image")));
            this.btn_Up_IRS.Location = new System.Drawing.Point(675, 124);
            this.btn_Up_IRS.Name = "btn_Up_IRS";
            this.btn_Up_IRS.Size = new System.Drawing.Size(30, 26);
            this.btn_Up_IRS.TabIndex = 18;
            this.btn_Up_IRS.UseVisualStyleBackColor = true;
            this.btn_Up_IRS.Click += new System.EventHandler(this.btn_Up_IRS_Click);
            // 
            // btn_Delete_IRS
            // 
            this.btn_Delete_IRS.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete_IRS.Image")));
            this.btn_Delete_IRS.Location = new System.Drawing.Point(675, 92);
            this.btn_Delete_IRS.Name = "btn_Delete_IRS";
            this.btn_Delete_IRS.Size = new System.Drawing.Size(30, 26);
            this.btn_Delete_IRS.TabIndex = 19;
            this.btn_Delete_IRS.UseVisualStyleBackColor = true;
            this.btn_Delete_IRS.Click += new System.EventHandler(this.btn_Delete_IRS_Click);
            // 
            // btn_OutPutPath
            // 
            this.btn_OutPutPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutPutPath.Image")));
            this.btn_OutPutPath.Location = new System.Drawing.Point(631, 414);
            this.btn_OutPutPath.Name = "btn_OutPutPath";
            this.btn_OutPutPath.Size = new System.Drawing.Size(25, 24);
            this.btn_OutPutPath.TabIndex = 20;
            this.btn_OutPutPath.UseVisualStyleBackColor = true;
            this.btn_OutPutPath.Click += new System.EventHandler(this.btn_OutPutPath_Click);
            // 
            // btn_OpenOutPutPath
            // 
            this.btn_OpenOutPutPath.Location = new System.Drawing.Point(565, 461);
            this.btn_OpenOutPutPath.Name = "btn_OpenOutPutPath";
            this.btn_OpenOutPutPath.Size = new System.Drawing.Size(123, 27);
            this.btn_OpenOutPutPath.TabIndex = 21;
            this.btn_OpenOutPutPath.Text = "打开输出路径";
            this.btn_OpenOutPutPath.UseVisualStyleBackColor = true;
            this.btn_OpenOutPutPath.Click += new System.EventHandler(this.btn_OpenOutPutPath_Click);
            // 
            // NDSI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 529);
            this.Controls.Add(this.btn_OpenOutPutPath);
            this.Controls.Add(this.btn_OutPutPath);
            this.Controls.Add(this.btn_Delete_IRS);
            this.Controls.Add(this.btn_Up_IRS);
            this.Controls.Add(this.btn_Down_IRS);
            this.Controls.Add(this.btn_Up_CCD);
            this.Controls.Add(this.btn_Down_CCD);
            this.Controls.Add(this.btn_Delete_CCD);
            this.Controls.Add(this.btn_Concel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.textBox_OutPutPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_Method);
            this.Controls.Add(this.listView_IRS);
            this.Controls.Add(this.listView_CCD);
            this.Controls.Add(this.btn_InPutFile_CCD);
            this.Controls.Add(this.btn_InPutFile_IRS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_IRSPath);
            this.Controls.Add(this.textBox_CCDPath);
            this.Name = "NDSI_Form";
            this.Text = "计算积雪指数";
            this.Load += new System.EventHandler(this.NDSI_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_CCDPath;
        private System.Windows.Forms.TextBox textBox_IRSPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_InPutFile_IRS;
        private System.Windows.Forms.Button btn_InPutFile_CCD;
        private System.Windows.Forms.ListView listView_CCD;
        private System.Windows.Forms.ColumnHeader columnHeaderCCD;
        private System.Windows.Forms.ListView listView_IRS;
        private System.Windows.Forms.ColumnHeader columnHeaderIRS;
        private System.Windows.Forms.ComboBox cbx_Method;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_OutPutPath;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Concel;
        private System.Windows.Forms.Button btn_Delete_CCD;
        private System.Windows.Forms.Button btn_Down_CCD;
        private System.Windows.Forms.Button btn_Up_CCD;
        private System.Windows.Forms.Button btn_Down_IRS;
        private System.Windows.Forms.Button btn_Up_IRS;
        private System.Windows.Forms.Button btn_Delete_IRS;
        private System.Windows.Forms.Button btn_OutPutPath;
        private System.Windows.Forms.Button btn_OpenOutPutPath;

    }
}

