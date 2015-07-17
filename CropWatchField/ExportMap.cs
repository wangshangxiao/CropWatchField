using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using RenderColor;
using ESRI.ArcGIS.Display;
using System.Diagnostics;

namespace CropWatchField
{
    public partial class ExportMap : DevExpress.XtraEditors.XtraForm
    {
        AxMapControl mapcontrol;
        ILayer layer;

        public ExportMap(AxMapControl mapcontrol, ILayer ex_layer)
        {
            InitializeComponent();
            this.mapcontrol = mapcontrol;
            this.layer = ex_layer;
        }

        private void ExportMap_Load(object sender, EventArgs e)
        {
            cmbTemplate.ComboBox.DataSource = getTemplateName();
            axPageLayoutControl1.PageLayout.ZoomToPercent(60);
            axToolbarControl1.SetBuddyControl(axPageLayoutControl1);
            cmbTemplate_SelectedIndexChanged(null,null);
          axPageLayoutControl1.ActiveView.Refresh();
            
        }
        //添加元素
        private void ElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = sender as ToolStripMenuItem;
            string menuText = tool.Text;
            CommonMenu menu = new CommonMenu(menuText, axPageLayoutControl1, "专题图");
        }
        //保存图片
        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string layername = layer.Name;
            ExportPictureMessage epm = new ExportPictureMessage(layername, axPageLayoutControl1, sender);
            epm.ShowDialog();
            
        }

        private void axPageLayoutControl1_OnDoubleClick(object sender, IPageLayoutControlEvents_OnDoubleClickEvent e)
        {
            AddMapSouround add = new AddMapSouround(axPageLayoutControl1);
            add.ChangeElement(sender, e);
        }

        public List<string> getTemplateName()
        {
            List<string> templateName = new List<string>();
            string[] templates = Directory.GetFiles(Application.StartupPath + "\\MapTemplates");
            for (int i = 0; i < templates.Length; i++)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(Application.StartupPath + "\\MapTemplates" + templates[i]);
                templateName.Add(name);
            }
            return templateName;
        }
        public void mapConnectPage()
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object toCopyMap = mapcontrol.Map;
            object copiedMap = objectCopy.Copy(toCopyMap);
            object toOverwriteMap = this.axPageLayoutControl1.ActiveView.FocusMap;
            objectCopy.Overwrite(copiedMap, ref toOverwriteMap);
        }
        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {    
           axPageLayoutControl1.LoadMxFile(Application.StartupPath + "\\MapTemplates\\" + cmbTemplate.SelectedItem.ToString() + ".mxd");
           mapConnectPage();
           axPageLayoutControl1.PageLayout.ZoomToPercent(60);
           //axPageLayoutControl1.ActiveView.Refresh();
           axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

        }

    }
}