namespace CropWatchField
{
    partial class frmRasterSym
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnRasterOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmbsymRaster = new CropWatchField.ComboBoxSym();
            this.comboBoxSym1 = new CropWatchField.ComboBoxSym();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSymClassify = new CropWatchField.ComboBoxSym();
            this.comboBoxSym2 = new CropWatchField.ComboBoxSym();
            this.cmbClassifyCount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbClassifyMethod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBand.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyMethod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(439, 262);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnRasterOK);
            this.xtraTabPage1.Controls.Add(this.cmbsymRaster);
            this.xtraTabPage1.Controls.Add(this.comboBoxSym1);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.cmbBand);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(434, 236);
            this.xtraTabPage1.Text = "拉伸渲染";
            // 
            // btnRasterOK
            // 
            this.btnRasterOK.Location = new System.Drawing.Point(327, 184);
            this.btnRasterOK.Name = "btnRasterOK";
            this.btnRasterOK.Size = new System.Drawing.Size(75, 23);
            this.btnRasterOK.TabIndex = 12;
            this.btnRasterOK.Text = "确定";
            this.btnRasterOK.Click += new System.EventHandler(this.btnRasterOK_Click_1);
            // 
            // cmbsymRaster
            // 
            this.cmbsymRaster.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsymRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsymRaster.FormattingEnabled = true;
            this.cmbsymRaster.Location = new System.Drawing.Point(111, 108);
            this.cmbsymRaster.Name = "cmbsymRaster";
            this.cmbsymRaster.Size = new System.Drawing.Size(297, 25);
            this.cmbsymRaster.TabIndex = 10;
            // 
            // comboBoxSym1
            // 
            this.comboBoxSym1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSym1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSym1.FormattingEnabled = true;
            this.comboBoxSym1.Location = new System.Drawing.Point(111, 136);
            this.comboBoxSym1.Name = "comboBoxSym1";
            this.comboBoxSym1.Size = new System.Drawing.Size(297, 25);
            this.comboBoxSym1.TabIndex = 11;
            this.comboBoxSym1.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Location = new System.Drawing.Point(25, 107);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "渲染颜色：";
            // 
            // cmbBand
            // 
            this.cmbBand.Location = new System.Drawing.Point(112, 44);
            this.cmbBand.Name = "cmbBand";
            this.cmbBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBand.Size = new System.Drawing.Size(100, 21);
            this.cmbBand.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(25, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "渲染波段：";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.simpleButton1);
            this.xtraTabPage2.Controls.Add(this.cmbSymClassify);
            this.xtraTabPage2.Controls.Add(this.comboBoxSym2);
            this.xtraTabPage2.Controls.Add(this.cmbClassifyCount);
            this.xtraTabPage2.Controls.Add(this.cmbClassifyMethod);
            this.xtraTabPage2.Controls.Add(this.labelControl5);
            this.xtraTabPage2.Controls.Add(this.labelControl4);
            this.xtraTabPage2.Controls.Add(this.labelControl3);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(433, 235);
            this.xtraTabPage2.Text = "分级渲染";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(334, 186);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.btnRasterOK_Click);
            // 
            // cmbSymClassify
            // 
            this.cmbSymClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymClassify.FormattingEnabled = true;
            this.cmbSymClassify.Location = new System.Drawing.Point(112, 127);
            this.cmbSymClassify.Name = "cmbSymClassify";
            this.cmbSymClassify.Size = new System.Drawing.Size(297, 25);
            this.cmbSymClassify.TabIndex = 13;
            // 
            // comboBoxSym2
            // 
            this.comboBoxSym2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSym2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSym2.FormattingEnabled = true;
            this.comboBoxSym2.Location = new System.Drawing.Point(112, 155);
            this.comboBoxSym2.Name = "comboBoxSym2";
            this.comboBoxSym2.Size = new System.Drawing.Size(297, 25);
            this.comboBoxSym2.TabIndex = 14;
            this.comboBoxSym2.Visible = false;
            // 
            // cmbClassifyCount
            // 
            this.cmbClassifyCount.Location = new System.Drawing.Point(113, 78);
            this.cmbClassifyCount.Name = "cmbClassifyCount";
            this.cmbClassifyCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClassifyCount.Size = new System.Drawing.Size(127, 21);
            this.cmbClassifyCount.TabIndex = 5;
            // 
            // cmbClassifyMethod
            // 
            this.cmbClassifyMethod.Location = new System.Drawing.Point(113, 32);
            this.cmbClassifyMethod.Name = "cmbClassifyMethod";
            this.cmbClassifyMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClassifyMethod.Size = new System.Drawing.Size(127, 21);
            this.cmbClassifyMethod.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Location = new System.Drawing.Point(26, 127);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 19);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "渲染颜色：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Location = new System.Drawing.Point(26, 80);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 19);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "分级数量：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Location = new System.Drawing.Point(26, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 19);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "分级方法：";
            // 
            // frmRasterSym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 262);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmRasterSym";
            this.Text = "栅格数据渲染";
            this.Load += new System.EventHandler(this.frmRasterSym_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBand.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyMethod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBand;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private ComboBoxSym cmbsymRaster;
        private ComboBoxSym comboBoxSym1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClassifyCount;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClassifyMethod;
        private ComboBoxSym cmbSymClassify;
        private ComboBoxSym comboBoxSym2;
        private DevExpress.XtraEditors.SimpleButton btnRasterOK;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}