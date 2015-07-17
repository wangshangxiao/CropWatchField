using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GDALAlgorithm
{
    public partial class SoilAggregateToTown : Form
    {
        public SoilAggregateToTown()
        {
            InitializeComponent();
        }

        //用来展示结果的datatable,最终绑定到datagridview上
        DataTable dt = AggregateToTown.CreateSoilDatatable();
        //处在选择的时间范围内的天数
        int date_count = 0;
        //获取具体的时间列表
        List<string> date_list = null;
        //获取Towncount
        int TownCount = 0;
        //获取具体的VillageCode
        List<string> TownCode_list = null;
        //获取CropCount
        int CropCount = 0;
        //获取具体的CropCode
        List<string> CropCode_list = null;
        //获取nutrientCount
        int nutrientCount = 0;
        //获取nutrient_code
        List<string> nutrient_list = null;

        private void btn_calculation_Click(object sender, EventArgs e)
        {
            date_count = DataBaseOperate.get_DateCount(dT_maize_s.Value, dT_maize_e.Value, "SOILNUTRIENT_PLOT");
            date_list = DataBaseOperate.get_DateDetail(dT_maize_s.Value, dT_maize_e.Value, "SOILNUTRIENT_PLOT");
            //获取Towncount
            TownCount = AggregateToTown.get_TownCount();
            //获取具体的TownCode
            TownCode_list = AggregateToTown.get_TownCode();
            CropCount = DataBaseOperate.get_CropCount();
            CropCode_list = DataBaseOperate.get_CropCode();
            nutrientCount = DataBaseOperate.get_NutrientCount();
            nutrient_list = DataBaseOperate.get_NutrientCode();
            if (date_count != 0)
            {
                for (int i = 0; i < date_count; i++)//datetime循环
                {
                    for (int j = 0; j < TownCount; j++)//villagecode循环
                    {
                        for (int k = 0; k < CropCount; k++) //crop_count循环
                        {
                            for (int h = 0; h < nutrientCount; h++)
                            {
                                //输入查询限制条件，执行存储过程
                                SqlParameter[] param = new SqlParameter[] {
                                    new SqlParameter("@time",Convert.ToDateTime(date_list[i])),
                                    new SqlParameter("@code",CropCode_list[k]),
                                    new SqlParameter("@towncode",TownCode_list[j]),
                                    new SqlParameter("@nutrient_code",nutrient_list[h]),
                                    new SqlParameter("@sum_result",SqlDbType.Float)
                                 };
                                param[4].Direction = ParameterDirection.Output;
                                string value = AggregateToTown.get_SoilTownValue("calc_Town_SOILNUTRIENT", param);
                                if (value != "")
                                {
                                    DataRow row = dt.NewRow();
                                    row["作业区"] = DataBaseOperate.getTownName(TownCode_list[j]);
                                    row["监测时间"] = Convert.ToDateTime(date_list[i]).ToShortDateString();
                                    row["作物类型"] = DataBaseOperate.get_CropCHName(CropCode_list[k]);
                                    row["养分类型"] = DataBaseOperate.get_NutrientCHName(nutrient_list[h]);
                                    row["汇总结果"] = float.Parse(value);
                                    row["汇总时间"] = DateTime.Now.ToShortDateString();
                                    dt.Rows.Add(row);
                                }
                            }

                        }
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("请检查输入条件或统计数据！");
                }
                else
                {
                    dataGridView1.DataSource = dt;
                }
            }

            else
            {
                MessageBox.Show("此时间段内，没有统计数据！");
            }

            InitDataSet();
        }

        private void btn_Input_Click(object sender, EventArgs e)
        {
            int reslut = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string TownCode = DataBaseOperate.getTownCode(dt.Rows[i][0].ToString());
                DateTime MONITORTIME = Convert.ToDateTime(dt.Rows[i][1]);
                string CROP_CODE = DataBaseOperate.get_CropCode(dt.Rows[i][2].ToString());
                string nutrient_code = DataBaseOperate.get_NutrientCode(dt.Rows[i][3].ToString());
                float value = float.Parse(dt.Rows[i][4].ToString());
                SqlParameter[] param = new SqlParameter[] {
                                new SqlParameter("@TOWNCODE",TownCode),
                                new SqlParameter("@MONITORTIME",MONITORTIME),
                                new SqlParameter("@CROP_CODE",CROP_CODE),
                                new SqlParameter("@NUTRIENT_CODE",nutrient_code),
                                new SqlParameter("@SOIL_NUTRIENT",value),
                                new SqlParameter("@RECORDTIME",DateTime.Now.ToShortDateString())
                                 };
                reslut = AggregateToTown.insert_Town_SOILNUTRIENT("insert_town_SOILNUTRIENT", param);
            }
            if (reslut > 0)
            {
                MessageBox.Show("数据库入库成功！");
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportDataToExcel.ExportExcel(dt);  
        }


    }
}
