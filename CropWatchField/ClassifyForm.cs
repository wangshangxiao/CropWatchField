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
    public partial class ClassifyForm : Form
    {
        public ClassifyForm()
        {
            InitializeComponent();
            this.btn_OpenOutPutPath.Visible = false;
        }

        private void ClassifyForm_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            this.Location = new Point(x, x / 2);
        }

        private void btn_InPutFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();     //创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;    //设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.textBox_NdsiPath.Text = Path.GetDirectoryName(dlg.FileName);
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)    //根据数组长度定义循环次数
                {
                    str = Path.GetFileName(dlg.FileNames.GetValue(i).ToString());    //获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = str };
                    this.listView_NDSI.Items.Add(item);
                }
            }
       }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_NDSI.SelectedItems)
            {
                listView_NDSI.Items.Remove(item);
            }
        }

        private void btn_OutPutPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox_OutPutPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_OpenOutPutPath_Click(object sender, EventArgs e)
        {
            string sFilename = this.textBox_OutPutPath.Text.Trim();
            System.Diagnostics.Process.Start("explorer.exe", sFilename);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.textBox_NdsiPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入NDSI图像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.textBox_OutPutPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出影像路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_Ok.Enabled = false;
            #region 界面参数获取
            //   NDSI图像
            List<string> List_NDSI = new List<string>();
            foreach (ListViewItem item in this.listView_NDSI.Items)
            {
                string s = this.textBox_NdsiPath.Text + "\\" + item.SubItems[0].Text.Trim();
                List_NDSI.Add(s);
            }
            string[] sFilename_NDSI = (string[])List_NDSI.ToArray();
            //输出路径
            string sFilename_Output = this.textBox_OutPutPath.Text.Trim();
            #endregion
            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\threshold_method.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("FilenameNDSI", sFilename_NDSI);
                oCom.SetIDLVariable("OutPutPath", sFilename_Output);
                //编译IDL功能源码
                oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
                oCom.ExecuteString("threshold_method,FilenameNDSI,OutPutPath,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                //返回错误消息
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    oCom.DestroyObject();
                    this.btn_Ok.Enabled = true;
                    return;
                }
                oCom.DestroyObject();
                MessageBox.Show("计算完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_Ok.Enabled = true;
                this.btn_OpenOutPutPath.Visible = true;
            }
            catch (Exception ex)
            {
            //    MessageBox.Show(ex.Message);
            }
            #endregion
        }



    }
}
