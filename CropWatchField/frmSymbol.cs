using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;

namespace CropWatchField
{
    public partial class frmSymbol : Form
    {
        public IFeatureLayer Layer;
        ColorStyle style = new ColorStyle();
        List<IColorRamp> pListRamp = new List<IColorRamp>();
        List<IColor> pListColor = new List<IColor>();
        public AxMapControl axmapcontrol;
        public AxTOCControl axtoccontrol;

        public frmSymbol()
        {
            InitializeComponent();
        }
        public frmSymbol(IFeatureLayer featLayer,AxMapControl mapcontrol,AxTOCControl toccontrol)
        {
            InitializeComponent();
            this.Layer = featLayer;
            axmapcontrol = mapcontrol;
            axtoccontrol = toccontrol;
        }
       
        private void btnSingleOK_Click(object sender, EventArgs e)
        {
            string name = xtraTabControl.SelectedTabPage.Name;
            IFeatureRender fRender;
            switch (name)
            {
                case "xtraTabSingle":
                     pListColor = style.pListColor;
                     fRender = new SingleRender(cmbSingleField.SelectedValue.ToString(), (IColor)pListColor[cmbSymSingle.SelectedIndex], Layer);
                     ((SingleRender)fRender).axmapcontrol = axmapcontrol;
                     ((SingleRender)fRender).axtoccontrol = axtoccontrol;
                     fRender.LayerRender();
                     axmapcontrol.Extent = Layer.AreaOfInterest;
                     break;
                case "xtraTabUnique":
                    pListRamp = style.pListRamp;
                    fRender = new OnlyRender(cmbOnlyField.SelectedValue.ToString(),(IColorRamp)pListRamp[cmbSymOnly.SelectedIndex],Layer);
                    ((OnlyRender)fRender).axmapcontrol = axmapcontrol;
                    ((OnlyRender)fRender).axtoccontrol = axtoccontrol;
                    fRender.LayerRender();
                    axmapcontrol.Extent = Layer.AreaOfInterest;
                    break;
                case "xtraTabClassfiy":
                    pListRamp = style.pListRamp;
                    string classname = cmbClassName.SelectedValue.ToString();
                    fRender = new ClassifyRender(Layer, cmbClassifyField.SelectedValue.ToString(), (IColorRamp)pListRamp[cmbSymClassify.SelectedIndex],Convert.ToInt32(cmbClassifyCount.SelectedValue.ToString()),classname);   
                    ((ClassifyRender)fRender).axmapcontrol = axmapcontrol;
                    ((ClassifyRender)fRender).axtoccontrol = axtoccontrol;
                    fRender.LayerRender();
                    axmapcontrol.Extent = Layer.AreaOfInterest;
                    break;
                case "xtraTabProport":
                    pListColor = style.pListColor;
                    int size =Convert.ToInt32(cmbProSize.SelectedValue);
                    fRender = new PropertonalRender(cmbProField.SelectedValue.ToString(), (IColor)pListColor[cmbSymPro.SelectedIndex], Layer,size);
                    ((PropertonalRender)fRender).axmapcontrol = axmapcontrol;
                    ((PropertonalRender)fRender).axtoccontrol = axtoccontrol;
                    fRender.LayerRender();
                    axmapcontrol.Extent = Layer.AreaOfInterest;
                    break;
                default:
                     pListColor = style.pListColor;
                     fRender = new SingleRender(cmbSingleField.SelectedValue.ToString(), (IColor)pListColor[cmbSymSingle.SelectedIndex], Layer);
                     ((SingleRender)fRender).axmapcontrol = axmapcontrol;
                     ((SingleRender)fRender).axtoccontrol = axtoccontrol;
                     fRender.LayerRender();
                     axmapcontrol.Extent = Layer.AreaOfInterest;
                    break;
            }
            this.Close();
        }

        private void frmSymbol_Load(object sender, EventArgs e)
        {           
            List<ComboBoxSym> list1 = new List<ComboBoxSym>();
            list1.Add(cmbSymPro);
            list1.Add(cmbSymSingle);
            style.Style("Colors", list1);
            List<ComboBoxSym> list2 = new List<ComboBoxSym>();
            list2.Add(cmbSymClassify);
            list2.Add(cmbSymOnly);
            style.Style("Color Ramps", list2);
            cmbSingleField.DataSource = RenderFactory.GetFieldList1(this.Layer);
            cmbOnlyField.DataSource = RenderFactory.GetFieldList1(this.Layer);
            cmbClassifyField.DataSource = RenderFactory.GetFieldList2(this.Layer);
            cmbProField.DataSource = RenderFactory.GetFieldList2(this.Layer);
            //分级渲染方法
            string[] itemname=new string[2]{"自然断点分级","等间距分级"};
            cmbClassName.DataSource=itemname;
            //分级渲染级数
            int[] items=new int[9]{2,3,4,5,6,7,8,9,10};
            cmbClassifyCount.DataSource=items;
            //比例渲染大小
            int[] itemsize=new int[15]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            cmbProSize.DataSource=itemsize;

            cmbSymPro.SelectedIndex = 10;
            cmbSymSingle.SelectedIndex = 10;
            cmbSymClassify.SelectedIndex = 10;
            cmbSymOnly.SelectedIndex = 10;

        }
    }
}
