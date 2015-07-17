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
    public partial class NDSI_Form : Form
    {
        public NDSI_Form()
        {
            InitializeComponent();
            List<string> cbxString = new List<string>();
            cbxString.Add(string.Format("NDSI"));
   //       cbxString.Add(string.Format("S3"));
            this.cbx_Method.DataSource = cbxString;
            this.cbx_Method.SelectedIndex = 0;
            this.btn_OpenOutPutPath.Visible = false;
        }
        private void btn_OutPutPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox_OutPutPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btn_InPutFile_CCD_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();     //创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;    //设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.textBox_CCDPath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)    //根据数组长度定义循环次数
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());    //获取文件文件名
                    ListViewItem item = new ListViewItem() {Text = str};
                    this.listView_CCD.Items.Add(item);
                }
            }

        }

        private void btn_InPutFile_IRS_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.textBox_IRSPath.Text =Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0;i <dlg.FileNames.Length;i++)
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());
                    ListViewItem item = new ListViewItem() {Text = str};
                    this.listView_IRS.Items.Add(item);
                }
            }
        }

        private void btn_Delete_CCD_Click(object sender, EventArgs e)    //CCD_delete
        {
            foreach (ListViewItem item in listView_CCD.SelectedItems)
            {
                listView_CCD.Items.Remove(item);
            }
        }

        private void btn_Up_CCD_Click(object sender, EventArgs e)   //CCD_UP
        {
            //可选择多个项目同时上移
            //未选择任何项目
            if (listView_CCD.SelectedItems.Count == 0)
            {
                return;
            }
            listView_CCD.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listView_CCD.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listView_CCD.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listView_CCD.Items.RemoveAt(indexSexlectedItem);
                    listView_CCD.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listView_CCD.EndUpdate();
            if (listView_CCD.Items.Count > 0 && listView_CCD.SelectedItems.Count > 0)
            {
                listView_CCD.Focus();
                listView_CCD.SelectedItems[0].Focused = true;
                listView_CCD.SelectedItems[0].EnsureVisible();
            }
             
        }

        private void btn_Down_CCD_Click(object sender, EventArgs e)  //CCD_down
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listView_CCD.SelectedItems.Count == 0)
            {
                return;
            }
            listView_CCD.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem =listView_CCD.SelectedItems[listView_CCD.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem <listView_CCD.Items.Count - 1)
            {
                for (int i =listView_CCD.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected =listView_CCD.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                   listView_CCD.Items.RemoveAt(indexSelected);
                   listView_CCD.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
           listView_CCD.EndUpdate();
            if (listView_CCD.Items.Count > 0 &&listView_CCD.SelectedItems.Count > 0)
            {
               listView_CCD.Focus();
               listView_CCD.SelectedItems[listView_CCD.SelectedItems.Count - 1].Focused = true;
               listView_CCD.SelectedItems[listView_CCD.SelectedItems.Count - 1].EnsureVisible();
            }
         }

        private void btn_Delete_IRS_Click(object sender, EventArgs e)     //IRS_delete
        {
            foreach (ListViewItem item in listView_IRS.SelectedItems)
            {
                listView_IRS.Items.Remove(item);
            }

        }

        private void btn_Up_IRS_Click(object sender, EventArgs e)       //IRS_up
        {

            //可选择多个项目同时上移
            //未选择任何项目
            if (listView_IRS.SelectedItems.Count == 0)
            {
                return;
            }
            listView_IRS.BeginUpdate();
            //选中的第一个项目不是第一个项目时才能进行上移操作
            if (listView_IRS.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem item in listView_IRS.SelectedItems)
                {
                    ListViewItem itemSelected = item;
                    int indexSexlectedItem = item.Index;
                    listView_IRS.Items.RemoveAt(indexSexlectedItem);
                    listView_IRS.Items.Insert(indexSexlectedItem - 1, itemSelected);
                }
            }
            listView_IRS.EndUpdate();
            if (listView_IRS.Items.Count > 0 && listView_IRS.SelectedItems.Count > 0)
            {
                listView_IRS.Focus();
                listView_IRS.SelectedItems[0].Focused = true;
                listView_IRS.SelectedItems[0].EnsureVisible();
            }
        }

        private void btn_Down_IRS_Click(object sender, EventArgs e)       //IRS_down
        {
            //可选择多个项目同时下移
            //未选择任何项目
            if (listView_IRS.SelectedItems.Count == 0)
            {
                return;
            }
            listView_IRS.BeginUpdate();
            //选中的第一个项目不是最后一个项目时才能进行上移操作
            int indexMaxSelectedItem = listView_IRS.SelectedItems[listView_IRS.SelectedItems.Count - 1].Index;//选中的最后一个项目索引
            if (indexMaxSelectedItem < listView_IRS.Items.Count - 1)
            {
                for (int i = listView_IRS.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem itemSelected = listView_IRS.SelectedItems[i];
                    int indexSelected = itemSelected.Index;
                    listView_IRS.Items.RemoveAt(indexSelected);
                    listView_IRS.Items.Insert(indexSelected + 1, itemSelected);
                }
            }
            listView_IRS.EndUpdate();
            if (listView_IRS.Items.Count > 0 && listView_IRS.SelectedItems.Count > 0)
            {
                listView_IRS.Focus();
                listView_IRS.SelectedItems[listView_IRS.SelectedItems.Count - 1].Focused = true;
                listView_IRS.SelectedItems[listView_IRS.SelectedItems.Count - 1].EnsureVisible();
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.textBox_CCDPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入CCD影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.textBox_IRSPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入IRS影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.textBox_OutPutPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出影像路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listView_CCD.Items.Count != this.listView_IRS.Items.Count)
            {
                MessageBox.Show("输入的CCD影像数和IRS影像数不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_Ok.Enabled = false;
            #region 界面参数获取
            //   CCD影像
            List<string> List_CCD = new List<string>();
            foreach (ListViewItem item in this.listView_CCD.Items)
            {
                string s = this.textBox_CCDPath.Text + "\\" + item.SubItems[0].Text.Trim();
                List_CCD.Add(s);
            }
            string[] sFilename_CCD = (string[])List_CCD.ToArray();
            //   IRS影像
            List<string> List_IRS = new List<string>();
            foreach (ListViewItem item in this.listView_IRS.Items)
            {
                string s = this.textBox_IRSPath.Text + "\\" + item.SubItems[0].Text.Trim();
                List_IRS.Add(s);
            }
            string[] sFilename_IRS = (string[])List_IRS.ToArray();
            //输出路径
            string sFilename_Output = this.textBox_OutPutPath.Text.Trim();
            //方法
            string sMethod = this.cbx_Method.SelectedValue.ToString();
   
            #endregion
            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\ndsi.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("FilenameCCD", sFilename_CCD);
                oCom.SetIDLVariable("FilenameIRS", sFilename_IRS);
                oCom.SetIDLVariable("OutputPath", sFilename_Output);
              //  oCom.SetIDLVariable("Method", sMethod);
 //               编译IDL功能源码
                oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
                oCom.ExecuteString("NDSI,FilenameCCD,FilenameIRS,OutputPath,Message=Message");
 //               object objArr = oCom.GetIDLVariable("Message");
 //               返回错误消息
 //               if (objArr != null)
//                {
 //                   MessageBox.Show(objArr.ToString());
 //                   oCom.DestroyObject();
//                    this.btn_Ok.Enabled = true;
//                    return;
 //               }
                oCom.DestroyObject();
                MessageBox.Show("计算完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_Ok.Enabled = true;
                this.btn_OpenOutPutPath.Visible = true;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btn_Concel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OpenOutPutPath_Click(object sender, EventArgs e)
        {
            string sFilename = this.textBox_OutPutPath.Text.Trim();
            System.Diagnostics.Process.Start("explorer.exe", sFilename);
        }

        private void NDSI_Form_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            this.Location = new Point(x, x / 2);
        }
       
       
    }
}