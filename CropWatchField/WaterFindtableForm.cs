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
    public partial class WaterFindtableForm : Form
    {
        public WaterFindtableForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// WatertableOutpathSelect
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WatertableOutpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_WatertableOutpath.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输出路径
            if (this.txt_WatertableOutpath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;

            #region 界面参数获取
            string sWatertableOutpath = this.txt_WatertableOutpath.Text.Trim();
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            //string sIDLSavPath = Application.StartupPath; ;
            //sIDLSavPath = sIDLSavPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
            string sIDLSavPath = FileManage.getApplicatonPath();
            string sIDLSavPath_pro = sIDLSavPath + "IDLSav\\main_water_buildtable.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置                
                oCom.SetIDLVariable("watertableoutpath", sWatertableOutpath);
                //编译IDL功能源码

                string sIDLSavPath_sav = sIDLSavPath + "IDLSav\\prosail_idl.sav";
                oCom.ExecuteString("restore,\'" + sIDLSavPath_sav + "\'");
                oCom.ExecuteString(".compile '" + sIDLSavPath_pro + "'");
                oCom.ExecuteString("main_water_buildtable,watertableoutpath=watertableoutpath,Message=Message");

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
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OpenOutPutpath_Click(object sender, EventArgs e)
        {
            string sWatertableOutpath = this.txt_WatertableOutpath.Text.Trim();
            string sPath = Path.GetDirectoryName(sWatertableOutpath);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }
    }
}
