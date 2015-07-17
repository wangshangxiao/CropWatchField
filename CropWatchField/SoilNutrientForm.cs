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
    public partial class SoilNutrientForm : Form
    {
        public SoilNutrientForm()
        {
            InitializeComponent();
            dT_RSData.Value = System.DateTime.Now.Date;
        }

        private void btn_InPutFile_lat_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_inputfile_HJccd.Text = dlg.FileName;
            }
        }

        private void btn_InPutfile_HJ_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_inputfile_landclass.Text = dlg.FileName;
            }
        }

        private void btn_OutPutFile_bio_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();　//创建一个OpenFileDialog 
            //dlg.Filter = "(*.tif)|*.tif";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    this.txt_outfilepath_O.Text = dlg.FileName;
            //}


            DateTime dtime = this.dT_RSData.Value;
            string sDatetime = this.dT_RSData.Value.ToString("yyyy-MM-dd");


            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_outfilepath_O.Text = folderBrowserDialog1.SelectedPath + "\\SOILNUTRIENT_All_SoilOLight_" + sDatetime + ".tif";
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btn_OpenOutPut_Click(object sender, EventArgs e)
        //{
        //    string sFilename = this.txt_outfilepath_O.Text.Trim();
        //    string sPath = Path.GetDirectoryName(sFilename);
        //    System.Diagnostics.Process.Start("explorer.exe", sPath);
        //}

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.txt_inputfile_HJccd.Text.Equals(""))
            {
                MessageBox.Show("请选择输入环境星裸土期影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (this.txt_inputfile_landclass.Text.Equals(""))
            {
                MessageBox.Show("请选择输入裸土分布图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_outfilepath_O.Text.Equals(""))
            {
                MessageBox.Show("请选择输入输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            string txtinputfileHJccd = this.txt_inputfile_HJccd.Text.Trim();
            string txtinputfilelandclass = this.txt_inputfile_landclass.Text.Trim();
            string txtoutfilepathO = this.txt_outfilepath_O.Text.Trim();

            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\ccdimg_to_soil_nitrogen.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("inputfile_path", txtinputfileHJccd);
                oCom.SetIDLVariable("inputfile_crop", txtinputfilelandclass);
                oCom.SetIDLVariable("outputfile_path", txtoutfilepathO);

                //编译idl功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("ccdimg_to_soil_nitrogen,inputfile_path,inputfile_crop,outputfile_path,message = message");
                object objArr = oCom.GetIDLVariable("message");
                //返回错误消息
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    return;
                }
                oCom.DestroyObject();
                MessageBox.Show("养分监测完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_ok.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void dT_RSData_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtime = this.dT_RSData.Value;
            string sDatetime = this.dT_RSData.Value.ToString("yyyy-MM-dd");
            string sOut = this.txt_outfilepath_O.Text.Trim();
            if (!sOut.Equals(""))
            {
                string sPath = Path.GetDirectoryName(sOut);
                string sNewPath = Path.GetFileNameWithoutExtension(sOut);

                string[] sStr = sNewPath.Split('_');
                string sFullNewPath = sPath + "\\" + sStr[0] + "_" + sStr[1] + "_" + sStr[2] + "_" + sDatetime + ".tif";
                this.txt_outfilepath_O.Text = sFullNewPath;
            }
        }

    }
}
