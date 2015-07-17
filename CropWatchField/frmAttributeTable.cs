using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using System.Data.OleDb;
//using Microsoft.Office.Interop.Excel;

using System.IO;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using Microsoft.Office.Interop.Excel;


namespace CropWatchField
{
    public partial class frmAttributeTable : Form
    {
        AxMapControl pAxMapControl;
        IFeatureLayer pLayer = null;
        ////string pName = null;
        ////string pField = null;
        System.Data.DataTable pTable = new System.Data.DataTable();

        public frmAttributeTable(IFeatureLayer layer, AxMapControl pMapControl)
        {
            this.pLayer = layer;
            pAxMapControl = pMapControl;
            InitializeComponent();

            if (layer is IRasterLayer)
            {
                return;
            }

            IFeatureClass pFeatureClass = pLayer.FeatureClass;
            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                string pFieldName = pFeatureClass.Fields.get_Field(i).Name.ToString();
                //if (pFeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                //{
                //    //pTable.Columns.Add(pFeatureClass.ShapeType.ToString());
                //    pTable.Columns.Add("几何类型");
                //}
                //else
                //{
                    pTable.Columns.Add(pFieldName);
                //}
            }
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            string sGometry = "";
            if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                sGometry = "Polygon";
            }
            else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                sGometry = "Polyline";

            }
            else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            { sGometry = "point"; }

            while (pFeature != null)
            {
                DataRow pRow = pTable.NewRow();
                for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                {
                    string svalue = pFeature.get_Value(j).ToString();
                    if (svalue == "System.__ComObject")
                    {
                        svalue = sGometry;

                    }
                    pRow[j] = svalue;
                }
                pTable.Rows.Add(pRow);
                pFeature = pFeatureCursor.NextFeature();
            }

            BindingSource bs = new BindingSource();
            dataGridViewTOC.DataSource = bs;
            bs.DataSource = pTable;
            bindingNavigator1.BindingSource = bs;
        }


        private void TOC_AttributeTable_Load(object sender, EventArgs e)
        {


        }
        #region
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //第二种方法
            //SaveToExcel();

            //第三种方法
            //SaveToCSV(dataGridViewTOC);

            //第四种方法
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls|CSV files (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出属性表";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportForDataGridview(dataGridViewTOC, saveFileDialog.FileName, false);
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //第一种方法
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files(*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 2;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.Title = "导出属性表";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    bool isOKorNot = ExportForDataGridview(dataGridViewTOC, saveFileDialog.FileName, false);
            //    if (isOKorNot == true)
            //    {
            //        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        this.Close();
            //    }
            //}
        }

        private void SaveToCSV(DataGridView dataGridView1)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有数据需要保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                //saveFileDialog.CreatePrompt = true;
                saveFileDialog.FileName = null;
                saveFileDialog.Title = "保存文件";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream myStream = saveFileDialog.OpenFile();
                    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                    string strLine = "";
                    try
                    {
                        //Write in the headers of the columns.
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (i > 0)
                                strLine += ",";
                            strLine += dataGridView1.Columns[i].HeaderText;
                        }
                        strLine.Remove(strLine.Length - 1);
                        sw.WriteLine(strLine);
                        strLine = "";
                        //Write in the content of the columns.
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            strLine = "";
                            for (int k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                if (k > 0)
                                    strLine += ",";
                                if (dataGridView1.Rows[j].Cells[k].Value == null)
                                    strLine += "";
                                else
                                {
                                    string m = dataGridView1.Rows[j].Cells[k].Value.ToString().Trim();
                                    strLine += m.Replace(",", "，");
                                }
                            }
                            strLine.Remove(strLine.Length - 1);
                            sw.WriteLine(strLine);
                            //Update the Progess Bar.
                            //toolStripProgressBar1.Value = 100 * (j + 1) / dataGridView1.Rows.Count;
                        }
                        sw.Close();
                        myStream.Close();
                        MessageBox.Show("成功保存在" + saveFileDialog.FileName.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //toolStripProgressBar1.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void SaveToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出属性表";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string str = " ";
                try
                {
                    for (int i = 0; i < dataGridViewTOC.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            str += "\t";

                        }
                        str += dataGridViewTOC.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);
                    for (int j = 0; j < dataGridViewTOC.Rows.Count; j++)
                    {
                        string tempStr = "";
                        for (int k = 0; k < dataGridViewTOC.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                tempStr += "\t";
                            }
                            if (dataGridViewTOC.Rows[j].Cells[k].Value != null)
                            {
                                tempStr += dataGridViewTOC.Rows[j].Cells[k].Value.ToString();
                            }
                            else
                            {
                                tempStr += "";
                            }
                        }
                        sw.WriteLine(tempStr);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                    MessageBox.Show("保存成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    this.Close();
                }
            }
        }


        public static bool ExportForDataGridview(DataGridView gridView, string fileName, bool isShowExcle)
        {

            //建立Ｅｘｃｅｌ对象
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (app == null)
                {
                    return false;
                }

                app.Visible = isShowExcle;
                Workbooks workbooks = app.Workbooks;
                _Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Sheets sheets = workbook.Worksheets;
                _Worksheet worksheet = (_Worksheet)sheets.get_Item(1);
                if (worksheet == null)
                {
                    return false;
                }
                string sLen = "";
                //取得最后一列列名
                char H = (char)(64 + gridView.ColumnCount / 26);
                char L = (char)(64 + gridView.ColumnCount % 26);
                if (gridView.ColumnCount < 26)
                {
                    sLen = L.ToString();
                }
                else
                {
                    sLen = H.ToString() + L.ToString();
                }


                //标题
                string sTmp = sLen + "1";
                Range ranCaption = worksheet.get_Range(sTmp, "A1");
                string[] asCaption = new string[gridView.ColumnCount];
                for (int i = 0; i < gridView.ColumnCount; i++)
                {
                    asCaption[i] = gridView.Columns[i].HeaderText;
                }
                ranCaption.Value2 = asCaption;

                //数据
                object[] obj = new object[gridView.Columns.Count];
                for (int r = 0; r < gridView.RowCount - 1; r++)
                {
                    for (int l = 0; l < gridView.Columns.Count; l++)
                    {
                        if (gridView[l, r].ValueType == typeof(DateTime))
                        {
                            obj[l] = gridView[l, r].Value.ToString();
                        }
                        else
                        {
                            obj[l] = gridView[l, r].Value;
                        }
                    }
                    string cell1 = sLen + ((int)(r + 2)).ToString();
                    string cell2 = "A" + ((int)(r + 2)).ToString();
                    Range ran = worksheet.get_Range(cell1, cell2);
                    ran.Value2 = obj;
                }
                //保存
                workbook.SaveCopyAs(fileName);
                workbook.Saved = true;
            }
            finally
            {
                //关闭
                app.UserControl = false;
                app.Quit();
            }
            return true;
        }

        private void SaveToExcelAutomatic(DataGridView dataGridView1, string fileName, bool isShowExcle)
        {
            int iRows = 0;
            int iCols = 0;
            int iTrueCols = 0;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet ws = null;

            if (wb.Worksheets.Count > 0)
            {
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
            }
            else
            {
                wb.Worksheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
            }

            if (ws != null)
            {
                ws.Name = "SheetName";

                iRows = dataGridView1.Rows.Count;      //加上列头行  
                iTrueCols = dataGridView1.Columns.Count;   //包含隐藏的列，一共有多少列  

                //求列数，省略Visible = false的列  
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible) iCols++;
                }

                string[,] dimArray = new string[iRows + 1, iCols];

                for (int j = 0, k = 0; j < iTrueCols; j++)
                {
                    //省略Visible = false的列  
                    if (dataGridView1.Columns[j].Visible)
                    {
                        dimArray[0, k] = dataGridView1.Columns[j].HeaderText;
                        k++;
                    }
                }

                for (int i = 0; i < iRows; i++)
                {
                    for (int j = 0, k = 0; j < iTrueCols; j++)
                    {
                        //省略Visible = false的列  
                        if (dataGridView1.Columns[j].Visible)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                                dimArray[i + 1, k] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            else
                                dimArray[i + 1, k] = "";
                            k++;

                        }

                    }

                }




                ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[iRows + 1, iCols] as Microsoft.Office.Interop.Excel.Range).Value2 = dimArray;
                ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[1, iCols] as Microsoft.Office.Interop.Excel.Range).Font.Bold = true;
                ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[iRows + 1, iCols] as Microsoft.Office.Interop.Excel.Range).Font.Size = 10.0;
                ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[iRows + 1, iCols] as Microsoft.Office.Interop.Excel.Range).RowHeight = 14.25;
                //ws.Columns[.ColumnWidth = datagridview.Columns[0].Width;  
                for (int j = 0, k = 0; j < iTrueCols; j++)
                {
                    //省略Visible = false的列  
                    if (dataGridView1.Columns[j].Visible)
                    {
                        ws.get_Range(ws.Cells[1, k + 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[1, k + 1] as Microsoft.Office.Interop.Excel.Range).ColumnWidth = (dataGridView1.Columns[j].Width / 8.4) > 255 ? 255 : (dataGridView1.Columns[j].Width / 8.4);
                        //ws.Columns.c = datagridview.Columns[j].Width;  
                        k++;
                    }
                }
            }
            //保存
            wb.SaveCopyAs(fileName);
            wb.Saved = true;
            //app.Visible = true;
        }


        #endregion

        private void dataGridViewTOC_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {//获取被选中的datagridview的其一列的数值
            //IField pField = new FieldClass();

            long strflag = Convert.ToInt64(dataGridViewTOC.SelectedRows[0].Cells[0].Value.ToString());
            string filename = pTable.Columns[0].ToString();

            if (filename == "FID")
            {

                FilterLayer("FID=" + strflag + "");
            }
            else
            {


                FilterLayer("OBJECTID=" + strflag + "");
            }
        }



        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <param name="where"></param>
        public void FilterLayer(string where)
        {
            IFeatureLayer flyr = pLayer;
            IFeatureClass fcls = flyr.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = where;

            // 缩放到选择结果集，并高亮显示 
            ZoomToSelectedFeature(flyr, queryFilter);

            //闪烁选中得图斑 
            IFeatureCursor featureCursor = fcls.Search(queryFilter, true);
            FlashPolygons(featureCursor);
        }
        /// <summary>
        /// 缩放到图层，并高亮显示
        /// </summary>
        /// <param name="pFeatureLyr"></param>
        /// <param name="pQueryFilter"></param>
        private void ZoomToSelectedFeature(IFeatureLayer pFeatureLyr, IQueryFilter pQueryFilter)
        {
            #region 高亮显示查询到的要素集合

            //符号边线颜色 
            IRgbColor pLineColor = new RgbColor();
            pLineColor.Red = 0;
            pLineColor.Green = 255;
            pLineColor.Blue = 255;
            ILineSymbol ilSymbl = new SimpleLineSymbolClass();
            ilSymbl.Color = pLineColor;
            ilSymbl.Width = 3;

            //定义选中要素的符号为红色 
            ISimpleFillSymbol ipSimpleFillSymbol = new SimpleFillSymbol();
            ipSimpleFillSymbol.Outline = ilSymbl;
            RgbColor pFillColor = new RgbColor();
            pFillColor.Green = 60;
            ipSimpleFillSymbol.Color = pFillColor;
            //ipSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
            ipSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSNull;

            //选取要素集 
            IFeatureSelection pFtSelection = pFeatureLyr as IFeatureSelection;
            pFtSelection.SetSelectionSymbol = true;
            pFtSelection.SelectionSymbol = (ISymbol)ipSimpleFillSymbol;
            pFtSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

            #endregion
            pAxMapControl.ActiveView.Refresh();
        }
        /// <summary>
        /// 闪烁选中图斑
        /// </summary>
        /// <param name="featureCursor"></param>
        private void FlashPolygons(IFeatureCursor featureCursor)
        {
            IArray geoArray = new ArrayClass();
            IFeature feature = null;
            while ((feature = featureCursor.NextFeature()) != null)
            {
                //feature是循环外指针，所以必须用ShapeCopy 
                geoArray.Add(feature.ShapeCopy);
            }

            //通过IHookActions闪烁要素集合 
            HookHelperClass m_pHookHelper = new HookHelperClass();
            m_pHookHelper.Hook = pAxMapControl.Object;
            IHookActions hookActions = (IHookActions)m_pHookHelper;

            hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsPan);
         
            System.Windows.Forms.Application.DoEvents();
            m_pHookHelper.ActiveView.ScreenDisplay.UpdateWindow();

            hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsFlash);
            System.Windows.Forms.Application.DoEvents();
            m_pHookHelper.ActiveView.ScreenDisplay.UpdateWindow();

        }

    }
}

