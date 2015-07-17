using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.esriSystem;

namespace CropWatchField
{

    public class AddMapSouround
    {
        ITextElement pTextElement;
        AxPageLayoutControl mainPage;

        public AddMapSouround(AxPageLayoutControl pagecontrol)
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
            addText(pTextElement, null);
            return true;
        }

        private bool addText(ITextElement ppTextElement, IGeometry geo)
        {
            IPageLayout pPageLayout = mainPage.PageLayout;
            IGraphicsContainer pGraphicsContainer = mainPage.PageLayout as IGraphicsContainer;
            IEnvelope pEnv = new EnvelopeClass();
            IElement pElement = ppTextElement as IElement;

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
        /// 图例
        /// </summary>
        /// <returns></returns>
        public bool AddLegend()
        {
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
            pLegendWizard = new LegendWizard();
            pLegendWizard.PageLayout = mainPage.PageLayout;
            pLegendWizard.InitialLegendFrame = pLegendFrame;
            bool bOk = pLegendWizard.DoModal(mainPage.hWnd);
            if (bOk == true)
            {
                IElement ele = pLegendWizard.LegendFrame as IElement;
                pGraphicsContainer.AddElement(ele, 0);
                mainPage.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            return true;
        }

    }
}
