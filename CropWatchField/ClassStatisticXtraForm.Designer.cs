namespace CropWatchField
{
    partial class ClassStatisticXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassStatisticXtraForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ImageInput = new System.Windows.Forms.TextBox();
            this.btn_InPutFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_classstatis = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 118);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(516, 349);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.Tag = "";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入分类重编码后影像：";
            // 
            // txt_ImageInput
            // 
            this.txt_ImageInput.Location = new System.Drawing.Point(15, 42);
            this.txt_ImageInput.Name = "txt_ImageInput";
            this.txt_ImageInput.Size = new System.Drawing.Size(447, 22);
            this.txt_ImageInput.TabIndex = 2;
            // 
            // btn_InPutFile
            // 
            this.btn_InPutFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_InPutFile.Image")));
            this.btn_InPutFile.Location = new System.Drawing.Point(478, 40);
            this.btn_InPutFile.Name = "btn_InPutFile";
            this.btn_InPutFile.Size = new System.Drawing.Size(26, 24);
            this.btn_InPutFile.TabIndex = 3;
            this.btn_InPutFile.UseVisualStyleBackColor = true;
            this.btn_InPutFile.Click += new System.EventHandler(this.btn_InPutFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "分类统计结果：";
            // 
            // btn_classstatis
            // 
            this.btn_classstatis.Location = new System.Drawing.Point(376, 80);
            this.btn_classstatis.Name = "btn_classstatis";
            this.btn_classstatis.Size = new System.Drawing.Size(86, 23);
            this.btn_classstatis.TabIndex = 4;
            this.btn_classstatis.Text = "分类结果统计";
            this.btn_classstatis.Click += new System.EventHandler(this.btn_classstatis_Click);
            // 
            // ClassStatisticXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 467);
            this.Controls.Add(this.btn_classstatis);
            this.Controls.Add(this.btn_InPutFile);
            this.Controls.Add(this.txt_ImageInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Name = "ClassStatisticXtraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分类结果统计表";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ImageInput;
        private System.Windows.Forms.Button btn_InPutFile;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btn_classstatis;
    }
}