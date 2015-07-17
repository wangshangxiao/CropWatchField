using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using COM_IDL_connectLib;

namespace CropWatchField
{
    public partial class ChlorophyllRetrievalForm : Form
    {
        public ChlorophyllRetrievalForm()
        {
            InitializeComponent();
            ComBoxDataBind();
            dT_RSData.Value = System.DateTime.Now.Date;
        }
        /// <summary>
        /// 输入作物类型
        /// </summary>
        public void ComBoxDataBind()
        {
            List<string> list = new List<string>();
            list.Add("请选择");
            list.Add("Maize");
            list.Add("Soybean");
            list.Add("Wheat");
            list.Add("Other");
            this.cbx_CropType.DataSource = list;
           

        }
        /// <summary>
        /// InputFileselect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chtableinpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_chtableinpath.Text = dlg.FileName;
            }
        }
        /// <summary>
        /// InputImageselect,mutiply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImageInputpath_Click(object sender, EventArgs e)
        {
            this.listViewImage.GridLines = true;
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";  //文件类型过滤器
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageInputpath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = dlg.FileNames.GetValue(i).ToString();//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = "  " + str };
                    this.listViewImage.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Delete SelectedItems, Mutipline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewImage.SelectedItems)
            {
                listViewImage.Items.Remove(item);
            }
        }

        private void btn_Up_CCD_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (listViewImage.SelectedItems.Count == 0)
            {
                return;
            }
            listViewImage.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listViewImage.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listViewImage.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listViewImage.Items.RemoveAt(indexSexlectedItem);
                    listViewImage.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listViewImage.EndUpdate();
            if (listViewImage.Items.Count > 0 && listViewImage.SelectedItems.Count > 0)
            {
                listViewImage.Focus();
                listViewImage.SelectedItems[0].Focused = true;
                listViewImage.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_CCD_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listViewImage.SelectedItems.Count == 0)
            {
                return;
            }
            listViewImage.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listViewImage.SelectedItems[listViewImage.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listViewImage.Items.Count - 1)
            {
                for (int i = listViewImage.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listViewImage.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listViewImage.Items.RemoveAt(indexSelected);
                    listViewImage.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listViewImage.EndUpdate();
            if (listViewImage.Items.Count > 0 && listViewImage.SelectedItems.Count > 0)
            {
                listViewImage.Focus();
                listViewImage.SelectedItems[listViewImage.SelectedItems.Count - 1].Focused = true;
                listViewImage.SelectedItems[listViewImage.SelectedItems.Count - 1].EnsureVisible();
            }
        }

        private void btn_ChImageOutPath_Click(object sender, EventArgs e)
        {
            string scbx_CropType = this.cbx_CropType.SelectedValue.ToString();
            DateTime dtime = this.dT_RSData.Value;
            string sDatetime = this.dT_RSData.Value.ToString("yyyy-MM-dd");
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_ChImageOutPath.Text = folderBrowserDialog1.SelectedPath + "\\ChlorophyllRetrieval_" + scbx_CropType + "_" + sDatetime + ".tif";
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.txt_chtableinpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入查找表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_ImageRefer_Inputpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入作物分布图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listViewImage.Items.Count <= 0)
            {
                MessageBox.Show("请选择输入影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dtRSData = this.dT_RSData.Value;
            if (dtRSData.Date == System.DateTime.Now.Date)
            {
                DialogResult dr;
                dr = MessageBox.Show("请确认影像过境时间是否是今天！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            if (this.cbx_CropType.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择作物类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_ChImageOutPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            List<string> list = new List<string>();
            foreach (ListViewItem item in this.listViewImage.Items)
            {
                string s = item.SubItems[0].Text.Trim();
                list.Add(s);
            }
            string[] sFilename = (string[])list.ToArray();
            string scbx_CropType = this.cbx_CropType.SelectedValue.ToString();
            string schtableinpath = this.txt_chtableinpath.Text.Trim();
            string sImageRefer_Inputpath = this.txt_ImageRefer_Inputpath.Text.Trim();
            string sChImageOutPath = this.txt_ChImageOutPath.Text.Trim();
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            //string sIDLSavPath = Application.StartupPath;
            //sIDLSavPath = sIDLSavPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
            string sIDLSavPath = FileManage.getApplicatonPath();
            string sIDLSavPath_pro = sIDLSavPath + "IDLSav\\main_ch_retrieve_Crop.pro";  
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置                
                oCom.SetIDLVariable("chtableinpath", schtableinpath);
                oCom.SetIDLVariable("Image_crop_inputpath", sImageRefer_Inputpath);
                oCom.SetIDLVariable("inputFiles", sFilename);
                oCom.SetIDLVariable("chimageoutpath", sChImageOutPath);
                oCom.SetIDLVariable("CropType", scbx_CropType);
                //编译IDL功能源码
                //string sIDLSavPath_sav = sIDLSavPath + "IDLSav\\prosail_idl.sav";
                //oCom.ExecuteString("restore,\'" + sIDLSavPath_sav + "\'");
                oCom.ExecuteString(".compile '" + sIDLSavPath_pro + "'");
                oCom.ExecuteString("main_ch_retrieve_Crop,chtableinpath=chtableinpath,inputFiles=inputFiles,"
                                    +"CropType=CropType,chimageoutpath=chimageoutpath,"
                                    +"Image_crop_inputpath=Image_crop_inputpath,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                //MessageBox.Show(objArr.ToString());
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    oCom.DestroyObject();
                    this.btn_ok.Enabled = true;
                    return;
                }
                oCom.DestroyObject();
                MessageBox.Show("冠层叶绿素分布图建立完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_ok.Enabled = true;
                this.btn_OpenOutPutpath.Visible = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OpenOutPutpath_Click(object sender, EventArgs e)
        {
            string sChImageOutPath = this.txt_ChImageOutPath.Text.Trim();
            string sPath = Path.GetDirectoryName(sChImageOutPath);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

        private void btn_ImageRefer_Inputpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageRefer_Inputpath.Text = dlg.FileName;
            }
        }
       
       
    }
}
