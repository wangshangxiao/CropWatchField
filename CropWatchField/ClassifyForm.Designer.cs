namespace CropWatchField
{
    partial class ClassifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassifyForm));
            this.textBox_NdsiPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_OutPutPath = new System.Windows.Forms.TextBox();
            this.listView_NDSI = new System.Windows.Forms.ListView();
            this.columnHeaderNDSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_InPutFile = new System.Windows.Forms.Button();
            this.btn_OutPutPath = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_OpenOutPutPath = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_NdsiPath
            // 
            this.textBox_NdsiPath.Location = new System.Drawing.Point(27, 44);
            this.textBox_NdsiPath.Name = "textBox_NdsiPath";
            this.textBox_NdsiPath.Size = new System.Drawing.Size(349, 21);
            this.textBox_NdsiPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "NDSI影像";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "输出路径";
            // 
            // textBox_OutPutPath
            // 
            this.textBox_OutPutPath.Location = new System.Drawing.Point(27, 309);
            this.textBox_OutPutPath.Name = "textBox_OutPutPath";
            this.textBox_OutPutPath.Size = new System.Drawing.Size(349, 21);
            this.textBox_OutPutPath.TabIndex = 3;
            // 
            // listView_NDSI
            // 
            this.listView_NDSI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNDSI});
            this.listView_NDSI.FullRowSelect = true;
            this.listView_NDSI.GridLines = true;
            this.listView_NDSI.Location = new System.Drawing.Point(27, 71);
            this.listView_NDSI.Name = "listView_NDSI";
            this.listView_NDSI.Size = new System.Drawing.Size(376, 195);
            this.listView_NDSI.TabIndex = 4;
            this.listView_NDSI.UseCompatibleStateImageBehavior = false;
            this.listView_NDSI.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNDSI
            // 
            this.columnHeaderNDSI.Text = "                        已添加文件";
            this.columnHeaderNDSI.Width = 634;
            // 
            // btn_InPutFile
            // 
            this.btn_InPutFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile.Image")));
            this.btn_InPutFile.Location = new System.Drawing.Point(382, 40);
            this.btn_InPutFile.Name = "btn_InPutFile";
            this.btn_InPutFile.Size = new System.Drawing.Size(29, 25);
            this.btn_InPutFile.TabIndex = 5;
            this.btn_InPutFile.UseVisualStyleBackColor = true;
            this.btn_InPutFile.Click += new System.EventHandler(this.btn_InPutFile_Click);
            // 
            // btn_OutPutPath
            // 
            this.btn_OutPutPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutPutPath.Image")));
            this.btn_OutPutPath.Location = new System.Drawing.Point(382, 305);
            this.btn_OutPutPath.Name = "btn_OutPutPath";
            this.btn_OutPutPath.Size = new System.Drawing.Size(29, 25);
            this.btn_OutPutPath.TabIndex = 6;
            this.btn_OutPutPath.UseVisualStyleBackColor = true;
            this.btn_OutPutPath.Click += new System.EventHandler(this.btn_OutPutPath_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.Location = new System.Drawing.Point(418, 91);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(26, 24);
            this.btn_delete.TabIndex = 42;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(226, 370);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(58, 23);
            this.btn_Ok.TabIndex = 59;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_OpenOutPutPath
            // 
            this.btn_OpenOutPutPath.Location = new System.Drawing.Point(382, 370);
            this.btn_OpenOutPutPath.Name = "btn_OpenOutPutPath";
            this.btn_OpenOutPutPath.Size = new System.Drawing.Size(99, 23);
            this.btn_OpenOutPutPath.TabIndex = 62;
            this.btn_OpenOutPutPath.Text = "打开输出路径";
            this.btn_OpenOutPutPath.UseVisualStyleBackColor = true;
            this.btn_OpenOutPutPath.Click += new System.EventHandler(this.btn_OpenOutPutPath_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(318, 370);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(58, 23);
            this.btn_Cancel.TabIndex = 61;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ClassifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 409);
            this.Controls.Add(this.btn_OpenOutPutPath);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_OutPutPath);
            this.Controls.Add(this.btn_InPutFile);
            this.Controls.Add(this.listView_NDSI);
            this.Controls.Add(this.textBox_OutPutPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_NdsiPath);
            this.Name = "ClassifyForm";
            this.Text = "利用阈值法分类";
            this.Load += new System.EventHandler(this.ClassifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_NdsiPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_OutPutPath;
        private System.Windows.Forms.ListView listView_NDSI;
        private System.Windows.Forms.ColumnHeader columnHeaderNDSI;
        private System.Windows.Forms.Button btn_InPutFile;
        private System.Windows.Forms.Button btn_OutPutPath;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_OpenOutPutPath;
        private System.Windows.Forms.Button btn_Cancel;
    }
}