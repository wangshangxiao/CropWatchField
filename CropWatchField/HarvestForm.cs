using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CropWatchField
{
    public partial class HarvestForm : Form
    {
        public HarvestForm()
        {
            InitializeComponent();
        }
        progressbar progress = new progressbar();
        private void thread1()
        {
            progress.ShowDialog();
        }
        private void btn_InPutFile_cropLand_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为非多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_inputfile_cropLand.Text = dlg.FileName;
            }
        }

        private void btn_InPutfile_HJ_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_inputfile_bio.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_OutPutFile_bio_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();　//创建一个OpenFileDialog 
            //dlg.Filter = "(*.tif)|*.tif";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    this.txt_outfilepath_har.Text = dlg.FileName;
            //}
            DateTime dtime = this.dT_wheat_e.Value;
            string sDatetime = this.dT_wheat_e.Value.ToString("yyyy-MM-dd");
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_outfilepath_har.Text = folderBrowserDialog1.SelectedPath + "\\CROPYIELD_All_" + sDatetime + ".tif";
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断
            if (this.txt_inputfile_cropLand.Text.Equals(""))
            {
                MessageBox.Show("请选择输入作物分布图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_inputfile_bio.Text.Equals(""))
            {
                MessageBox.Show("请选择输入每天生物量存储路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_outfilepath_har.Text.Equals(""))
            {
                MessageBox.Show("请选择输入输出文件名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dT_maize_s.Value.Year != this.dT_maize_e.Value.Year)
            {
                MessageBox.Show("请选择输入正确的玉米年份！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dT_bean_s.Value.Year != this.dT_bean_e.Value.Year)
            {
                MessageBox.Show("请选择输入正确的大豆年份！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dT_wheat_s.Value.Year != this.dT_wheat_e.Value.Year)
            {
                MessageBox.Show("请选择输入正确的小麦年份！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dT_wheat_s.Value.Year != this.dT_maize_s.Value.Year || this.dT_wheat_s.Value.Year != this.dT_bean_s.Value.Year)
            {
                MessageBox.Show("请选择输入相同的作物年份！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            string txtinputfilecropLand = this.txt_inputfile_cropLand.Text.Trim();
            string txtinputfilebio = this.txt_inputfile_bio.Text.Trim();
            string txtoutfilepathhar = this.txt_outfilepath_har.Text.Trim();
            int[] maizeLive = new int[6];
            DateTime ymd0 = this.dT_maize_s.Value;
            maizeLive[0] = ymd0.Year;
            maizeLive[1] = ymd0.Month;
            maizeLive[2] = ymd0.Day;
            DateTime ymd1 = this.dT_maize_e.Value;
            maizeLive[3] = ymd1.Year;
            maizeLive[4] = ymd1.Month;
            maizeLive[5] = ymd1.Day;

            int[] beanLive = new int[6];
            DateTime ymd2 = this.dT_bean_s.Value;
            beanLive[0] = ymd2.Year;
            beanLive[1] = ymd2.Month;
            beanLive[2] = ymd2.Day;
            DateTime ymd3 = this.dT_bean_e.Value;
            beanLive[3] = ymd3.Year;
            beanLive[4] = ymd3.Month;
            beanLive[5] = ymd3.Day;

            int[] wheatLive = new int[6];
            DateTime ymd4 = this.dT_wheat_s.Value;
            wheatLive[0] = ymd4.Year;
            wheatLive[1] = ymd4.Month;
            wheatLive[2] = ymd4.Day;
            DateTime ymd5 = this.dT_wheat_e.Value;
            wheatLive[3] = ymd5.Year;
            wheatLive[4] = ymd5.Month;
            wheatLive[5] = ymd5.Day;
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\crop_harvest_all.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            Thread t = new Thread(new ThreadStart(thread1));
            t.Start();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("in_hx_crop_class",txtinputfilecropLand);
                oCom.SetIDLVariable("in_file_bio", txtinputfilebio);
                oCom.SetIDLVariable("maize_live_day", maizeLive);
                oCom.SetIDLVariable("bean_live_day", beanLive);
                oCom.SetIDLVariable("wheat_live_day", wheatLive);
                oCom.SetIDLVariable("out_filename", txtoutfilepathhar);
                //编译IDL功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("crop_harvest_all,in_hx_crop_class=in_hx_crop_class,in_file_bio=in_file_bio,maize_live_day=maize_live_day,bean_live_day=bean_live_day,wheat_live_day=wheat_live_day,out_filename=out_filename,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    return;
                }
                oCom.DestroyObject();
                t.Abort();
                MessageBox.Show("单产计算完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_ok.Enabled = true;
                this.btn_OpenOutPut.Visible = true;
                
            }
            catch (Exception ex)
            {
                t.Abort();
                MessageBox.Show("计算失败，请联系系统管理员！");
            }

            #endregion
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OpenOutPut_Click(object sender, EventArgs e)
        {
            string sFilename = this.txt_outfilepath_har.Text.Trim();
            string sPath = Path.GetDirectoryName(sFilename);
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

    }
}
