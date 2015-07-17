namespace CropWatchField
{
    partial class SANForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SANForm));
            this.listView_Yield = new System.Windows.Forms.ListView();
            this.columnHeaderLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TextBox_YieldPath = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_OpenOutputPath = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBox_OutputPath = new System.Windows.Forms.TextBox();
            this.btn_OutputPath = new System.Windows.Forms.Button();
            this.btn_delete_Yield = new System.Windows.Forms.Button();
            this.btn_InPutFile_Yield = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_Yield
            // 
            this.listView_Yield.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLow});
            this.listView_Yield.FullRowSelect = true;
            this.listView_Yield.GridLines = true;
            this.listView_Yield.Location = new System.Drawing.Point(12, 64);
            this.listView_Yield.Name = "listView_Yield";
            this.listView_Yield.Size = new System.Drawing.Size(300, 210);
            this.listView_Yield.TabIndex = 52;
            this.listView_Yield.UseCompatibleStateImageBehavior = false;
            this.listView_Yield.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLow
            // 
            this.columnHeaderLow.Text = "                  已添加文件";
            this.columnHeaderLow.Width = 634;
            // 
            // TextBox_YieldPath
            // 
            this.TextBox_YieldPath.Location = new System.Drawing.Point(11, 26);
            this.TextBox_YieldPath.Name = "TextBox_YieldPath";
            this.TextBox_YieldPath.Size = new System.Drawing.Size(301, 21);
            this.TextBox_YieldPath.TabIndex = 50;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(197, 12);
            this.Label1.TabIndex = 49;
            this.Label1.Text = "经作物分布图裁剪的归一化产量文件";
            // 
            // btn_OpenOutputPath
            // 
            this.btn_OpenOutputPath.Location = new System.Drawing.Point(245, 342);
            this.btn_OpenOutputPath.Name = "btn_OpenOutputPath";
            this.btn_OpenOutputPath.Size = new System.Drawing.Size(99, 23);
            this.btn_OpenOutputPath.TabIndex = 94;
            this.btn_OpenOutputPath.Text = "打开输出路径";
            this.btn_OpenOutputPath.UseVisualStyleBackColor = true;
            this.btn_OpenOutputPath.Click += new System.EventHandler(this.btn_OpenOutputPath_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(148, 342);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(58, 23);
            this.btn_Cancel.TabIndex = 93;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(51, 342);
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
            this.label11.Location = new System.Drawing.Point(12, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 91;
            this.label11.Text = "输出路径";
            // 
            // TextBox_OutputPath
            // 
            this.TextBox_OutputPath.Location = new System.Drawing.Point(12, 305);
            this.TextBox_OutputPath.Name = "TextBox_OutputPath";
            this.TextBox_OutputPath.Size = new System.Drawing.Size(300, 21);
            this.TextBox_OutputPath.TabIndex = 90;
            // 
            // btn_OutputPath
            // 
            this.btn_OutputPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutputPath.Image")));
            this.btn_OutputPath.Location = new System.Drawing.Point(316, 302);
            this.btn_OutputPath.Name = "btn_OutputPath";
            this.btn_OutputPath.Size = new System.Drawing.Size(26, 24);
            this.btn_OutputPath.TabIndex = 97;
            this.btn_OutputPath.UseVisualStyleBackColor = true;
            this.btn_OutputPath.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // btn_delete_Yield
            // 
            this.btn_delete_Yield.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_Yield.Image")));
            this.btn_delete_Yield.Location = new System.Drawing.Point(316, 64);
            this.btn_delete_Yield.Name = "btn_delete_Yield";
            this.btn_delete_Yield.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_Yield.TabIndex = 96;
            this.btn_delete_Yield.UseVisualStyleBackColor = true;
            this.btn_delete_Yield.Click += new System.EventHandler(this.btn_delete_Yield_Click);
            // 
            // btn_InPutFile_Yield
            // 
            this.btn_InPutFile_Yield.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile_Yield.Image")));
            this.btn_InPutFile_Yield.Location = new System.Drawing.Point(316, 23);
            this.btn_InPutFile_Yield.Name = "btn_InPutFile_Yield";
            this.btn_InPutFile_Yield.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile_Yield.TabIndex = 95;
            this.btn_InPutFile_Yield.UseVisualStyleBackColor = true;
            this.btn_InPutFile_Yield.Click += new System.EventHandler(this.btn_InPutFile_Yield_Click);
            // 
            // SANForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 383);
            this.Controls.Add(this.btn_OutputPath);
            this.Controls.Add(this.btn_delete_Yield);
            this.Controls.Add(this.btn_InPutFile_Yield);
            this.Controls.Add(this.btn_OpenOutputPath);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TextBox_OutputPath);
            this.Controls.Add(this.listView_Yield);
            this.Controls.Add(this.TextBox_YieldPath);
            this.Controls.Add(this.Label1);
            this.Name = "SANForm";
            this.Text = "土壤速效氮";
            this.Load += new System.EventHandler(this.SANForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Yield;
        private System.Windows.Forms.ColumnHeader columnHeaderLow;
        private System.Windows.Forms.TextBox TextBox_YieldPath;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btn_OpenOutputPath;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBox_OutputPath;
        private System.Windows.Forms.Button btn_OutputPath;
        private System.Windows.Forms.Button btn_delete_Yield;
        private System.Windows.Forms.Button btn_InPutFile_Yield;
    }
}