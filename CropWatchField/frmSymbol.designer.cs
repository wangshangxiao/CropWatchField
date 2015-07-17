namespace CropWatchField
{
    partial class frmSymbol
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
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabSingle = new DevExpress.XtraTab.XtraTabPage();
            this.cmbSymSingle = new CropWatchField.ComboBoxSym();
            this.btnSingleOK = new System.Windows.Forms.Button();
            this.lblSingleColor = new System.Windows.Forms.Label();
            this.cmbSingleField = new System.Windows.Forms.ComboBox();
            this.lblSingleField = new System.Windows.Forms.Label();
            this.xtraTabUnique = new DevExpress.XtraTab.XtraTabPage();
            this.cmbSymOnly = new CropWatchField.ComboBoxSym();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOnlyOK = new System.Windows.Forms.Button();
            this.cmbOnlyField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabClassfiy = new DevExpress.XtraTab.XtraTabPage();
            this.cmbClassName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSymClassify = new CropWatchField.ComboBoxSym();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbClassifyCount = new System.Windows.Forms.ComboBox();
            this.lblClassifyCount = new System.Windows.Forms.Label();
            this.btnClassifyOK = new System.Windows.Forms.Button();
            this.cmbClassifyField = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.xtraTabProport = new DevExpress.XtraTab.XtraTabPage();
            this.cmbProSize = new System.Windows.Forms.ComboBox();
            this.lblProSize = new System.Windows.Forms.Label();
            this.cmbSymPro = new CropWatchField.ComboBoxSym();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProOK = new System.Windows.Forms.Button();
            this.cmbProField = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.xtraTabSingle.SuspendLayout();
            this.xtraTabUnique.SuspendLayout();
            this.xtraTabClassfiy.SuspendLayout();
            this.xtraTabProport.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.PaintStyleName = "PropertyView";
            this.xtraTabControl.SelectedTabPage = this.xtraTabSingle;
            this.xtraTabControl.Size = new System.Drawing.Size(460, 303);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabSingle,
            this.xtraTabUnique,
            this.xtraTabClassfiy,
            this.xtraTabProport});
            // 
            // xtraTabSingle
            // 
            this.xtraTabSingle.Controls.Add(this.cmbSymSingle);
            this.xtraTabSingle.Controls.Add(this.btnSingleOK);
            this.xtraTabSingle.Controls.Add(this.lblSingleColor);
            this.xtraTabSingle.Controls.Add(this.cmbSingleField);
            this.xtraTabSingle.Controls.Add(this.lblSingleField);
            this.xtraTabSingle.Name = "xtraTabSingle";
            this.xtraTabSingle.Size = new System.Drawing.Size(458, 281);
            this.xtraTabSingle.Text = "单一颜色";
            // 
            // cmbSymSingle
            // 
            this.cmbSymSingle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymSingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymSingle.FormattingEnabled = true;
            this.cmbSymSingle.Location = new System.Drawing.Point(132, 134);
            this.cmbSymSingle.Name = "cmbSymSingle";
            this.cmbSymSingle.Size = new System.Drawing.Size(297, 22);
            this.cmbSymSingle.TabIndex = 5;
            // 
            // btnSingleOK
            // 
            this.btnSingleOK.Location = new System.Drawing.Point(340, 217);
            this.btnSingleOK.Name = "btnSingleOK";
            this.btnSingleOK.Size = new System.Drawing.Size(75, 23);
            this.btnSingleOK.TabIndex = 4;
            this.btnSingleOK.Text = "确定";
            this.btnSingleOK.UseVisualStyleBackColor = true;
            this.btnSingleOK.Click += new System.EventHandler(this.btnSingleOK_Click);
            // 
            // lblSingleColor
            // 
            this.lblSingleColor.AutoSize = true;
            this.lblSingleColor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSingleColor.Location = new System.Drawing.Point(27, 134);
            this.lblSingleColor.Name = "lblSingleColor";
            this.lblSingleColor.Size = new System.Drawing.Size(80, 16);
            this.lblSingleColor.TabIndex = 3;
            this.lblSingleColor.Text = "渲染颜色:";
            // 
            // cmbSingleField
            // 
            this.cmbSingleField.FormattingEnabled = true;
            this.cmbSingleField.Location = new System.Drawing.Point(132, 61);
            this.cmbSingleField.Name = "cmbSingleField";
            this.cmbSingleField.Size = new System.Drawing.Size(121, 20);
            this.cmbSingleField.TabIndex = 1;
            // 
            // lblSingleField
            // 
            this.lblSingleField.AutoSize = true;
            this.lblSingleField.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSingleField.Location = new System.Drawing.Point(27, 65);
            this.lblSingleField.Name = "lblSingleField";
            this.lblSingleField.Size = new System.Drawing.Size(80, 16);
            this.lblSingleField.TabIndex = 0;
            this.lblSingleField.Text = "渲染字段:";
            // 
            // xtraTabUnique
            // 
            this.xtraTabUnique.Controls.Add(this.cmbSymOnly);
            this.xtraTabUnique.Controls.Add(this.label1);
            this.xtraTabUnique.Controls.Add(this.btnOnlyOK);
            this.xtraTabUnique.Controls.Add(this.cmbOnlyField);
            this.xtraTabUnique.Controls.Add(this.label2);
            this.xtraTabUnique.Name = "xtraTabUnique";
            this.xtraTabUnique.Size = new System.Drawing.Size(458, 281);
            this.xtraTabUnique.Text = "唯一值渲染";
            // 
            // cmbSymOnly
            // 
            this.cmbSymOnly.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymOnly.FormattingEnabled = true;
            this.cmbSymOnly.Location = new System.Drawing.Point(134, 144);
            this.cmbSymOnly.Name = "cmbSymOnly";
            this.cmbSymOnly.Size = new System.Drawing.Size(297, 22);
            this.cmbSymOnly.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "渲染颜色:";
            // 
            // btnOnlyOK
            // 
            this.btnOnlyOK.Location = new System.Drawing.Point(342, 222);
            this.btnOnlyOK.Name = "btnOnlyOK";
            this.btnOnlyOK.Size = new System.Drawing.Size(75, 23);
            this.btnOnlyOK.TabIndex = 9;
            this.btnOnlyOK.Text = "确定";
            this.btnOnlyOK.UseVisualStyleBackColor = true;
            this.btnOnlyOK.Click += new System.EventHandler(this.btnSingleOK_Click);
            // 
            // cmbOnlyField
            // 
            this.cmbOnlyField.FormattingEnabled = true;
            this.cmbOnlyField.Location = new System.Drawing.Point(134, 66);
            this.cmbOnlyField.Name = "cmbOnlyField";
            this.cmbOnlyField.Size = new System.Drawing.Size(121, 20);
            this.cmbOnlyField.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "渲染字段:";
            // 
            // xtraTabClassfiy
            // 
            this.xtraTabClassfiy.Controls.Add(this.cmbClassName);
            this.xtraTabClassfiy.Controls.Add(this.label7);
            this.xtraTabClassfiy.Controls.Add(this.cmbSymClassify);
            this.xtraTabClassfiy.Controls.Add(this.label5);
            this.xtraTabClassfiy.Controls.Add(this.cmbClassifyCount);
            this.xtraTabClassfiy.Controls.Add(this.lblClassifyCount);
            this.xtraTabClassfiy.Controls.Add(this.btnClassifyOK);
            this.xtraTabClassfiy.Controls.Add(this.cmbClassifyField);
            this.xtraTabClassfiy.Controls.Add(this.label6);
            this.xtraTabClassfiy.Name = "xtraTabClassfiy";
            this.xtraTabClassfiy.Size = new System.Drawing.Size(458, 281);
            this.xtraTabClassfiy.Text = "分级渲染";
            // 
            // cmbClassName
            // 
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new System.Drawing.Point(133, 75);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(121, 20);
            this.cmbClassName.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(28, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "分级方法:";
            // 
            // cmbSymClassify
            // 
            this.cmbSymClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymClassify.FormattingEnabled = true;
            this.cmbSymClassify.Location = new System.Drawing.Point(133, 156);
            this.cmbSymClassify.Name = "cmbSymClassify";
            this.cmbSymClassify.Size = new System.Drawing.Size(297, 22);
            this.cmbSymClassify.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(28, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "渲染颜色:";
            // 
            // cmbClassifyCount
            // 
            this.cmbClassifyCount.FormattingEnabled = true;
            this.cmbClassifyCount.Location = new System.Drawing.Point(133, 112);
            this.cmbClassifyCount.Name = "cmbClassifyCount";
            this.cmbClassifyCount.Size = new System.Drawing.Size(121, 20);
            this.cmbClassifyCount.TabIndex = 11;
            // 
            // lblClassifyCount
            // 
            this.lblClassifyCount.AutoSize = true;
            this.lblClassifyCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClassifyCount.Location = new System.Drawing.Point(29, 117);
            this.lblClassifyCount.Name = "lblClassifyCount";
            this.lblClassifyCount.Size = new System.Drawing.Size(88, 16);
            this.lblClassifyCount.TabIndex = 10;
            this.lblClassifyCount.Text = "分级数量：";
            // 
            // btnClassifyOK
            // 
            this.btnClassifyOK.Location = new System.Drawing.Point(333, 220);
            this.btnClassifyOK.Name = "btnClassifyOK";
            this.btnClassifyOK.Size = new System.Drawing.Size(75, 23);
            this.btnClassifyOK.TabIndex = 9;
            this.btnClassifyOK.Text = "确定";
            this.btnClassifyOK.UseVisualStyleBackColor = true;
            this.btnClassifyOK.Click += new System.EventHandler(this.btnSingleOK_Click);
            // 
            // cmbClassifyField
            // 
            this.cmbClassifyField.FormattingEnabled = true;
            this.cmbClassifyField.Location = new System.Drawing.Point(133, 37);
            this.cmbClassifyField.Name = "cmbClassifyField";
            this.cmbClassifyField.Size = new System.Drawing.Size(121, 20);
            this.cmbClassifyField.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(28, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "渲染字段:";
            // 
            // xtraTabProport
            // 
            this.xtraTabProport.Controls.Add(this.cmbProSize);
            this.xtraTabProport.Controls.Add(this.lblProSize);
            this.xtraTabProport.Controls.Add(this.cmbSymPro);
            this.xtraTabProport.Controls.Add(this.label3);
            this.xtraTabProport.Controls.Add(this.btnProOK);
            this.xtraTabProport.Controls.Add(this.cmbProField);
            this.xtraTabProport.Controls.Add(this.label4);
            this.xtraTabProport.Name = "xtraTabProport";
            this.xtraTabProport.Size = new System.Drawing.Size(458, 281);
            this.xtraTabProport.Text = "比例渲染";
            // 
            // cmbProSize
            // 
            this.cmbProSize.FormattingEnabled = true;
            this.cmbProSize.Location = new System.Drawing.Point(128, 104);
            this.cmbProSize.Name = "cmbProSize";
            this.cmbProSize.Size = new System.Drawing.Size(121, 20);
            this.cmbProSize.TabIndex = 13;
            // 
            // lblProSize
            // 
            this.lblProSize.AutoSize = true;
            this.lblProSize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProSize.Location = new System.Drawing.Point(23, 108);
            this.lblProSize.Name = "lblProSize";
            this.lblProSize.Size = new System.Drawing.Size(88, 16);
            this.lblProSize.TabIndex = 12;
            this.lblProSize.Text = "符号大小：";
            // 
            // cmbSymPro
            // 
            this.cmbSymPro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymPro.FormattingEnabled = true;
            this.cmbSymPro.Location = new System.Drawing.Point(128, 144);
            this.cmbSymPro.Name = "cmbSymPro";
            this.cmbSymPro.Size = new System.Drawing.Size(290, 22);
            this.cmbSymPro.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "渲染颜色:";
            // 
            // btnProOK
            // 
            this.btnProOK.Location = new System.Drawing.Point(329, 218);
            this.btnProOK.Name = "btnProOK";
            this.btnProOK.Size = new System.Drawing.Size(75, 23);
            this.btnProOK.TabIndex = 9;
            this.btnProOK.Text = "确定";
            this.btnProOK.UseVisualStyleBackColor = true;
            this.btnProOK.Click += new System.EventHandler(this.btnSingleOK_Click);
            // 
            // cmbProField
            // 
            this.cmbProField.FormattingEnabled = true;
            this.cmbProField.Location = new System.Drawing.Point(128, 60);
            this.cmbProField.Name = "cmbProField";
            this.cmbProField.Size = new System.Drawing.Size(121, 20);
            this.cmbProField.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "渲染字段:";
            // 
            // frmSymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 303);
            this.Controls.Add(this.xtraTabControl);
            this.Name = "frmSymbol";
            this.Text = "矢量数据渲染";
            this.Load += new System.EventHandler(this.frmSymbol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.xtraTabSingle.ResumeLayout(false);
            this.xtraTabSingle.PerformLayout();
            this.xtraTabUnique.ResumeLayout(false);
            this.xtraTabUnique.PerformLayout();
            this.xtraTabClassfiy.ResumeLayout(false);
            this.xtraTabClassfiy.PerformLayout();
            this.xtraTabProport.ResumeLayout(false);
            this.xtraTabProport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtraTabSingle;
        private DevExpress.XtraTab.XtraTabPage xtraTabUnique;
        private DevExpress.XtraTab.XtraTabPage xtraTabClassfiy;
        private DevExpress.XtraTab.XtraTabPage xtraTabProport;
        private System.Windows.Forms.Label lblClassifyCount;
        private System.Windows.Forms.Button btnClassifyOK;
        private System.Windows.Forms.ComboBox cmbClassifyField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnProOK;
        private System.Windows.Forms.ComboBox cmbProField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSingleOK;
        private System.Windows.Forms.Label lblSingleColor;
        private System.Windows.Forms.ComboBox cmbSingleField;
        private System.Windows.Forms.Label lblSingleField;
        private System.Windows.Forms.Button btnOnlyOK;
        private System.Windows.Forms.ComboBox cmbOnlyField;
        private System.Windows.Forms.Label label2;
        private CropWatchField.ComboBoxSym cmbSymSingle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraTab.XtraTabControl xtraTabControl;
        public ComboBoxSym cmbSymOnly;
        public ComboBoxSym cmbSymClassify;
        public ComboBoxSym cmbSymPro;
        public System.Windows.Forms.ComboBox cmbClassifyCount;
        private System.Windows.Forms.ComboBox cmbProSize;
        private System.Windows.Forms.Label lblProSize;
        private System.Windows.Forms.ComboBox cmbClassName;
        private System.Windows.Forms.Label label7;

    }
}