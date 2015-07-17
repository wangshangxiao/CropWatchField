using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using System.IO;
using ESRI.ArcGIS.OutputUI;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using System.Diagnostics;
namespace CropWatchField
{
    public partial class ExportPictureMessage : Form
    {
        string layername;
        AxPageLayoutControl pagelayout;
        Object Obj_sender;
        public ExportPictureMessage(string name,AxPageLayoutControl Layout,Object sender)
        {
            InitializeComponent();
            this.layername = name;
            this.pagelayout = Layout;
            this.Obj_sender = sender;
        }

        private void btn_InPutFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "图片文件|*.jpg";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageInput.Text = savefile.FileName;
            }
            
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ImageInput.Text))
            {
                //导出图片
                ExportPictureMyself(txt_ImageInput.Text);
                //保存图片到Image下面，以便入库使用
                ToolStripMenuItem tool = Obj_sender as ToolStripMenuItem;
                string menuText = tool.Text;
                CommonMenu menu = new CommonMenu(menuText, pagelayout, "专题图");
                string[] List = layername.Split(new char[] { '_' ,'.'}, StringSplitOptions.RemoveEmptyEntries);
                
                //根据数据名称选择图片入库方法
                if (List[0] != "SOILNUTRIENT")
                {
                    //OperatePicture.InsertPicture(List);
                  string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
                  Process.Start(sExePath, "9_InsertPicture_" + List[0] + "_" + List[1] + "_" + List[2]);
                }
                else
                {
                    //OperatePicture.InsertSoilPicture(List);
                    string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
                    Process.Start(sExePath, "10_InsertSoilPicture_" + List[0] + "_" + List[1] + "_" + List[2] + "_" + List[3]);
                }
                MessageBox.Show("图片保存成功！", "提示");
            }
            else
            {
                MessageBox.Show("请选择输路径！", "提示");
            }
        }


        /// <summary>
        /// 导出图片
        /// </summary>
        public void ExportPictureMyself(string fileName)
        {
            IActiveView pActiveView = pagelayout.ActiveView;
            IEnvelope pEnv;
            int iOutputResolution = 600;
            int iScreenResolution = 96;
            int hDC;
            tagRECT exportRECT;
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = pActiveView.ExportFrame.right * (iOutputResolution / iScreenResolution);
            exportRECT.bottom = pActiveView.ExportFrame.bottom * (iOutputResolution / iScreenResolution);

            pEnv = new EnvelopeClass();
            pEnv.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            IExportFileDialog pExportFileDialog = new ExportFileDialogClass();

            string filename = fileName;
            IExport pExport = new ExportJPEGClass();
            pExport.ExportFileName = filename;
            pExport.Resolution = iOutputResolution;
            pExport.PixelBounds = pEnv;
            hDC = pExport.StartExporting();
            pActiveView.Output(hDC, (int)pExport.Resolution, ref exportRECT, null, null);
            pExport.FinishExporting();
            pExport.Cleanup();

        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            insert_PictureToBase();
            this.Close();
        }

        private void ExportPictureMessage_Load(object sender, EventArgs e)
        {
            txt_ImageInput.Text = @"C:\Users\Administrator\Desktop\" + layername;
        }

        private void ExportPictureMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            insert_PictureToBase();
        }
        //图片入库公共方法
        public void insert_PictureToBase()
        {
            string[] List = layername.Split(new char[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);

            //根据数据名称选择图片入库方法
            if (List[0] != "SOILNUTRIENT")
            {
                //OperatePicture.InsertPicture(List);
                string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
                Process.Start(sExePath, "9_InsertPicture_" + List[0] + "_" + List[1] + "_" + List[2]);
            }
            else
            {
                //OperatePicture.InsertSoilPicture(List);
                string sExePath = Application.StartupPath + "\\GDALAlgorithm.exe";
                Process.Start(sExePath, "10_InsertSoilPicture_" + List[0] + "_" + List[1] + "_" + List[2] + "_" + List[3]);
            }
        }
    }
}
