using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;

namespace CropWatchField
{
    public partial class frmFeatureSym : DevExpress.XtraEditors.XtraForm
    {
        public IFeatureLayer Layer;
        ColorStyle style = new ColorStyle();
        List<IColorRamp> pListRamp = new List<IColorRamp>();
        List<IColor> pListColor = new List<IColor>();
        public AxMapControl axmapcontrol;
        public AxTOCControl axtoccontrol;

        public frmFeatureSym()
        {
            InitializeComponent();
        }

        public frmFeatureSym(IFeatureLayer featLayer, AxMapControl mapcontrol, AxTOCControl toccontrol)
        {
            InitializeComponent();
            this.Layer = featLayer;
            axmapcontrol = mapcontrol;
            axtoccontrol = toccontrol;
        }

        private void frmFeatureSym_Load(object sender, EventArgs e)
        {
            List<ComboBoxSym> list1 = new List<ComboBoxSym>();
            list1.Add(cmbSymPro);
            list1.Add(cmbSymSingle);
            style.Style("Colors", list1);
            List<ComboBoxSym> list2 = new List<ComboBoxSym>();
            list2.Add(cmbSymClassify);
            list2.Add(cmbSymOnly);
            style.Style("Color Ramps", list2);
            cmbSingleField.Properties.Items.AddRange(RenderFactory.GetFieldList1(this.Layer));
            cmbOnlyField.Properties.Items.AddRange(RenderFactory.GetFieldList1(this.Layer));
            cmbClassifyField.Properties.Items.AddRange(RenderFactory.GetFieldList2(this.Layer));
            cmbProField.Properties.Items.AddRange(RenderFactory.GetFieldList2(this.Layer));
            //分级渲染方法
            string[] itemname = new string[2] { "自然断点分级", "等间距分级" };
            cmbClassName.Properties.Items.AddRange(itemname);
            //分级渲染级数
            int[] items = new int[9] { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            cmbClassifyCount.Properties.Items.AddRange(items);
            //比例渲染大小
            int[] itemsize = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            cmbProSize.Properties.Items.AddRange(itemsize);

            cmbSymPro.SelectedIndex = 10;
            cmbSymSingle.SelectedIndex = 10;
            cmbSymClassify.SelectedIndex = 10;
            cmbSymOnly.SelectedIndex = 10;
            cmbClassName.SelectedIndex = 0;
            cmbClassifyCount.SelectedIndex = 3;
            cmbProSize.SelectedIndex = 3;
            cmbSingleField.SelectedIndex = 0;
            cmbOnlyField.SelectedIndex = 0;
            cmbClassifyField.SelectedIndex = 0;
            cmbProField.SelectedIndex = 0;
        }
        private void btnSingleOK_Click(object sender, EventArgs e)
        {
            IFeatureRender fRender;
            pListColor = style.pListColor;
            fRender = new SingleRender(cmbSingleField.SelectedItem.ToString(), (IColor)pListColor[cmbSymSingle.SelectedIndex], Layer);
            ((SingleRender)fRender).axmapcontrol = axmapcontrol;
            ((SingleRender)fRender).axtoccontrol = axtoccontrol;
            fRender.LayerRender();
            axmapcontrol.Extent = Layer.AreaOfInterest;

        }

        private void btnOnlyOK_Click(object sender, EventArgs e)
        {
            IFeatureRender fRender;
            pListRamp = style.pListRamp;
            fRender = new OnlyRender(cmbOnlyField.SelectedItem.ToString(), (IColorRamp)pListRamp[cmbSymOnly.SelectedIndex], Layer);
            ((OnlyRender)fRender).axmapcontrol = axmapcontrol;
            ((OnlyRender)fRender).axtoccontrol = axtoccontrol;
            fRender.LayerRender();
            axmapcontrol.Extent = Layer.AreaOfInterest;
        }

        private void btnClassifyOK_Click(object sender, EventArgs e)
        {
            IFeatureRender fRender;
            pListRamp = style.pListRamp;
            string classname = cmbClassName.SelectedItem.ToString();
            fRender = new ClassifyRender(Layer, cmbClassifyField.SelectedItem.ToString(), (IColorRamp)pListRamp[cmbSymClassify.SelectedIndex], Convert.ToInt32(cmbClassifyCount.SelectedItem.ToString()), classname);
            ((ClassifyRender)fRender).axmapcontrol = axmapcontrol;
            ((ClassifyRender)fRender).axtoccontrol = axtoccontrol;
            fRender.LayerRender();
            axmapcontrol.Extent = Layer.AreaOfInterest;
        }

        private void btnProOK_Click(object sender, EventArgs e)
        {
            IFeatureRender fRender;
            pListColor = style.pListColor;
            int size = Convert.ToInt32(cmbProSize.SelectedItem);
            fRender = new PropertonalRender(cmbProField.SelectedItem.ToString(), (IColor)pListColor[cmbSymPro.SelectedIndex], Layer, size);
            ((PropertonalRender)fRender).axmapcontrol = axmapcontrol;
            ((PropertonalRender)fRender).axtoccontrol = axtoccontrol;
            fRender.LayerRender();
            axmapcontrol.Extent = Layer.AreaOfInterest;
        }
    }
}