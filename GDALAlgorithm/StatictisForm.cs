using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GdalAlg;
using System.Threading;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace GDALAlgorithm
{
    public partial class StatictisForm : Form
    {

        public int ProgressBarInfo(double dfComplete, char[] strMessage, IntPtr pData)
        {
            StatictisForm form = (StatictisForm)Control.FromHandle(pData);

            int iValue = (int)(100 * dfComplete + 0.5);
            form.progressBar.Value = iValue;
            string strMsg = new string(strMessage);
            form.labelMessage.Text = strMsg;
            return 1;
        }

        public StatictisForm()
        {
            InitializeComponent();
            //this.txt_ImageInput.Text = Application.StartupPath + "\\BaseData\\soil_organic_fromYield_sobean_20140313.tif";
        }
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录
        System.Data.DataTable dtInfo;
        string[] res;//存储解析的文件名
        private void InitDataSet()
        {
            pageSize = 20;      //设置页面行数
            nMax = dtInfo.Rows.Count;
            pageCount = (nMax / pageSize);    //计算出总页数
            if ((nMax % pageSize) > 0) pageCount++;
            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始
            LoadData();
        }


        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行
            if (dtInfo.Rows.Count != 0)
            {
                System.Data.DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

                if (pageCurrent == pageCount)
                {
                    nEndPos = nMax;
                }
                else
                {
                    nEndPos = pageSize * pageCurrent;
                }

                nStartPos = nCurrent;
                lblPageCount.Text = "/" + pageCount.ToString();
                txtCurrentPage.Text = Convert.ToString(pageCurrent);


                //从元数据源复制记录行
                for (int i = nStartPos; i < nEndPos; i++)
                {

                    dtTemp.ImportRow(dtInfo.Rows[i]);
                    nCurrent++;
                }
                bindingSource1.DataSource = dtTemp;
                bindingNavigator1.BindingSource = bindingSource1;
                dgvInfo.DataSource = bindingSource1;
                dgvInfo.Visible = true;
            }
        }

        private void btn_classstatis_Click(object sender, EventArgs e)
        {
            #region 输入与输出路径条件判断

            string sImageInput = this.txt_ImageInput.Text.Trim();
            if (sImageInput.Equals(""))
            {
                MessageBox.Show("请选择待统计影像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string filename = sImageInput.Substring(sImageInput.LastIndexOf("\\")+1);
            res = filename.Split(new char[] { '_','.' }, StringSplitOptions.RemoveEmptyEntries);
            #endregion

            //调用进度条界面线程
            //Thread t = new Thread(new ThreadStart(thread1));
            //t.Start();
            #region 执行统计

            try
            {
                ProgressFunc pd = new ProgressFunc(this.ProgressBarInfo);
                IntPtr pre = this.Handle;
                int ire = 0;

                //string strInFile = @"D:\share\Hongxingtest\wxf\text_data\soil\soil_organic1.tif";
                char[] strInFileList = sImageInput.ToCharArray();

                string strRegionFile = System.Windows.Forms.Application.StartupPath + "\\BaseData\\hongxing_plot.shp";
                char[] strRegionFileList = strRegionFile.ToCharArray();

                string strField = "RASTERID";
                char[] strFieldList = strField.ToCharArray();

                int nCount = ReadShape.getShapeCount(strRegionFile);

                int[] pRegionCodeList = new int[nCount];

                double[] padfResultList = new double[nCount];
                ire = GdalAlgInterface.ImageStatisticalByVector(strInFileList, strRegionFileList, strFieldList, 2, pRegionCodeList, padfResultList, padfResultList.Length, pd, pre);
                //第三步
                //运行成功或失败，停止线程，即终止进度条。
                //t.Abort();
                string[,] arrStatistic = new string[nCount, 6];
                for (int i = 0; i < nCount; i++)
                {
                    string sRASTERID = pRegionCodeList[i].ToString();
                    //获得后，到PLOT_DKINFO中找到用sRASTERID找到对应PlotID
                    //string sPlotID = sRASTERID;///此处为测试
                    ///到PLOT_DKINFO中找到用sRASTERID找到对应GLQ,再用GLQ到TOWN表里找到对应的[TownName]进行显示到这里（PLOT_DKINFO.GLQ=TOWN.TowCode）；
                    //string sGLQName = "作业区_TOWN.TownName";
                    ///到PLOT_DKINFO中找到用sRASTERID找到对应JMZ，再用GLQ到VILLAGE表里找到对应的VillName进行显示到这里（PLOT_DKINFO.JMZ=VILLAGE.[VillCode]）；
                    ///string sJMZName = "作业站_VILLAGE.VillName";
                    ///到PLOT_DKINFO中找到用sRASTERID找到对应FULLNAME，显示到这里；
                    //string sPlotName = "地块名称_[PLOT_DKINFO].[FULLNAME]";

                    arrStatistic[i, 0] = res[2];//文件名中的时间，从文件名中解析，此处获取的系统时间只为测试
                    arrStatistic[i, 1] = DataBaseOperate.getTownName(DataBaseOperate.getGLQ(sRASTERID));
                    //arrStatistic[i, 1] = sGLQName;
                    arrStatistic[i, 2] = DataBaseOperate.getVillName(DataBaseOperate.getJMZ(sRASTERID));
                    //arrStatistic[i, 2] = sJMZName;
                    //arrStatistic[i, 3] = sPlotName;
                    arrStatistic[i, 3] = DataBaseOperate.getPlotName(sRASTERID);
                    arrStatistic[i, 4] = DataBaseOperate.getPlotId(sRASTERID);
                    //arrStatistic[i, 4] = sRASTERID; "区域代码"

                    if (res[0].Contains("RETRIEVAL"))
                    {
                        //int result = (int)(padfResultList[i]*100);
                        arrStatistic[i, 5] =Math.Round(padfResultList[i]).ToString();
                    }
                    else
                    {
                        arrStatistic[i, 5] = padfResultList[i].ToString("0.00");
                    }
                }

                string sResultTitle = DataBaseOperate.getTableTitleName(res[0],res[1]);
                //表头
                string[] arrName = { "监测时间", "作业区", "作业站", "地块名称", "地块编号", sResultTitle };
                //数组行按"，"拆分后转DataTable
                dtInfo = StringFormater.Convert(arrName, arrStatistic);
                InitDataSet();
                //dgvInfo.DataSource = dt;
            }
            catch (Exception ex)
            {
                //第三步
                //运行成功或失败，停止线程，即终止进度条。
                //t.Abort();
                MessageBox.Show(ex.Message);

            }
            #endregion
        }

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
                if (sFileName.Contains("SOILNUTRIENT"))
                {
                    MessageBox.Show("输入的数据不正确，请重新输入！");
                    return;
                }

                else
                {
                    this.txt_ImageInput.Text = sFileName;
                }
            }
        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "关闭")
            {
                this.Close();
            }
            if (e.ClickedItem.Text == "上一页")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
            if (e.ClickedItem.Text == "下一页")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }

        }

        private void btn_InDatabase_Click(object sender, EventArgs e)
        {
            //判断入库的结果
            int result = 0;
           //判断入库到那个表当中
            switch (res[0])
            {
                case "CROPYIELD":
                    string code1 = DataBaseOperate.getCrop_Code(res[1]);//获取crop_Code
                    for (int i = 1; i < dtInfo.Rows.Count - 1; i++)
                    {
                        SqlParameter[] param = new SqlParameter[] { 
                            new SqlParameter("@PLOTID", dtInfo.Rows[i]["地块编号"]),
                            new SqlParameter("@MONITORTIME", dtInfo.Rows[i]["监测时间"]),
                            new SqlParameter("@CROP_CODE",code1),
                            new SqlParameter("@CROP_YIELD", dtInfo.Rows[i][5]),
                            new SqlParameter("@RECORDTIME", DateTime.Now)};
                        result = DataBaseOperate.InsertDatabase("insert_Plot_CROPYIELD", param);
                    }
                    if (result > 0)
                    {

                        MessageBox.Show("入库成功！");
                    }

                    break;
                case "MATUREPERIOD":
                    string code3 = DataBaseOperate.getCrop_Code(res[1]);//获取crop_Code
                    for (int i = 1; i < dtInfo.Rows.Count - 1; i++)
                    {
                        SqlParameter[] param = new SqlParameter[] { 
                            new SqlParameter("@PLOTID", dtInfo.Rows[i]["地块编号"]),
                            new SqlParameter("@MONITORTIME", dtInfo.Rows[i]["监测时间"]),
                            new SqlParameter("@CROP_CODE",code3),
                            new SqlParameter("@MATURE_PERIOD", dtInfo.Rows[i][5]),
                            new SqlParameter("@RECORDTIME", DateTime.Now)};
                        result = DataBaseOperate.InsertDatabase("insert_Plot_MATUREPERIOD", param);
                    }
                    if (result > 0)
                    {

                        MessageBox.Show("入库成功！");
                    }
                    break;
                case "WATERRETRIEVAL":
                    string code4 = DataBaseOperate.getCrop_Code(res[1]);//获取crop_Code
                    for (int i = 1; i < dtInfo.Rows.Count - 1; i++)
                    {
                        SqlParameter[] param = new SqlParameter[] { 
                        new SqlParameter("@PLOTID", dtInfo.Rows[i]["地块编号"]),
                        new SqlParameter("@MONITORTIME", dtInfo.Rows[i]["监测时间"]),
                        new SqlParameter("@CROP_CODE",code4),
                        new SqlParameter("@WATERVALUE", dtInfo.Rows[i][5]),
                        new SqlParameter("@RECORDTIME", DateTime.Now)};
                        result = DataBaseOperate.InsertDatabase("insert_Plot_WATERRETRIEVAL", param);
                    }
                    if (result > 0)
                    {

                        MessageBox.Show("入库成功！");
                    }
                    break;
                case "CHLOROPHYLLRETRIEVAL":
                    string code5 = DataBaseOperate.getCrop_Code(res[1]);//获取crop_Code
                    for (int i = 1; i < dtInfo.Rows.Count - 1; i++)
                    {
                        SqlParameter[] param = new SqlParameter[] { 
                        new SqlParameter("@PLOTID", dtInfo.Rows[i]["地块编号"]),
                        new SqlParameter("@MONITORTIME", dtInfo.Rows[i]["监测时间"]),
                        new SqlParameter("@CROP_CODE",code5),
                        new SqlParameter("@CHLOROPHYLLVALUE", dtInfo.Rows[i][5]),
                        new SqlParameter("@RECORDTIME", DateTime.Now)};
                        result = DataBaseOperate.InsertDatabase("insert_Plot_CHLOROPHYLLRETRIEVAL", param);
                    }
                    if (result > 0)
                    {

                        MessageBox.Show("入库成功！");
                    }
                    break;

            }

        }
        //输出到Excel
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         ExportDataToExcel.ExportExcel(dtInfo);   
        }

       
    }
}
