using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;

namespace CropWatchField
{
    public partial class ClassStatisticXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public ClassStatisticXtraForm()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// InputFileselect,mutiply
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InPutFile_Click(object sender, EventArgs e)
        {
            //修改，只能选择一个
            OpenFileDialog dlg = new OpenFileDialog();　//创建一个OpenFileDialog 
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = false;//设置属性为多选
            string sFileName = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sFileName = dlg.FileNames.GetValue(0).ToString();//获取文件文件名
            }
            this.txt_ImageInput.Text = sFileName;
        }

        private void BindDataSource(DataTable dt)
        {
            gridControl1.DataSource = dt;
        }

        private void btn_classstatis_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断

            string sImageInput = this.txt_ImageInput.Text.Trim();
            if (sImageInput.Equals(""))
            {
                MessageBox.Show("请选择待分类统计影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion
            this.btn_classstatis.Enabled = false;

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\GetFileHist.pro";
            string sCSVPath = FileManage.getApplicatonPath();
            string sFullName = sCSVPath + "AllSense.csv";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                    //初始化
                    oCom.CreateObject(0, 0, 0);
                    //参数设置
                    oCom.SetIDLVariable("File", sImageInput);
                    oCom.SetIDLVariable("CSVPath", sFullName);
                    //oCom.SetIDLVariable("Background", "0");
                    //编译IDL功能源码
                    oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                    //执行计算
                    oCom.ExecuteString("GetFileHist,file,CSVPath,DataArray=DataArray");
                    //获取计算结果
                    object objArr = oCom.GetIDLVariable("DataArray");
                    //MessageBox.Show(objArr.ToString());
                    if (objArr == null)
                    {
                        MessageBox.Show("输入影像有误，请重新选择分类后影像！");
                        return;
                    }
                    //将对象转为一维数组
                    string[] arrStatistic = (string[])objArr;
                    //表头
                    string[] arrName = { "作物类型","面积（亩）","所占比例（%）"};
                    //数组行按"，"拆分后转DataTable
                    DataTable dt = StringFormater.Convert(arrName, arrStatistic);
                   //数据绑定
                    BindDataSource(dt);
                    oCom.DestroyObject();
                //MessageBox.Show("影像裁剪完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_classstatis.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

    }
}