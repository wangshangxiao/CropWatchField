namespace CropWatchField
{
    partial class ExportMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportMap));
            this.menuExportMap = new System.Windows.Forms.MenuStrip();
            this.添加地图要素MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指北针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印输出MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.页面设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制图模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbTemplate = new System.Windows.Forms.ToolStripComboBox();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuExportMap
            // 
            this.menuExportMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加地图要素MenuItem,
            this.打印输出MenuItem,
            this.制图模板ToolStripMenuItem,
            this.cmbTemplate});
            this.menuExportMap.Location = new System.Drawing.Point(0, 0);
            this.menuExportMap.Name = "menuExportMap";
            this.menuExportMap.Size = new System.Drawing.Size(661, 24);
            this.menuExportMap.TabIndex = 1;
            this.menuExportMap.Text = "menuStrip1";
            // 
            // 添加地图要素MenuItem
            // 
            this.添加地图要素MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图名ToolStripMenuItem,
            this.指北针ToolStripMenuItem,
            this.图例ToolStripMenuItem,
            this.比例尺ToolStripMenuItem});
            this.添加地图要素MenuItem.Name = "添加地图要素MenuItem";
            this.添加地图要素MenuItem.Size = new System.Drawing.Size(89, 20);
            this.添加地图要素MenuItem.Text = "添加地图要素";
            // 
            // 图名ToolStripMenuItem
            // 
            this.图名ToolStripMenuItem.Name = "图名ToolStripMenuItem";
            this.图名ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.图名ToolStripMenuItem.Text = "图名";
            this.图名ToolStripMenuItem.Click += new System.EventHandler(this.ElementToolStripMenuItem_Click);
            // 
            // 指北针ToolStripMenuItem
            // 
            this.指北针ToolStripMenuItem.Name = "指北针ToolStripMenuItem";
            this.指北针ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.指北针ToolStripMenuItem.Text = "指北针";
            this.指北针ToolStripMenuItem.Click += new System.EventHandler(this.ElementToolStripMenuItem_Click);
            // 
            // 图例ToolStripMenuItem
            // 
            this.图例ToolStripMenuItem.Name = "图例ToolStripMenuItem";
            this.图例ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.图例ToolStripMenuItem.Text = "图例";
            this.图例ToolStripMenuItem.Click += new System.EventHandler(this.ElementToolStripMenuItem_Click);
            // 
            // 比例尺ToolStripMenuItem
            // 
            this.比例尺ToolStripMenuItem.Name = "比例尺ToolStripMenuItem";
            this.比例尺ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.比例尺ToolStripMenuItem.Text = "比例尺";
            this.比例尺ToolStripMenuItem.Click += new System.EventHandler(this.ElementToolStripMenuItem_Click);
            // 
            // 打印输出MenuItem
            // 
            this.打印输出MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.页面设置ToolStripMenuItem,
            this.打印预览ToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.导出图片ToolStripMenuItem});
            this.打印输出MenuItem.Name = "打印输出MenuItem";
            this.打印输出MenuItem.Size = new System.Drawing.Size(65, 20);
            this.打印输出MenuItem.Text = "打印输出";
            // 
            // 页面设置ToolStripMenuItem
            // 
            this.页面设置ToolStripMenuItem.Name = "页面设置ToolStripMenuItem";
            this.页面设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.页面设置ToolStripMenuItem.Text = "页面设置";
            this.页面设置ToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打印预览ToolStripMenuItem.Text = "打印预览";
            this.打印预览ToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // 导出图片ToolStripMenuItem
            // 
            this.导出图片ToolStripMenuItem.Name = "导出图片ToolStripMenuItem";
            this.导出图片ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出图片ToolStripMenuItem.Text = "保存图片";
            this.导出图片ToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // 制图模板ToolStripMenuItem
            // 
            this.制图模板ToolStripMenuItem.Name = "制图模板ToolStripMenuItem";
            this.制图模板ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.制图模板ToolStripMenuItem.Text = "制图模板:";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(180, 20);
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbTemplate_SelectedIndexChanged);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 24);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(661, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(0, 52);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(661, 421);
            this.axPageLayoutControl1.TabIndex = 3;
            this.axPageLayoutControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnDoubleClickEventHandler(this.axPageLayoutControl1_OnDoubleClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // ExportMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 473);
            this.Controls.Add(this.axPageLayoutControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuExportMap);
            this.Name = "ExportMap";
            this.Text = "专题制图";
            this.Load += new System.EventHandler(this.ExportMap_Load);
            this.menuExportMap.ResumeLayout(false);
            this.menuExportMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuExportMap;
        private System.Windows.Forms.ToolStripMenuItem 添加地图要素MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指北针ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比例尺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印输出MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 页面设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图片ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem 制图模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripComboBox cmbTemplate;
        public ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;

    }
}