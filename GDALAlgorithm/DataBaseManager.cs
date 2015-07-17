using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GDALAlgorithm
{
    public partial class DataBaseManager : Form
    {
        public DataBaseManager()
        {
            InitializeComponent();
        }

        public void BindDataSource()
        {
            DataTable dt = null;
            //获取字段的英文名称
            //rankname = DataManager.get_TableEName(cmb_Rank.SelectedItem.ToString());
            typename = DataManager.get_TableEName(cmb_Type.SelectedItem.ToString());
            tablename = typename + "_" + rankname;
            if (!tablename.Contains("SOILNUTRIENT"))
            {
                switch (rankname)
                {
                    case "COUNTY":
                    case "TOWN":
                        dt = DataManager.get_SelectResult(tablename, cmbCropType.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value);
                        break;
                    case "VILLAGE":
                        dt = DataManager.getVillageSelectResult(tablename, cmbCropType.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value, rankCHname);
                        break;
                    case "PLOT":
                        dt = DataManager.getPlotSelectResult(tablename, cmbCropType.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value, rankCHname);
                        break;
                }
            }
            else
            {
                switch (rankname)
                {
                    case "COUNTY":
                    case "TOWN":
                        dt = DataManager.get_SelectSoilResult(tablename, cmbCropType.SelectedItem.ToString(), cmb_Nutrient.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value);
                        break;
                    case "VILLAGE":
                        dt = DataManager.get_VillageSoilResult(tablename, cmbCropType.SelectedItem.ToString(), cmb_Nutrient.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value,rankCHname);
                        break;

                    case "PLOT":
                        dt = DataManager.getSoilPlotSelectResult(tablename, cmbCropType.SelectedItem.ToString(), cmb_Nutrient.SelectedItem.ToString(), dT_maize_s.Value, dT_maize_e.Value, rankCHname);
                        break;
                }
            }
            if (dt.Rows.Count != 0)
            {

                dtInfo = DataManager.Convert_ColumeName(DataManager.convert_TableValue(rankname, typename, dt));
                InitDataSet();
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                if (!tablename.Contains("SOILNUTRIENT"))
                {
                    dataGridView1.Columns[3].ReadOnly = false;
                    dataGridView1.Columns[4].ReadOnly = true;

                }
                else
                {
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[4].ReadOnly = false;
                    dataGridView1.Columns[5].ReadOnly = true;

                }
            }
            else
            {
                MessageBox.Show("没有符合条件的记录");
                dataGridView1.DataSource = null;
            }

        }

        private void DataBaseManager_Load(object sender, EventArgs e)
        {
            TreeNodeOperate.generateTree(treeView1);
            cmbCropType.DataSource = DataManager.get_CropType();
            cmb_Type.SelectedIndex = 0;
        }
        string tablename = "";
        string rankname = "";
        string typename = "";
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            if (rankname != "")
            {
                if (cmb_Type.SelectedItem != null || cmbCropType.SelectedItem != null)
                {
                    BindDataSource();
                }
                else
                {
                    MessageBox.Show("查询类型或作物类型不能为空！");
                }
            }
            else
            {
                MessageBox.Show("请选择管理级别！");
            }
        }


        public Dictionary<string, string> return_Dicts(List<string> list_value)
        {
            Dictionary<string, string> dicts = new Dictionary<string, string>();
            string column1 = "";
            switch (rankname)
            {
                case "PLOT":
                    column1 = DataBaseOperate.get_PlotCodeName(list_value[0]);
                    break;
                case "COUNTY":
                    column1 = DataBaseOperate.getCountyCode(list_value[0]);
                    break;
                case "VILLAGE":
                    column1 = DataBaseOperate.getVillCode(list_value[0]);
                    break;
                case "TOWN":
                    column1 = DataBaseOperate.getTownCode(list_value[0]);
                    break;
            }
            dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[0].Name), column1);

            dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[1].Name), list_value[1]);
            dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[2].Name), DataBaseOperate.get_CropCode(list_value[2]));
            if (tablename.Contains("SOILNUTRIENT"))
            {
                dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[3].Name), DataBaseOperate.get_NutrientCode(list_value[3]));
                dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[4].Name), list_value[4]);
            }
            else
            {
                dicts.Add(DataManager.get_TableEName(dataGridView1.Columns[3].Name), list_value[3]);
            }
            return dicts;
        }



        //修改
        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count != 0)//是否选择某个单元格
            {
                List<string> list = new List<string>();
                //添加第一列的值
                list.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                //添加第二列的值
                list.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString());
                //添加第三列的值
                list.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());
                list.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
                if (tablename.Contains("SOILNUTRIENT"))
                {
                    list.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
                }

                int result = DataManager.alter_Data(tablename, return_Dicts(list));
                if (result > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                //绑定数据源
                BindDataSource();
            }
            else
            {
                MessageBox.Show("请选择修改项！");
            }
        }
        //删除
        private void button3_Click(object sender, EventArgs e)
        {

            int selectedRows = dataGridView1.SelectedRows.Count;
            if (selectedRows != 0)
            {
                int currentRow = dataGridView1.CurrentRow.Index;
                int result = 0;
                for (int i = 0; i < selectedRows; i++)
                {
                    List<string> list = new List<string>();
                    list.Add(dataGridView1.Rows[currentRow - i].Cells[0].Value.ToString());
                    list.Add(dataGridView1.Rows[currentRow - i].Cells[1].Value.ToString());
                    list.Add(dataGridView1.Rows[currentRow - i].Cells[2].Value.ToString());

                    if (tablename.Contains("SOILNUTRIENT"))
                    {
                        list.Add(dataGridView1.Rows[currentRow - i].Cells[3].Value.ToString());
                        list.Add(dataGridView1.Rows[currentRow - i].Cells[4].Value.ToString());
                    }
                    else
                    {
                        list.Add(dataGridView1.Rows[currentRow - i].Cells[3].Value.ToString());
                    }
                    Dictionary<string, string> dicts = return_Dicts(list);
                    result = DataManager.del_Data(tablename, dicts);
                }

                if (result > 0)
                {
                    MessageBox.Show("删除成功！");
                }
                BindDataSource();
            }
            else
            {
                MessageBox.Show("请选择删除项！");
            }
        }


        //根据选择的表名来更新养分列表
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string value = DataManager.get_TableName(cmb_Rank.SelectedItem.ToString());
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
            ExportDataToExcel.ExportExcel(dtInfo);
        }
        string rankCHname = "";
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = e.Node.Text;
            rankCHname = e.Node.Text;
            if (name.EndsWith("管理局"))
            {
                rankname = "TOWN";
            }
            else if (name.EndsWith("农场"))
            {
                rankname = "TOWN";
            }
            else if (name.EndsWith("作业区"))
            {
                rankname = "VILLAGE";
            }
            else if (name.EndsWith("作业站"))
            {
                rankname = "PLOT";
            }
        }
    }
}
