using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace GDALAlgorithm
{
    public partial class WDLChart : Form
    {
        public WDLChart()
        {
            InitializeComponent();
        }
        string rankCHname = "";//级别中文名
        string tablename = "";//表名
        string rankname = "";//级别名
        string typename = "";//类型名
        string treeNodeEName = "";//选取指标的英文名
        DataTable dt = null;//数据源
        private void WDLChart_Load(object sender, EventArgs e)
        {
            TreeNodeOperate.generatePlotTree(treeView2);
            cmbCropType.DataSource = DataManager.get_CropType();
            string[] items = { "柱状图", "线状图" };
            cmb_ChartType.DataSource = items;
            cmb_Type.SelectedIndex = 1;
        }

        private void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Type.SelectedItem.ToString().Contains("土壤"))
            {
                label2.Visible = true;
                cmb_Nutrient.Visible = true;
                cmb_Nutrient.DataSource = DataManager.get_NutrientType();
            }
            else
            {
                label2.Visible = false;
                cmb_Nutrient.Visible = false;
                cmb_Nutrient.DataSource = null;
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            rankCHname = e.Node.Text;
            if (rankCHname.EndsWith("农场"))
            {
                rankname = "COUNTY";
                treeNodeEName = DataBaseOperate.getCountyCode(rankCHname);
            }
            else if (rankCHname.EndsWith("作业区"))
            {
                rankname = "TOWN";
                treeNodeEName = DataBaseOperate.getTownCode(rankCHname);
            }
            else if (rankCHname.EndsWith("作业站"))
            {
                rankname = "VILLAGE";
                treeNodeEName = DataBaseOperate.getVillCode(rankCHname);
            }
            else
            {
                rankname = "PLOT";
                treeNodeEName = DataBaseOperate.get_PlotCodeName(rankCHname);
            }
        }

        private void btn_Chart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rankCHname))
            {
                typename = DataManager.get_TableEName(cmb_Type.SelectedItem.ToString());
                tablename = typename + "_" + rankname;
                if (!tablename.Contains("SOILNUTRIENT"))
                {
                    ChartObject co = new ChartObject();
                    co.cropcode = DataBaseOperate.get_CropCode(cmbCropType.SelectedItem.ToString());
                    co.datemin = dT_maize_s.Value;
                    co.datemax = dT_maize_e.Value;
                    co.treeNodeEName = treeNodeEName;
                    co.chartType = cmb_ChartType.SelectedItem.ToString();
                    BindDataSource(co);
                }
                else
                {
                    ChartObject co = new ChartObject();
                    co.cropcode = DataBaseOperate.get_CropCode(cmbCropType.SelectedItem.ToString());
                    co.datemin = dT_maize_s.Value;
                    co.datemax = dT_maize_e.Value;
                    co.treeNodeEName = treeNodeEName;
                    co.nutrientcode = DataBaseOperate.get_NutrientCode(cmb_Nutrient.SelectedItem.ToString());
                    co.chartType = cmb_ChartType.SelectedItem.ToString();
                    BindSoilDataSource(co);
                }
                InitDataSet();
            }
            else
            {
                MessageBox.Show("请选择监测类型！");
            }
            

        }
        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="co"></param>
        public void BindDataSource(ChartObject co)
        {
            chartControl1.Series.Clear();
            //DataTable dt = null;
            switch (rankname)
            {
                case "COUNTY":
                    string str_county = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and COUNTYCODE='{4}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName);
                    dt = DataManager.return_DataTable(str_county);
                    break;
                case "TOWN":
                    string str_town = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and TOWNCODE='{4}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName);
                    dt = DataManager.return_DataTable(str_town);
                    break;
                case "VILLAGE":
                    string str_village = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and VILLAGECODE='{4}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName);
                    dt = DataManager.return_DataTable(str_village);
                    break;
                case "PLOT":
                    string str_Plot = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and PLOTID='{4}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName);
                    dt = DataManager.return_DataTable(str_Plot);
                    break;
            }

            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = DataManager.Convert_ColumeName(DataManager.convert_TableValue(rankname, typename, dt));
                //dataGridView1.DataSource = dt;
                Dictionary<string, string> dicts = new Dictionary<string, string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dicts.Add(((DateTime)dt.Rows[i][1]).ToShortDateString(), dt.Rows[i][3].ToString());
                }
                Series ser = ChartOperate.CreateSeries(co.chartType, dicts);
                ser.Name = cmb_Type.SelectedItem.ToString();
                chartControl1.Series.Add(ser);
                chartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                chartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
            }
            else
            {
                MessageBox.Show("没有符合条件的记录");
                dataGridView1.DataSource = null;
            }

        }
        /// <summary>
        /// 绑定Soil数据源
        /// </summary>
        /// <param name="co"></param>
        public void BindSoilDataSource(ChartObject co)
        {
            chartControl1.Series.Clear();
            //DataTable dt = null;
            switch (rankname)
            {
                case "COUNTY":
                    string str_county = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and COUNTYCODE='{4}' and NUTRIENT_CODE='{5}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName, co.nutrientcode);
                    dt = DataManager.return_DataTable(str_county);
                    break;
                case "TOWN":
                    string str_town = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and TOWNCODE='{4}' and NUTRIENT_CODE='{5}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName, co.nutrientcode);
                    dt = DataManager.return_DataTable(str_town);
                    break;
                case "VILLAGE":
                    string str_village = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and VILLAGECODE='{4}' and NUTRIENT_CODE='{5}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName, co.nutrientcode);
                    dt = DataManager.return_DataTable(str_village);
                    break;
                case "PLOT":
                    string str_Plot = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and PLOTID='{4}' and NUTRIENT_CODE='{5}' order by MONITORTIME asc", tablename, co.cropcode, co.datemin, co.datemax, co.treeNodeEName, co.nutrientcode);
                    dt = DataManager.return_DataTable(str_Plot);
                    break;
            }

            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = DataManager.Convert_ColumeName(DataManager.convert_TableValue(rankname, typename, dt));
                Dictionary<string, string> dicts = new Dictionary<string, string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dicts.Add(((DateTime)dt.Rows[i][1]).ToShortDateString(), dt.Rows[i][4].ToString());
                }
                Series ser = ChartOperate.CreateSeries(co.chartType, dicts);
                ser.Name = cmb_Type.SelectedItem.ToString();
                chartControl1.Series.Add(ser);
            }
            else
            {
                MessageBox.Show("没有符合条件的记录");
                dataGridView1.DataSource = null;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportDataToExcel.ExportExcel(dt);  
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


        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录
        private void InitDataSet()
        {
            pageSize = 20;      //设置页面行数
            nMax = dt.Rows.Count;
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
            if (dt.Rows.Count != 0)
            {
                System.Data.DataTable dtTemp = dt.Clone();   //克隆DataTable结构框架

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

                    dtTemp.ImportRow(dt.Rows[i]);
                    nCurrent++;
                }
                bindingSource1.DataSource = dtTemp;
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.Visible = true;
            }
        }
    }

    public class ChartObject
    {
        public string cropcode;
        public DateTime datemin;
        public DateTime datemax;
        public string nutrientcode;
        public string treeNodeEName;//节点英文名
        public string chartType;//图表线型

    }
}
