using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using RenderColor;

namespace CropWatchField
{
    public partial class frmRasterSym : DevExpress.XtraEditors.XtraForm
    {
        public IRasterLayer rasterlayer;
        ColorStyle style = new ColorStyle();
        List<IColorRamp> pListRamp = new List<IColorRamp>();
        public AxMapControl axmapcontrol;
        public AxTOCControl axtoccontrol;
        string[] classmethod = new string[] { "自然断点分级","等间距分级"};
        int[] classcount = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        public frmRasterSym()
        {
            InitializeComponent();
        }

        public frmRasterSym(IRasterLayer rasLayer, AxMapControl mapcontrol, AxTOCControl toccontrol)
        {
            InitializeComponent();
            this.rasterlayer = rasLayer;
            axmapcontrol = mapcontrol;
            axtoccontrol = toccontrol;
        }

        private void frmRasterSym_Load(object sender, EventArgs e)
        {
            cmbBand.Properties.Items.AddRange(RasterRender.getBandName(rasterlayer));
            List<ComboBoxSym> list3 = new List<ComboBoxSym>();
            list3.Add(cmbsymRaster);
            list3.Add(comboBoxSym1);
            style.Style("Color Ramps", list3);
            List<ComboBoxSym> list4 = new List<ComboBoxSym>();
            list4.Add(cmbSymClassify);
            list4.Add(comboBoxSym2);
            style.Style("Color Ramps", list4);
            cmbClassifyCount.Properties.Items.AddRange(classcount);
            cmbClassifyMethod.Properties.Items.AddRange(classmethod);
            cmbsymRaster.SelectedIndex = 0;
            cmbSymClassify.SelectedIndex = 0;
            cmbClassifyMethod.SelectedIndex = 0;
            cmbClassifyCount.SelectedIndex = 3;
            cmbBand.SelectedIndex = 0;
        }

        private void btnRasterOK_Click(object sender, EventArgs e)
        {
            try
            {
                RasterRender render = new RasterRender();
                pListRamp = style.pListRamp;
                render.RasterClassify(rasterlayer, cmbClassifyMethod.SelectedItem.ToString(), Convert.ToInt32(cmbClassifyCount.SelectedItem), (IColorRamp)pListRamp[cmbSymClassify.SelectedIndex]);
                //axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axmapcontrol.Refresh();
                axtoccontrol.Update();
                axmapcontrol.Extent = rasterlayer.AreaOfInterest;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnRasterOK_Click_1(object sender, EventArgs e)
        {
            try
            {
                IRasterStretchColorRampRenderer rasStreRen = new RasterStretchColorRampRendererClass();
                IRasterRenderer rasRen = rasStreRen as IRasterRenderer;
                rasRen.Raster = rasterlayer.Raster;
                rasRen.Update();
                rasStreRen.BandIndex = cmbBand.SelectedIndex;
                pListRamp = style.pListRamp;
                rasStreRen.ColorRamp = (IColorRamp)pListRamp[cmbsymRaster.SelectedIndex];
                rasRen.Update();
                rasterlayer.Renderer = rasStreRen as IRasterRenderer;
                IRasterStretch2 stretch = rasStreRen as IRasterStretch2;
                stretch.BackgroundValue = 0;
                stretch.Background = true;
                stretch.BackgroundColor = RasterRender.GET(255, 255, 255) as IColor;
                //axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axmapcontrol.Refresh();
                axtoccontrol.Update();
                axmapcontrol.Extent = rasterlayer.AreaOfInterest;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}