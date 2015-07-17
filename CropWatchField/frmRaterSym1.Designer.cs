namespace CropWatchField
{
    partial class frmRaterSym1
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
            this.lblSingleColor = new System.Windows.Forms.Label();
            this.btnRasterOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBand = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbsymRaster = new CropWatchField.ComboBoxSym();
            this.comboBoxSym1 = new CropWatchField.ComboBoxSym();
            this.cmbSymClassify = new CropWatchField.ComboBoxSym();
            this.comboBoxSym2 = new CropWatchField.ComboBoxSym();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClassifyMethod = new System.Windows.Forms.ComboBox();
            this.cmbClassifyCount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSingleColor
            // 
            this.lblSingleColor.AutoSize = true;
            this.lblSingleColor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSingleColor.Location = new System.Drawing.Point(8, 112);
            this.lblSingleColor.Name = "lblSingleColor";
            this.lblSingleColor.Size = new System.Drawing.Size(80, 16);
            this.lblSingleColor.TabIndex = 6;
            this.lblSingleColor.Text = "渲染颜色:";
            // 
            // btnRasterOK
            // 
            this.btnRasterOK.Location = new System.Drawing.Point(293, 196);
            this.btnRasterOK.Name = "btnRasterOK";
            this.btnRasterOK.Size = new System.Drawing.Size(75, 23);
            this.btnRasterOK.TabIndex = 8;
            this.btnRasterOK.Text = "确定";
            this.btnRasterOK.UseVisualStyleBackColor = true;
            this.btnRasterOK.Click += new System.EventHandler(this.btnRasterOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "渲染波段:";
            // 
            // cmbBand
            // 
            this.cmbBand.FormattingEnabled = true;
            this.cmbBand.Location = new System.Drawing.Point(97, 56);
            this.cmbBand.Name = "cmbBand";
            this.cmbBand.Size = new System.Drawing.Size(121, 20);
            this.cmbBand.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 288);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.cmbBand);
            this.tabPage1.Controls.Add(this.lblSingleColor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbsymRaster);
            this.tabPage1.Controls.Add(this.comboBoxSym1);
            this.tabPage1.Controls.Add(this.btnRasterOK);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "拉伸渲染";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.cmbClassifyCount);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmbSymClassify);
            this.tabPage2.Controls.Add(this.comboBoxSym2);
            this.tabPage2.Controls.Add(this.cmbClassifyMethod);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "分级渲染";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "渲染颜色:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRasterOK_Click);
            // 
            // cmbsymRaster
            // 
            this.cmbsymRaster.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsymRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsymRaster.FormattingEnabled = true;
            this.cmbsymRaster.Location = new System.Drawing.Point(94, 112);
            this.cmbsymRaster.Name = "cmbsymRaster";
            this.cmbsymRaster.Size = new System.Drawing.Size(297, 22);
            this.cmbsymRaster.TabIndex = 7;
            // 
            // comboBoxSym1
            // 
            this.comboBoxSym1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSym1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSym1.FormattingEnabled = true;
            this.comboBoxSym1.Location = new System.Drawing.Point(94, 140);
            this.comboBoxSym1.Name = "comboBoxSym1";
            this.comboBoxSym1.Size = new System.Drawing.Size(297, 22);
            this.comboBoxSym1.TabIndex = 9;
            this.comboBoxSym1.Visible = false;
            // 
            // cmbSymClassify
            // 
            this.cmbSymClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymClassify.FormattingEnabled = true;
            this.cmbSymClassify.Location = new System.Drawing.Point(117, 140);
            this.cmbSymClassify.Name = "cmbSymClassify";
            this.cmbSymClassify.Size = new System.Drawing.Size(297, 22);
            this.cmbSymClassify.TabIndex = 11;
            // 
            // comboBoxSym2
            // 
            this.comboBoxSym2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSym2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSym2.FormattingEnabled = true;
            this.comboBoxSym2.Location = new System.Drawing.Point(117, 168);
            this.comboBoxSym2.Name = "comboBoxSym2";
            this.comboBoxSym2.Size = new System.Drawing.Size(297, 22);
            this.comboBoxSym2.TabIndex = 12;
            this.comboBoxSym2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "分级方法：";
            // 
            // cmbClassifyMethod
            // 
            this.cmbClassifyMethod.FormattingEnabled = true;
            this.cmbClassifyMethod.Location = new System.Drawing.Point(117, 34);
            this.cmbClassifyMethod.Name = "cmbClassifyMethod";
            this.cmbClassifyMethod.Size = new System.Drawing.Size(121, 20);
            this.cmbClassifyMethod.TabIndex = 1;
            // 
            // cmbClassifyCount
            // 
            this.cmbClassifyCount.FormattingEnabled = true;
            this.cmbClassifyCount.Location = new System.Drawing.Point(117, 87);
            this.cmbClassifyCount.Name = "cmbClassifyCount";
            this.cmbClassifyCount.Size = new System.Drawing.Size(121, 20);
            this.cmbClassifyCount.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(31, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "分级数量：";
            // 
            // frmRaterSym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 288);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmRaterSym";
            this.Text = "栅格数据渲染";
            this.Load += new System.EventHandler(this.frmRaterSym_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxSym cmbsymRaster;
        private System.Windows.Forms.Label lblSingleColor;
        private System.Windows.Forms.Button btnRasterOK;
        private ComboBoxSym comboBoxSym1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBand;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private ComboBoxSym cmbSymClassify;
        private ComboBoxSym comboBoxSym2;
        private System.Windows.Forms.ComboBox cmbClassifyCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbClassifyMethod;
        private System.Windows.Forms.Label label2;
    }
}