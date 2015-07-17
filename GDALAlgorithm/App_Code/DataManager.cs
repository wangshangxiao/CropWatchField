using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GDALAlgorithm
{
    public class DataManager
    {
        /// <summary>
        /// 通用的执行Adapter的sql语句返回DataTable
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static DataTable return_DataTable(string strsql)
        {
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlDataAdapter sa = new SqlDataAdapter(strsql, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return dt;
        }
        /// <summary>
        /// 通过Reader方法获取数据列表
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static List<string> return_DataList(string strsql)
        {
            List<string> list_table = new List<string>();
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list_table.Add(reader[0].ToString());
            }
            con.Close();
            return list_table;
        }
        /// <summary>
        /// 返回执行添加、删除情况
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static int return_OperateSucess(string strsql)
        {
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            //SqlTransaction trans = con.BeginTransaction();
            //cmd.Transaction = trans;
            //try
            //{
            int count = cmd.ExecuteNonQuery();
            return count;
            //}
            //catch
            //{
            //    trans.Rollback();
            //    return 0;
            //}
        }

        /// <summary>
        /// 返回数据库中五大类表的名字
        /// </summary>
        /// <returns></returns>
        //public static List<string> get_TableNames()
        //{
        //    string strsql = "SELECT name FROM sysobjects " +
        //    "WHERE xtype = 'U' and name like '%_COUNTY' or " +
        //    "name like '%_TOWN' or name like '%_VILLAGE' or name like '%_PLOT' order by name";
        //    List<string> list_table= return_DataList(strsql);
        //    List<string> list_CHtable = new List<string>();
        //    for (int i = 0; i < list_table.Count; i++)
        //    {
        //        string value=get_TableName(list_table[i].ToString());
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            list_CHtable.Add(value);
        //        }
        //    }
        //    return list_CHtable;
        //}
        /// <summary>
        /// 获取表的列名
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static List<string> get_ColumnsName(string tablename)
        {
            string strsql = string.Format("SELECT name FROM SysColumns WHERE id=Object_Id('{0}')", tablename);
            return return_DataList(strsql);
        }

        /// <summary>
        /// 返回数据库中字段的英文名
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static string get_TableEName(string tablename)
        {
            string strsql = "select TableEName from DIC_TABLENAME where TableCHName=@name";
            SqlParameter param = new SqlParameter("@name", tablename);
            string result = DataBaseOperate.getResult(strsql, param);
            return result;
        }

        /// <summary>
        /// 返回数据库中字段的中文名
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static string get_TableCHName(string tablename)
        {
            string strsql = "select TableCHName from DIC_TABLENAME where TableEName=@name";
            SqlParameter param = new SqlParameter("@name", tablename);
            string result = DataBaseOperate.getResult(strsql, param);
            return result;
        }
        /// <summary>
        /// 获取作物类型
        /// </summary>
        /// <returns></returns>
        public static List<string> get_CropType()
        {
            List<string> list_table = new List<string>();
            string strsql = "select CropName from CROPINFO WHERE DELFLAG='1'";
            return return_DataList(strsql);
        }

        /// <summary>
        /// 获取养分类型
        /// </summary>
        /// <returns></returns>
        public static List<string> get_NutrientType()
        {
            List<string> list_table = new List<string>();
            string strsql = "select NUTRIENT_NAME from SOILNUTRIENT_CODE WHERE DELFLAG='1'";
            return return_DataList(strsql);
        }

        /// <summary>
        /// 返回满足查询条件的数据表
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="cropcode"></param>
        /// <returns></returns>
        public static DataTable get_SelectResult(string tablename, string cropName, DateTime date1, DateTime date2)
        {
            string cropcode = DataBaseOperate.get_CropCode(cropName);
            string strsql = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}'", tablename, cropcode, date1, date2);
            return return_DataTable(strsql);
        }

        /// <summary>
        /// 返回满足查询条件的Soil数据表
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="cropcode"></param>
        /// <returns></returns>
        public static DataTable get_SelectSoilResult(string tablename, string cropName, string nutrientName, DateTime date1, DateTime date2)
        {
            string cropcode = DataBaseOperate.get_CropCode(cropName);
            string nutrient = DataBaseOperate.get_NutrientCode(nutrientName);
            string strsql = string.Format("select * from {0} where CROP_CODE='{1}' and NUTRIENT_CODE='{2}' and MONITORTIME between '{3}' and '{4}'", tablename, cropcode, nutrient, date1, date2);
            return return_DataTable(strsql);
        }

        //转换表中的值
        public static DataTable convert_TableValue(string rankname, string typename, DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (rankname)
                {
                    case "PLOT":
                        dt.Rows[i][0] = DataBaseOperate.get_PlotName(dt.Rows[i][0].ToString());
                        break;
                    case "COUNTY":
                        dt.Rows[i][0] = DataBaseOperate.getCountyName(dt.Rows[i][0].ToString());
                        break;
                    case "VILLAGE":
                        dt.Rows[i][0] = DataBaseOperate.getVillName(dt.Rows[i][0].ToString());
                        break;
                    case "TOWN":
                        dt.Rows[i][0] = DataBaseOperate.getTownName(dt.Rows[i][0].ToString());
                        break;
                }
                dt.Rows[i][2] = DataBaseOperate.get_CropCHName(dt.Rows[i][2].ToString());

                if (!typename.Contains("SOILNUTRIENT"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    {
                        dt.Rows[i][3] = Math.Round(Convert.ToDecimal(dt.Rows[i][3].ToString()), 3);
                    }
                }
                else
                {
                    dt.Rows[i][3] = DataBaseOperate.get_NutrientCHName(dt.Rows[i][3].ToString());
                    if (!string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    {
                        dt.Rows[i][4] = Math.Round(Convert.ToDecimal(dt.Rows[i][4].ToString()), 3);
                    }
                }
                
            }

            return dt;
        }
        //转换列名
        public static DataTable Convert_ColumeName(DataTable dt)
        { 
            for (int i = 0; i <dt.Columns.Count ; i++)
			{
                dt.Columns[i].ColumnName = DataManager.get_TableCHName(dt.Columns[i].ColumnName);
			}
            return dt;
        }

        //更新数据
        public static int alter_Data(string tablename, Dictionary<string, string> dicts)
        {
            int Count = 0;
            String Fields = " ";

            for (int i = 0; i < dicts.Keys.Count - 1; i++)
            {
                if (Count != 0)
                {
                    Fields += " and ";
                }
                Fields += dicts.Keys.ElementAt(i).ToString();
                Fields += "=";
                Fields += "'" + dicts[dicts.Keys.ElementAt(i)].ToString() + "'";
                Count++;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(dicts.Keys.ElementAt(dicts.Keys.Count - 1).ToString()).Append(" = '")
                .Append(dicts[dicts.Keys.ElementAt(dicts.Keys.Count - 1)].ToString())
                .Append("'");
            Fields += " ";
            String SqlString = "Update " + tablename + " Set " + sb.ToString() + " where " + Fields;
            return return_OperateSucess(SqlString);
        }
        /// <summary>
        /// 删除选中的记录
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="del_info"></param>
        /// <returns></returns>
        public static int del_Data(string tablename, Dictionary<string, string> dicts)
        {
            int Count = 0;
            String Fields = " ";
            foreach (KeyValuePair<string, string> item in dicts)
            {
                if (Count != 0)
                {
                    Fields += " and ";
                }
                Fields += item.Key.ToString();
                Fields += "=";
                Fields += "'" + item.Value.ToString() + "'";
                Count++;
            }
            Fields += " ";

            string strsql = string.Format("delete from {0} where {1}", tablename, Fields);
            return return_OperateSucess(strsql);
        }

        public static DataTable getVillageSelectResult(string tablename, string cropName, DateTime date1, DateTime date2,string townname) 
        {
            string cropcode = DataBaseOperate.get_CropCode(cropName);
            string towncode = DataBaseOperate.getTownCode(townname);
            string strsql = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and VILLAGECODE in (select VillCode from VILLAGE where TowCode='{4}')", tablename, cropcode, date1, date2, towncode);
            return return_DataTable(strsql);
        }
        public static DataTable get_VillageSoilResult(string tablename, string cropName, string nutrientName, DateTime date1, DateTime date2,string townname)
        {
            string cropcode = DataBaseOperate.get_CropCode(cropName);
            string nutrient = DataBaseOperate.get_NutrientCode(nutrientName);
            string towncode = DataBaseOperate.getTownCode(townname);
            string strsql = string.Format("select * from {0} where CROP_CODE='{1}' and NUTRIENT_CODE='{2}' and MONITORTIME between '{3}' and '{4}' and  VILLAGECODE in (select VillCode from VILLAGE where TowCode='{5}')", tablename, cropcode, nutrient, date1, date2, towncode);
            return return_DataTable(strsql);
        }

        public static DataTable getPlotSelectResult(string tablename, string cropName, DateTime date1, DateTime date2, string Villagename)
        {
            string cropcode = DataBaseOperate.get_CropCode(cropName);
            string Villagecode = DataBaseOperate.getVillCode(Villagename);
            string strsql = string.Format("select * from {0} where CROP_CODE='{1}' and MONITORTIME between '{2}' and '{3}' and  PLOTID in (select PlotID from PLOT_DKINFO where JMZ='{4}')", tablename, cropcode, date1, date2, Villagecode);
            return return_DataTable(strsql);
        }
        public static DataTable getSoilPlotSelectResult(string tablename, string cropName, string nutrientName, DateTime date1, DateTime date2, string Villagename)
        {
            string cropcode = DataBaseOperate.get_CropCode(cropName);
            string nutrient = DataBaseOperate.get_NutrientCode(nutrientName);
            string Villagecode = DataBaseOperate.getVillCode(Villagename);
            string strsql = string.Format("select * from {0} where CROP_CODE='{1}' and NUTRIENT_CODE='{2}' and MONITORTIME between '{3}' and '{4}' and  PLOTID in (select PlotID from PLOT_DKINFO where JMZ='{5}')", tablename, cropcode, nutrient, date1, date2, Villagecode);
            return return_DataTable(strsql);
        }
        
    }
}
