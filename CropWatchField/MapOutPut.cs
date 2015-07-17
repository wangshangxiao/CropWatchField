using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Output;
using System.Drawing.Printing;
using System.Collections;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.OutputUI;
using System.IO;

namespace CropWatchField
{
    public class MapOutPut
    {
        //declare the dialogs for print preview, print dialog, page setup
        private PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        //declare a PrintDocument object named document, to be displayed in the print preview
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        //cancel tracker which is passed to the output function when printing to the print preview
        private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        //the page that is currently printed to the print preview
        private short m_CurrentPrintPage;
        System.Windows.Forms.ComboBox comboBox1 = new System.Windows.Forms.ComboBox();

        public MapOutPut(AxPageLayoutControl pagecontrol) 
        {
            axPageLayoutControl1 = pagecontrol;

            printDialog1 = new System.Windows.Forms.PrintDialog(); //create a print dialog object
            InitializePageSetupDialog(); //intitialize the page setup dialog   

            comboBox1.Items.Add("esriPageMappingTile");
            comboBox1.Items.Add("esriPageMappingCrop");
            comboBox1.Items.Add("esriPageMappingScale");
            comboBox1.SelectedIndex = 0;

            // create a new PrintPreviewDialog using constructor
            printPreviewDialog1 = new PrintPreviewDialog();
            //set the size, location, name and the minimum size the dialog can be resized to
            printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 600);
            printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            printPreviewDialog1.Name = "PrintPreviewDialog1";
            printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
            //set UseAntiAlias to true to allow the operating system to smooth fonts
            printPreviewDialog1.UseAntiAlias = true;

            //associate the event-handling method with the document's PrintPage event
            this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);

        }

        private void InitializePageSetupDialog()
        {
            //create a new PageSetupDialog using constructor
            pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            //initialize the dialog's PrinterSettings property to hold user defined printer settings
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            //initialize dialog's PrinterSettings property to hold user set printer settings
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            //do not show the network in the printer dialog
            pageSetupDialog1.ShowNetwork = false;
        }


        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPreview()
        {
            try 
            {
                //initialize the currently printed page number
                m_CurrentPrintPage = 0;

                //check if a document is loaded into PageLayout	control
                //if (axPageLayoutControl1.DocumentFilename == null) return;
                //set the name of the print preview document to the name of the mxd doc
                //document.DocumentName = axPageLayoutControl1.DocumentFilename;
                Form frm = printPreviewDialog1 as Form;
                frm.WindowState = FormWindowState.Maximized;
                if (axPageLayoutControl1.Printer.Paper.Orientation == 2) 
                {
                    document.DefaultPageSettings.Landscape = true;
                }

                //set the PrintPreviewDialog.Document property to the PrintDocument object selected by the user
                printPreviewDialog1.Document = document;

                //show the dialog - this triggers the document's PrintPage event
                printPreviewDialog1.ShowDialog();

            }
            catch(Exception ax)
            {
                if (ax.ToString().Contains("未安装打印机"))
                {
                    MessageBox.Show("请安装打印机", "提示");
                }
            }
        }

        /// <summary>
        /// 页面设置
        /// </summary>
        public void PageSetUp() 
        {
            //Show the page setup dialog storing the result.
            DialogResult result;
            try 
            {
                result = pageSetupDialog1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("未安装打印机", "提示");
                return;
            }
            if (result == DialogResult.OK) 
            {

                //set the printer settings of the preview document to the selected printer settings
                document.PrinterSettings = pageSetupDialog1.PrinterSettings;

                //set the page settings of the preview document to the selected page settings
                document.DefaultPageSettings = pageSetupDialog1.PageSettings;

                //due to a bug in PageSetupDialog the PaperSize has to be set explicitly by iterating through the
                //available PaperSizes in the PageSetupDialog finding the selected PaperSize
                int i;
                IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Kind == document.DefaultPageSettings.PaperSize.Kind)
                    {
                        document.DefaultPageSettings.PaperSize = ((PaperSize)paperSizes.Current);
                    }
                }

                /////////////////////////////////////////////////////////////
                ///initialize the current printer from the printer settings selected
                ///in the page setup dialog
                /////////////////////////////////////////////////////////////
                IPaper paper;
                paper = new PaperClass(); //create a paper object

                IPrinter printer;
                printer = new EmfPrinterClass(); //create a printer object
                //in this case an EMF printer, alternatively a PS printer could be used

                //initialize the paper with the DEVMODE and DEVNAMES structures from the windows GDI
                //these structures specify information about the initialization and environment of a printer as well as
                //driver, device, and output port names for a printer
                paper.Attach(pageSetupDialog1.PrinterSettings.GetHdevmode(pageSetupDialog1.PageSettings).ToInt32(), pageSetupDialog1.PrinterSettings.GetHdevnames().ToInt32());

                //pass the paper to the emf printer
                printer.Paper = paper;

                //set the page layout control's printer to the currently selected printer
                axPageLayoutControl1.Printer = printer;
            }

        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print() 
        {
            try 
            {
                //allow the user to choose the page range to be printed
                printDialog1.AllowSomePages = true;
                //show the help button.
                printDialog1.ShowHelp = true;

                //set the Document property to the PrintDocument for which the PrintPage Event 
                //has been handled. To display the dialog, either this property or the 
                //PrinterSettings property must be set 
                printDialog1.Document = document;

                //show the print dialog and wait for user input
                DialogResult result = printDialog1.ShowDialog();

                // If the result is OK then print the document.
                if (result == DialogResult.OK) document.Print();
            }
            catch
            {
                MessageBox.Show("未安装打印机", "提示");
            }



        }

        /// <summary>
        /// 导出图片
        /// </summary>
        public void ExportPicture(string strdefaultfilename) 
        {
            if (strdefaultfilename.Contains("制")) 
            {
                strdefaultfilename = strdefaultfilename.Replace("制","");
            }
            try
            {
                IActiveView pActiveView =axPageLayoutControl1.ActiveView;
                IEnvelope pEnv;
                int iOutputResolution = 600;
                int iScreenResolution = 96;
                int hDC;
                tagRECT exportRECT;
                exportRECT.left = 0;
                exportRECT.top = 0;
                //exportRECT.right = pActiveView.ExportFrame.right;
                //exportRECT.bottom = pActiveView.ExportFrame.bottom;
                exportRECT.right = pActiveView.ExportFrame.right * (iOutputResolution / iScreenResolution);
                exportRECT.bottom = pActiveView.ExportFrame.bottom * (iOutputResolution / iScreenResolution);

                pEnv = new EnvelopeClass();
                pEnv.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
                IExportFileDialog pExportFileDialog = new ExportFileDialogClass();
                pExportFileDialog.DocumentName = strdefaultfilename;
                //bool bl;
                //bl = pExportFileDialog.DoModal(pEnv, pActiveView.Extent, pActiveView.Extent, 900);
                //if (!bl) return;
                //IExport pExport = pExportFileDialog.Export;
                //pExport.Resolution = iOutputResolution;
                //pExport.PixelBounds = pEnv;
                string filename = Application.StartupPath + @"\Image\1.jpg";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                IExport pExport = new ExportJPEGClass();
                pExport.ExportFileName = filename;
                pExport.Resolution = iOutputResolution;
                pExport.PixelBounds = pEnv;
                hDC = pExport.StartExporting();
                pActiveView.Output(hDC, (int)pExport.Resolution, ref exportRECT, null, null);
                pExport.FinishExporting();
                pExport.Cleanup();
              
                hDC = pExport.StartExporting();
                pActiveView.Output(hDC, (int)pExport.Resolution, ref exportRECT, null, null);
                pExport.FinishExporting();
                pExport.Cleanup();
               // MessageBox.Show("保存成功", "提示");
            }
            catch (Exception ax)
            {
                MessageBox.Show(ax.ToString());
            }

            //try
            //{
            //    System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.Filter = "*.jpeg|*.jpeg|*.pdf|*.pdf|*.bmp|*.bmp";
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        IExport pExport = null;
            //        if (1 == sfd.FilterIndex)
            //        {
            //            pExport = new ExportJPEGClass();
            //        }
            //        else if (2 == sfd.FilterIndex)
            //        {
            //            pExport = new ExportPDFClass();
            //        }
            //        else if (3 == sfd.FilterIndex)
            //        {
            //            pExport = new ExportBMPClass();
            //        }
            //        pExport.ExportFileName = sfd.FileName;
            //        //设置参数
            //        //默认精度               
            //        int reslution = 300;
            //        pExport.Resolution = reslution;
            //        //获取导出范围
            //        tagRECT exportRECT = axPageLayoutControl1.ActiveView.ExportFrame;
            //        //tagRECT exportRECT = axMapMain.ActiveView.ExportFrame;
            //        IEnvelope pPixelBoundsEnv = new EnvelopeClass();
            //        pPixelBoundsEnv.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            //        pExport.PixelBounds = pPixelBoundsEnv;
            //        //开始导出，获取DC  
            //        int hDC = pExport.StartExporting();
            //        IEnvelope pVisbounds = null;
            //        ITrackCancel ptrac = null;
            //        //导出
            //        axPageLayoutControl1.ActiveView.Output(hDC, (int)pExport.Resolution, ref exportRECT, pVisbounds, ptrac);
            //        //结束导出
            //        pExport.FinishExporting();
            //        //清理导出类
            //        pExport.Cleanup();
            //        MessageBox.Show("导出成功","提示");
            //    }
            //}
            //catch
            //{

            //}
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this code will be called when the PrintPreviewDialog.Show method is called
            //set the PageToPrinterMapping property of the Page. This specifies how the page 
            //is mapped onto the printer page. By default the page will be tiled 
            //get the selected mapping option
            string sPageToPrinterMapping = (string)this.comboBox1.SelectedItem;
            if (sPageToPrinterMapping == null)
                //if no selection has been made the default is tiling
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("esriPageMappingTile"))
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("esriPageMappingCrop"))
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingCrop;
            else if (sPageToPrinterMapping.Equals("esriPageMappingScale"))
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
            else
                axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;

            //get the resolution of the graphics device used by the print preview (including the graphics device)
            short dpi = (short)e.Graphics.DpiX;
            //envelope for the device boundaries
            IEnvelope devBounds = new EnvelopeClass();
            //get page
            IPage page = axPageLayoutControl1.Page;

            //the number of printer pages the page will be printed on
            short printPageCount;
            printPageCount = axPageLayoutControl1.get_PrinterPageCount(0);
            m_CurrentPrintPage++;

            //the currently selected printer
            IPrinter printer = axPageLayoutControl1.Printer;
            //get the device bounds of the currently selected printer
            page.GetDeviceBounds(printer, m_CurrentPrintPage, 0, dpi, devBounds);

            //structure for the device boundaries
            tagRECT deviceRect;
            //Returns the coordinates of lower, left and upper, right corners
            double xmin, ymin, xmax, ymax;
            devBounds.QueryCoords(out xmin, out ymin, out xmax, out ymax);
            //initialize the structure for the device boundaries
            deviceRect.bottom = (int)ymax;
            deviceRect.left = (int)xmin;
            deviceRect.top = (int)ymin;
            deviceRect.right = (int)xmax;

            //determine the visible bounds of the currently printed page
            IEnvelope visBounds = new EnvelopeClass();
            page.GetPageBounds(printer, m_CurrentPrintPage, 0, visBounds);

            //get a handle to the graphics device that the print preview will be drawn to
            IntPtr hdc = e.Graphics.GetHdc();

            //print the page to the graphics device using the specified boundaries 
            axPageLayoutControl1.ActiveView.Output(hdc.ToInt32(), dpi, ref deviceRect, visBounds, m_TrackCancel);

            //release the graphics device handle
            e.Graphics.ReleaseHdc(hdc);

            //check if further pages have to be printed
            if (m_CurrentPrintPage < printPageCount)
                e.HasMorePages = true; //document_PrintPage event will be called again
            else
                e.HasMorePages = false;

        }

    }
}
