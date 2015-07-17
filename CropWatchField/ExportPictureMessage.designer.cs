namespace CropWatchField
{
    partial class ExportPictureMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportPictureMessage));
            this.txt_ImageInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_InPutFile = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_ImageInput
            // 
            this.txt_ImageInput.Location = new System.Drawing.Point(94, 35);
            this.txt_ImageInput.Name = "txt_ImageInput";
            this.txt_ImageInput.Size = new System.Drawing.Size(341, 21);
            this.txt_ImageInput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "保存路径：";
            // 
            // btn_InPutFile
            // 
            this.btn_InPutFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile.Image")));
            this.btn_InPutFile.Location = new System.Drawing.Point(465, 34);
            this.btn_InPutFile.Name = "btn_InPutFile";
            this.btn_InPutFile.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile.TabIndex = 5;
            this.btn_InPutFile.UseVisualStyleBackColor = true;
            this.btn_InPutFile.Click += new System.EventHandler(this.btn_InPutFile_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(360, 101);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 6;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(238, 101);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ExportPictureMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 151);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_InPutFile);
            this.Controls.Add(this.txt_ImageInput);
            this.Controls.Add(this.label1);
            this.Name = "ExportPictureMessage";
            this.Text = "保存图片";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportPictureMessage_FormClosed);
            this.Load += new System.EventHandler(this.ExportPictureMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ImageInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_InPutFile;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_ok;
    }
}