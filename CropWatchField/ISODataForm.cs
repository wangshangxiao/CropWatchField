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
    public partial class ISODataForm : Form
    {
        public ISODataForm()
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
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_ImageInput.Text = dlg.FileName;
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
            if (this.txt_ImageInput.Text.Equals(""))
            {
                MessageBox.Show("请选择输入影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sMinclass = this.txt_minclass.Text;
            if (sMinclass.Equals(""))
            {
                MessageBox.Show("请输入最小分类数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nMinclass;
            bool bMinclass = int.TryParse(sMinclass, out nMinclass);
            if (bMinclass==false)
            {
                MessageBox.Show("最小分类数只能为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sMaxclass = this.txt_maxclass.Text;
            if (sMaxclass.Equals(""))
            {
                MessageBox.Show("请输入最大分类数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nMaxclass;
            bool bMaxclass = int.TryParse(sMaxclass, out nMaxclass);
            if (bMaxclass == false)
            {
                MessageBox.Show("最大分类数只能为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nMaxclass < nMinclass)
            {
                MessageBox.Show("最大分类数不能小于最小分类数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sIterations = this.txt_Iterations.Text;
            if (sIterations.Equals(""))
            {
                MessageBox.Show("请选择最大迭代次数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nIterations;
            bool bIterations = int.TryParse(sIterations, out nIterations);
            if (bIterations == false)
            {
                MessageBox.Show("最大迭代次数只能为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sChangethersh = this.txt_changethersh.Text;
            if (sChangethersh.Equals(""))
            {
                MessageBox.Show("请输入变化阈值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nChangethersh;
            bool bChangethersh = int.TryParse(sChangethersh, out nChangethersh);
            if (bChangethersh == false)
            {
                MessageBox.Show("变化阈值只能为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nChangethersh < 0 && nChangethersh>100)
            {
                MessageBox.Show("变化阈值只能为0-100的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            float fChangethersh=0.00f;
            bool f = float.TryParse(sChangethersh, out fChangethersh);
            fChangethersh = fChangethersh / 100;

            if (this.txt_ImageOutPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            this.btn_ok.Enabled = false;
            #region 界面参数获取
            string sFilename = this.txt_ImageInput.Text.Trim();
            string sImageOutPath = this.txt_ImageOutPath.Text.Trim();
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\class_isodata.pro";
            
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("inputfile", sFilename);
                oCom.SetIDLVariable("MIN_CLASSES", sMinclass);
                oCom.SetIDLVariable("NUM_CLASSES", sMaxclass);
                oCom.SetIDLVariable("ITERATIONS", sIterations);
                oCom.SetIDLVariable("CHANGE_THRESH", fChangethersh);
                oCom.SetIDLVariable("outputDir", sImageOutPath);
                //编译IDL功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("CLASS_ISODATA,inputfile,outputDir,ITERATIONS = ITERATIONS,NUM_CLASSES = NUM_CLASSES,CHANGE_THRESH = CHANGE_THRESH,MIN_CLASSES = MIN_CLASSES,Message=Message");
                object objArr = oCom.GetIDLVariable("Message");
                //MessageBox.Show(objArr.ToString());
                if (objArr != null)
                {
                    MessageBox.Show(objArr.ToString());
                    return;
                }
                oCom.DestroyObject();
                MessageBox.Show("分类完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            System.Diagnostics.Process.Start("explorer.exe", sPath);
        }

        private void ISODataForm_Load(object sender, EventArgs e)
        {
            this.txt_minclass.Text = "10";
            this.txt_maxclass.Text = "15";
            this.txt_Iterations.Text = "10";
            this.txt_changethersh.Text = "5";
        }
    }
}
