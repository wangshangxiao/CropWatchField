using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CropWatchField
{
    public partial class FormatConvertForm : Form
    {
        public FormatConvertForm()
        {
            InitializeComponent();
            ComBoxDataBind();
        }

        /// <summary>
        /// 输出类型数据绑定，从XML文件中获取
        /// </summary>
        public void ComBoxDataBind()
        {
            string sPath = FileManage.getApplicatonPath();
            //string sPath = Application.StartupPath;
            sPath = sPath + "ImageFormatType.xml";
            List<string> list = XmlManage.getXmlListByNodesName(sPath, "ImageFormatType", "OutPutType", "Name");
            this.cbx_FormatType.DataSource = list;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// InputFileselect,mutiply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InPutFile_Click(object sender, EventArgs e)
        {
            this.listViewImage.GridLines = true;
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            string sPath = FileManage.getApplicatonPath();
            sPath = sPath + "ImageFormatType.xml";
            List<string> list = XmlManage.getXmlListByNodesName(sPath, "ImageFormatType", "InputType", "Name");
            string strs = "";
            string str1= "";
            string str2 = "";
            for (int i = 0; i < list.Count; i++)
            {
                var item=list[i].ToString();
                str1 += item + ";";
                str2 += item + ";";
                strs += "(" + item + ")|" + item + "|";
            }
            //MessageBox.Show("str1=" + str1 + "\n" + " str2=" + str2);
            string str3 = "(" + str1 + ")|" + str2+"|";
            strs = strs+"(*.*)|*.*";
            dlg.Filter = str3+strs;
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = dlg.FileNames.GetValue(i).ToString();//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = "  "+str };
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

        /// <summary>
        /// ImageOutPathSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImageOutPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageOutPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        { 
            #region 输入与输出路径条件判断
            if (this.listViewImage.Items.Count <= 0)
            {
                MessageBox.Show("请选择输入影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_ImageOutPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbx_FormatType.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择输出类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string sOutType = this.cbx_FormatType.SelectedValue.ToString();
            string sImageOutPath = this.txt_ImageOutPath.Text.Trim();
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\Format_Convertion.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("InputFile", sFilename);
                oCom.SetIDLVariable("OutputPath", sImageOutPath);
                oCom.SetIDLVariable("Format", sOutType);
                //编译IDL功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("Format_Convertion,InputFile,OutputPath=OutputPath,Format=Format,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                if (objArr!=null)
                {
                    MessageBox.Show(objArr.ToString());
                    return;
                }
                oCom.DestroyObject();
                MessageBox.Show("格式转换完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_ok.Enabled = true;
                this.btn_OpenOutPut.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion

        }

        /// <summary>
        /// 打开输出文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenOutPut_Click(object sender, EventArgs e)
        {
            string sPath = this.txt_ImageOutPath.Text.Trim();
            System.Diagnostics.Process.Start("explorer.exe",sPath);
        }
    }
}
