using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using msword = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Data;
using System.Windows.Forms;

namespace CropWatchField
{
    public class CreateWord
    {
        #region
        //public static void createNewWord(Object path, DataTable list_tables)
        //{
        //    msword.Application tableApp = new msword.ApplicationClass();
        //    object nothing = Missing.Value;
        //    msword.Document wordDoc = tableApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);
        //    //msword.Table table = wordDoc.Tables.Add(tableApp.Selection.Range, 3, 2, ref nothing, ref nothing);
        //    msword.Table table = wordDoc.Tables.Add(tableApp.Selection.Range, list_tables.Rows.Count + 1, list_tables.Columns.Count, ref nothing, ref nothing);
        //    table.Borders.Enable = 1;
        //    table.Borders.OutsideLineStyle = msword.WdLineStyle.wdLineStyleSingle;
        //    for (int l = 0; l < list_tables.Columns.Count; l++)
        //    {
        //        table.Cell(1, l + 1).Range.Text = list_tables.Columns[l].ColumnName;
        //    }

        //    for (int i = 0; i < list_tables.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < list_tables.Columns.Count; j++)
        //        {
        //            table.Cell(i + 2, j + 1).Range.Text = list_tables.Rows[i][j].ToString();
        //        }
        //    }

        //    object moveUnit = msword.WdUnits.wdLine;
        //    object moveCount = list_tables.Rows.Count*2+2;
        //    table.Cell(1, 1).Range.Select(); //获取焦点
        //    tableApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref nothing);
        //    tableApp.ActiveWindow.Selection.EndKey(ref moveUnit, ref nothing);
        //    tableApp.Selection.TypeParagraph();

        //    //插入图片
        //    string FileName = Application.StartupPath + @"\Image\2.jpg";//图片所在路径
        //    object LinkToFile = false;
        //    object SaveWithDocument = true;
        //    object Anchor = wordDoc.Paragraphs.Last.Range;
        //    //object Anchor = tableApp.Selection.Range;
        //    wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);

        //    msword.Table table2 = wordDoc.Tables.Add(tableApp.Selection.Range, list_tables.Rows.Count + 1, list_tables.Columns.Count, ref nothing, ref nothing);
        //    table2.Borders.Enable = 1;
        //    table2.Borders.OutsideLineStyle = msword.WdLineStyle.wdLineStyleSingle;
        //    for (int l = 0; l < list_tables.Columns.Count; l++)
        //    {
        //        table2.Cell(1, l + 1).Range.Text = list_tables.Columns[l].ColumnName;
        //    }

        //    for (int i = 0; i < list_tables.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < list_tables.Columns.Count; j++)
        //        {
        //            table2.Cell(i + 2, j + 1).Range.Text = list_tables.Rows[i][j].ToString();
        //        }
        //    }

        //    /*3、导入模板
        //    object oMissing = System.Reflection.Missing.Value;
        //    Word._Application oWord;
        //    Word._Document oDoc;
        //    oWord = new Word.Application();
        //    oWord.Visible = true;
        //    object fileName = @"E:XXXCCXTest.doc";
        //    oDoc = oWord.Documents.Add(ref fileName, ref oMissing, ref oMissing, ref oMissing);*/   
            
           
           
        //    //wordDoc.Application.ActiveDocument.InlineShapes[1].Width = 100f;//图片宽度
        //    //wordDoc.Application.ActiveDocument.InlineShapes[1].Height = 100f;//图片高度
        //    //将图片设置为四周环绕型
        //    //Microsoft.Office.Interop.Word.Shape s = wordDoc.Application.ActiveDocument.InlineShapes[1].ConvertToShape();
        //    // s.WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapSquare;
           
        //    object format = msword.WdSaveFormat.wdFormatDocumentDefault;
        //    wordDoc.SaveAs(ref path, ref format, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
        //    wordDoc.Close(ref nothing, ref nothing, ref nothing);
        //    tableApp.Quit(ref nothing, ref nothing, ref nothing);
        //}

        //public static void createNewWord2(Object path, List<DataTable> list_tables,string image_path)
        //{
        //    msword.Application tableApp = new msword.ApplicationClass();
        //    object nothing = Missing.Value;
        //    msword.Document wordDoc = tableApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);
            
        //    //msword.Table table = wordDoc.Tables.Add(tableApp.Selection.Range, 3, 2, ref nothing, ref nothing);
        //    for (int k = 0; k < list_tables.Count; k++)
        //    {
        //        msword.Table table = wordDoc.Tables.Add(tableApp.Selection.Range, list_tables[k].Rows.Count + 1, list_tables[k].Columns.Count, ref nothing, ref nothing);
        //        table.Borders.Enable = 1;
                
        //        table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //        for (int l = 0; l < list_tables[k].Columns.Count; l++)
        //        {
        //            table.Cell(1, l + 1).Range.Text = list_tables[k].Columns[l].ColumnName;
        //        }

        //        for (int i = 0; i < list_tables[k].Rows.Count; i++)
        //        {
        //            for (int j = 0; j < list_tables[k].Columns.Count; j++)
        //            {
        //                table.Cell(i + 2, j + 1).Range.Text = list_tables[k].Rows[i][j].ToString();
        //            }
        //        }
        //        object moveUnit = msword.WdUnits.wdLine;
        //        object moveCount = list_tables[k].Rows.Count * 2 + 2;
        //        table.Cell(1, 1).Range.Select(); //获取焦点
                
        //        object dummy = System.Reflection.Missing.Value;
        //        object what = msword.WdGoToItem.wdGoToLine;
        //        object which = msword.WdGoToDirection.wdGoToFirst;
        //        object count = list_tables[k].Rows.Count+1;
        //        wordDoc.Application.ActiveDocument.GoTo(ref what, ref which, ref count, ref dummy);
              
        //        //tableApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref nothing);
        //        //tableApp.ActiveWindow.Selection.EndKey(ref moveUnit, ref nothing);
        //        //tableApp.Selection.TypeParagraph();
        //        //OperatePicture.ExportPicture(list_types[k]+"_PLOT");
        //        //插入图片
        //        string FileName = image_path;//图片所在路径
        //        object LinkToFile = false;
        //        object SaveWithDocument = true;
        //        //object Anchor = wordDoc.Paragraphs.Last.Range;
        //        object Anchor = wordDoc.Paragraphs.Last.Range;
        //        wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
              
        //    }
        //    object format = msword.WdSaveFormat.wdFormatDocumentDefault;
        //    wordDoc.SaveAs(ref path, ref format, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
        //    wordDoc.Close(ref nothing, ref nothing, ref nothing);
        //    tableApp.Quit(ref nothing, ref nothing, ref nothing);
        //}
        #endregion
        public static void createNewWord3(Object path, Dictionary<DataTable,string> dicts)
        {
            msword.Application tableApp = new msword.ApplicationClass();
            object nothing = Missing.Value;
            msword.Document wordDoc = tableApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);
            foreach (KeyValuePair<DataTable,string> pair in dicts)
            {
                //wordDoc.Application.Selection.TypeText("表一");
                //wordDoc.Application.Selection.TypeParagraph();
                DataTable item = pair.Key;
                msword.Table table = wordDoc.Tables.Add(tableApp.Selection.Range, item.Rows.Count + 1, item.Columns.Count, ref nothing, ref nothing);
                table.Borders.Enable = 1;
                table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                for (int l = 0; l < item.Columns.Count; l++)
                {
                    table.Cell(1, l + 1).Range.Text = item.Columns[l].ColumnName;
                }

                for (int i = 0; i < item.Rows.Count; i++)
                {
                    for (int j = 0; j < item.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = item.Rows[i][j].ToString();
                    }
                }
                //wordDoc.Application.Selection.Font.Size = 16;
                //wordDoc.Application.Selection.Font.Size = 10;
                //wordDoc.Application.Selection.Font.Bold = 10;
                object moveUnit = msword.WdUnits.wdLine;
                object moveCount = 4;
                //table.Cell(1, 1).Range.Select(); //获取焦点
                table.Select();
                tableApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref nothing);
                //tableApp.ActiveWindow.Selection.EndKey(ref moveUnit, ref nothing);
                tableApp.Selection.TypeParagraph();
                

                //OperatePicture.ExportPicture(list_types[k]+"_PLOT");
                //插入图片
                string FileName =pair.Value;//图片所在路径
                if (!string.IsNullOrEmpty(FileName))
                {
                    object LinkToFile = false;
                    object SaveWithDocument = true;
                    //object Anchor = wordDoc.Paragraphs.Last.Range;
                    object Anchor = wordDoc.Paragraphs.Last.Range;
                    wordDoc.Application.Selection.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument);
                    //wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                }
            }
            object format = msword.WdSaveFormat.wdFormatDocumentDefault;
            wordDoc.SaveAs(ref path, ref format, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
            wordDoc.Close(ref nothing, ref nothing, ref nothing);
            tableApp.Quit(ref nothing, ref nothing, ref nothing);
        }

 
    
    }
}
