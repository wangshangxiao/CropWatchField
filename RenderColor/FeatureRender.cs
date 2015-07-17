using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;

namespace CropWatchField
{
    public interface IFeatureRender
    {
        void LayerRender();
    }


    public class SingleRender : RenderFactory, IFeatureRender
    {
        IColor color;
        string fieldName;
        IFeatureLayer featLayer;
        public SingleRender(string fieldname, IColor color, IFeatureLayer layer)
        {
            fieldName = fieldname;
            this.color = color;
            featLayer = layer;
        }
        public void LayerRender()
        {
            try
            {
                IGeoFeatureLayer pGeoFeatureLayer = featLayer as IGeoFeatureLayer;
                IFeatureClass pFeatureClass = featLayer.FeatureClass;      //获取图层上的featureClass            
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                IUniqueValueRenderer pUniqueValueRenderer = new UniqueValueRendererClass();   //唯一值渲染器
                //设置渲染字段对象
                pUniqueValueRenderer.FieldCount = 1;
                pUniqueValueRenderer.set_Field(0, fieldName);
                ISimpleFillSymbol pSimFillSymbol = new SimpleFillSymbolClass();   //创建填充符号
                pUniqueValueRenderer.DefaultSymbol = (ISymbol)pSimFillSymbol;
                pUniqueValueRenderer.UseDefaultSymbol = false;
                int n = pFeatureClass.FeatureCount(null);
                for (int i = 0; i < n; i++)
                {
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    IClone pSourceClone = pSimFillSymbol as IClone;
                    ISimpleFillSymbol pSimpleFillSymbol = pSourceClone.Clone() as ISimpleFillSymbol;
                    string pFeatureValue = pFeature.get_Value(pFeature.Fields.FindField(fieldName)).ToString();
                    pUniqueValueRenderer.AddValue(pFeatureValue, "", (ISymbol)pSimpleFillSymbol);
                    if (pFeatureValue.Contains("."))
                    {
                        pUniqueValueRenderer.set_Label(pFeatureValue, pFeatureValue.Substring(0, pFeatureValue.IndexOf(".") + 4));
                    }
                    else
                    {
                        pUniqueValueRenderer.set_Label(pFeatureValue, pFeatureValue);
                    }
                }

                //为每个符号设置颜色

                for (int i = 0; i <= pUniqueValueRenderer.ValueCount - 1; i++)
                {
                    string xv = pUniqueValueRenderer.get_Value(i);

                    if (xv != "")
                    {
                        ISimpleFillSymbol pNextSymbol = (ISimpleFillSymbol)pUniqueValueRenderer.get_Symbol(xv);
                        pNextSymbol.Color = color;
                        pUniqueValueRenderer.set_Symbol(xv, (ISymbol)pNextSymbol);
                    }
                }

                pGeoFeatureLayer.Renderer = (IFeatureRenderer)pUniqueValueRenderer;
                axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axtoccontrol.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

    public class OnlyRender : RenderFactory, IFeatureRender
    {
        IColorRamp colorRamp;
        string fieldName;
        IFeatureLayer featLayer;
        public OnlyRender(string fieldname, IColorRamp ramp, IFeatureLayer layer)
        {
            fieldName = fieldname;
            this.colorRamp = ramp;
            featLayer = layer;
        }
        public void LayerRender()
        {
            try
            {
                //IFeatureLayer pFeatureLayer = featLayer;
                IGeoFeatureLayer pGeoFeatureLayer = featLayer as IGeoFeatureLayer;
                IFeatureClass pFeatureClass = featLayer.FeatureClass;      //获取图层上的featureClass            
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                IUniqueValueRenderer pUniqueValueRenderer = new UniqueValueRendererClass();   //唯一值渲染器
                //设置渲染字段对象
                pUniqueValueRenderer.FieldCount = 1;
                pUniqueValueRenderer.set_Field(0, fieldName);
                ISimpleFillSymbol pSimFillSymbol = new SimpleFillSymbolClass();   //创建填充符号
                pUniqueValueRenderer.DefaultSymbol = (ISymbol)pSimFillSymbol;
                pUniqueValueRenderer.UseDefaultSymbol = false;
                int n = pFeatureClass.FeatureCount(null);
                for (int i = 0; i < n; i++)
                {
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    IClone pSourceClone = pSimFillSymbol as IClone;
                    ISimpleFillSymbol pSimpleFillSymbol = pSourceClone.Clone() as ISimpleFillSymbol;
                    string pFeatureValue = pFeature.get_Value(pFeature.Fields.FindField(fieldName)).ToString();
                    pUniqueValueRenderer.AddValue(pFeatureValue, "", (ISymbol)pSimpleFillSymbol);

                }

                //为每个符号设置颜色

                for (int i = 0; i <= pUniqueValueRenderer.ValueCount - 1; i++)
                {
                    string xv = pUniqueValueRenderer.get_Value(i);

                    if (xv != "")
                    {
                        ISimpleFillSymbol pNextSymbol = (ISimpleFillSymbol)pUniqueValueRenderer.get_Symbol(xv);
                        pNextSymbol.Color = colorRamp.get_Color(i * (colorRamp.Size / pUniqueValueRenderer.ValueCount));
                        pUniqueValueRenderer.set_Symbol(xv, (ISymbol)pNextSymbol);
                        if (xv.Contains("."))
                        {
                            pUniqueValueRenderer.set_Label(xv, xv.Substring(0, xv.IndexOf(".") + 4));
                        }
                        else
                        {
                            pUniqueValueRenderer.set_Label(xv, xv);
                        }
                    }
                }

                pGeoFeatureLayer.Renderer = (IFeatureRenderer)pUniqueValueRenderer;
                axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axtoccontrol.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

    public class ClassifyRender : RenderFactory, IFeatureRender
    {
        IColorRamp ramp;
        string FiledName;
        int count;
        IFeatureLayer Layer;
        string classname;
        public ClassifyRender(IFeatureLayer Layer, string FiledName, IColorRamp ramp, int count,string classname)
        {
            this.Layer = Layer;
            this.FiledName = FiledName;
            this.ramp = ramp;
            this.count = count;
            this.classname = classname;
        }
        public void LayerRender()
        {
            try
            {
                //值分级
                IBasicHistogram pBasicHis = new BasicTableHistogramClass();
                ITableHistogram pTabHis = (ITableHistogram)pBasicHis;
                IClassifyGEN pClassify=null;
                switch (classname)
                { 
                   case "自然断点分级":
                        pClassify= new NaturalBreaksClass();
                        break;
                    case "等间距分级":
                        pClassify = new EqualIntervalClass();
                        break;
                }
                pTabHis.Field = FiledName;
                //IGeoFeatureLayer geolayer = (IGeoFeatureLayer)Layer;
                ITable pTab = (ITable)Layer;
                pTabHis.Table = pTab;
                object doubleArrVal, longArrFreq;
                pBasicHis.GetHistogram(out doubleArrVal, out longArrFreq);

                int nDes = count;
                pClassify.Classify(doubleArrVal, longArrFreq, ref nDes);
                object classes = pClassify.ClassBreaks;
                double[] ClassNum;
                ClassNum = (double[])pClassify.ClassBreaks;
                int ClassCountResult = ClassNum.GetUpperBound(0);
                IClassBreaksRenderer pRender = new ClassBreaksRendererClass();
                pRender.BreakCount = ClassCountResult;
                pRender.Field = FiledName;
                ISimpleFillSymbol pSym;
                IColor pColor;
                for (int j = 0; j < ClassCountResult; j++)
                {
                    pColor = ramp.get_Color(j * (ramp.Size / ClassCountResult));
                    pSym = new SimpleFillSymbolClass();
                    pSym.Color = pColor;
                    pRender.set_Symbol(j, (ISymbol)pSym);
                    pRender.set_Break(j, ClassNum[j + 1]);
                    if (ClassNum[j].ToString().Contains("."))
                    {
                        pRender.set_Label(j, ClassNum[j].ToString("0.000") + " - " + ClassNum[j + 1].ToString("0.000"));
                    }
                    else
                    {
                        pRender.set_Label(j, ClassNum[j].ToString() + " - " + ClassNum[j + 1].ToString());
                    }
                    }

                IGeoFeatureLayer pGeoLyr = (IGeoFeatureLayer)Layer;
                pGeoLyr.Renderer = (IFeatureRenderer)pRender;
                axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axtoccontrol.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

    public class PropertonalRender : RenderFactory, IFeatureRender
    {
        string fieldName;
        IColor color;
        IFeatureLayer featLayer;
        int size;
        public PropertonalRender(string fieldname, IColor color, IFeatureLayer layer, int x)
        {
            fieldName = fieldname;
            this.color = color;
            featLayer = layer;
            size = x;
        }
        public void LayerRender()
        {
            try
            {
                IProportionalSymbolRenderer psrender = new ProportionalSymbolRendererClass();
                psrender.Field = fieldName;
                psrender.ValueUnit = esriUnits.esriUnknownUnits;
                psrender.ValueRepresentation = esriValueRepresentations.esriValueRepUnknown;
                //选择渲染的样式，与颜色 minsymbol为比填内容，否则没有效果
                ISimpleMarkerSymbol markersym = new SimpleMarkerSymbol();
                markersym.Size = size;
                markersym.Style = esriSimpleMarkerStyle.esriSMSCircle;
                markersym.Color = color;
                psrender.MinSymbol = markersym as ISymbol;
                //IFeatureLayer featLayer = featLayer;
                IGeoFeatureLayer geofeat = featLayer as IGeoFeatureLayer;
                ICursor cursor = ((ITable)featLayer).Search(null, true);
                IDataStatistics datastat = new DataStatisticsClass();
                datastat.Cursor = cursor;
                datastat.Field = fieldName;//千万不能忽视
                psrender.MinDataValue = datastat.Statistics.Minimum;
                psrender.MaxDataValue = datastat.Statistics.Maximum;
                ////设置background的样式
                IFillSymbol fillsym = new SimpleFillSymbolClass();
                fillsym.Color = getcolor(201, 201, 251);
                ILineSymbol linesym = new SimpleLineSymbolClass();
                linesym.Width = 1;
                fillsym.Outline = linesym;
                psrender.BackgroundSymbol = fillsym;
                psrender.LegendSymbolCount = 5;//legend的数量
                psrender.CreateLegendSymbols();//创建TOC的legend
                geofeat.Renderer = (IFeatureRenderer)psrender;
                axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axtoccontrol.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }

    public class RenderFactory
    {
        public AxMapControl axmapcontrol;
        public AxTOCControl axtoccontrol;
        public IRgbColor getcolor(int r, int g, int b)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = r;
            color.Green = g;
            color.Blue = b;
            return color;
        }

        public static List<string> GetFieldList1(IFeatureLayer featLayer)
        {
            List<string> fieldlist = new List<string>();
            IFields fields = featLayer.FeatureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if (fields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry && fields.get_Field(i).Type != esriFieldType.esriFieldTypeOID && fields.get_Field(i).Type != esriFieldType.esriFieldTypeGlobalID)
                {
                    fieldlist.Add(fields.get_Field(i).Name.Trim());
                }
            }
            return fieldlist;
        }
        public static List<string> GetFieldList2(IFeatureLayer featLayer)
        {
            List<string> fieldlist = new List<string>();
            IFields fields = featLayer.FeatureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if (fields.get_Field(i).Type == esriFieldType.esriFieldTypeDouble || fields.get_Field(i).Type == esriFieldType.esriFieldTypeInteger || fields.get_Field(i).Type == esriFieldType.esriFieldTypeSingle || fields.get_Field(i).Type == esriFieldType.esriFieldTypeSmallInteger && fields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry && fields.get_Field(i).Type != esriFieldType.esriFieldTypeGUID)
                {
                    fieldlist.Add(fields.get_Field(i).Name.Trim());
                }
            }
            return fieldlist;
        }
    }

}
