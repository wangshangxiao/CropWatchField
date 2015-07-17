using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CropWatchField
{
    public partial class YieldHistogramForm : Form
    {

        public YieldHistogramForm()
        {
            InitializeComponent();
            //初始化
            //组距
            this.trackBar_Interval.Minimum = 10;
            this.trackBar_Interval.Maximum = 50;
            this.trackBar_Interval.TickFrequency = 5;
            this.trackBar_Interval.SmallChange = 1;
            this.trackBar_Interval.LargeChange = 5;
            this.trackBar_Interval.Value = 20;
            this.txt_HistPara1.Text = "20";
            //方法
            List<string> cbxString = new List<string>();
            cbxString.Add(string.Format("高斯拟合"));
            cbxString.Add(string.Format("规定百分数"));
            this.cbx_Method.DataSource = cbxString;
            this.cbx_Method.SelectedIndex = 0;
            //N
            List<string> cbxString1 = new List<string>();
            cbxString1.Add(string.Format("1"));
            cbxString1.Add(string.Format("2"));
            cbxString1.Add(string.Format("3"));
            this.cbx_N.DataSource = cbxString1;
            this.cbx_N.SelectedIndex = 0;
            //初始化百分数
            this.trackBar_Percent.Minimum = 80;
            this.trackBar_Percent.Maximum = 95;
            this.trackBar_Percent.TickFrequency = 5;
            this.trackBar_Percent.SmallChange = 1;
            this.trackBar_Percent.LargeChange = 5;
            this.trackBar_Percent.Value = 90;
            this.txt_Percent.Text = "90";
        }
        private void btn_InPutFile_Yield_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.TextBox_YieldPath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = str };
                    this.listView_Yield.Items.Add(item);
                }
            }
        }

        private void btn_InPutFile_Crop_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.TextBox_CropPath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = str };
                    this.listView_Crop.Items.Add(item);
                }
            }
        }

        private void btn_delete_Yield_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView_Yield.SelectedItems)
            {
                this.listView_Yield.Items.Remove(item);
            }
        }

        private void btn_Up_Yield_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (listView_Yield.SelectedItems.Count == 0)
            {
                return;
            }
            listView_Yield.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listView_Yield.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listView_Yield.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listView_Yield.Items.RemoveAt(indexSexlectedItem);
                    listView_Yield.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listView_Yield.EndUpdate();
            if (listView_Yield.Items.Count > 0 && listView_Yield.SelectedItems.Count > 0)
            {
                listView_Yield.Focus();
                listView_Yield.SelectedItems[0].Focused = true;
                listView_Yield.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_Yield_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listView_Yield.SelectedItems.Count == 0)
            {
                return;
            }
            listView_Yield.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listView_Yield.SelectedItems[listView_Yield.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listView_Yield.Items.Count - 1)
            {
                for (int i = listView_Yield.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listView_Yield.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listView_Yield.Items.RemoveAt(indexSelected);
                    listView_Yield.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listView_Yield.EndUpdate();
            if (listView_Yield.Items.Count > 0 && listView_Yield.SelectedItems.Count > 0)
            {
                listView_Yield.Focus();
                listView_Yield.SelectedItems[listView_Yield.SelectedItems.Count - 1].Focused = true;
                listView_Yield.SelectedItems[listView_Yield.SelectedItems.Count - 1].EnsureVisible();
            }
        }

        private void btn_delete_Crop_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_Crop.SelectedItems)
            {
                listView_Crop.Items.Remove(item);
            }
        }

        private void btn_Up_Crop_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (listView_Crop.SelectedItems.Count == 0)
            {
                return;
            }
            listView_Crop.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listView_Crop.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listView_Crop.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listView_Crop.Items.RemoveAt(indexSexlectedItem);
                    listView_Crop.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listView_Crop.EndUpdate();
            if (listView_Crop.Items.Count > 0 && listView_Crop.SelectedItems.Count > 0)
            {
                listView_Crop.Focus();
                listView_Crop.SelectedItems[0].Focused = true;
                listView_Crop.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_Crop_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listView_Crop.SelectedItems.Count == 0)
            {
                return;
            }
            listView_Crop.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listView_Crop.SelectedItems[listView_Crop.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listView_Crop.Items.Count - 1)
            {
                for (int i = listView_Crop.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listView_Crop.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listView_Crop.Items.RemoveAt(indexSelected);
                    listView_Crop.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listView_Crop.EndUpdate();
            if (listView_Crop.Items.Count > 0 && listView_Crop.SelectedItems.Count > 0)
            {
                listView_Crop.Focus();
                listView_Crop.SelectedItems[listView_Crop.SelectedItems.Count - 1].Focused = true;
                listView_Crop.SelectedItems[listView_Crop.SelectedItems.Count - 1].EnsureVisible();
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.TextBox_YieldPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入单产影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.TextBox_CropPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入作物分布影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.TextBox_OutputPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出影像路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listView_Yield.Items.Count != this.listView_Crop.Items.Count)
            {
                MessageBox.Show("输入的单产影像与作物分布影像文件数不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_OK.Enabled = false;
            #region 界面参数获取
            //单产文件
            List<string> list_Yield = new List<string>();
            foreach (ListViewItem item in this.listView_Yield.Items)
            {
                string s = this.TextBox_YieldPath.Text + "\\" + item.SubItems[0].Text.Trim();
                list_Yield.Add(s);
            }
            string[] sFilename_Yield = (string[])list_Yield.ToArray();
            //作物分布
            List<string> list_Crop = new List<string>();
            foreach (ListViewItem item in this.listView_Crop.Items)
            {
                string s = this.TextBox_CropPath.Text + "\\" + item.SubItems[0].Text.Trim();
                list_Crop.Add(s);
            }
            string[] sFilename_Crop = (string[])list_Crop.ToArray();
            //输出路径
            string sFilename_Output = this.TextBox_OutputPath.Text.Trim();
            //方法
            string sMethod = this.cbx_Method.SelectedValue.ToString();
            //参数
            string HisPara1 = this.txt_HistPara1.Text;//组距
            string HisPara2 = this.cbx_N.SelectedValue.ToString();//[mu-N*sigma,mu+N*sigma]中的N
            string Percent = this.txt_Percent.Text;//百分数           
            #endregion
            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            if (sMethod == "高斯拟合")
            {
                sIDLSavPath = sIDLSavPath + "IDLSav\\nutrient_gaussfit.pro";
                COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
                //try
                //{
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置

                oCom.SetIDLVariable("YieldFilenames", sFilename_Yield);
                oCom.SetIDLVariable("CropClassifyFilenames", sFilename_Crop);
                oCom.SetIDLVariable("OutputPath", sFilename_Output);

                oCom.SetIDLVariable("HisPara1", HisPara1);
                oCom.SetIDLVariable("HisPara2", HisPara2);
                //编译idl功能源码
                oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
                //oCom.ExecuteString("restore,\'" + sIDLSavPath + "\'");
                oCom.ExecuteString("Nutrient_GaussFit,YieldFilenames,CropClassifyFilenames,OutputPath,HisPara1,HisPara2,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                ////返回错误消息
                //if (objArr != null)
                //{
                //    MessageBox.Show(objArr.ToString());
                //    oCom.DestroyObject();
                //    this.btn_OK.Enabled = true;
                //    return;
                //}
                oCom.DestroyObject();
                MessageBox.Show("单产直方图分析完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_OK.Enabled = true;
                this.btn_OpenOutputPath.Visible = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else
            {
                sIDLSavPath = sIDLSavPath + "IDLSav\\nutrient_percent.pro";
                COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
                //try
                //{
                //初始化
                oCom.CreateObject(0, 0, 0);

                oCom.SetIDLVariable("YieldFilenames", sFilename_Yield);
                oCom.SetIDLVariable("CropClassifyFilenames", sFilename_Crop);
                oCom.SetIDLVariable("OutputPath", sFilename_Output);

                oCom.SetIDLVariable("HisPara1", HisPara1);
                oCom.SetIDLVariable("HisPara2", Percent);
                //编译idl功能源码
                oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
                //oCom.ExecuteString("restore,\'" + sIDLSavPath + "\'");
                oCom.ExecuteString("Nutrient_Percent,YieldFilenames,CropClassifyFilenames,OutputPath,HisPara1,HisPara2,Message=Message");
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
                MessageBox.Show("单产直方图分析完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_OK.Enabled = true;
                this.btn_OpenOutputPath.Visible = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            #endregion
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

        private void YieldHistogramForm_Load(object sender, EventArgs e)
        {

        }

        private void trackBar_Interval_Scroll(object sender, EventArgs e)
        {
            this.txt_HistPara1.Text = this.trackBar_Interval.Value.ToString();
        }

        private void cbx_Method_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMethod = this.cbx_Method.SelectedValue.ToString();
            if (sMethod == "高斯拟合")
            {

                this.panel_Percent.Visible = false;
                this.panel_Gauss.Visible = true;
            }
            else
            {
                this.panel_Gauss.Visible = false;
                this.panel_Percent.Visible = true;
            }
        }

        private void trackBar_Percent_Scroll(object sender, EventArgs e)
        {
            this.txt_Percent.Text = this.trackBar_Percent.Value.ToString();
        }
    }
}
