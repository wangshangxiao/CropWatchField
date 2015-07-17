namespace CropWatchField
{
    partial class OMForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OMForm));
            this.listView_HJ = new System.Windows.Forms.ListView();
            this.columnHeaderLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TextBox_ObserPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_HJPath = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_OpenOutputPath = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBox_OutputPath = new System.Windows.Forms.TextBox();
            this.btn_OutputPath = new System.Windows.Forms.Button();
            this.btn_delete_HJ = new System.Windows.Forms.Button();
            this.btn_InPutFile_Obser = new System.Windows.Forms.Button();
            this.btn_InPutFile_HJ = new System.Windows.Forms.Button();
            this.btn_His = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rab_Yes = new System.Windows.Forms.RadioButton();
            this.rab_No = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // listView_HJ
            // 
            this.listView_HJ.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLow});
            this.listView_HJ.FullRowSelect = true;
            this.listView_HJ.GridLines = true;
            this.listView_HJ.Location = new System.Drawing.Point(16, 68);
            this.listView_HJ.Name = "listView_HJ";
            this.listView_HJ.Size = new System.Drawing.Size(300, 210);
            this.listView_HJ.TabIndex = 61;
            this.listView_HJ.UseCompatibleStateImageBehavior = false;
            this.listView_HJ.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLow
            // 
            this.columnHeaderLow.Text = "                  已添加文件";
            this.columnHeaderLow.Width = 634;
            // 
            // TextBox_ObserPath
            // 
            this.TextBox_ObserPath.Location = new System.Drawing.Point(16, 312);
            this.TextBox_ObserPath.Name = "TextBox_ObserPath";
            this.TextBox_ObserPath.Size = new System.Drawing.Size(299, 21);
            this.TextBox_ObserPath.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 57;
            this.label2.Text = "地面观测数据文件";
            // 
            // TextBox_HJPath
            // 
            this.TextBox_HJPath.Location = new System.Drawing.Point(16, 26);
            this.TextBox_HJPath.Name = "TextBox_HJPath";
            this.TextBox_HJPath.Size = new System.Drawing.Size(299, 21);
            this.TextBox_HJPath.TabIndex = 56;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(173, 12);
            this.Label1.TabIndex = 55;
            this.Label1.Text = "经作物分布图裁剪的环境星文件";
            // 
            // btn_OpenOutputPath
            // 
            this.btn_OpenOutputPath.Location = new System.Drawing.Point(250, 468);
            this.btn_OpenOutputPath.Name = "btn_OpenOutputPath";
            this.btn_OpenOutputPath.Size = new System.Drawing.Size(99, 23);
            this.btn_OpenOutputPath.TabIndex = 94;
            this.btn_OpenOutputPath.Text = "打开输出路径";
            this.btn_OpenOutputPath.UseVisualStyleBackColor = true;
            this.btn_OpenOutputPath.Click += new System.EventHandler(this.btn_OpenOutputPath_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(170, 468);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(58, 23);
            this.btn_Cancel.TabIndex = 93;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(85, 468);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(58, 23);
            this.btn_OK.TabIndex = 92;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 91;
            this.label11.Text = "输出路径";
            // 
            // TextBox_OutputPath
            // 
            this.TextBox_OutputPath.Location = new System.Drawing.Point(16, 433);
            this.TextBox_OutputPath.Name = "TextBox_OutputPath";
            this.TextBox_OutputPath.Size = new System.Drawing.Size(300, 21);
            this.TextBox_OutputPath.TabIndex = 90;
            // 
            // btn_OutputPath
            // 
            this.btn_OutputPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutputPath.Image")));
            this.btn_OutputPath.Location = new System.Drawing.Point(323, 433);
            this.btn_OutputPath.Name = "btn_OutputPath";
            this.btn_OutputPath.Size = new System.Drawing.Size(26, 24);
            this.btn_OutputPath.TabIndex = 100;
            this.btn_OutputPath.UseVisualStyleBackColor = true;
            this.btn_OutputPath.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // btn_delete_HJ
            // 
            this.btn_delete_HJ.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_HJ.Image")));
            this.btn_delete_HJ.Location = new System.Drawing.Point(323, 68);
            this.btn_delete_HJ.Name = "btn_delete_HJ";
            this.btn_delete_HJ.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_HJ.TabIndex = 97;
            this.btn_delete_HJ.UseVisualStyleBackColor = true;
            this.btn_delete_HJ.Click += new System.EventHandler(this.btn_delete_HJ_Click);
            // 
            // btn_InPutFile_Obser
            // 
            this.btn_InPutFile_Obser.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_Obser.Image")));
            this.btn_InPutFile_Obser.Location = new System.Drawing.Point(323, 309);
            this.btn_InPutFile_Obser.Name = "btn_InPutFile_Obser";
            this.btn_InPutFile_Obser.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile_Obser.TabIndex = 96;
            this.btn_InPutFile_Obser.UseVisualStyleBackColor = true;
            this.btn_InPutFile_Obser.Click += new System.EventHandler(this.btn_InPutFile_Obser_Click);
            // 
            // btn_InPutFile_HJ
            // 
            this.btn_InPutFile_HJ.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_HJ.Image")));
            this.btn_InPutFile_HJ.Location = new System.Drawing.Point(323, 26);
            this.btn_InPutFile_HJ.Name = "btn_InPutFile_HJ";
            this.btn_InPutFile_HJ.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile_HJ.TabIndex = 95;
            this.btn_InPutFile_HJ.UseVisualStyleBackColor = true;
            this.btn_InPutFile_HJ.Click += new System.EventHandler(this.btn_InPutFile_HJ_Click);
            // 
            // btn_His
            // 
            this.btn_His.Location = new System.Drawing.Point(16, 342);
            this.btn_His.Name = "btn_His";
            this.btn_His.Size = new System.Drawing.Size(299, 23);
            this.btn_His.TabIndex = 101;
            this.btn_His.Text = "地面观测数据直方图及其高斯拟合";
            this.btn_His.UseVisualStyleBackColor = true;
            this.btn_His.Click += new System.EventHandler(this.btn_His_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 102;
            this.label3.Text = "观测数据文件服从正态分布";
            // 
            // rab_Yes
            // 
            this.rab_Yes.AutoSize = true;
            this.rab_Yes.Location = new System.Drawing.Point(170, 377);
            this.rab_Yes.Name = "rab_Yes";
            this.rab_Yes.Size = new System.Drawing.Size(35, 16);
            this.rab_Yes.TabIndex = 103;
            this.rab_Yes.TabStop = true;
            this.rab_Yes.Text = "是";
            this.rab_Yes.UseVisualStyleBackColor = true;
            this.rab_Yes.CheckedChanged += new System.EventHandler(this.rab_Yes_CheckedChanged);
            // 
            // rab_No
            // 
            this.rab_No.AutoSize = true;
            this.rab_No.Checked = true;
            this.rab_No.Location = new System.Drawing.Point(211, 377);
            this.rab_No.Name = "rab_No";
            this.rab_No.Size = new System.Drawing.Size(35, 16);
            this.rab_No.TabIndex = 104;
            this.rab_No.TabStop = true;
            this.rab_No.Text = "否";
            this.rab_No.UseVisualStyleBackColor = true;
            this.rab_No.CheckedChanged += new System.EventHandler(this.rab_No_CheckedChanged);
            // 
            // OMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 500);
            this.Controls.Add(this.rab_No);
            this.Controls.Add(this.rab_Yes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_His);
            this.Controls.Add(this.btn_OutputPath);
            this.Controls.Add(this.btn_delete_HJ);
            this.Controls.Add(this.btn_InPutFile_Obser);
            this.Controls.Add(this.btn_InPutFile_HJ);
            this.Controls.Add(this.btn_OpenOutputPath);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TextBox_OutputPath);
            this.Controls.Add(this.listView_HJ);
            this.Controls.Add(this.TextBox_ObserPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_HJPath);
            this.Controls.Add(this.Label1);
            this.Name = "OMForm";
            this.Text = "有机质";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_HJ;
        private System.Windows.Forms.ColumnHeader columnHeaderLow;
        private System.Windows.Forms.TextBox TextBox_ObserPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_HJPath;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btn_OpenOutputPath;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBox_OutputPath;
        private System.Windows.Forms.Button btn_OutputPath;
        private System.Windows.Forms.Button btn_delete_HJ;
        private System.Windows.Forms.Button btn_InPutFile_Obser;
        private System.Windows.Forms.Button btn_InPutFile_HJ;
        private System.Windows.Forms.Button btn_His;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rab_Yes;
        private System.Windows.Forms.RadioButton rab_No;
    }
}