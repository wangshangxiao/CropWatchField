namespace CropWatchField
{
    partial class DBConnectForm
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
            this.btn_DBConnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_DBConnTest
            // 
            this.btn_DBConnTest.Location = new System.Drawing.Point(107, 31);
            this.btn_DBConnTest.Name = "btn_DBConnTest";
            this.btn_DBConnTest.Size = new System.Drawing.Size(120, 23);
            this.btn_DBConnTest.TabIndex = 0;
            this.btn_DBConnTest.Text = "测试数据库连接";
            this.btn_DBConnTest.UseVisualStyleBackColor = true;
            this.btn_DBConnTest.Click += new System.EventHandler(this.btn_DBConnTest_Click);
            // 
            // DBConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 92);
            this.Controls.Add(this.btn_DBConnTest);
            this.Name = "DBConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBConnectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DBConnTest;
    }
}