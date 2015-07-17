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
    public partial class SprWheatMDForm : Form
    {
        public SprWheatMDForm()
        {
            InitializeComponent();
            //将时间选择表默认为系统时间
            dT_CCDData.Value = System.DateTime.Now.Date;
        }
        private void btn_ImageCrop_Inputpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageCrop_Inputpath.Text = dlg.FileName;
            }

        }
        private void btn_CCDImageInputpath_Click(object sender, EventArgs e)
        {
            this.listViewCCDImage.GridLines = true;
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_CCDImageInputpath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = dlg.FileNames.GetValue(i).ToString();//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = "  " + str };
                    this.listViewCCDImage.Items.Add(item);
                }
            }
        }

        private void btn_delete_SprCCD_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCCDImage.SelectedItems)
            {
                listViewCCDImage.Items.Remove(item);
            }
        }

        private void btn_Up_SprCCD_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (listViewCCDImage.SelectedItems.Count == 0)
            {
                return;
            }
            listViewCCDImage.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listViewCCDImage.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listViewCCDImage.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listViewCCDImage.Items.RemoveAt(indexSexlectedItem);
                    listViewCCDImage.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listViewCCDImage.EndUpdate();
            if (listViewCCDImage.Items.Count > 0 && listViewCCDImage.SelectedItems.Count > 0)
            {
                listViewCCDImage.Focus();
                listViewCCDImage.SelectedItems[0].Focused = true;
                listViewCCDImage.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_SprCCD_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listViewCCDImage.SelectedItems.Count == 0)
            {
                return;
            }
            listViewCCDImage.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listViewCCDImage.SelectedItems[listViewCCDImage.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listViewCCDImage.Items.Count - 1)
            {
                for (int i = listViewCCDImage.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listViewCCDImage.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listViewCCDImage.Items.RemoveAt(indexSelected);
                    listViewCCDImage.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listViewCCDImage.EndUpdate();
            if (listViewCCDImage.Items.Count > 0 && listViewCCDImage.SelectedItems.Count > 0)
            {
                listViewCCDImage.Focus();
                listViewCCDImage.SelectedItems[listViewCCDImage.SelectedItems.Count - 1].Focused = true;
                listViewCCDImage.SelectedItems[listViewCCDImage.SelectedItems.Count - 1].EnsureVisible();
            }
        }

        private void btn_IRSImageInputpath_Click(object sender, EventArgs e)
        {
            this.listViewIRSImage.GridLines = true;
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_IRSImageInputpath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = dlg.FileNames.GetValue(i).ToString();//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = "  " + str };
                    this.listViewIRSImage.Items.Add(item);
                }
            }

        }

        private void btn_delete_SprIRS_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewIRSImage.SelectedItems)
            {
                listViewIRSImage.Items.Remove(item);
            }
        }

        private void btn_Up_SprIRS_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (listViewIRSImage.SelectedItems.Count == 0)
            {
                return;
            }
            listViewIRSImage.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listViewIRSImage.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listViewIRSImage.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listViewIRSImage.Items.RemoveAt(indexSexlectedItem);
                    listViewIRSImage.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listViewIRSImage.EndUpdate();
            if (listViewIRSImage.Items.Count > 0 && listViewIRSImage.SelectedItems.Count > 0)
            {
                listViewIRSImage.Focus();
                listViewIRSImage.SelectedItems[0].Focused = true;
                listViewIRSImage.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_SprIRS_Click(object sender, EventArgs e)
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listViewIRSImage.SelectedItems.Count == 0)
            {
                return;
            }
            listViewIRSImage.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listViewIRSImage.SelectedItems[listViewIRSImage.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listViewIRSImage.Items.Count - 1)
            {
                for (int i = listViewIRSImage.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listViewIRSImage.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listViewIRSImage.Items.RemoveAt(indexSelected);
                    listViewIRSImage.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listViewIRSImage.EndUpdate();
            if (listViewIRSImage.Items.Count > 0 && listViewIRSImage.SelectedItems.Count > 0)
            {
                listViewIRSImage.Focus();
                listViewIRSImage.SelectedItems[listViewIRSImage.SelectedItems.Count - 1].Focused = true;
                listViewIRSImage.SelectedItems[listViewIRSImage.SelectedItems.Count - 1].EnsureVisible();
            }
        }

        private void btn_SprwheatMDoutpath_Click(object sender, EventArgs e)
        {
            DateTime dtime = this.dT_CCDData.Value;
            string sDatetime = this.dT_CCDData.Value.ToString("yyyy-MM-dd");
            
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_SprwheatMDoutpath.Text = folderBrowserDialog1.SelectedPath + "\\MATUREPERIOD_wheat_" + sDatetime + ".tif";
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            //作物分布图
            if (this.txt_ImageCrop_Inputpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入作物分布图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listViewCCDImage.Items.Count <= 0)
            {
                MessageBox.Show("请选择输入CCD影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dtCCDData = this.dT_CCDData.Value;
            if (dtCCDData.Date == System.DateTime.Now.Date)
            {
                DialogResult dr;
                dr = MessageBox.Show("请确认影像过境时间是否是今天！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            //IRS数据
            if (this.txt_IRSImageInputpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入IRS影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listViewIRSImage.Items.Count <= 0)
            {
                MessageBox.Show("请选择输入IRS影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (this.txt_SprwheatMDoutpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            //CCD数据
            List<string> list_CCD = new List<string>();
            foreach (ListViewItem item in this.listViewCCDImage.Items)
            {
                //设置路径
                string s = item.SubItems[0].Text.Trim();
                list_CCD.Add(s);
            }
            string[] sFilename_CCD = (string[])list_CCD.ToArray();
            //IRS数据
            List<string> list_IRS = new List<string>();
            foreach (ListViewItem item in this.listViewIRSImage.Items)
            {
                //设置路径
                string s = item.SubItems[0].Text.Trim();
                list_IRS.Add(s);
            }
            string[] sFilename_IRS = (string[])list_IRS.ToArray();
            //输出路径
            string sImageCrop_Inputpath = this.txt_ImageCrop_Inputpath.Text.Trim();
            string sSprwheatMDoutpath = this.txt_SprwheatMDoutpath.Text.Trim();
            #endregion
            #region 调用IDL程序
            //IDLSav的路径
            //string sIDLSavPath = Application.StartupPath;
            //sIDLSavPath = sIDLSavPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\SprwheatMD.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("Image_crop_inputpath", sImageCrop_Inputpath);
                oCom.SetIDLVariable("CCDImageInputpath", sFilename_CCD);
                oCom.SetIDLVariable("IRSImageInputpath", sFilename_IRS);
                oCom.SetIDLVariable("Sprwheatoutpath", sSprwheatMDoutpath);
                //编译IDL功能源码

                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("SprwheatMD,CCDImageInputpath=CCDImageInputpath,IRSImageInputpath=IRSImageInputpath,"
                +"Sprwheatoutpath=Sprwheatoutpath,Image_crop_inputpath=Image_crop_inputpath,Message=Message");
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
                MessageBox.Show("春小麦成熟期预测完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string sSprwheatMDoutpath = this.txt_SprwheatMDoutpath.Text.Trim();
            string sPath = Path.GetDirectoryName(sSprwheatMDoutpath);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

        

        
    
    }
}
