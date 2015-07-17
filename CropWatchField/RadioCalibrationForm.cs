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
    public partial class RadioCalibrationForm : Form
    {
        public RadioCalibrationForm()
        {
            InitializeComponent();
            //传感器类型数据绑定
            ComBoxDataBind();
        }

        /// <summary>
        /// 输出类型数据绑定，从XML文件中获取
        /// </summary>
        public void ComBoxDataBind()
        {
            string sPath = FileManage.getApplicatonPath();
            sPath = sPath + "ImageFormatType.xml";
            List<string> listHJSensorType = XmlManage.getXmlListByNodesName(sPath, "ImageFormatType", "HJSensorType", "Name");
            this.cbx_SensorType.DataSource = listHJSensorType;
            List<string> listHJBandType = XmlManage.getXmlListByNodesName(sPath, "ImageFormatType", "HJBandType", "Name");
            string[] sBandBlue = listHJBandType.ToArray();
            this.cbx_BandBlue.DataSource = sBandBlue;
            string[] sBandGreen = listHJBandType.ToArray();
            this.cbx_BandGreen.DataSource = sBandGreen;
            string[] sBandRed = listHJBandType.ToArray();
            this.cbx_BandRed.DataSource = sBandRed;
            string[] sBandNInfrared = listHJBandType.ToArray();
            this.cbx_BandNInfrared.DataSource = sBandNInfrared;
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
            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            dlg.Multiselect = true;//设置属性为多选
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string str = " ";
                for (int i = 0; i < dlg.FileNames.Length; i++)//根据数组长度定义循环次数
                {
                    str = dlg.FileNames.GetValue(i).ToString();//获取文件文件名
                    ListViewItem item = new ListViewItem() { Text = "  " + str };
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
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string sPath = save.FileName;
                this.txt_ImageOutPath.Text = sPath;
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
            if (this.cbx_SensorType.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择传感器类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbx_BandBlue.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择蓝光波段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbx_BandGreen.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择绿光波段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbx_BandRed.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择红光波段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbx_BandNInfrared.SelectedValue.ToString().Equals("请选择"))
            {
                MessageBox.Show("请选择近红外波段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string sSensorType = this.cbx_SensorType.SelectedValue.ToString();
            string sBandBlue = this.cbx_BandBlue.SelectedValue.ToString();
            string sBandGreen = this.cbx_BandGreen.SelectedValue.ToString();
            string sBandRed = this.cbx_BandRed.SelectedValue.ToString();
            string sBandNInfrared = this.cbx_BandNInfrared.SelectedValue.ToString();

            string sImageOutPath = this.txt_ImageOutPath.Text.Trim();
            #endregion

            #region 调用IDL程序
            //IDLSav的路径
            string sIDLSavPath = FileManage.getApplicatonPath();
            sIDLSavPath = sIDLSavPath + "IDLSav\\openfile.pro";
            COM_IDL_connectLib.COM_IDL_connectClass oCom = new COM_IDL_connectLib.COM_IDL_connectClass();
            try
            {
                //初始化
                oCom.CreateObject(0, 0, 0);
                //参数设置
                oCom.SetIDLVariable("filename", sFilename);
                oCom.SetIDLVariable("ImageOutPath", sIDLSavPath);
                oCom.SetIDLVariable("SensorType", sSensorType);
                oCom.SetIDLVariable("BandBlue", sBandBlue);
                oCom.SetIDLVariable("BandGreen", sBandGreen);
                oCom.SetIDLVariable("BandRed", sBandRed);
                oCom.SetIDLVariable("BandNInfrared", sBandNInfrared);

                //编译IDL功能源码
                oCom.ExecuteString(".compile '" + sIDLSavPath + "'");
                oCom.ExecuteString("OpenFile,filename,ImageOutPath=ImageOutPath,OutType,ErrorMSG=msg");
                object objArr = oCom.GetIDLVariable("msg");
                //MessageBox.Show(objArr.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oCom.DestroyObject();

                MessageBox.Show("格式转换完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_ok.Enabled = true;
                this.btn_OpenOutPut.Visible = true;

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
    }
}
