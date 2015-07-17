using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using System.Diagnostics;
using DevExpress.XtraBars.Helpers;

namespace CropWatchField
{
    public partial class RibbonForm : DevExpress.XtraEditors.XtraForm
    {

        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;

        //获取打开的栅格数据列表
        List<IRasterLayer> pRasterLayerList = new List<IRasterLayer>();
        //进行灰度显示的波段索引
        private int grayPos = 0;
        //RGB合成时候选中的波段数POS
        private int[] rgbPos = new int[3] { 0, 1, 2 };
       
        public RibbonForm()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2010 Blue");
        }
        //窗体加载
        private void RibbonForm_Load(object sender, EventArgs e)
        {
            
            m_mapControl = (IMapControl3)axMapControl1.Object;
            barBtnItemSave.Enabled = false;
            axToolbarControl1.SetBuddyControl(axMapControl1);
            axTOCControl1.SetBuddyControl(axMapControl1);

            //修改TOCControl上图层控制的名称
            this.axMapControl1.Map.Name = "Map";
            this.axTOCControl1.Update();

            //控制波段列表中灰度显示和彩色合成
            radioGroup1.SelectedIndex = 1;
            labelRed.Visible = true;
            labelGreen.Visible = true;
            labelBlue.Visible = true;
            combRed.Visible = true;
            combGreen.Visible = true;
            combBlue.Visible = true;

            labelGray.Visible = false;
            combGray.Visible = false;
           
        }
        //新建文档
        private void barBtnItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }
        //打开文档
        private void barBtnItemOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }
        //保存文档
        private void barBtnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }
        //另存文档
        private void barBtnItemSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }
        //退出程序
        private void barBtnItemExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //加个对话框提示一下

            Application.Exit();
        }

        /// <summary>
        /// 影像拼接界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemYXPJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImageMosaicForm imageMosaicForm = new ImageMosaicForm();
            imageMosaicForm.ShowDialog();
        }

        /// <summary>
        /// 影像裁剪界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemYXCQ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImageClipForm imageClipForm = new ImageClipForm();
            imageClipForm.ShowDialog();
        }

        /// <summary>
        /// 投影转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemTYZH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProJTransferForm proJTransferForm = new ProJTransferForm();
            proJTransferForm.ShowDialog();
        }

        /// <summary>
        /// 格式转换界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemGSZH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormatConvertForm formatConvertForm = new FormatConvertForm();
            formatConvertForm.ShowDialog();
        }

        /// <summary>
        /// 几何纠正-环境星
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemJHJZ_HJX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HJAutoCorrectForm hJAutoCorrectForm = new HJAutoCorrectForm();
            hJAutoCorrectForm.ShowDialog();
        }

        ///// <summary>
        ///// 几何纠正-风云
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void barBtnItemJHJZ_FY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    GeoCorrectForm geoCorrectForm = new GeoCorrectForm(1);
        //    geoCorrectForm.ShowDialog();
        //}

        /// <summary>
        /// 辐射标定界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItem_FSDB_HJX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RadioCalibrationForm radioCalibrationForm = new RadioCalibrationForm();
            radioCalibrationForm.ShowDialog();
        }
        /// <summary>
        /// 关于系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtonItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        ExportMap exportmap;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (axMapControl1.LayerCount > 0)
            {
                exportmap = new ExportMap(axMapControl1,axMapControl1.get_Layer(0));
                exportmap.Show();
            }
            else
            {
                MessageBox.Show("请添加数据");
                return;
            }
            
        }
        //图层操作
        private ILayer TOCRightLayer;
        esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
        IBasicMap basicMap = null;
        ILayer layer = null;
        object unk = null;
        object data = null;

        //删除图层
        private void ctMenuTFRemove_Click(object sender, EventArgs e)
        {
            this.axMapControl1.Map.DeleteLayer(this.TOCRightLayer);
            this.axTOCControl1.Update();

            //清空combSelectedFile、treeList1和combRed、combGreen、combBlue、combGray控件。
            this.combSlectedFile.Text="";
            this.treeList1.Nodes.Clear();
            this.combRed.Properties.Items.Clear();
            this.combGreen.Properties.Items.Clear();
            this.combBlue.Properties.Items.Clear();
            this.combGray.Properties.Items.Clear();
        }
        //缩放至图层
        private void ctMenuTFZoomToLayer_Click(object sender, EventArgs e)
        {
            IGeoDataset pGeoDataset = null;
            if (this.TOCRightLayer is IFeatureLayer)
            {
                IFeatureClass pFeatureClass = ((IFeatureLayer)this.TOCRightLayer).FeatureClass;
                pGeoDataset = pFeatureClass as IGeoDataset;
            }
            else if (this.TOCRightLayer is IRasterLayer)
            {
                IRasterLayer pRaterLayer = this.TOCRightLayer as IRasterLayer;
                pGeoDataset = pRaterLayer.Raster as IGeoDataset;
            }
            else if (this.TOCRightLayer is ITinLayer)
            {
                ITinLayer pTinLayer = this.TOCRightLayer as ITinLayer;
                pGeoDataset = pTinLayer.Dataset as IGeoDataset;
            }
            else
            {
                return;
            }
            this.axMapControl1.Extent = pGeoDataset.Extent;
            this.axMapControl1.Refresh();
        }
        //保存图层
        private void ctMenuSaveAsLyr_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Title = "保存为Lyr文件";
            this.saveFileDialog.Filter = "Lyr文件|*.lyr";
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string direction = System.IO.Path.GetDirectoryName(this.saveFileDialog.FileName);
                string file = System.IO.Path.GetFileName(this.saveFileDialog.FileName);
                ILayerFile pLayerFile = new LayerFileClass();
                pLayerFile.New(this.saveFileDialog.FileName);
                pLayerFile.ReplaceContents(this.TOCRightLayer);
                pLayerFile.Save();
            }
        }
        //打开属性表
        private void ctMenuTFProperties_Click(object sender, EventArgs e)
        {
            frmAttributeTable fmAttriTable = new frmAttributeTable(layer as IFeatureLayer, axMapControl1);
            fmAttriTable.ShowDialog();
        }
        //符号系统
        private void ctMenuSymSystem_Click(object sender, EventArgs e)
        {
            if (this.TOCRightLayer is IFeatureLayer)
            {
                frmFeatureSym Featuresym = new frmFeatureSym(this.TOCRightLayer as IFeatureLayer, axMapControl1, axTOCControl1);
                Featuresym.Show();
            }
            if (this.TOCRightLayer is IRasterLayer)
            {
                frmRasterSym rastersym = new frmRasterSym(this.TOCRightLayer as IRasterLayer,axMapControl1,axTOCControl1);
                rastersym.Show();
            }
        }

        private void axTOCControl1_OnDoubleClick(object sender, ITOCControlEvents_OnDoubleClickEvent e)
        {
            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null;
            object data = null;
            this.axTOCControl1.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref unk, ref data);
            if (e.button == 1)
            {
                System.Drawing.Point pos = new System.Drawing.Point(e.x, e.y);
                if (itemType == esriTOCControlItem.esriTOCControlItemLegendClass)
                {
                    //取得图例
                    ILegendClass pLegendClass = ((ILegendGroup)unk).get_Class((int)data);
                    //创建符号选择器SymbolSelector实例
                    SymbolSelectorFrm SymbolSelectorFrm = new SymbolSelectorFrm(pLegendClass, layer);
                    if (SymbolSelectorFrm.ShowDialog() == DialogResult.OK)
                    {
                        //局部更新主Map控件
                        this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                        //设置新的符号
                        pLegendClass.Symbol = SymbolSelectorFrm.pSymbol;
                        //更新主Map控件和图层控件
                        this.axMapControl1.ActiveView.Refresh();
                        this.axTOCControl1.Refresh();
                    }
                }
            }
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            this.axTOCControl1.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref unk, ref data);
            if (e.button == 2)
            {
                switch (itemType)
                {   
                    case esriTOCControlItem.esriTOCControlItemLayer:
                        this.TOCRightLayer = layer;
                        this.contextMenuTOCFeatureLyr.Show(this.axTOCControl1, e.x, e.y);
                        break;
                    case esriTOCControlItem.esriTOCControlItemMap:
                        this.contextMenuTOCMap.Show(this.axTOCControl1, e.x, e.y);
                        break;
                }
            }
        }

        private void contextMenuTOCFeatureLyr_Opening(object sender, CancelEventArgs e)
        {
            if (this.TOCRightLayer is IGeoFeatureLayer)
            {
                this.ctMenuTFProperties.Enabled = true;
                //this.ctMenuSymSystem.Enabled = true;
            }
            else
            {
                this.ctMenuTFProperties.Enabled = false;
                //this.ctMenuSymSystem.Enabled = false;
            }
        }
        //打开所有图层
        private void ctMenuMapTurnOnAll_Click(object sender, EventArgs e)
        {
            IEnumLayer pEnumLayer = this.axMapControl1.Map.get_Layers(null, false);
            if (pEnumLayer == null) return;
            ILayer pLayer;
            pEnumLayer.Reset();
            for (pLayer = pEnumLayer.Next(); pLayer != null; pLayer = pEnumLayer.Next())
            {
                pLayer.Visible = true;
            }
            this.axMapControl1.Refresh();
            this.axTOCControl1.Update();
        }
        //关闭所有图层
        private void ctMenuMapTurnOffAll_Click(object sender, EventArgs e)
        {
            IEnumLayer pEnumLayer = this.axMapControl1.Map.get_Layers(null, false);
            if (pEnumLayer == null) return;
            ILayer pLayer;
            pEnumLayer.Reset();
            for (pLayer = pEnumLayer.Next(); pLayer != null; pLayer = pEnumLayer.Next())
            {
                pLayer.Visible = false;
            }
            this.axMapControl1.Refresh();
            this.axTOCControl1.Update();
        }
        //展开所有图层
        private void ctMenuMapExpandAll_Click(object sender, EventArgs e)
        {
            IEnumLayer pEnumLayer = this.axMapControl1.Map.get_Layers(null, false);
            if (pEnumLayer == null) return;
            ILayer pLayer;
            ILegendInfo pLengendInfo;
            ILegendGroup pLengendGroup;
            pEnumLayer.Reset();
            for (pLayer = pEnumLayer.Next(); pLayer != null; pLayer = pEnumLayer.Next())
            {
                if (pLayer is ILegendInfo)
                {
                    pLengendInfo = pLayer as ILegendInfo;
                    for (int i = 0; i < pLengendInfo.LegendGroupCount; i++)
                    {
                        pLengendGroup = pLengendInfo.get_LegendGroup(i);
                        pLengendGroup.Visible = true;
                    }
                }
            }
            this.axTOCControl1.Update();
        }
        //折叠所有图层
        private void ctMenwMapCollapseAll_Click(object sender, EventArgs e)
        {
            IEnumLayer pEnumLayer = this.axMapControl1.Map.get_Layers(null, false);
            if (pEnumLayer == null) return;
            ILayer pLayer;
            ILegendInfo pLengendInfo;
            ILegendGroup pLengendGroup;
            pEnumLayer.Reset();
            for (pLayer = pEnumLayer.Next(); pLayer != null; pLayer = pEnumLayer.Next())
            {
                if (pLayer is ILegendInfo)
                {
                    pLengendInfo = pLayer as ILegendInfo;
                    for (int i = 0; i < pLengendInfo.LegendGroupCount; i++)
                    {
                        pLengendGroup = pLengendInfo.get_LegendGroup(i);
                        pLengendGroup.Visible = false;
                    }
                }
            }
            this.axTOCControl1.Update();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                //控制波段列表中灰度显示和彩色合成
                labelRed.Visible = true;
                labelGreen.Visible = true;
                labelBlue.Visible = true;
                combRed.Visible = true;
                combGreen.Visible = true;
                combBlue.Visible = true;

                labelGray.Visible = false;
                combGray.Visible = false;
            }
            else
            {
                labelRed.Visible = false;
                labelGreen.Visible = false;
                labelBlue.Visible = false;
                combRed.Visible = false;
                combGreen.Visible = false;
                combBlue.Visible = false;

                labelGray.Visible = true;
                combGray.Visible = true;
            }
        }

        private void axToolbarControl1_OnItemClick(object sender, IToolbarControlEvents_OnItemClickEvent e)
        {
            if (e.index == 2)
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            pRasterLayerList.Clear();
            combSlectedFile.Properties.Items.Clear();
            if (axMapControl1.LayerCount == 0)
                return;
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                if (axMapControl1.get_Layer(i) is IFeatureLayer)
                {
                    continue;
                }
                else if (axMapControl1.get_Layer(i) is IRasterLayer)
                {
                    IRasterLayer pRL = new RasterLayerClass();
                    pRL = axMapControl1.get_Layer(i) as IRasterLayer;
                    pRasterLayerList.Add(pRL);
                    combSlectedFile.Properties.Items.Add(pRL.Name.ToString());
                }
            }
        }

        private void combSlectedFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0;i<pRasterLayerList.Count;i++)
            {
                if (combSlectedFile.SelectedText.Trim() == pRasterLayerList[i].Name.ToString().Trim())
                {
                    List<string> bandnames =new List<string>();
                    bandnames = getBandName(pRasterLayerList[i]);
                    addBandNameToCombox(combGray, bandnames);
                    addBandNameToCombox(combRed, bandnames);
                    addBandNameToCombox(combGreen, bandnames);
                    addBandNameToCombox(combBlue, bandnames);
                    showBandsInTree(pRasterLayerList[i].Name.ToString().Trim(), bandnames);
                }
            }
        }

        private List<string> getBandName(IRasterLayer pRLayer)
        {
            try
            {
                string fullPath = pRLayer.FilePath;
                IRasterDataset rasterDataset = OpenFileRasterDataset(fullPath);
                IRasterBandCollection pRBCollection = rasterDataset as IRasterBandCollection;
                List<string> lstring = new List<string>();
                for (int i = 0; i < pRLayer.BandCount; i++)
                {
                    IRasterBand pRBand = pRBCollection.Item(i);
                    lstring.Add(pRBand.Bandname);
                }
                return lstring;
            }
            catch 
            {
                return null;
            }
        }

        private static IRasterDataset OpenFileRasterDataset(string fullpath)
        {
            try
            {
                IWorkspaceFactory WorkspaceFactory = new RasterWorkspaceFactoryClass();
                string filePath = System.IO.Path.GetDirectoryName(fullpath);
                string fileName = System.IO.Path.GetFileName(fullpath);
                IWorkspace Workspace = WorkspaceFactory.OpenFromFile(filePath, 0);
                IRasterWorkspace rasterWorkspace = (IRasterWorkspace)Workspace;
                IRasterDataset rasterSet = (IRasterDataset)rasterWorkspace.OpenRasterDataset(fileName);
                return rasterSet;
            }
            catch
            {
                return null;
            }
        }

        private void addBandNameToCombox(ComboBoxEdit cb, List<string> bandName)
        {
            cb.Text = "";
            cb.Properties.Items.Clear();
            foreach (string name in bandName)
            {
                cb.Properties.Items.Add(name);
            }
        }

        private void showBandsInTree(string filename, List<string> bandname)
        {
            treeList1.Nodes.Clear();
            this.treeList1.AppendNode(new object[] { filename }, null);
            foreach (string str in bandname)
            {
                this.treeList1.AppendNode(new object[] { str }, 0);
            }
            this.treeList1.ExpandAll();
        }

        private void sBtnBandShow_Click(object sender, EventArgs e)
        {
            if (combSlectedFile.Text == "")
            {
                MessageBox.Show("请选择影像", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //isOpenOrReRenderer = true;
                if (treeList1.Nodes.Count > 0)
                {
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        if (combGray.Text=="")
                        {
                            MessageBox.Show("请选择显示波段", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        this.grayPos = combGray.SelectedIndex;
                        drawImage(combSlectedFile.SelectedItem.ToString(), axMapControl1.Extent);
                        this.axMapControl1.Refresh();
                        this.axTOCControl1.Refresh();
                    }
                    else
                    {
                        //如果选择的不够三个波段，无法进行彩色合成
                        if (combRed.Text.Length == 0 || combGreen.Text.Length == 0 || combBlue.Text.Length == 0)
                        {
                            MessageBox.Show("请选择进行彩色合成的波段！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        this.rgbPos[0] = combRed.SelectedIndex;
                        this.rgbPos[1] = combGreen.SelectedIndex;
                        this.rgbPos[2] = combBlue.SelectedIndex;

                        drawImage(combSlectedFile.SelectedItem.ToString(), axMapControl1.Extent);
                        this.axMapControl1.Refresh();
                        this.axTOCControl1.Refresh();
                    }
                }
            }
        }

        //波段合成影像
        private void drawImage(string file, IEnvelope extent)
        {
            IRasterLayer pSelectedRasterLayer = new RasterLayerClass();
            ILayer pLayer;
            foreach (IRasterLayer pR in pRasterLayerList)
            {
                if (pR.Name.ToString() == file)
                {
                    pSelectedRasterLayer = pR;
                }
            }
            IRasterBandCollection pRBCollection = pSelectedRasterLayer.Raster as IRasterBandCollection;
            //判断所选择是渲染方式是否是彩色通道
            if (radioGroup1.SelectedIndex == 1 && pSelectedRasterLayer.BandCount >= 2)
            {
                pLayer = RasterRenderedLayer(pSelectedRasterLayer,true, 0, rgbPos);

                if (axMapControl1.LayerCount == 0)
                {
                    this.axMapControl1.AddLayer(pLayer);
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < axMapControl1.LayerCount; i++)
                    {
                        if (pLayer.Name.ToString() == axMapControl1.get_Layer(i).Name.ToString())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.axMapControl1.AddLayer(pLayer);
                    }
                    else
                    {
                        for (int i = 0; i < axMapControl1.LayerCount; i++)
                        {
                            if (pLayer.Name == axMapControl1.get_Layer(i).Name)
                            {
                                this.axMapControl1.DeleteLayer(i);
                                this.axMapControl1.AddLayer(pLayer);
                            }
                        }
                    }
                }
                //if (extent == null)
                //{
                    this.axMapControl1.Extent = ((pLayer as IRasterLayer).Raster as IGeoDataset).Extent;
                //}
                //else
                //{
                //    this.axMapControl1.Extent = extent;
                //}
            }
            else
            {
                pLayer = RasterRenderedLayer(pSelectedRasterLayer,false, grayPos, null);

                if (axMapControl1.LayerCount == 0)
                {
                    this.axMapControl1.AddLayer(pLayer);
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < axMapControl1.LayerCount; i++)
                    {
                        if (pLayer.Name.ToString() == axMapControl1.get_Layer(i).Name.ToString())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.axMapControl1.AddLayer(pLayer);
                    }
                    else
                    {
                        for (int i = 0; i < axMapControl1.LayerCount; i++)
                        {
                            if (pLayer.Name == axMapControl1.get_Layer(i).Name)
                            {
                                this.axMapControl1.DeleteLayer(i);
                                this.axMapControl1.AddLayer(pLayer);
                            }
                        }
                    }
                }

                //this.mainMap.AddLayer(layer);
                //if (extent == null)
                //{
                    this.axMapControl1.Extent = ((pLayer as IRasterLayer).Raster as IGeoDataset).Extent;
                //}
                //else
                //{
                //    this.axMapControl1.Extent = extent;
                //}
            }
        }

        /// <summary>
        ///对Raster根据数据行进行渲染，可以渲染成单通道灰度显示和RGB合成显示
        /// </summary>
        /// <param name="renderType">渲染方式调节</param>
        /// <returns></returns>
        public IRasterLayer RasterRenderedLayer(IRasterLayer pRL, bool renderType, int grayBandIndex, int[] rgbBandIndex)
        {
            //实例新的栅格图层
            IRasterLayer rlayer = new RasterLayerClass();

            string fullPath = pRL.FilePath;
            IRasterDataset rasterDataset = OpenFileRasterDataset(fullPath);


            //单波段
            if (rgbBandIndex == null)
            {
                //如果grayBandIndex=-1
                try
                {
                    IRasterRenderer render = null;
                    render = BandCombinationShow.StretchRenderer(rasterDataset, grayBandIndex);
                    rlayer.CreateFromDataset(rasterDataset);
                    rlayer.Renderer = render as IRasterRenderer;
                    return rlayer;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
            else//多波段显示
            {

                try
                {
                    if (!renderType)
                    {
                        IRasterRenderer render = BandCombinationShow.StretchRenderer(rasterDataset, grayPos);
                        rlayer.CreateFromDataset(rasterDataset);
                        rlayer.Renderer = render as IRasterRenderer;
                    }
                    else
                    {
                        //设置彩色合成顺序 生成新的渲染模式
                        IRasterRGBRenderer render = new RasterRGBRendererClass();
                        render.RedBandIndex = rgbBandIndex[0];
                        render.GreenBandIndex = rgbBandIndex[1];
                        render.BlueBandIndex = rgbBandIndex[2];

                        IRasterStretch stretchType = (IRasterStretch)render;
                        stretchType.StretchType = esriRasterStretchTypesEnum.esriRasterStretch_StandardDeviations;
                        stretchType.StandardDeviationsParam = 2;


                        rlayer.CreateFromDataset(rasterDataset);
                        rlayer.Renderer = render as IRasterRenderer;

                    }

                    return rlayer;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
        }

        private void barBtnItemWaterTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaterFindtableForm wff = new WaterFindtableForm();
            wff.ShowDialog();
        }

        private void barBtnItemWaterMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaterRetrievalForm wrf = new WaterRetrievalForm();
            wrf.ShowDialog();
        }

        private void barBtnItemYLSTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChlorophyllFindtableForm cff = new ChlorophyllFindtableForm();
            cff.ShowDialog();
        }

        private void barBtnItemYLSMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChlorophyllRetrievalForm crf = new ChlorophyllRetrievalForm();
            crf.ShowDialog();
        }

        private void barBtnItemSKRH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TSFusionForm TSFusionForm = new TSFusionForm();
            TSFusionForm.ShowDialog();
        }

        private void barBtnItemGPRH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            SpecFusionForm SpecFusionForm = new SpecFusionForm();
            SpecFusionForm.ShowDialog();
        }

        private void barBtnItemISOData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ISODataForm iSODataForm = new ISODataForm();
            iSODataForm.ShowDialog();
        }

        private void barBtnItemRecode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\recode.sav";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            //初始化
            oCom.CreateObject(0, 0, 0);
            oCom.ExecuteString("restore,\'" + sIDLSavPath + "\'");
            oCom.ExecuteString("RECODE");
            CodeListXtraForm clxf = new CodeListXtraForm();
            clxf.ShowDialog();
        }


        private void barBtnItemAreaStatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClassStatisticXtraForm csx = new ClassStatisticXtraForm();
            csx.ShowDialog();
        }

        private void barBtnItemBio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BiomassForm BiomassForm = new BiomassForm();
            BiomassForm.ShowDialog();
        }

        private void barBtnItemYield_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HarvestForm HarvestForm = new HarvestForm();
            HarvestForm.ShowDialog();
        }

        private void barBtnItemCropNutrient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SANForm vSANForm = new SANForm();
            vSANForm.ShowDialog();
        }

        private void barBtnItemSoilNutrient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OMForm vOMForm = new OMForm();
            vOMForm.ShowDialog();
        }

        private void barBtnItemSprWheat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SprWheatMDForm sprWheatMDForm = new SprWheatMDForm();
            sprWheatMDForm.ShowDialog();
        }

        private void barBtnItemSoybean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            SoybeanMDForm soybeanMDForm = new SoybeanMDForm();
            soybeanMDForm.ShowDialog();
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            //IActiveView pAcv = exportmap.axPageLayoutControl1.ActiveView.FocusMap as IActiveView;
            //IDisplayTransformation displayTransformation = pAcv.ScreenDisplay.DisplayTransformation;
            //displayTransformation.VisibleBounds = axMapControl1.Extent;//设置焦点地图的可视范围
            //exportmap.axPageLayoutControl1.ActiveView.Refresh();
            //CopyAndOverwriteMap(axMapControl1, exportmap.axPageLayoutControl1);
        }

        public void CopyAndOverwriteMap(AxMapControl mapcontrol, AxPageLayoutControl PageLayoutControl)
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object toCopyMap = mapcontrol.Map;
            object copiedMap = objectCopy.Copy(toCopyMap);
            object toOverwriteMap = PageLayoutControl.ActiveView.FocusMap;
            objectCopy.Overwrite(copiedMap, ref toOverwriteMap);
        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            CopyAndOverwriteMap(axMapControl1, exportmap.axPageLayoutControl1);
        }

        private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            axTOCControl1.Update();
            CopyAndOverwriteMap(axMapControl1, exportmap.axPageLayoutControl1);
        }

        private void barBtnItemDataInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("此模块正在开发中!");
            return;
        }

        private void barBtnItemDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ExportToWord exportword = new ExportToWord();
            //exportword.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "11_ExportWord");
        }

        private void barBtnItemVtoR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "0");
        }

        private void barBtnSDSToP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "4");
        }

        private void barBtnSIDSToP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "4");
        }

        private void barBtnWSToP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //StatictisForm staForm = new StatictisForm();
            //staForm.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "3");
        }

        private void barBtnChSToP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "3");
        }

        private void barBtnItemSPlot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "3");
        }

        private void barBtnSMPSToP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "3");
        }

        private void barBtnSWMPSToP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "3");
        }

        private void barBtnWPToV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToVillageForm atvf = new AggregateToVillageForm();
            //atvf.lbl_tablename.Text = "WATERRETRIEVAL";
            //atvf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "5_WATERRETRIEVAL");
            
        }

        private void barBtnChPToV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToVillageForm atvf = new AggregateToVillageForm();
            //atvf.lbl_tablename.Text = "CHLOROPHYLLRETRIEVAL";
            //atvf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "5_CHLOROPHYLLRETRIEVAL");
        }

        private void barBtnItemPtoVillage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToVillageForm atvf = new AggregateToVillageForm();
            //atvf.lbl_tablename.Text = "CROPYIELD";
            //atvf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "5_CROPYIELD");
        }



        private void barBtnSIDPToV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SoilAggregateToVillage atvf = new SoilAggregateToVillage();
            //atvf.lbl_tablename.Text = "SOILNUTRIENT";
            //atvf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "7_SOILNUTRIENT");
        }

        private void barBtnSMPPToV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToVillageForm atvf = new AggregateToVillageForm();
            //atvf.lbl_tablename.Text = "MATUREPERIOD";
            //atvf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "5_MATUREPERIOD");
        }

        private void barBtnWPToT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToTownForm attf = new AggregateToTownForm();
            //attf.lbl_tablename.Text = "WATERRETRIEVAL";
            //attf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "6_WATERRETRIEVAL");
        }

        private void barBtnChPToT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToTownForm attf = new AggregateToTownForm();
            //attf.lbl_tablename.Text = "CHLOROPHYLLRETRIEVAL";
            //attf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "6_CHLOROPHYLLRETRIEVAL");
        }

        private void barBtnItemPtoT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToTownForm attf = new AggregateToTownForm();
            //attf.lbl_tablename.Text = "CROPYIELD";
            //attf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "6_CROPYIELD");
        }

        private void barBtnSIDPToT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SoilAggregateToTown attf = new SoilAggregateToTown();
            //attf.lbl_tablename.Text = "SOILNUTRIENT";
            //attf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "8_SOILNUTRIENT");
        }

        private void barBtnSMPPToT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AggregateToTownForm attf = new AggregateToTownForm();
            //attf.lbl_tablename.Text = "MATUREPERIOD";
            //attf.ShowDialog();
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "6_MATUREPERIOD");
        }

       

        private void barBtnItemResample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "1");
        }

        private void barBtnItemLayerStack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "2");
        }

        private void barBtnWPToC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "12_WATERRETRIEVAL");
        }

        private void barBtnChPToC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "12_CHLOROPHYLLRETRIEVAL");
        }

        private void barBtnItemPtoC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "12_CROPYIELD");
        }

        private void barBtnSMPPToC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "12_MATUREPERIOD");
        }

        private void barBtnSIDPToC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "13_SOILNUTRIENT");
        }

        private void barBtnItemDBConn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "15");
        }


        private void barBtnItemDBCon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "14");
        }

        private void barBtnItemYieldNorm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YieldHistogramForm vYieldHistogramForm = new YieldHistogramForm();
            vYieldHistogramForm.ShowDialog();
        }

        private void barBtnItemGPRHZLPJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SpecQuaAssForm vSpecQuaAssForm = new SpecQuaAssForm();
            vSpecQuaAssForm.ShowDialog();
        }

        private void barBtnItemSHRHZLPJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TSQuaAssForm vTSQuaAssForm = new TSQuaAssForm();
            vTSQuaAssForm.ShowDialog();
        }

        private void barBtnItemNDSI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NDSI_Form vNDSI_Form = new NDSI_Form();
            vNDSI_Form.ShowDialog();
        }

        private void barBtnItemThreshold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClassifyForm vClassifyForm = new ClassifyForm();
            vClassifyForm.ShowDialog();
        }

        private void barBtnItemWDLChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "24");
        }

        private void barBtnItemVICal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "20");
        }

        private void barBtnItemVIStatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "21");
        }

        private void barBtnItemChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "22");
        }

        private void barBtnItemMutiChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
            Process.Start(sExePath, "23");
        }


    }
}