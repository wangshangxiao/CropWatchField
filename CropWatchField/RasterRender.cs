using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

namespace CropWatchField
{
    public class RasterRender
    {
        public static List<string> getBandName(IRasterLayer rasterlayer)
        {
            string fullpath = rasterlayer.FilePath;
            string filePath = System.IO.Path.GetDirectoryName(fullpath);
            string fileName = System.IO.Path.GetFileName(fullpath);
            IWorkspaceFactory wsf = new RasterWorkspaceFactoryClass();
            IWorkspace ws = wsf.OpenFromFile(filePath, 0);
            IRasterWorkspace rasterws = ws as IRasterWorkspace;
            IRasterDataset rastdataset = rasterws.OpenRasterDataset(fileName);
            IRasterBandCollection bandcoll = rastdataset as IRasterBandCollection;
            List<string> itemband = new List<string>();
            for (int i = 0; i < bandcoll.Count; i++)
            {
                itemband.Add(bandcoll.Item(i).Bandname);
            }
            return itemband;
        }

        public static IRgbColor GET(int red, int green, int blue)
        {
            IRgbColor RGB = new RgbColorClass();
            RGB.Red = red;
            RGB.Green = green;
            RGB.Blue = blue;
            return RGB;
        }

        public void RasterClassify(IRasterLayer rastlayer, string classMethod, int count, IColorRamp ramp)
        {
            IRasterBand band = GetBand(rastlayer);
            if (band.Histogram == null)
            {
                band.ComputeStatsAndHist();
            }
            IRasterClassifyColorRampRenderer rasClassifyRender = new RasterClassifyColorRampRendererClass();
            IRasterRenderer rasRender = rasClassifyRender as IRasterRenderer;
            rasRender.Raster = rastlayer.Raster;
            rasRender.Update();

            int numClasses = count;
            IRasterHistogram pRasterHistogram = band.Histogram;
            double[] dblValues = pRasterHistogram.Counts as double[];
            int intValueCount = dblValues.GetUpperBound(0) + 1;
            double[] vValues = new double[intValueCount];
            IRasterStatistics pRasterStatistic = band.Statistics;
            double dMaxValue = pRasterStatistic.Maximum;
            double dMinValue = pRasterStatistic.Minimum;
            if (dMinValue == 0)
            {
                pRasterStatistic.IgnoredValues = pRasterStatistic.Minimum;
                pRasterStatistic.Recalculate();
                dMinValue = pRasterStatistic.Minimum;
            }
            double BinInterval = Convert.ToDouble((dMaxValue - dMinValue) / intValueCount);
            for (int i = 0; i < intValueCount; i++)
            {
                vValues[i] = i * BinInterval + pRasterStatistic.Minimum;
            }
            long[] longvalues = new long[dblValues.Length];
            for (int i = 0; i <= dblValues.Length - 1; i++)
            {
                longvalues[i] = long.Parse(Convert.ToString(dblValues[i]));
            }
            //IClassifyGEN classify = null;
            IClassify classify = null;
            switch (classMethod)
            {
                case "等间距分级":
                    EqualInterval eqclassify = new EqualIntervalClass();
                    eqclassify.Classify(vValues, longvalues, ref numClasses);
                    classify = eqclassify as IClassify;
                    break;
                case "自然断点分级":
                    NaturalBreaks naclassify = new NaturalBreaksClass();
                    naclassify.Classify(vValues, longvalues, ref numClasses);
                    classify = naclassify as IClassify;
                    break;
            }
            //switch (classMethod)
            //{
            //    case "等间距分级":
            //        classify = new EqualIntervalClass();
            //        break;
            //    case "自然断点分级":
            //        classify = new NaturalBreaksClass();
            //        break;
            //}
            //classify.Classify(vValues, longvalues, ref numClasses);
            double[] Classes = classify.ClassBreaks as double[];
            UID pUid = classify.ClassID;
            IRasterClassifyUIProperties rasClassifyUI = rasClassifyRender as IRasterClassifyUIProperties;
            rasClassifyUI.ClassificationMethod = pUid;
            rasClassifyRender.ClassCount = count;
            IColor pColor;
            ISimpleFillSymbol pSym;
            for (int j = 0; j < count; j++)
            {
                IRasterProps rasterProps = (IRasterProps)rastlayer.Raster;
                rasterProps.NoDataValue = 0;
                pColor = ramp.get_Color(j * (ramp.Size / count));
                pSym = new SimpleFillSymbolClass();
                pSym.Color = pColor;
                rasClassifyRender.set_Symbol(j, (ISymbol)pSym);
                rasRender.Update();
                rasClassifyRender.set_Break(j,rasClassifyRender.get_Break(j));
                rasClassifyRender.set_Label(j, Classes[j].ToString("0.000") + "-" + Classes[j + 1].ToString("0.000"));
                rasRender.Update();
            }
            rastlayer.Renderer = rasClassifyRender as IRasterRenderer;

        }

        public IRasterBand GetBand(IRasterLayer rasterlayer)
        {
            string fullpath = rasterlayer.FilePath;
            string filePath = System.IO.Path.GetDirectoryName(fullpath);
            string fileName = System.IO.Path.GetFileName(fullpath);
            IWorkspaceFactory wsf = new RasterWorkspaceFactoryClass();
            IWorkspace ws = wsf.OpenFromFile(filePath, 0);
            IRasterWorkspace rasterws = ws as IRasterWorkspace;
            IRasterDataset rastdataset = rasterws.OpenRasterDataset(fileName);
            IRasterBandCollection bandcoll = rastdataset as IRasterBandCollection;
            return bandcoll.Item(0);
        }
    }
}
