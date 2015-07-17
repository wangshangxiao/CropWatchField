namespace CropWatchField
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPrePro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoasic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClip = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFormatConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImageFusion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeoCorrect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeoHJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeoFY = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRadiocalibra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRadioCalibHJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRadioCalibFY = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetectCloud = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTwoReflectCorrect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCropClass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUnsupervised = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClassRecode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClassStatis = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGrowthMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGrowthRealT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGrowthProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.menuYieldPre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNutrientMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCropNutrient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoilNutrient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlantAndMature = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlantMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMatureMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDataMange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDBConnSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDataQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDataInput = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuTOCFeatureLyr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctMenuTFRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenuTFZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenuSaveAsLyr = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenuTFProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuTOCMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctMenuMapTurnOnAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenuMapTurnOffAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenuMapExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenwMapCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuTOCFeatureLyr.SuspendLayout();
            this.contextMenuTOCMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(191, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(668, 466);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(859, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 53);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(188, 466);
            this.axTOCControl1.TabIndex = 4;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            this.axTOCControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnDoubleClickEventHandler(this.axTOCControl1_OnDoubleClick);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 488);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(110, 22);
            this.menuNewDoc.Text = "新建";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(110, 22);
            this.menuOpenDoc.Text = "打开…";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(110, 22);
            this.menuSaveDoc.Text = "保存";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(110, 22);
            this.menuSaveAs.Text = "另存...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(107, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(110, 22);
            this.menuExitApp.Text = "退出";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuPrePro,
            this.menuCropClass,
            this.menuGrowthMonitor,
            this.menuYieldPre,
            this.menuNutrientMonitor,
            this.menuPlantAndMature,
            this.menuDataMange,
            this.menuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuPrePro
            // 
            this.menuPrePro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMoasic,
            this.menuClip,
            this.menuProjTrans,
            this.menuFormatConvert,
            this.menuImageFusion,
            this.menuGeoCorrect,
            this.menuRadiocalibra,
            this.menuDetectCloud,
            this.menuTwoReflectCorrect});
            this.menuPrePro.Name = "menuPrePro";
            this.menuPrePro.Size = new System.Drawing.Size(80, 21);
            this.menuPrePro.Text = "数据预处理";
            // 
            // menuMoasic
            // 
            this.menuMoasic.Name = "menuMoasic";
            this.menuMoasic.Size = new System.Drawing.Size(148, 22);
            this.menuMoasic.Text = "影像拼接";
            this.menuMoasic.Click += new System.EventHandler(this.menuMoasic_Click);
            // 
            // menuClip
            // 
            this.menuClip.Name = "menuClip";
            this.menuClip.Size = new System.Drawing.Size(148, 22);
            this.menuClip.Text = "影像裁剪";
            this.menuClip.Click += new System.EventHandler(this.menuClip_Click);
            // 
            // menuProjTrans
            // 
            this.menuProjTrans.Name = "menuProjTrans";
            this.menuProjTrans.Size = new System.Drawing.Size(148, 22);
            this.menuProjTrans.Text = "投影转换";
            this.menuProjTrans.Click += new System.EventHandler(this.menuProjTrans_Click);
            // 
            // menuFormatConvert
            // 
            this.menuFormatConvert.Name = "menuFormatConvert";
            this.menuFormatConvert.Size = new System.Drawing.Size(148, 22);
            this.menuFormatConvert.Text = "格式转换";
            this.menuFormatConvert.Click += new System.EventHandler(this.menuFormatConvert_Click);
            // 
            // menuImageFusion
            // 
            this.menuImageFusion.Name = "menuImageFusion";
            this.menuImageFusion.Size = new System.Drawing.Size(148, 22);
            this.menuImageFusion.Text = "数据融合";
            // 
            // menuGeoCorrect
            // 
            this.menuGeoCorrect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGeoHJ,
            this.menuGeoFY});
            this.menuGeoCorrect.Name = "menuGeoCorrect";
            this.menuGeoCorrect.Size = new System.Drawing.Size(148, 22);
            this.menuGeoCorrect.Text = "几何纠正";
            // 
            // menuGeoHJ
            // 
            this.menuGeoHJ.Name = "menuGeoHJ";
            this.menuGeoHJ.Size = new System.Drawing.Size(119, 22);
            this.menuGeoHJ.Text = "环境星";
            this.menuGeoHJ.Click += new System.EventHandler(this.menuGeoHJ_Click);
            // 
            // menuGeoFY
            // 
            this.menuGeoFY.Name = "menuGeoFY";
            this.menuGeoFY.Size = new System.Drawing.Size(119, 22);
            this.menuGeoFY.Text = "风云3号";
            this.menuGeoFY.Click += new System.EventHandler(this.menuGeoFY_Click);
            // 
            // menuRadiocalibra
            // 
            this.menuRadiocalibra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRadioCalibHJ,
            this.menuRadioCalibFY});
            this.menuRadiocalibra.Name = "menuRadiocalibra";
            this.menuRadiocalibra.Size = new System.Drawing.Size(148, 22);
            this.menuRadiocalibra.Text = "辐射定标";
            // 
            // menuRadioCalibHJ
            // 
            this.menuRadioCalibHJ.Name = "menuRadioCalibHJ";
            this.menuRadioCalibHJ.Size = new System.Drawing.Size(119, 22);
            this.menuRadioCalibHJ.Text = "环境星";
            this.menuRadioCalibHJ.Click += new System.EventHandler(this.menuRadioCalibHJ_Click);
            // 
            // menuRadioCalibFY
            // 
            this.menuRadioCalibFY.Name = "menuRadioCalibFY";
            this.menuRadioCalibFY.Size = new System.Drawing.Size(119, 22);
            this.menuRadioCalibFY.Text = "风云3号";
            // 
            // menuDetectCloud
            // 
            this.menuDetectCloud.Name = "menuDetectCloud";
            this.menuDetectCloud.Size = new System.Drawing.Size(148, 22);
            this.menuDetectCloud.Text = "云检测";
            // 
            // menuTwoReflectCorrect
            // 
            this.menuTwoReflectCorrect.Name = "menuTwoReflectCorrect";
            this.menuTwoReflectCorrect.Size = new System.Drawing.Size(148, 22);
            this.menuTwoReflectCorrect.Text = "二向反射纠正";
            // 
            // menuCropClass
            // 
            this.menuCropClass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUnsupervised,
            this.menuClassRecode,
            this.menuClassStatis});
            this.menuCropClass.Name = "menuCropClass";
            this.menuCropClass.Size = new System.Drawing.Size(92, 21);
            this.menuCropClass.Text = "作物分类识别";
            // 
            // menuUnsupervised
            // 
            this.menuUnsupervised.Name = "menuUnsupervised";
            this.menuUnsupervised.Size = new System.Drawing.Size(136, 22);
            this.menuUnsupervised.Text = "非监督分类";
            // 
            // menuClassRecode
            // 
            this.menuClassRecode.Name = "menuClassRecode";
            this.menuClassRecode.Size = new System.Drawing.Size(136, 22);
            this.menuClassRecode.Text = "分类重编码";
            // 
            // menuClassStatis
            // 
            this.menuClassStatis.Name = "menuClassStatis";
            this.menuClassStatis.Size = new System.Drawing.Size(136, 22);
            this.menuClassStatis.Text = "分类统计";
            // 
            // menuGrowthMonitor
            // 
            this.menuGrowthMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGrowthRealT,
            this.menuGrowthProcess});
            this.menuGrowthMonitor.Name = "menuGrowthMonitor";
            this.menuGrowthMonitor.Size = new System.Drawing.Size(92, 21);
            this.menuGrowthMonitor.Text = "作物长势监测";
            // 
            // menuGrowthRealT
            // 
            this.menuGrowthRealT.Name = "menuGrowthRealT";
            this.menuGrowthRealT.Size = new System.Drawing.Size(148, 22);
            this.menuGrowthRealT.Text = "实时长势监测";
            // 
            // menuGrowthProcess
            // 
            this.menuGrowthProcess.Name = "menuGrowthProcess";
            this.menuGrowthProcess.Size = new System.Drawing.Size(148, 22);
            this.menuGrowthProcess.Text = "过程长势监测";
            // 
            // menuYieldPre
            // 
            this.menuYieldPre.Name = "menuYieldPre";
            this.menuYieldPre.Size = new System.Drawing.Size(92, 21);
            this.menuYieldPre.Text = "作物单产预测";
            // 
            // menuNutrientMonitor
            // 
            this.menuNutrientMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCropNutrient,
            this.menuSoilNutrient});
            this.menuNutrientMonitor.Name = "menuNutrientMonitor";
            this.menuNutrientMonitor.Size = new System.Drawing.Size(116, 21);
            this.menuNutrientMonitor.Text = "养分胁迫状况监测";
            // 
            // menuCropNutrient
            // 
            this.menuCropNutrient.Name = "menuCropNutrient";
            this.menuCropNutrient.Size = new System.Drawing.Size(196, 22);
            this.menuCropNutrient.Text = "作物养分吸收胁迫监测";
            // 
            // menuSoilNutrient
            // 
            this.menuSoilNutrient.Name = "menuSoilNutrient";
            this.menuSoilNutrient.Size = new System.Drawing.Size(196, 22);
            this.menuSoilNutrient.Text = "土壤养分胁迫监测";
            // 
            // menuPlantAndMature
            // 
            this.menuPlantAndMature.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPlantMonitor,
            this.menuMatureMonitor});
            this.menuPlantAndMature.Name = "menuPlantAndMature";
            this.menuPlantAndMature.Size = new System.Drawing.Size(140, 21);
            this.menuPlantAndMature.Text = "作物播种与成熟期监测";
            // 
            // menuPlantMonitor
            // 
            this.menuPlantMonitor.Name = "menuPlantMonitor";
            this.menuPlantMonitor.Size = new System.Drawing.Size(160, 22);
            this.menuPlantMonitor.Text = "播种适宜性监测";
            // 
            // menuMatureMonitor
            // 
            this.menuMatureMonitor.Name = "menuMatureMonitor";
            this.menuMatureMonitor.Size = new System.Drawing.Size(160, 22);
            this.menuMatureMonitor.Text = "成熟期监测";
            // 
            // menuDataMange
            // 
            this.menuDataMange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDBConnSet,
            this.menuDataQuery,
            this.menuDataInput});
            this.menuDataMange.Name = "menuDataMange";
            this.menuDataMange.Size = new System.Drawing.Size(68, 21);
            this.menuDataMange.Text = "数据管理";
            // 
            // menuDBConnSet
            // 
            this.menuDBConnSet.Name = "menuDBConnSet";
            this.menuDBConnSet.Size = new System.Drawing.Size(160, 22);
            this.menuDBConnSet.Text = "数据库连接设置";
            this.menuDBConnSet.Click += new System.EventHandler(this.menuDBConnSet_Click);
            // 
            // menuDataQuery
            // 
            this.menuDataQuery.Name = "menuDataQuery";
            this.menuDataQuery.Size = new System.Drawing.Size(160, 22);
            this.menuDataQuery.Text = "数据查询";
            // 
            // menuDataInput
            // 
            this.menuDataInput.Name = "menuDataInput";
            this.menuDataInput.Size = new System.Drawing.Size(160, 22);
            this.menuDataInput.Text = "数据入库";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(68, 21);
            this.menuAbout.Text = "关于系统";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // contextMenuTOCFeatureLyr
            // 
            this.contextMenuTOCFeatureLyr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctMenuTFRemove,
            this.ctMenuTFZoomToLayer,
            this.ctMenuSaveAsLyr,
            this.ctMenuTFProperties});
            this.contextMenuTOCFeatureLyr.Name = "contextMenuTOCFeatureLyr";
            this.contextMenuTOCFeatureLyr.Size = new System.Drawing.Size(144, 92);
            this.contextMenuTOCFeatureLyr.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuTOCFeatureLyr_Opening);
            // 
            // ctMenuTFRemove
            // 
            this.ctMenuTFRemove.Name = "ctMenuTFRemove";
            this.ctMenuTFRemove.Size = new System.Drawing.Size(143, 22);
            this.ctMenuTFRemove.Text = "移除";
            this.ctMenuTFRemove.Click += new System.EventHandler(this.ctMenuTFRemove_Click);
            // 
            // ctMenuTFZoomToLayer
            // 
            this.ctMenuTFZoomToLayer.Name = "ctMenuTFZoomToLayer";
            this.ctMenuTFZoomToLayer.Size = new System.Drawing.Size(143, 22);
            this.ctMenuTFZoomToLayer.Text = "缩放到图层";
            this.ctMenuTFZoomToLayer.Click += new System.EventHandler(this.ctMenuTFZoomToLayer_Click);
            // 
            // ctMenuSaveAsLyr
            // 
            this.ctMenuSaveAsLyr.Name = "ctMenuSaveAsLyr";
            this.ctMenuSaveAsLyr.Size = new System.Drawing.Size(143, 22);
            this.ctMenuSaveAsLyr.Text = "保存为Layer";
            this.ctMenuSaveAsLyr.Click += new System.EventHandler(this.ctMenuSaveAsLyr_Click);
            // 
            // ctMenuTFProperties
            // 
            this.ctMenuTFProperties.Name = "ctMenuTFProperties";
            this.ctMenuTFProperties.Size = new System.Drawing.Size(143, 22);
            this.ctMenuTFProperties.Text = "属性";
            this.ctMenuTFProperties.Click += new System.EventHandler(this.ctMenuTFProperties_Click);
            // 
            // contextMenuTOCMap
            // 
            this.contextMenuTOCMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctMenuMapTurnOnAll,
            this.ctMenuMapTurnOffAll,
            this.ctMenuMapExpandAll,
            this.ctMenwMapCollapseAll});
            this.contextMenuTOCMap.Name = "contextMenuTOCMap";
            this.contextMenuTOCMap.Size = new System.Drawing.Size(153, 114);
            // 
            // ctMenuMapTurnOnAll
            // 
            this.ctMenuMapTurnOnAll.Name = "ctMenuMapTurnOnAll";
            this.ctMenuMapTurnOnAll.Size = new System.Drawing.Size(152, 22);
            this.ctMenuMapTurnOnAll.Text = "打开所有图层";
            this.ctMenuMapTurnOnAll.Click += new System.EventHandler(this.ctMenuMapTurnOnAll_Click);
            // 
            // ctMenuMapTurnOffAll
            // 
            this.ctMenuMapTurnOffAll.Name = "ctMenuMapTurnOffAll";
            this.ctMenuMapTurnOffAll.Size = new System.Drawing.Size(152, 22);
            this.ctMenuMapTurnOffAll.Text = "关闭所有图层";
            this.ctMenuMapTurnOffAll.Click += new System.EventHandler(this.ctMenuMapTurnOffAll_Click);
            // 
            // ctMenuMapExpandAll
            // 
            this.ctMenuMapExpandAll.Name = "ctMenuMapExpandAll";
            this.ctMenuMapExpandAll.Size = new System.Drawing.Size(152, 22);
            this.ctMenuMapExpandAll.Text = "展开所有图层";
            this.ctMenuMapExpandAll.Click += new System.EventHandler(this.ctMenuMapExpandAll_Click);
            // 
            // ctMenwMapCollapseAll
            // 
            this.ctMenwMapCollapseAll.Name = "ctMenwMapCollapseAll";
            this.ctMenwMapCollapseAll.Size = new System.Drawing.Size(152, 22);
            this.ctMenwMapCollapseAll.Text = "折叠所有图层";
            this.ctMenwMapCollapseAll.Click += new System.EventHandler(this.ctMenwMapCollapseAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 541);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "黑龙江红星农场农情监测系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuTOCFeatureLyr.ResumeLayout(false);
            this.contextMenuTOCMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPrePro;
        private System.Windows.Forms.ToolStripMenuItem menuMoasic;
        private System.Windows.Forms.ToolStripMenuItem menuClip;
        private System.Windows.Forms.ToolStripMenuItem menuProjTrans;
        private System.Windows.Forms.ToolStripMenuItem menuFormatConvert;
        private System.Windows.Forms.ToolStripMenuItem menuImageFusion;
        private System.Windows.Forms.ToolStripMenuItem menuGeoCorrect;
        private System.Windows.Forms.ToolStripMenuItem menuRadiocalibra;
        private System.Windows.Forms.ToolStripMenuItem menuPlantAndMature;
        private System.Windows.Forms.ToolStripMenuItem menuPlantMonitor;
        private System.Windows.Forms.ToolStripMenuItem menuMatureMonitor;
        private System.Windows.Forms.ToolStripMenuItem menuCropClass;
        private System.Windows.Forms.ToolStripMenuItem menuUnsupervised;
        private System.Windows.Forms.ToolStripMenuItem menuClassRecode;
        private System.Windows.Forms.ToolStripMenuItem menuClassStatis;
        private System.Windows.Forms.ToolStripMenuItem menuNutrientMonitor;
        private System.Windows.Forms.ToolStripMenuItem menuCropNutrient;
        private System.Windows.Forms.ToolStripMenuItem menuSoilNutrient;
        private System.Windows.Forms.ToolStripMenuItem menuGrowthMonitor;
        private System.Windows.Forms.ToolStripMenuItem menuGrowthRealT;
        private System.Windows.Forms.ToolStripMenuItem menuGrowthProcess;
        private System.Windows.Forms.ToolStripMenuItem menuYieldPre;
        private System.Windows.Forms.ToolStripMenuItem menuDataMange;
        private System.Windows.Forms.ToolStripMenuItem menuDBConnSet;
        private System.Windows.Forms.ToolStripMenuItem menuDataQuery;
        private System.Windows.Forms.ToolStripMenuItem menuDataInput;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuDetectCloud;
        private System.Windows.Forms.ToolStripMenuItem menuTwoReflectCorrect;
        private System.Windows.Forms.ToolStripMenuItem menuGeoHJ;
        private System.Windows.Forms.ToolStripMenuItem menuGeoFY;
        private System.Windows.Forms.ToolStripMenuItem menuRadioCalibHJ;
        private System.Windows.Forms.ToolStripMenuItem menuRadioCalibFY;
        private System.Windows.Forms.ContextMenuStrip contextMenuTOCFeatureLyr;
        private System.Windows.Forms.ToolStripMenuItem ctMenuTFRemove;
        private System.Windows.Forms.ToolStripMenuItem ctMenuTFZoomToLayer;
        private System.Windows.Forms.ToolStripMenuItem ctMenuSaveAsLyr;
        private System.Windows.Forms.ToolStripMenuItem ctMenuTFProperties;
        private System.Windows.Forms.ContextMenuStrip contextMenuTOCMap;
        private System.Windows.Forms.ToolStripMenuItem ctMenuMapTurnOnAll;
        private System.Windows.Forms.ToolStripMenuItem ctMenuMapTurnOffAll;
        private System.Windows.Forms.ToolStripMenuItem ctMenuMapExpandAll;
        private System.Windows.Forms.ToolStripMenuItem ctMenwMapCollapseAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

