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
    public partial class SANForm : Form
    {

        public SANForm()
        {
            InitializeComponent();
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

        private void btn_delete_Yield_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView_Yield.SelectedItems)
            {
                this.listView_Yield.Items.Remove(item);
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

        private void SANForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.TextBox_YieldPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入单产影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.TextBox_OutputPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出影像路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            #region 界面参数获取
            //单产文件
            List<string> list_Yield = new List<string>();
            foreach (ListViewItem item in this.listView_Yield.Items)
            {
                string s = this.TextBox_YieldPath.Text + "\\" + item.SubItems[0].Text.Trim();
                list_Yield.Add(s);
            }
            string[] sFilename_Yield = (string[])list_Yield.ToArray();
            //输出路径
            string sFilename_Output = this.TextBox_OutputPath.Text.Trim();
            #endregion
            #region
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\nutrient_N.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("YieldFilenames", sFilename_Yield);
                oCom.SetIDLVariable("OutputPath", sFilename_Output);
                //编译idl功能源码
                oCom.ExecuteString(".compile -v '" + sIDLSavPath + "'");
                oCom.ExecuteString("Nutrient_N,YieldFilenames,OutputPath,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                //返回错误消息
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    oCom.DestroyObject();
                    return;
                }
                oCom.DestroyObject();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }
    }
}
