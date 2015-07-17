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
    public partial class BiomassForm : Form
    {
        public BiomassForm()
        {
            InitializeComponent();
        }



        private void btn_InPutFile_a0_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.txt)|*.txt|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_filename_a0.Text = dlg.FileName;
            }
        }

        private void btn_InPutPath_HJ_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_inputfile_HJ.Text = folderBrowserDialog1.SelectedPath;
            }
            //OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            //dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            ////dlg.Multiselect = false;//设置属性为非多选
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    this.txt_inputfile_HJ.Text = dlg.FileName;
            //}
        }
        private void btn_InPutFile_lat_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_inputfile_lat.Text = dlg.FileName;
            }
        }

        private void btn_OutPutFile_bio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_outfilepath_bio.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.txt_filename_a0.Text.Equals(""))
            {
                MessageBox.Show("请选择输入气象数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_inputfile_lat.Text.Equals(""))
            {
                MessageBox.Show("请选择输入经纬度数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_inputfile_HJ.Text.Equals(""))
            {
                MessageBox.Show("请选择输入文件路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dT_maize_s.Text.Equals(""))
            {
                MessageBox.Show("请选择输出作物生长起始时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_outfilepath_bio.Text.Equals(""))
            {
                MessageBox.Show("请选择输出文件路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            string txtfilenamea = this.txt_filename_a0.Text.Trim();
            string txtinputfilelat = this.txt_inputfile_lat.Text.Trim();
            string txtinputfileHJ = this.txt_inputfile_HJ.Text.Trim()+"\\";
            string txtoutfilepathbio = this.txt_outfilepath_bio.Text.Trim()+ "\\";
            int[] cropLive = new int [3];
            DateTime ymd0 = this.dT_maize_s.Value;
            cropLive[0] = ymd0.Year ;
            cropLive[1] = ymd0.Month ;
            cropLive[2] = ymd0.Day;
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\bio_hongxing.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("meteorology_data", txtfilenamea);
                oCom.SetIDLVariable("latitude", txtinputfilelat);
                oCom.SetIDLVariable("start_end_day", cropLive);
                oCom.SetIDLVariable("HJ_file", txtinputfileHJ);
                oCom.SetIDLVariable("out_bio", txtoutfilepathbio);
                //编译IDL功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("bio_hongxing,latitude=latitude, HJ_file=HJ_file, meteorology_data=meteorology_data, out_bio=out_bio,start_end_day=start_end_day, Message= Message");
                object objArr = oCom.GetIDLVariable("Message");
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    this.btn_ok.Enabled = true;
                    return;
                }
                oCom.DestroyObject();
                MessageBox.Show("每日生物量计算完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string sFilename = this.txt_outfilepath_bio.Text.Trim();
            string sPath = Path.GetDirectoryName(sFilename);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

    

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_filename_a0_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
