namespace CropWatchField
{
    partial class ISODataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ISODataForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_changethersh = new System.Windows.Forms.TextBox();
            this.txt_Iterations = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_maxclass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_minclass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_ImageOutPath = new System.Windows.Forms.TextBox();
            this.btn_ImageOutPath = new System.Windows.Forms.Button();
            this.txt_ImageInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_InPutFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_OpenOutPut = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.txt_changethersh);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Iterations);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txt_maxclass);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txt_minclass);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ImageOutPath);
            this.splitContainer1.Panel1.Controls.Add(this.btn_ImageOutPath);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ImageInput);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btn_InPutFile);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(696, 238);
            this.splitContainer1.SplitterDistance = 510;
            this.splitContainer1.TabIndex = 7;
            // 
            // txt_changethersh
            // 
            this.txt_changethersh.Location = new System.Drawing.Point(356, 124);
            this.txt_changethersh.Name = "txt_changethersh";
            this.txt_changethersh.Size = new System.Drawing.Size(100, 21);
            this.txt_changethersh.TabIndex = 5;
            // 
            // txt_Iterations
            // 
            this.txt_Iterations.Location = new System.Drawing.Point(100, 124);
            this.txt_Iterations.Name = "txt_Iterations";
            this.txt_Iterations.Size = new System.Drawing.Size(100, 21);
            this.txt_Iterations.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "变化阈值%（0-100）：";
            // 
            // txt_maxclass
            // 
            this.txt_maxclass.Location = new System.Drawing.Point(356, 70);
            this.txt_maxclass.Name = "txt_maxclass";
            this.txt_maxclass.Size = new System.Drawing.Size(100, 21);
            this.txt_maxclass.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "最大迭代次数：";
            // 
            // txt_minclass
            // 
            this.txt_minclass.Location = new System.Drawing.Point(100, 70);
            this.txt_minclass.Name = "txt_minclass";
            this.txt_minclass.Size = new System.Drawing.Size(100, 21);
            this.txt_minclass.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "最大分类数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "最小分类数：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(4, 182);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 14);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txt_ImageOutPath
            // 
            this.txt_ImageOutPath.Location = new System.Drawing.Point(17, 198);
            this.txt_ImageOutPath.Name = "txt_ImageOutPath";
            this.txt_ImageOutPath.Size = new System.Drawing.Size(456, 21);
            this.txt_ImageOutPath.TabIndex = 1;
            // 
            // btn_ImageOutPath
            // 
            this.btn_ImageOutPath.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImageOutPath.Image")));
            this.btn_ImageOutPath.Location = new System.Drawing.Point(479, 195);
            this.btn_ImageOutPath.Name = "btn_ImageOutPath";
            this.btn_ImageOutPath.Size = new System.Drawing.Size(26, 24);
            this.btn_ImageOutPath.TabIndex = 2;
            this.btn_ImageOutPath.UseVisualStyleBackColor = true;
            this.btn_ImageOutPath.Click += new System.EventHandler(this.btn_ImageOutPath_Click);
            // 
            // txt_ImageInput
            // 
            this.txt_ImageInput.Location = new System.Drawing.Point(17, 27);
            this.txt_ImageInput.Name = "txt_ImageInput";
            this.txt_ImageInput.Size = new System.Drawing.Size(456, 21);
            this.txt_ImageInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "输出文件夹";
            // 
            // btn_InPutFile
            // 
            this.btn_InPutFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile.Image")));
            this.btn_InPutFile.Location = new System.Drawing.Point(479, 24);
            this.btn_InPutFile.Name = "btn_InPutFile";
            this.btn_InPutFile.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile.TabIndex = 2;
            this.btn_InPutFile.UseVisualStyleBackColor = true;
            this.btn_InPutFile.Click += new System.EventHandler(this.btn_InPutFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入影像";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(34, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "非监督分类";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(0, -2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(178, 237);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "\n\n    ISOData非监督分类";
            // 
            // btn_OpenOutPut
            // 
            this.btn_OpenOutPut.Location = new System.Drawing.Point(515, 267);
            this.btn_OpenOutPut.Name = "btn_OpenOutPut";
            this.btn_OpenOutPut.Size = new System.Drawing.Size(99, 23);
            this.btn_OpenOutPut.TabIndex = 18;
            this.btn_OpenOutPut.Text = "打开输出文件夹";
            this.btn_OpenOutPut.UseVisualStyleBackColor = true;
            this.btn_OpenOutPut.Visible = false;
            this.btn_OpenOutPut.Click += new System.EventHandler(this.btn_OpenOutPut_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(410, 267);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 16;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(311, 267);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 17;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ISODataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 314);
            this.Controls.Add(this.btn_OpenOutPut);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ISODataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "非监督分类ISOData";
            this.Load += new System.EventHandler(this.ISODataForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_ImageOutPath;
        private System.Windows.Forms.Button btn_ImageOutPath;
        private System.Windows.Forms.TextBox txt_ImageInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_InPutFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_OpenOutPut;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_maxclass;
        private System.Windows.Forms.TextBox txt_minclass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Iterations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_changethersh;
        private System.Windows.Forms.Label label7;
    }
}