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
    public partial class CropNutrientForm : Form
    {
        public CropNutrientForm()
        {
            InitializeComponent();
            dT_RSData.Value = System.DateTime.Now.Date;
        }

        private void btn_InPutFile_t0HS_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_Filename_Cropland.Text = dlg.FileName;
            }
        }

        private void btn_InPutFile_t0HT_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            string sFileName = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
                sFileName = dlg.FileNames.GetValue(0).ToString();//获取文件文件名
                if (!sFileName.Contains("CROPYIELD_All"))
                {
                    MessageBox.Show("输入的数据不是单产监测数据，请重新输入前辍名为CROPYIELD_All的文件！");
                    return;
                }

                else
                {
                    this.txt_Filename_harvest.Text = dlg.FileName;
                    if (!sFileName.Equals(""))
                    {
                        string sPath = Path.GetDirectoryName(sFileName);
                        string sNewPath = Path.GetFileNameWithoutExtension(sFileName);

                        string[] sStr = sNewPath.Split('_');
                        if (sStr.Length > 2)
                        {
                            dT_RSData.Value = Convert.ToDateTime(sStr[2]);
                        }
                    }
                }
            }
        }

        private void btn_InPutFile_t1HS_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();　//创建一个SaveFileDialog 
            //dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    this.txt_outFilename_N.Text = dlg.FileName;
            //}
            DateTime dtime = this.dT_RSData.Value;
            string sDatetime = this.dT_RSData.Value.ToString("yyyy-MM-dd");
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_outFilename_N.Text = folderBrowserDialog1.SelectedPath + "\\SOILNUTRIENT_All_SoilNYield_" + sDatetime + ".tif";
            }
        }

        private void btn_ImageOutPath_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();　//创建一个SaveFileDialog 
            //dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    this.txt_outFilename_O.Text = dlg.FileName;
            //}
            DateTime dtime = this.dT_RSData.Value;
            string sDatetime = this.dT_RSData.Value.ToString("yyyy-MM-dd");
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_outFilename_O.Text = folderBrowserDialog1.SelectedPath + "\\SOILNUTRIENT_All_SoilOYield_" + sDatetime + ".tif";
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.txt_Filename_Cropland.Text.Equals(""))
            {
                MessageBox.Show("请选择输入作物分布图路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_Filename_harvest.Text.Equals(""))
            {
                MessageBox.Show("请选择输入单产路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dtRSData = this.dT_RSData.Value;

            if (dtRSData.Date == System.DateTime.Now.Date)
            {
                DialogResult dr;
                dr = MessageBox.Show("请确认单产数据监测时间是否是今天！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            if (this.txt_outFilename_N.Text.Equals(""))
            {
                MessageBox.Show("请选择输入碱解氮含量输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_outFilename_O.Text.Equals(""))
            {
                MessageBox.Show("请选择输入有机质含量输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            string FilenameCropland = this.txt_Filename_Cropland.Text.Trim();
            string FilenameHharvest = this.txt_Filename_harvest.Text.Trim();
            string outFilenameN = this.txt_outFilename_N.Text.Trim();
            

            string outFilenameO = this.txt_outFilename_O.Text.Trim();
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\harvest_to_soil_nitrogen.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("in_farm_land", FilenameCropland);
                oCom.SetIDLVariable("in_crop_harvest", FilenameHharvest);
                oCom.SetIDLVariable("out_dir_N", outFilenameN);
                oCom.SetIDLVariable("out_dir_O", outFilenameO);
                //编译idl功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("harvest_to_soil_nitrogen,in_farm_land,in_crop_harvest,out_dir_N,out_dir_O,message = message");
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
                this.btn_OpenOutPut.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btn_OpenOutPut_Click(object sender, EventArgs e)
        {
            string sFilename = this.txt_outFilename_O.Text.Trim();
            string sPath = Path.GetDirectoryName(sFilename);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

        private void dT_RSData_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtime = this.dT_RSData.Value;
            string sDatetime = this.dT_RSData.Value.ToString("yyyy-MM-dd");
            string sOut = this.txt_outFilename_N.Text.Trim();
            if (!sOut.Equals(""))
            {
                string sPath = Path.GetDirectoryName(sOut);
                string sNewPath = Path.GetFileNameWithoutExtension(sOut);

                string[] sStr = sNewPath.Split('_');
                string sFullNewPath = sPath + "\\" + sStr[0] + "_" + sStr[1] + "_" + sStr[2] + "_" + sDatetime + ".tif";
                this.txt_outFilename_N.Text = sFullNewPath;
            }
            sOut = this.txt_outFilename_O.Text.Trim();
            if (!sOut.Equals(""))
            {
                string sPath = Path.GetDirectoryName(sOut);
                string sNewPath = Path.GetFileNameWithoutExtension(sOut);

                string[] sStr = sNewPath.Split('_');
                string sFullNewPath = sPath + "\\" + sStr[0] + "_" + sStr[1] + "_" + sStr[2] + "_" + sDatetime + ".tif";
                this.txt_outFilename_O.Text = sFullNewPath;
            }
        }

    }
}
