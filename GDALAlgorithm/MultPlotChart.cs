using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraCharts;

namespace GDALAlgorithm
{
    public partial class MultPlotChart : Form
    {
        public MultPlotChart()
        {
            InitializeComponent();
        }

        private void MultPlotChart_Load(object sender, EventArgs e)
        {
            list_IndexType.DataSource = ChartOperate.get_chartIndexType();
            string[] items = { "线状图", "柱状图" };
            TreeNodeOperate.generatePlotTree(treeView2);
            cmb_StaticsType.DataSource = ChartOperate.get_chartStaticsType();
            cmb_ChartType.DataSource = items;
            cmb_sensorType.DataSource = ChartOperate.get_SensorSource();
        }

        string plotname = "";
        string charttype = "线状图";
        DataTable dt = null;//数据源
        private void btn_Chart_Click(object sender, EventArgs e)
        {
            chartControl1.Series.Clear();
            if (!string.IsNullOrEmpty(plotname))
            {
                if (list_IndexType.SelectedItem != null && cmb_StaticsType.SelectedItem != null && cmb_ChartType.SelectedItem != null&&cmb_sensorType.SelectedItem!=null)
                {
                    string StaticsType = ChartOperate.get_STATYPE(cmb_StaticsType.SelectedItem.ToString()).Trim();
                    string sensortype = ChartOperate.get_SensorTYPE(cmb_sensorType.SelectedItem.ToString());
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select  * from VI_PLOT where PLOTID='")
                        .Append(plotname + "' and  VI_STATYPE='")
                        .Append(StaticsType + "' and MONITORTIME between '")
                        .Append(dT_maize_s.Value + "' and '" + dT_maize_e.Value + "' and SENSORTYPE='")
                    .Append(sensortype+"' and VI_TYPE in ('");
                    for (int i = 0; i < list_IndexType.SelectedItems.Count; i++)
                    {
                        string value = ChartOperate.get_VITYPE(list_IndexType.SelectedItems[i].ToString()).Trim();
                        sb.Append(value + "','");
                    }
                    string strsql = sb.ToString();
                    strsql = strsql.Substring(0, strsql.LastIndexOf(",")) + ")";//以上全部拼接SQL语句
                    dt = ChartOperate.get_VillPlotMulitData(strsql);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("没有满足条件的数据！");
                    }
                    else
                    {
                        for (int i = 0; i < list_IndexType.SelectedItems.Count; i++)
                        {
                            string IndexType = ChartOperate.get_VITYPE(list_IndexType.SelectedItems[i].ToString());
                            SqlParameter[] param2 = new SqlParameter[] {
                                    new SqlParameter("@name",plotname),
                                    new SqlParameter("@VI_TYPE",IndexType),
                                    new SqlParameter("@VI_STATYPE",StaticsType),
                                    new SqlParameter("@SENSORTYPE",sensortype),
                                    new SqlParameter("@date1",Convert.ToDateTime(dT_maize_s.Value)),
                                    new SqlParameter("@date2",Convert.ToDateTime(dT_maize_e.Value))
                            };

                            Dictionary<string, string> dicts = dicts = ChartOperate.get_VillPlotChartData(param2);

                            Series ser = ChartOperate.CreateSeries(charttype, dicts);
                            ser.Name = list_IndexType.SelectedItems[i].ToString();
                            chartControl1.Series.Add(ser);
                            chartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                            chartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.Top;

                            //chartControl1.ExportToImage(@"C:\Users\LYM\Desktop\1.png", ImageFormat.Png);
                        }

                        dataGridView1.DataSource = dt;
                        InitDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("统计指标或图表类型不能为空！");
                }
            }

            else
            {
                MessageBox.Show("请选择地块！");
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 5)
            {
                plotname = DataBaseOperate.getChartPlotId(e.Node.Text);
            }
            else
            {
                plotname = "";
            }
        }

        private void cmb_ChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            charttype = cmb_ChartType.SelectedItem.ToString();
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
}
