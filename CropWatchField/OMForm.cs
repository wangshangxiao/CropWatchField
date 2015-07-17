using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CropWatchField
{
    public partial class OMForm : Form
    {
        private string sHistogram="false";
        public string ObserFilename;
        public OMForm()
        {
            InitializeComponent();
        }

        private void btn_InPutFile_HJ_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.TextBox_HJPath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = str };
                    this.listView_HJ.Items.Add(item);
                }
            }
        }

        private void btn_InPutFile_Obser_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.TextBox_ObserPath.Text = (dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = str };
                }
            }
        }

        private void btn_delete_HJ_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView_HJ.SelectedItems)
            {
                this.listView_HJ.Items.Remove(item);
            }
        }

        private void btn_Up_HJ_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (this.listView_HJ.SelectedItems.Count == 0)
            {
                return;
            }
            listView_HJ.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listView_HJ.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listView_HJ.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listView_HJ.Items.RemoveAt(indexSexlectedItem);
                    listView_HJ.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listView_HJ.EndUpdate();
            if (listView_HJ.Items.Count > 0 && listView_HJ.SelectedItems.Count > 0)
            {
                listView_HJ.Focus();
                listView_HJ.SelectedItems[0].Focused = true;
                listView_HJ.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_HJ_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (this.listView_HJ.SelectedItems.Count == 0)
            {
                return;
            }
            listView_HJ.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listView_HJ.SelectedItems[listView_HJ.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listView_HJ.Items.Count - 1)
            {
                for (int i = listView_HJ.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listView_HJ.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listView_HJ.Items.RemoveAt(indexSelected);
                    listView_HJ.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listView_HJ.EndUpdate();
            if (listView_HJ.Items.Count > 0 && listView_HJ.SelectedItems.Count > 0)
            {
                listView_HJ.Focus();
                listView_HJ.SelectedItems[listView_HJ.SelectedItems.Count - 1].Focused = true;
                listView_HJ.SelectedItems[listView_HJ.SelectedItems.Count - 1].EnsureVisible();
            }
        }
        private void btn_OutputPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.TextBox_OutputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OpenOutputPath_Click(object sender, EventArgs e)
        {
            string sFilename = this.TextBox_OutputPath.Text.Trim();
            //string sPath = Path.GetDirectoryName(sFilename);
            System.Diagnostics.Process.Start("explorer.exe", sFilename);
        }
        private void btn_His_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.TextBox_ObserPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入地面观测数据文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            //地面观测数据文件
            string sFilename_Obser = this.TextBox_ObserPath.Text.Trim();
            ObserFilename = sFilename_Obser;
            #region
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\Histogram.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            //try
            //{
            //初始化
            oCom.CreateObject(0, 0, 0);
            //参数设置

            oCom.SetIDLVariable("ObserFilename", sFilename_Obser);

            //编译idl功能源码
            oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
            oCom.ExecuteString("Histogram,ObserFilename,Message=Message");
            object objArr = oCom.GetIDLVariable("Message");
            ////返回错误消息
            //if (objArr != null)
            //{
            //    MessageBox.Show(objArr.ToString());
            //    oCom.DestroyObject();
            //    return;
            //}
            //oCom.DestroyObject();
            oCom.DestroyObject();
            HistogramShow vHistogramShow = new HistogramShow(this);
            vHistogramShow.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            #endregion
        }

        private void rab_Yes_CheckedChanged(object sender, EventArgs e)
        {
            sHistogram = "true";
        }

        private void rab_No_CheckedChanged(object sender, EventArgs e)
        {
            sHistogram = "false";
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.TextBox_HJPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入环境星影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.TextBox_ObserPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入地面观测数据文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.TextBox_OutputPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出影像路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 界面参数获取
            //环境星影像文件
            List<string> list_HJ = new List<string>();
            foreach (ListViewItem item in this.listView_HJ.Items)
            {
                string s = this.TextBox_HJPath.Text + "\\" + item.SubItems[0].Text.Trim();
                list_HJ.Add(s);
            }
            string[] sFilename_HJ = (string[])list_HJ.ToArray();
            //地面观测数据文件
            string sFilename_Obser = this.TextBox_ObserPath.Text.Trim();
            ObserFilename = sFilename_Obser;
            //输出路径
            string sFilename_Output = this.TextBox_OutputPath.Text.Trim();
            #endregion
            #region
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\nutrient_OM.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("HJFilenames", sFilename_HJ);
                oCom.SetIDLVariable("ObserFilename", sFilename_Obser);
                oCom.SetIDLVariable("OutputPath", sFilename_Output);
                oCom.SetIDLVariable("sHistogram", sHistogram);
                //编译idl功能源码
                oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
                oCom.ExecuteString("Nutrient_OM,HJFilenames,ObserFilename,OutputPath,sHistogram,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                //返回错误消息
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    oCom.DestroyObject();
                    this.btn_OK.Enabled = true;
                    return;
                                   }
                oCom.DestroyObject();
                MessageBox.Show("土壤有机质计算完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_OK.Enabled = true;
                this.btn_OutputPath.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void OMForm_Load(object sender, EventArgs e)
        {

        }

       


    }
}
