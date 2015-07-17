using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Framework;

namespace CropWatchField
{
    public class AddMapSouround
    {
        //IEnvelope pEnv;
        //UID uid;
        //IMapFrame pMapFrame;
        //IMapSurroundFrame pMapSurroundFrame;
        //ITrackCancel pTrackCancel;
        ITextElement pTextElement;
        //ISymbologyStyleClass pSymbologyStyleClass;]
        //IStyleGalleryItem pStyleGalleryItem;
        AxPageLayoutControl mainPage;

        public AddMapSouround(AxPageLayoutControl  pagecontrol)
        {
            this.mainPage = pagecontrol;
        }

        /// <添加指北针>
        /// 
        /// </添加指北针>
        /// <returns></returns>
        public bool AddNorthArrow() 
        {

            IStyleSelector pStyleSelector = new NorthArrowSelectorClass();
            bool m_bOK = pStyleSelector.DoModal(0);
            if (m_bOK == true) 
            {
                IMarkerNorthArrow pMarkerNorthArrow = pStyleSelector.GetStyle(0) as IMarkerNorthArrow;

                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(0.2, 0.2, 5, 5);
                ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
                uid.Value = "esriCarto.MarkerNorthArrow";
                IMap pMap = mainPage.ActiveView.FocusMap;
                IGraphicsContainer graphicsContainer = mainPage.ActiveView as IGraphicsContainer;
                IActiveView activeView = mainPage.ActiveView as IActiveView;
                IFrameElement frameElement = graphicsContainer.FindFrame(pMap);
                IMapFrame mapFrame = frameElement as IMapFrame;
                IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null);
                IElement element = mapSurroundFrame as IElement;
                element.Geometry = envelope;
                element.Activate(activeView.ScreenDisplay);
                graphicsContainer.AddElement(element, 0);
                IMapSurround mapSurround = mapSurroundFrame.MapSurround;

                IMarkerNorthArrow markerNorthArrow = mapSurround as IMarkerNorthArrow;
                markerNorthArrow.MarkerSymbol = pMarkerNorthArrow.MarkerSymbol;
            }
            return true;
        }

        /// <summary>
        /// 文字比例尺
        /// </summary>
        /// <returns></returns>
        public bool AddTxtSacleBar() 
        {
            IStyleSelector pStyleSelector = new ScaleTextSelectorClass();
            bool m_bOK = pStyleSelector.DoModal(0);
            if (m_bOK == true)
            {
                IScaleText pScaleText = pStyleSelector.GetStyle(0) as IScaleText;

                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(0.2, 0.2, 5, 1);
                ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
                uid.Value = "esriCarto.Scaletext";
                IMap pMap = mainPage.ActiveView.FocusMap;
                IGraphicsContainer graphicsContainer = mainPage.ActiveView as IGraphicsContainer;
                IActiveView activeView = mainPage.ActiveView as IActiveView;
                IFrameElement frameElement = graphicsContainer.FindFrame(pMap);
                IMapFrame mapFrame = frameElement as IMapFrame;
                IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null);
                IMapSurround mapsurround = pScaleText as IMapSurround;
                mapSurroundFrame.MapSurround = mapsurround;
                IElement element = mapSurroundFrame as IElement;
                element.Geometry = envelope;
                element.Activate(activeView.ScreenDisplay);
                graphicsContainer.AddElement(element, 0);
                IMapSurround mapSurround = mapSurroundFrame.MapSurround;
            }
            return true;
        }

        /// <summary>
        /// 图形比例尺
        /// </summary>
        /// <returns></returns>
        public bool AddImgScaleBar() 
        {

            IStyleSelector pStyleSelector = new ScaleBarSelectorClass();
            bool m_bOK = pStyleSelector.DoModal(0);
            if (m_bOK == true)
            {
                IScaleBar pScaleBar = pStyleSelector.GetStyle(0) as IScaleBar;
                
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(0.2, 0.2, 5, 1);
                ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
                uid.Value = "esriCarto.Scalebar";
                IMap pMap = mainPage.ActiveView.FocusMap;
                IGraphicsContainer graphicsContainer = mainPage.ActiveView as IGraphicsContainer;
                IActiveView activeView = mainPage.ActiveView as IActiveView;
                IFrameElement frameElement = graphicsContainer.FindFrame(pMap);
                IMapFrame mapFrame = frameElement as IMapFrame;
                IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null);
                IMapSurround mapsurround = pScaleBar as IMapSurround;
                mapSurroundFrame.MapSurround = mapsurround;
                IElement element = mapSurroundFrame as IElement;
                element.Geometry = envelope;
                element.Activate(activeView.ScreenDisplay);
                graphicsContainer.AddElement(element, 0);
                IMapSurround mapSurround = mapSurroundFrame.MapSurround;
            }
            return true;
        }

        //添加文本
        public bool AddText() 
        {
            pTextElement = new TextElementClass();
            pTextElement.Text = "输入文本";

            IElement pElment = pTextElement as IElement;
            ITextSymbol pSymbol = new TextSymbolClass();
            pSymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
            stdole.Font pFont;
            pFont = new stdole.StdFontClass();
            pFont.Name = "verdana";
            pFont.Size = 40;
            pSymbol.Font = pFont as stdole.IFontDisp;
            pTextElement.Symbol = pSymbol;
            addText(pTextElement,null);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstvalue"></param>
        /// <param name="pageXPart">在X方向所在位置占整个page的比例比例</param>
        /// <param name="pageYPart">在Y方向所在位置占整个page的比例比例</param>
        /// <returns></returns>
        public bool AddText(List<string> lstvalue,double pageXPart,double pageYPart,string fountName,double fontSize) 
        {
            pTextElement = new TextElementClass();
            string sValue = lstvalue[0];
            for (int i = 1; i < lstvalue.Count;i++ )
            {
                sValue += "\n" + lstvalue[i];
            }
            pTextElement.Text = sValue;

            IElement pElment = pTextElement as IElement;
            ITextSymbol pSymbol = new TextSymbolClass();
            pSymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
            stdole.Font pFont;
            pFont = new stdole.StdFontClass();
            pFont.Name = fountName;
            pFont.Size =(decimal) fontSize;
            pSymbol.Font = pFont as stdole.IFontDisp;
            pTextElement.Symbol = pSymbol;
            IPoint pPoint = new PointClass();
            IEnvelope pEnv = new EnvelopeClass();
            pEnv = this.mainPage.ActiveView.Extent;

            pPoint.PutCoords((pEnv.XMin + pEnv.YMax) *pageXPart, (pEnv.YMin + pEnv.YMax) *pageYPart);

            addText(pTextElement, pPoint);
            return true;
        }

        private bool addText(ITextElement ppTextElement,IGeometry geo)
        {
            IPageLayout pPageLayout = mainPage.PageLayout;
            IGraphicsContainer pGraphicsContainer = mainPage.PageLayout as IGraphicsContainer;
            IEnvelope pEnv = new EnvelopeClass();
            IElement pElement= ppTextElement as IElement;
            
            pEnv = this.mainPage.ActiveView.Extent;

            if (geo == null)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords((pEnv.XMin + pEnv.YMax) / 2, (pEnv.YMin + pEnv.YMax) / 2);
                pElement.Geometry = pPoint;
            }
            else 
            {
                pElement.Geometry = geo;
            }

            pGraphicsContainer.AddElement(pElement, 0);
            mainPage.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            return true;
        }

        /// <summary>
        /// 改变要素属性
        /// </summary>
        /// <returns></returns>
        public bool ChangeElement(object sender, IPageLayoutControlEvents_OnDoubleClickEvent e) 
        {
            IGraphicsContainer pGraphicsCon;
            pGraphicsCon = this.mainPage.PageLayout as IGraphicsContainer;
            pGraphicsCon.Reset();
            IGraphicsContainerSelect pGraSelect = this.mainPage.PageLayout as IGraphicsContainerSelect;
            IElement pElement = pGraSelect.SelectedElement(0);
            IMapSurroundFrame pMapSurroundFrame = null;
            if(pElement is IMapSurroundFrame)
            {
                pMapSurroundFrame = pElement as IMapSurroundFrame;
            }
            IGeometry geo = pElement.Geometry;

            # region 文本
            if (pElement is ITextElement)
            {
                ITextElement txtEle = pElement as ITextElement;
                # region
                try
                {
                    IComPropertySheet PSheet = new ComPropertySheet();

                    PSheet.Title = "属性";
                    PSheet.HideHelpButton = true;
                    ESRI.ArcGIS.esriSystem.ISet PSet = new ESRI.ArcGIS.esriSystem.SetClass();

                    PSet.Add(txtEle);//这里加入MapControl当前选中的Layer, 也就是你要编辑属性的图层

                    IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.TextElementPropertyPageClass();
                    IPropertyPage page2 = new ESRI.ArcGIS.CartoUI.SizeAndPositionPropertyPageClass();
                    PSheet.AddPage(pGenPage);
                    PSheet.AddPage(page2);

                    PSheet.AddCategoryID(new UIDClass() as UID);
                    PSheet.ActivePage = 0;
                    PSheet.Title = "属性设置";
                    if (PSheet.EditProperties(PSet, 0))
                    {
                        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                    }
                }
                catch 
                {
                    //MessageBox.Show(err.ToString());
                }
                # endregion

            }
            # endregion
            # region 图形
            else if (pElement is IFillShapeElement)
            {
                try
                {
                    IComPropertySheet PSheet = new ComPropertySheet();

                    PSheet.Title = "属性";
                    PSheet.HideHelpButton = true;
                    ESRI.ArcGIS.esriSystem.ISet PSet = new ESRI.ArcGIS.esriSystem.SetClass();

                    PSet.Add(pElement);//这里加入MapControl当前选中的Layer, 也就是你要编辑属性的图层

                    IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.FillShapeElementPropertyPageClass();
                    IPropertyPage page2 = new ESRI.ArcGIS.CartoUI.SizeAndPositionPropertyPageClass();
                    PSheet.AddPage(pGenPage);
                    PSheet.AddPage(page2);

                    PSheet.AddCategoryID(new UIDClass() as UID);
                    PSheet.ActivePage = 0;
                    PSheet.Title = "属性设置";
                    if (PSheet.EditProperties(PSet, 0))
                    {
                        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                    }
                }
                catch
                {
                    //MessageBox.Show(err.ToString());
                }
            }
            # endregion
            # region 比例尺
            else if (pMapSurroundFrame.MapSurround is IScaleBar)
            {
                try
                {
                    IComPropertySheet PSheet = new ComPropertySheet();

                    PSheet.Title = "属性";
                    PSheet.HideHelpButton = true;
                    ESRI.ArcGIS.esriSystem.ISet PSet = new ESRI.ArcGIS.esriSystem.SetClass();

                    PSet.Add(pMapSurroundFrame);//这里加入MapControl当前选中的Layer, 也就是你要编辑属性的图层

                    IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.ScaleBarFormatPropertyPageClass();
                    IPropertyPage page3 = new ESRI.ArcGIS.CartoUI.ScaleBarScalePropertyPageClass();
                    PSheet.AddPage(pGenPage);
                    PSheet.AddPage(page3);
                    PSheet.AddCategoryID(new UIDClass() as UID);
                    PSheet.ActivePage = 0;
                    PSheet.Title = "属性设置";
                    if (PSheet.EditProperties(PSet, 0))
                    {
                        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                    }
                }
                catch 
                {
                    //MessageBox.Show(err.ToString());
                }

                //AddChangedElement(3, pElement);
            }
            else if (pMapSurroundFrame.MapSurround is IScaleText) 
            {
                try
                {
                    IComPropertySheet PSheet = new ComPropertySheet();

                    PSheet.HideHelpButton = true;
                    ESRI.ArcGIS.esriSystem.ISet PSet = new ESRI.ArcGIS.esriSystem.SetClass();

                    PSet.Add(pMapSurroundFrame);//这里加入MapControl当前选中的Layer, 也就是你要编辑属性的图层

                    IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.ScaleTextElementPropertyPageClass();
                    IPropertyPage page2 = new ESRI.ArcGIS.CartoUI.ScaleTextPropertyPageClass();
                    PSheet.AddPage(pGenPage);
                    PSheet.AddPage(page2);
                    PSheet.AddCategoryID(new UIDClass() as UID);
                    PSheet.ActivePage = 0;
                    PSheet.Title = "属性设置";
                    if (PSheet.EditProperties(PSet, 0))
                    {
                        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                    }
                }
                catch
                {
                    //MessageBox.Show(err.ToString());
                }
                //AddChangedElement(2,pElement);
            }
            # endregion

            # region 指北针
            else if (pMapSurroundFrame.MapSurround is INorthArrow)
            {
                try
                {
                    IComPropertySheet PSheet = new ComPropertySheet();

                    PSheet.HideHelpButton = true;
                    ESRI.ArcGIS.esriSystem.ISet PSet = new ESRI.ArcGIS.esriSystem.SetClass();

                    PSet.Add(pMapSurroundFrame);//这里加入MapControl当前选中的Layer, 也就是你要编辑属性的图层

                    IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.NorthArrowElementPropertyPageClass();
                    IPropertyPage page2 = new ESRI.ArcGIS.CartoUI.FramePropertyPageClass();
                    IPropertyPage page3 = new ESRI.ArcGIS.CartoUI.SizeAndPositionPropertyPageClass();
                    PSheet.AddPage(pGenPage);
                    PSheet.AddPage(page2);

                    PSheet.AddCategoryID(new UIDClass() as UID);
                    PSheet.ActivePage = 0;
                    PSheet.Title = "属性设置";
                    if (PSheet.EditProperties(PSet, 0))
                    {
                        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                    }
                }
                catch
                {
                    //MessageBox.Show(err.ToString());
                }
            }
            # endregion
            else if (pMapSurroundFrame.MapSurround is ILegend)
            {
                ILegend legend = pMapSurroundFrame.MapSurround as ILegend;
                # region
                try
                {
                    IComPropertySheet PSheet = new ComPropertySheet();

                    PSheet.Title = "属性";
                    PSheet.HideHelpButton = true;
                    ESRI.ArcGIS.esriSystem.ISet PSet = new ESRI.ArcGIS.esriSystem.SetClass();

                    PSet.Add(pMapSurroundFrame);//这里加入MapControl当前选中的Layer, 也就是你要编辑属性的图层
                    IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.LegendElementItemsPropertyPageClass();
                    IPropertyPage page2 = new ESRI.ArcGIS.CartoUI.LegendElementPropertyPageClass();
                    IPropertyPage page4 = new ESRI.ArcGIS.CartoUI.FramePropertyPageClass();
                    PSheet.AddPage(pGenPage);
                    PSheet.AddPage(page2);
                    PSheet.AddPage(page4);
                    PSheet.AddCategoryID(new UIDClass() as UID);
                    PSheet.ActivePage = 0;
                    PSheet.Title = "属性设置";
                    if (PSheet.EditProperties(PSet, 0))
                    {
                        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
                    }
                }
                catch
                {
                    //MessageBox.Show(err.ToString());
                }
                # endregion
            }

            this.mainPage.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,null,null);



            return true;
        }

        ////地图边框
        //public bool AddFrame() 
        //{
        //    int i = 4;
        //    frmSymbol frm = new frmSymbol(i);
        //    frm.ShowDialog();
        //    if (frm.IsOK == true)
        //    {
        //        IStyleGalleryItem styleGalleryItem = frm.sytl;
        //        //frm.Dispose();
        //        IFrameProperties frameProperties = (IFrameProperties)mainPage.GraphicsContainer.FindFrame(mainPage.ActiveView.FocusMap);
        //        if (styleGalleryItem == null) return false;
        //        frameProperties.Border = (IBorder)styleGalleryItem.Item;
        //        mainPage.Refresh(esriViewDrawPhase.esriViewBackground, null, null);
        //    }
        //    return true;
        //}

        /// <summary>
        /// 图例
        /// </summary>
        /// <returns></returns>
        public bool AddLegend()
        {
            # region
            IGraphicsContainer pGraphicsContainer;
            pGraphicsContainer = mainPage.PageLayout as IGraphicsContainer;
            IMapFrame pFocusMapFrame;
            pFocusMapFrame = pGraphicsContainer.FindFrame(mainPage.ActiveView.FocusMap) as IMapFrame;
            UID u = new UIDClass();
            u.Value = "esriCarto.Legend";
            IMapSurroundFrame pLegendFrame;
            pLegendFrame = pFocusMapFrame.CreateSurroundFrame(u, null);
            IEnvelope pEnvelope;
            pEnvelope = new EnvelopeClass();
            pEnvelope.PutCoords(3, 3, 6, 8);
            IElement pElement;
            pElement = pLegendFrame as IElement;
            pElement.Geometry = pEnvelope;
            ILegendWizard pLegendWizard;
            pLegendWizard = new LegendWizardClass();
            pLegendWizard.PageLayout = mainPage.PageLayout;
            pLegendWizard.InitialLegendFrame = pLegendFrame;
            bool bOk = pLegendWizard.DoModal(mainPage.hWnd);
            if (bOk == true)
            {
                IElement ele = pLegendWizard.LegendFrame as IElement;
                pGraphicsContainer.AddElement(ele, 0);
                mainPage.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,null,null);
            }
            return true;
            # endregion
        }

        ///// <summary>
        ///// 修改要素
        ///// </summary>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //private bool AddChangedElement(int index,IElement originElement)
        //{
        //    IGeometry geo = originElement.Geometry;
        //    //frmSymbol frm = new frmSymbol(index);
        //    frm.ShowDialog();
        //    if (frm.IsOK == true)
        //    {
        //        IStyleGalleryItem styleGalleryItem = frm.sytl;

        //        if (styleGalleryItem == null)
        //            return false;

        //        //Get the map frame of the focus map
        //        IMapFrame mapFrame = (IMapFrame)mainPage.ActiveView.GraphicsContainer.FindFrame(mainPage.ActiveView.FocusMap);

        //        //Create a map surround frame
        //        IMapSurroundFrame mapSurroundFrame = new MapSurroundFrameClass();
        //        //Set its map frame and map surround
        //        mapSurroundFrame.MapFrame = mapFrame;
        //        mapSurroundFrame.MapSurround = (IMapSurround)styleGalleryItem.Item;

        //        //QI to IElement and set its geometry
        //        IElement element = (IElement)mapSurroundFrame;
        //        element.Geometry = geo;

        //        //Add the element to the graphics container
        //        mainPage.ActiveView.GraphicsContainer.AddElement(element, 0);
        //        //Refresh
        //        mainPage.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, mapSurroundFrame, null);
        //        IGraphicsContainer pGraphicsCon = mainPage.PageLayout as IGraphicsContainer;
        //        pGraphicsCon.DeleteElement(originElement);
        //        return true;
        //    }
        //    else 
        //    {
        //        return false;
        //    }
        //}


    }
}
