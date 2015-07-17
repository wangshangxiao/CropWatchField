using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using RenderColor;

namespace CropWatchField
{
    public partial class frmRaterSym1 : Form
    {

        public IRasterLayer rasterlayer;
        ColorStyle style = new ColorStyle();
        List<IColorRamp> pListRamp = new List<IColorRamp>();
        public AxMapControl axmapcontrol;
        public AxTOCControl axtoccontrol;
        string[] classmethod = new string[] { "等间距分级", "自然断点分级" };
        int[] classcount = new int[] {2,3,4,5,6,7,8,9,10,11,12,13,14,15 };

        public frmRaterSym1()
        {
            InitializeComponent();
        }
        public frmRaterSym1(IRasterLayer rasLayer, AxMapControl mapcontrol, AxTOCControl toccontrol)
        {
            InitializeComponent();
            this.rasterlayer = rasLayer;
            axmapcontrol = mapcontrol;
            axtoccontrol = toccontrol;
        }

        private void btnRasterOK_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
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
                        axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                        axtoccontrol.Update();
                        axmapcontrol.Extent = rasterlayer.AreaOfInterest;
                        this.Close();
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show(ec.Message);
                    }
                    break;
                case 1:
                     RasterRender render = new RasterRender();
                     pListRamp = style.pListRamp;
                     render.RasterClassify(rasterlayer, cmbClassifyMethod.SelectedValue.ToString(), Convert.ToInt32(cmbClassifyCount.SelectedValue), (IColorRamp)pListRamp[cmbSymClassify.SelectedIndex]);
                     axmapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                     axtoccontrol.Update();
                     axmapcontrol.Extent = rasterlayer.AreaOfInterest;
                    break;

            }
        }

        private void frmRaterSym_Load(object sender, EventArgs e)
        {
            cmbBand.DataSource = RasterRender.getBandName(rasterlayer);
            List<ComboBoxSym> list3 = new List<ComboBoxSym>();
            list3.Add(cmbsymRaster);
            list3.Add(comboBoxSym1);
            style.Style("Color Ramps", list3);
            List<ComboBoxSym> list4 = new List<ComboBoxSym>();
            list4.Add(cmbSymClassify);
            list4.Add(comboBoxSym2);
            style.Style("Color Ramps", list4);
            cmbClassifyCount.DataSource = classcount;
            cmbClassifyMethod.DataSource = classmethod;
            cmbsymRaster.SelectedIndex = 0;
            cmbSymClassify.SelectedIndex = 0;
            cmbClassifyMethod.SelectedIndex = 0;
            cmbClassifyCount.SelectedIndex = 0;
        }


    }
}
