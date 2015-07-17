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
    public partial class ChlorophyllFindtableForm : Form
    {
        public ChlorophyllFindtableForm()
        {
            InitializeComponent();
            ComBoxDataBind();
        }
        /// <summary>
        /// 输入CCD数据类型
        /// </summary>
        public void ComBoxDataBind()
        {
            List<string> list = new List<string>();
            list.Add("请选择");
            list.Add("HJCCDA1");
            list.Add("HJCCDA2");
            list.Add("HJCCDB1");
            list.Add("HJCCDB2");
            this.cbx_CCDType.DataSource = list;
        }
        /// <summary>
        /// ChtableOutpathSelect
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chtableOutPutpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_chtableOutPutpath.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输出路径
            if (this.txt_chtableOutPutpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbx_CCDType.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择数据类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;

            #region 界面参数获取
            string scbx_CCDType = this.cbx_CCDType.SelectedValue.ToString();
            //输出路径的选择非常重要
            string schtableOutPutpath = this.txt_chtableOutPutpath.Text.Trim();
            #endregion


            #region 调用IDL程序
            //IDLSav的路径
            // sIDLSavPath为"D:\\3_HongXing\\6_software\\CropWatchField\\CropWatchField\\bin\\Debug"
            // sIDLSavPath2为"D:\\3_HongXing\\6_software\\CropWatchField\\CropWatchField\\"
            //pro的路径正确

            //string sIDLSavPath = Application.StartupPath;
            //sIDLSavPath = sIDLSavPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
            string sIDLSavPath = FileManage.getApplicatonPath();
            string sIDLSavPath_pro = sIDLSavPath + "IDLSav\\main_ch_buildtable.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置                
                oCom.SetIDLVariable("inputtype", scbx_CCDType);
                oCom.SetIDLVariable("chtableoutpath", schtableOutPutpath);
                //编译IDL功能源码
                string sIDLSavPath_sav = sIDLSavPath + "IDLSav\\prosail_idl.sav";
                oCom.ExecuteString("restore,\'" + sIDLSavPath_sav + "\'");
                oCom.ExecuteString(".compile '" + sIDLSavPath_pro + "'"); 
                oCom.ExecuteString("main_ch_buildtable,inputtype=inputtype,chtableoutpath=chtableoutpath,Message=Message");

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
                MessageBox.Show("查找表建立完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string schtableOutPutpath = this.txt_chtableOutPutpath.Text.Trim();
            string sPath = Path.GetDirectoryName(schtableOutPutpath);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

       
    }
}
