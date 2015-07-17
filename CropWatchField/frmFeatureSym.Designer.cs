namespace CropWatchField
{
    partial class frmFeatureSym
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
            this.xtraTabSingle = new DevExpress.XtraTab.XtraTabPage();
            this.btnSingleOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSymSingle = new CropWatchField.ComboBoxSym();
            this.cmbSingleField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSingleColor = new System.Windows.Forms.Label();
            this.lblSingleField = new System.Windows.Forms.Label();
            this.xtraTabUnique = new DevExpress.XtraTab.XtraTabPage();
            this.btnOnlyOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSymOnly = new CropWatchField.ComboBoxSym();
            this.cmbOnlyField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabClassfiy = new DevExpress.XtraTab.XtraTabPage();
            this.btnClassifyOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSymClassify = new CropWatchField.ComboBoxSym();
            this.cmbClassifyCount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbClassName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbClassifyField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblClassifyCount = new System.Windows.Forms.Label();
            this.xtraTabProport = new DevExpress.XtraTab.XtraTabPage();
            this.btnProOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSymPro = new CropWatchField.ComboBoxSym();
            this.cmbProSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbProField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabSingle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSingleField.Properties)).BeginInit();
            this.xtraTabUnique.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOnlyField.Properties)).BeginInit();
            this.xtraTabClassfiy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyField.Properties)).BeginInit();
            this.xtraTabProport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProField.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabSingle;
            this.xtraTabControl1.Size = new System.Drawing.Size(446, 241);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabSingle,
            this.xtraTabUnique,
            this.xtraTabClassfiy,
            this.xtraTabProport});
            // 
            // xtraTabSingle
            // 
            this.xtraTabSingle.Controls.Add(this.btnSingleOK);
            this.xtraTabSingle.Controls.Add(this.cmbSymSingle);
            this.xtraTabSingle.Controls.Add(this.cmbSingleField);
            this.xtraTabSingle.Controls.Add(this.lblSingleColor);
            this.xtraTabSingle.Controls.Add(this.lblSingleField);
            this.xtraTabSingle.Name = "xtraTabSingle";
            this.xtraTabSingle.Size = new System.Drawing.Size(441, 215);
            this.xtraTabSingle.Text = "单一颜色";
            // 
            // btnSingleOK
            // 
            this.btnSingleOK.Location = new System.Drawing.Point(312, 162);
            this.btnSingleOK.Name = "btnSingleOK";
            this.btnSingleOK.Size = new System.Drawing.Size(75, 23);
            this.btnSingleOK.TabIndex = 8;
            this.btnSingleOK.Text = "确定";
            this.btnSingleOK.Click += new System.EventHandler(this.btnSingleOK_Click);
            // 
            // cmbSymSingle
            // 
            this.cmbSymSingle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymSingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymSingle.FormattingEnabled = true;
            this.cmbSymSingle.Location = new System.Drawing.Point(112, 100);
            this.cmbSymSingle.Name = "cmbSymSingle";
            this.cmbSymSingle.Size = new System.Drawing.Size(297, 25);
            this.cmbSymSingle.TabIndex = 7;
            // 
            // cmbSingleField
            // 
            this.cmbSingleField.Location = new System.Drawing.Point(112, 44);
            this.cmbSingleField.Name = "cmbSingleField";
            this.cmbSingleField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSingleField.Size = new System.Drawing.Size(114, 21);
            this.cmbSingleField.TabIndex = 6;
            // 
            // lblSingleColor
            // 
            this.lblSingleColor.AutoSize = true;
            this.lblSingleColor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSingleColor.Location = new System.Drawing.Point(26, 104);
            this.lblSingleColor.Name = "lblSingleColor";
            this.lblSingleColor.Size = new System.Drawing.Size(80, 16);
            this.lblSingleColor.TabIndex = 5;
            this.lblSingleColor.Text = "渲染颜色:";
            // 
            // lblSingleField
            // 
            this.lblSingleField.AutoSize = true;
            this.lblSingleField.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSingleField.Location = new System.Drawing.Point(26, 46);
            this.lblSingleField.Name = "lblSingleField";
            this.lblSingleField.Size = new System.Drawing.Size(80, 16);
            this.lblSingleField.TabIndex = 4;
            this.lblSingleField.Text = "渲染字段:";
            // 
            // xtraTabUnique
            // 
            this.xtraTabUnique.Controls.Add(this.btnOnlyOK);
            this.xtraTabUnique.Controls.Add(this.cmbSymOnly);
            this.xtraTabUnique.Controls.Add(this.cmbOnlyField);
            this.xtraTabUnique.Controls.Add(this.label1);
            this.xtraTabUnique.Controls.Add(this.label2);
            this.xtraTabUnique.Name = "xtraTabUnique";
            this.xtraTabUnique.Size = new System.Drawing.Size(441, 215);
            this.xtraTabUnique.Text = "唯一值渲染";
            // 
            // btnOnlyOK
            // 
            this.btnOnlyOK.Location = new System.Drawing.Point(315, 157);
            this.btnOnlyOK.Name = "btnOnlyOK";
            this.btnOnlyOK.Size = new System.Drawing.Size(75, 23);
            this.btnOnlyOK.TabIndex = 13;
            this.btnOnlyOK.Text = "确定";
            this.btnOnlyOK.Click += new System.EventHandler(this.btnOnlyOK_Click);
            // 
            // cmbSymOnly
            // 
            this.cmbSymOnly.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymOnly.FormattingEnabled = true;
            this.cmbSymOnly.Location = new System.Drawing.Point(115, 95);
            this.cmbSymOnly.Name = "cmbSymOnly";
            this.cmbSymOnly.Size = new System.Drawing.Size(297, 25);
            this.cmbSymOnly.TabIndex = 12;
            // 
            // cmbOnlyField
            // 
            this.cmbOnlyField.Location = new System.Drawing.Point(115, 39);
            this.cmbOnlyField.Name = "cmbOnlyField";
            this.cmbOnlyField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOnlyField.Size = new System.Drawing.Size(114, 21);
            this.cmbOnlyField.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "渲染颜色:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "渲染字段:";
            // 
            // xtraTabClassfiy
            // 
            this.xtraTabClassfiy.Controls.Add(this.btnClassifyOK);
            this.xtraTabClassfiy.Controls.Add(this.cmbSymClassify);
            this.xtraTabClassfiy.Controls.Add(this.cmbClassifyCount);
            this.xtraTabClassfiy.Controls.Add(this.cmbClassName);
            this.xtraTabClassfiy.Controls.Add(this.cmbClassifyField);
            this.xtraTabClassfiy.Controls.Add(this.label3);
            this.xtraTabClassfiy.Controls.Add(this.label7);
            this.xtraTabClassfiy.Controls.Add(this.label5);
            this.xtraTabClassfiy.Controls.Add(this.lblClassifyCount);
            this.xtraTabClassfiy.Name = "xtraTabClassfiy";
            this.xtraTabClassfiy.Size = new System.Drawing.Size(441, 215);
            this.xtraTabClassfiy.Text = "分级渲染";
            // 
            // btnClassifyOK
            // 
            this.btnClassifyOK.Location = new System.Drawing.Point(316, 182);
            this.btnClassifyOK.Name = "btnClassifyOK";
            this.btnClassifyOK.Size = new System.Drawing.Size(75, 23);
            this.btnClassifyOK.TabIndex = 24;
            this.btnClassifyOK.Text = "确定";
            this.btnClassifyOK.Click += new System.EventHandler(this.btnClassifyOK_Click);
            // 
            // cmbSymClassify
            // 
            this.cmbSymClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymClassify.FormattingEnabled = true;
            this.cmbSymClassify.Location = new System.Drawing.Point(127, 138);
            this.cmbSymClassify.Name = "cmbSymClassify";
            this.cmbSymClassify.Size = new System.Drawing.Size(297, 25);
            this.cmbSymClassify.TabIndex = 23;
            // 
            // cmbClassifyCount
            // 
            this.cmbClassifyCount.Location = new System.Drawing.Point(127, 98);
            this.cmbClassifyCount.Name = "cmbClassifyCount";
            this.cmbClassifyCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClassifyCount.Size = new System.Drawing.Size(114, 21);
            this.cmbClassifyCount.TabIndex = 22;
            // 
            // cmbClassName
            // 
            this.cmbClassName.Location = new System.Drawing.Point(127, 59);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClassName.Size = new System.Drawing.Size(114, 21);
            this.cmbClassName.TabIndex = 21;
            // 
            // cmbClassifyField
            // 
            this.cmbClassifyField.Location = new System.Drawing.Point(127, 19);
            this.cmbClassifyField.Name = "cmbClassifyField";
            this.cmbClassifyField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClassifyField.Size = new System.Drawing.Size(114, 21);
            this.cmbClassifyField.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(33, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "渲染字段:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(33, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "分级方法:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(33, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "渲染颜色:";
            // 
            // lblClassifyCount
            // 
            this.lblClassifyCount.AutoSize = true;
            this.lblClassifyCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClassifyCount.Location = new System.Drawing.Point(33, 101);
            this.lblClassifyCount.Name = "lblClassifyCount";
            this.lblClassifyCount.Size = new System.Drawing.Size(88, 16);
            this.lblClassifyCount.TabIndex = 16;
            this.lblClassifyCount.Text = "分级数量：";
            // 
            // xtraTabProport
            // 
            this.xtraTabProport.Controls.Add(this.btnProOK);
            this.xtraTabProport.Controls.Add(this.cmbSymPro);
            this.xtraTabProport.Controls.Add(this.cmbProSize);
            this.xtraTabProport.Controls.Add(this.cmbProField);
            this.xtraTabProport.Controls.Add(this.label4);
            this.xtraTabProport.Controls.Add(this.label6);
            this.xtraTabProport.Controls.Add(this.label8);
            this.xtraTabProport.Name = "xtraTabProport";
            this.xtraTabProport.Size = new System.Drawing.Size(441, 215);
            this.xtraTabProport.Text = "比例渲染";
            // 
            // btnProOK
            // 
            this.btnProOK.Location = new System.Drawing.Point(308, 177);
            this.btnProOK.Name = "btnProOK";
            this.btnProOK.Size = new System.Drawing.Size(75, 23);
            this.btnProOK.TabIndex = 33;
            this.btnProOK.Text = "确定";
            this.btnProOK.Click += new System.EventHandler(this.btnProOK_Click);
            // 
            // cmbSymPro
            // 
            this.cmbSymPro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymPro.FormattingEnabled = true;
            this.cmbSymPro.Location = new System.Drawing.Point(119, 121);
            this.cmbSymPro.Name = "cmbSymPro";
            this.cmbSymPro.Size = new System.Drawing.Size(297, 25);
            this.cmbSymPro.TabIndex = 32;
            // 
            // cmbProSize
            // 
            this.cmbProSize.Location = new System.Drawing.Point(119, 72);
            this.cmbProSize.Name = "cmbProSize";
            this.cmbProSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProSize.Size = new System.Drawing.Size(114, 21);
            this.cmbProSize.TabIndex = 30;
            // 
            // cmbProField
            // 
            this.cmbProField.Location = new System.Drawing.Point(119, 26);
            this.cmbProField.Name = "cmbProField";
            this.cmbProField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProField.Size = new System.Drawing.Size(114, 21);
            this.cmbProField.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "渲染字段:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(25, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "符号大小:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(25, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "渲染颜色:";
            // 
            // frmFeatureSym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 241);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmFeatureSym";
            this.Text = "矢量数据渲染";
            this.Load += new System.EventHandler(this.frmFeatureSym_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabSingle.ResumeLayout(false);
            this.xtraTabSingle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSingleField.Properties)).EndInit();
            this.xtraTabUnique.ResumeLayout(false);
            this.xtraTabUnique.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOnlyField.Properties)).EndInit();
            this.xtraTabClassfiy.ResumeLayout(false);
            this.xtraTabClassfiy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClassifyField.Properties)).EndInit();
            this.xtraTabProport.ResumeLayout(false);
            this.xtraTabProport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProField.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabSingle;
        private DevExpress.XtraTab.XtraTabPage xtraTabUnique;
        private DevExpress.XtraTab.XtraTabPage xtraTabClassfiy;
        private DevExpress.XtraTab.XtraTabPage xtraTabProport;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSingleField;
        private System.Windows.Forms.Label lblSingleColor;
        private System.Windows.Forms.Label lblSingleField;
        private DevExpress.XtraEditors.SimpleButton btnSingleOK;
        private ComboBoxSym cmbSymSingle;
        private DevExpress.XtraEditors.SimpleButton btnOnlyOK;
        private ComboBoxSym cmbSymOnly;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOnlyField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClassifyCount;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClassName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClassifyField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblClassifyCount;
        private DevExpress.XtraEditors.SimpleButton btnClassifyOK;
        public ComboBoxSym cmbSymClassify;
        private DevExpress.XtraEditors.SimpleButton btnProOK;
        public ComboBoxSym cmbSymPro;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProSize;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}