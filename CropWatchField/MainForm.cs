using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;

namespace CropWatchField
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
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

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        /// <summary>
        /// 数据库连接界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDBConnSet_Click(object sender, EventArgs e)
        {
            DBConnectForm dBConnectForm = new DBConnectForm();
            dBConnectForm.Show();
        }

        #region ProprecessMenuEnvet
        
        /// <summary>
        /// 影像拼接界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMoasic_Click(object sender, EventArgs e)
        {
            ImageMosaicForm imageMosaicForm = new ImageMosaicForm();
            imageMosaicForm.Show();
        }

        /// <summary>
        /// 影像裁剪界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuClip_Click(object sender, EventArgs e)
        {
            ImageClipForm imageClipForm = new ImageClipForm();
            imageClipForm.Show();
        }

        /// <summary>
        /// 投影转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuProjTrans_Click(object sender, EventArgs e)
        {
            ProJTransferForm proJTransferForm = new ProJTransferForm();
            proJTransferForm.Show();
        }

        /// <summary>
        /// 格式转换界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFormatConvert_Click(object sender, EventArgs e)
        {
            FormatConvertForm formatConvertForm = new FormatConvertForm();
            formatConvertForm.Show();
        }

       /// <summary>
       /// 几何纠正-环境星
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void menuGeoHJ_Click(object sender, EventArgs e)
        {
            HJAutoCorrectForm geoCorrectForm = new HJAutoCorrectForm();
            geoCorrectForm.Show();
        }
        /// <summary>
        /// 几何纠正-风云
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuGeoFY_Click(object sender, EventArgs e)
        {
            HJAutoCorrectForm geoCorrectForm = new HJAutoCorrectForm();
            geoCorrectForm.Show();
        }

        /// <summary>
        /// 辐射标定界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuRadioCalibHJ_Click(object sender, EventArgs e)
        {
            RadioCalibrationForm radioCalibrationForm = new RadioCalibrationForm();
            radioCalibrationForm.Show();
        }

       

        #endregion

        /// <summary>
        /// 关于系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }


        #region 图层操作

        private ILayer TOCRightLayer;
        esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
        IBasicMap basicMap = null;
        ILayer layer = null;
        object unk = null;
        object data = null;
        /// <summary>
        /// 图层列表点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //else if (e.button == 1)
            //{
                //System.Drawing.Point pos = new System.Drawing.Point(e.x, e.y);
                //if (itemType == esriTOCControlItem.esriTOCControlItemLegendClass)
                //{
                //    //取得图例
                //    ILegendClass pLegendClass = ((ILegendGroup)unk).get_Class((int)data);
                //    //创建符号选择器SymbolSelector实例
                //    SymbolSelectorForm SymbolSelectorFrm = new SymbolSelectorForm(pLegendClass, layer);
                //    if (SymbolSelectorFrm.ShowDialog() == DialogResult.OK)
                //    {
                //        //局部更新主Map控件
                //        this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                //        //this.axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                //        //设置新的符号
                //        pLegendClass.Symbol = SymbolSelectorFrm.pSymbol;
                //        //更新主Map控件和图层控件
                //        this.axMapControl1.ActiveView.Refresh();
                //        //this.axMapControl2.ActiveView.Refresh();
                //        this.axTOCControl1.Refresh();
                //    }
                //}
            //}

            //只有英文版本的engine才可以打开颜色选取
            //if (e.button == 1)
            //{
            //    switch (itemType)
            //    {
            //        case esriTOCControlItem.esriTOCControlItemLegendClass:
            //            ILegendClass pLegendClass = ((ILegendGroup)unk).get_Class((int)data);
            //            SymbolSelectorForm newSymbolSelectorFrm = new SymbolSelectorForm(pLegendClass, layer);
            //            if (newSymbolSelectorFrm.ShowDialog() == DialogResult.OK)
            //            {
            //                this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            //                pLegendClass.Symbol = newSymbolSelectorFrm.pSymbol;
            //                this.axTOCControl1.Update();
            //            }
            //            break;
            //    }
            //}
        }


        private void ctMenuTFRemove_Click(object sender, EventArgs e)
        {
            this.axMapControl1.Map.DeleteLayer(this.TOCRightLayer);
            this.axTOCControl1.Update();
        }

        private void ctMenuTFZoomToLayer_Click(object sender, EventArgs e)
        {
            IFeatureClass pFeatureClass = ((IFeatureLayer)this.TOCRightLayer).FeatureClass;
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            this.axMapControl1.Extent = pGeoDataset.Extent;
            this.axMapControl1.Refresh();
        }

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

        private void ctMenuTFProperties_Click(object sender, EventArgs e)
        {
            frmAttributeTable fmAttriTable = new frmAttributeTable(layer as IFeatureLayer, axMapControl1);
            fmAttriTable.Show();
        }


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

        #endregion

        private void contextMenuTOCFeatureLyr_Opening(object sender, CancelEventArgs e)
        {
            if (this.TOCRightLayer is IGeoFeatureLayer)
            {
                this.ctMenuTFProperties.Enabled = true;
            }
            else
            {
                this.ctMenuTFProperties.Enabled = false;
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

            #region 调用ESRI自带的图层样式
            //if (e.button == 1)
            //{
            //    axTOCControl1.HitTest(e.x, e.y, ref item, ref pBasicMap, ref pLayer, ref other, ref index);
            //    System.Drawing.Point pos = new System.Drawing.Point(e.x, e.y);
            //    if (item == esriTOCControlItem.esriTOCControlItemLegendClass)
            //    {
            //        ILegendClass pLC = new LegendClassClass();
            //        ILegendGroup pLG = new LegendGroupClass();
            //        if (other is ILegendGroup)
            //        {
            //            pLG = (ILegendGroup)other;
            //        }
            //        pLC = pLG.get_Class((int)index);
            //        ISymbol pSym = pLC.Symbol;
            //        ISymbolSelector pSS = new SymbolSelectorClass();
            //        bool bOK = false;
            //        pSS.AddSymbol(pSym);
            //        bOK = pSS.SelectSymbol(0);
            //        if (bOK)
            //        {
            //            pLC.Symbol = pSS.GetSymbolAt(0);
            //        }
            //        this.axMapControl1.ActiveView.Refresh();
            //        //this.axMapControl2.ActiveView.Refresh();
            //        this.axTOCControl1.Refresh();
            //    }
            //} 
            #endregion

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
    }
}