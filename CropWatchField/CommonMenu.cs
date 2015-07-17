using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;

namespace CropWatchField
{
    public class CommonMenu
    {
        public CommonMenu(string strBtnText, AxPageLayoutControl axPageLayoutControl1, string strexxpicname)
        {
            AddMapSouround add = new AddMapSouround(axPageLayoutControl1);
            switch (strBtnText)
            {
                case "图名":
                    add.AddText();
                    break;
                case "图例":
                    add.AddLegend();
                    break;
                //case "文字比例尺":
                //    add.AddTxtSacleBar();
                //    break;
                case "比例尺":
                    add.AddImgScaleBar();
                    break;
                case "指北针":
                    add.AddNorthArrow();
                    break;
                //case "地图边框":
                //    add.AddFrame();
                   // break;
                case "页面设置":
                    MapOutPut mapout = new MapOutPut(axPageLayoutControl1);
                    mapout.PageSetUp();
                    break;
                case "打印预览":
                    MapOutPut mapoutyl = new MapOutPut(axPageLayoutControl1);
                    mapoutyl.PrintPreview();
                    break;
                //case "打印地图":找个影像
                //    //FrmPrintPreview frmPP = new FrmPrintPreview(axPageLayoutControl1);
                //    //frmPP.ShowDialog();
                //    break;
                case "打印":
                    MapOutPut mapoutdy = new MapOutPut(axPageLayoutControl1);
                    mapoutdy.Print();
                    break;
                case "保存图片":
                    MapOutPut mapoutex = new MapOutPut(axPageLayoutControl1);
                    //strexxpicname += "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2");
                    mapoutex.ExportPicture(strexxpicname);
                    break;
            }
        }
    }

}
