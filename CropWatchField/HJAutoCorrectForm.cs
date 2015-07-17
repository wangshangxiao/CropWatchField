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
    public partial class HJAutoCorrectForm : Form
    {
        public HJAutoCorrectForm()
        {
            InitializeComponent();
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
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageInput.Text = folderBrowserDialog1.SelectedPath+"\\";
            }
        }

        private void btn_ReferenceImage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_ReferenceImage.Text = folderBrowserDialog1.SelectedPath + "\\";
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
                this.txt_ImageOutPath.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }

        private void btn_winrar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_winrar.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            
            #region 输入与输出路径条件判断
            if (this.txt_ImageInput.Text.Equals(""))
            {
                MessageBox.Show("请输入影像目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txt_ReferenceImage.Text.Equals(""))
            {
                MessageBox.Show("请选择参考文件总目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_winrar.Text.Equals(""))
            {
                MessageBox.Show("请选择解压缩文件WinRAR目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txt_ImageOutPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            string sInputDIR = this.txt_ImageInput.Text.Trim();
            string sReferenceDIR = this.txt_ReferenceImage.Text.Trim();
            string sOuputDIR = this.txt_ImageOutPath.Text.Trim();
            string sWinrarDIR = this.txt_winrar.Text.Trim();
            sInputDIR = StringFormater.GetMarkedDirectory(sInputDIR);
            sReferenceDIR=StringFormater.GetMarkedDirectory(sReferenceDIR);
            sOuputDIR = StringFormater.GetMarkedDirectory(sOuputDIR);
            sWinrarDIR = StringFormater.GetMarkedDirectory(sWinrarDIR);
            DirectoryInfo source = new DirectoryInfo(sInputDIR);
            if (!source.Exists)
            {
                MessageBox.Show("输入文件夹不存在：" + sInputDIR, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            source = new DirectoryInfo(sReferenceDIR);
            if (!source.Exists)
            {
                MessageBox.Show("参考文件夹不存在：" + sInputDIR, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            source = new DirectoryInfo(sOuputDIR);
            if (!source.Exists)
            {
                try
                {
                    source.Create();
                }
                catch (Exception)
                {
                    MessageBox.Show("输出文件夹不存在，而且不能创建：" + sOuputDIR, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            source = new DirectoryInfo(sWinrarDIR);
            if (!source.Exists)
            {
                MessageBox.Show("Winrar文件夹不存在：" + sWinrarDIR, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string sWinrarEXE = StringFormater.GetMarkedDirectory(sWinrarDIR) + "WinRAR.exe";
                if (!System.IO.File.Exists(sWinrarEXE))
                {
                    MessageBox.Show("WinRAR.exe 不存在：" + sWinrarEXE, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\HJPreProSysWinV3_1.pro";
            int iACTFlag = this.checkBox2.Checked ? 1 : 0;
            int iDeleteFlag = this.checkBox1.Checked ? 1 : 0;
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                //oCom.SetIDLVariable("InputDIR", sInputDIR);
                //oCom.SetIDLVariable("OutPutDIR", sOuputDIR);
                //oCom.SetIDLVariable("WinrarDIR", sWinrarDIR);
                //oCom.SetIDLVariable("ATCFlag", iACTFlag);
                //oCom.SetIDLVariable("DeleteFlag", iDeleteFlag);
                oCom.ExecuteString(".compile '" + sIDLSavPath);
                this.toolStripStatusLabel2.Text = "运行中，请等候";
                this.statusStrip1.Refresh();
                string comstr = "HJPreProSysWinV3_1,'" + sInputDIR + "','" + sOuputDIR + "','" + sWinrarDIR + "','" + sReferenceDIR + "'," + iACTFlag.ToString() + "," + iDeleteFlag.ToString();

                oCom.ExecuteString(comstr);
                //oCom.ExecuteString("HJPreProSysWinV3_1,InputDIR,OutPutDIR,WinrarDIR,ATCFlag,DeleteFlag");
                this.toolStripStatusLabel2.Text = "运行完成";
                this.statusStrip1.Refresh();

                oCom.DestroyObject();
                MessageBox.Show("几何纠正完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_ok.Enabled = true;
                this.btn_OpenOutPut.Visible = true;
                //写配置文件
                string sCfgPath = System.AppDomain.CurrentDomain.BaseDirectory + "ExeConfig.txt";
                StreamWriter sw = new StreamWriter(sCfgPath);
                sw.WriteLine(this.txt_ImageInput.Text);
                sw.WriteLine(this.txt_ReferenceImage.Text);
                sw.WriteLine(this.txt_winrar.Text);
                sw.WriteLine(this.txt_ImageOutPath.Text);
                sw.Close();
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
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

        private void HJAutoCorrectForm_Load(object sender, EventArgs e)
        {
            //如果有配置文件则读
            string sCfgPath = System.AppDomain.CurrentDomain.BaseDirectory+"ExeConfig.txt";
            if (System.IO.File.Exists(sCfgPath))
            {
                StreamReader sr = new StreamReader(sCfgPath);
                string sLine;
                statusStrip1.Text = "未运行";
                try
                {
                    sLine = sr.ReadLine();
                    this.txt_ImageInput.Text = sLine;
                    sLine = sr.ReadLine();
                    this.txt_ReferenceImage.Text = sLine;
                    sLine = sr.ReadLine();
                    this.txt_winrar.Text = sLine;
                    sLine = sr.ReadLine();
                    this.txt_ImageOutPath.Text = sLine;
                    sr.Close();
                }
                catch (System.Exception)
                {
                    return;
                }
            }
        }

       
    }
}
