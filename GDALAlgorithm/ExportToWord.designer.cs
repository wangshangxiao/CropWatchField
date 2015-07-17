namespace GDALAlgorithm
{
    partial class ExportToWord
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
            this.lbl_Rank = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.checkBox_WATERRETRIEVAL = new System.Windows.Forms.CheckBox();
            this.checkBox_MATUREPERIOD = new System.Windows.Forms.CheckBox();
            this.checkBox_CHLOROPHYLLRETRIEVAL = new System.Windows.Forms.CheckBox();
            this.checkBox_SOILNUTRIENT = new System.Windows.Forms.CheckBox();
            this.checkBox_CROPYIELD = new System.Windows.Forms.CheckBox();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.dT_maize_e = new System.Windows.Forms.DateTimePicker();
            this.dT_maize_s = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Rank
            // 
            this.lbl_Rank.AutoSize = true;
            this.lbl_Rank.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Rank.Location = new System.Drawing.Point(25, 27);
            this.lbl_Rank.Name = "lbl_Rank";
            this.lbl_Rank.Size = new System.Drawing.Size(88, 16);
            this.lbl_Rank.TabIndex = 0;
            this.lbl_Rank.Text = "导出范围：";
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "作业区",
            "作业站"});
            this.comboBox_type.Location = new System.Drawing.Point(120, 22);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(121, 20);
            this.comboBox_type.Sorted = true;
            this.comboBox_type.TabIndex = 1;
            // 
            // lbl_Content
            // 
            this.lbl_Content.AutoSize = true;
            this.lbl_Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Content.Location = new System.Drawing.Point(25, 138);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(88, 16);
            this.lbl_Content.TabIndex = 2;
            this.lbl_Content.Text = "导出类别：";
            // 
            // checkBox_WATERRETRIEVAL
            // 
            this.checkBox_WATERRETRIEVAL.AutoSize = true;
            this.checkBox_WATERRETRIEVAL.Location = new System.Drawing.Point(120, 137);
            this.checkBox_WATERRETRIEVAL.Name = "checkBox_WATERRETRIEVAL";
            this.checkBox_WATERRETRIEVAL.Size = new System.Drawing.Size(120, 16);
            this.checkBox_WATERRETRIEVAL.TabIndex = 3;
            this.checkBox_WATERRETRIEVAL.Text = "作物冠层水分含量";
            this.checkBox_WATERRETRIEVAL.UseVisualStyleBackColor = true;
            this.checkBox_WATERRETRIEVAL.CheckedChanged += new System.EventHandler(this.checkBox_WATERRETRIEVAL_CheckedChanged);
            // 
            // checkBox_MATUREPERIOD
            // 
            this.checkBox_MATUREPERIOD.AutoSize = true;
            this.checkBox_MATUREPERIOD.Location = new System.Drawing.Point(403, 138);
            this.checkBox_MATUREPERIOD.Name = "checkBox_MATUREPERIOD";
            this.checkBox_MATUREPERIOD.Size = new System.Drawing.Size(84, 16);
            this.checkBox_MATUREPERIOD.TabIndex = 4;
            this.checkBox_MATUREPERIOD.Text = "作物成熟期";
            this.checkBox_MATUREPERIOD.UseVisualStyleBackColor = true;
            this.checkBox_MATUREPERIOD.CheckedChanged += new System.EventHandler(this.checkBox_MATUREPERIOD_CheckedChanged);
            // 
            // checkBox_CHLOROPHYLLRETRIEVAL
            // 
            this.checkBox_CHLOROPHYLLRETRIEVAL.AutoSize = true;
            this.checkBox_CHLOROPHYLLRETRIEVAL.Location = new System.Drawing.Point(120, 171);
            this.checkBox_CHLOROPHYLLRETRIEVAL.Name = "checkBox_CHLOROPHYLLRETRIEVAL";
            this.checkBox_CHLOROPHYLLRETRIEVAL.Size = new System.Drawing.Size(84, 16);
            this.checkBox_CHLOROPHYLLRETRIEVAL.TabIndex = 5;
            this.checkBox_CHLOROPHYLLRETRIEVAL.Text = "叶绿素含量";
            this.checkBox_CHLOROPHYLLRETRIEVAL.UseVisualStyleBackColor = true;
            this.checkBox_CHLOROPHYLLRETRIEVAL.CheckedChanged += new System.EventHandler(this.checkBox_CHLOROPHYLLRETRIEVAL_CheckedChanged);
            // 
            // checkBox_SOILNUTRIENT
            // 
            this.checkBox_SOILNUTRIENT.AutoSize = true;
            this.checkBox_SOILNUTRIENT.Location = new System.Drawing.Point(276, 137);
            this.checkBox_SOILNUTRIENT.Name = "checkBox_SOILNUTRIENT";
            this.checkBox_SOILNUTRIENT.Size = new System.Drawing.Size(72, 16);
            this.checkBox_SOILNUTRIENT.TabIndex = 6;
            this.checkBox_SOILNUTRIENT.Text = "土壤养分";
            this.checkBox_SOILNUTRIENT.UseVisualStyleBackColor = true;
            this.checkBox_SOILNUTRIENT.CheckedChanged += new System.EventHandler(this.checkBox_SOILNUTRIENT_CheckedChanged);
            // 
            // checkBox_CROPYIELD
            // 
            this.checkBox_CROPYIELD.AutoSize = true;
            this.checkBox_CROPYIELD.Location = new System.Drawing.Point(277, 171);
            this.checkBox_CROPYIELD.Name = "checkBox_CROPYIELD";
            this.checkBox_CROPYIELD.Size = new System.Drawing.Size(72, 16);
            this.checkBox_CROPYIELD.TabIndex = 7;
            this.checkBox_CROPYIELD.Text = "作物单产";
            this.checkBox_CROPYIELD.UseVisualStyleBackColor = true;
            this.checkBox_CROPYIELD.CheckedChanged += new System.EventHandler(this.checkBox_CROPYIELD_CheckedChanged);
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(189, 221);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 8;
            this.btn_Export.Text = "导出报告";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(339, 221);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 9;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 92;
            this.label5.Text = "至";
            // 
            // dT_maize_e
            // 
            this.dT_maize_e.Location = new System.Drawing.Point(334, 81);
            this.dT_maize_e.Name = "dT_maize_e";
            this.dT_maize_e.Size = new System.Drawing.Size(170, 21);
            this.dT_maize_e.TabIndex = 93;
            this.dT_maize_e.Value = new System.DateTime(2010, 9, 1, 0, 0, 0, 0);
            // 
            // dT_maize_s
            // 
            this.dT_maize_s.Location = new System.Drawing.Point(119, 81);
            this.dT_maize_s.Name = "dT_maize_s";
            this.dT_maize_s.Size = new System.Drawing.Size(170, 21);
            this.dT_maize_s.TabIndex = 94;
            this.dT_maize_s.Value = new System.DateTime(2010, 4, 30, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 96;
            this.label1.Text = "时间范围：";
            // 
            // ExportToWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 260);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dT_maize_s);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dT_maize_e);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.checkBox_CROPYIELD);
            this.Controls.Add(this.checkBox_SOILNUTRIENT);
            this.Controls.Add(this.checkBox_CHLOROPHYLLRETRIEVAL);
            this.Controls.Add(this.checkBox_MATUREPERIOD);
            this.Controls.Add(this.checkBox_WATERRETRIEVAL);
            this.Controls.Add(this.lbl_Content);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.lbl_Rank);
            this.Name = "ExportToWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报告生成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Rank;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.CheckBox checkBox_WATERRETRIEVAL;
        private System.Windows.Forms.CheckBox checkBox_MATUREPERIOD;
        private System.Windows.Forms.CheckBox checkBox_CHLOROPHYLLRETRIEVAL;
        private System.Windows.Forms.CheckBox checkBox_SOILNUTRIENT;
        private System.Windows.Forms.CheckBox checkBox_CROPYIELD;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dT_maize_e;
        private System.Windows.Forms.DateTimePicker dT_maize_s;
        private System.Windows.Forms.Label label1;
    }
}