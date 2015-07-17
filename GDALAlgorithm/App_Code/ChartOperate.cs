using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraCharts;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GDALAlgorithm
{
    public class ChartOperate
    {
        public static Series CreateSeries(string typechar, Dictionary<string, string> diction)
        {
            Series ser = null;
            Dictionary<string, string> dicts = diction;
            switch (typechar)
            {
                case "柱状图":
                    ser = new Series("", ViewType.Bar);
                    break;
                case "线状图":
                    ser = new Series("", ViewType.Line);
                    break;
                default:
                    ser = new Series("", ViewType.Bar);
                    break;
            }

            ser.ArgumentScaleType = ScaleType.Qualitative;
            foreach (var item in dicts)
            {
                SeriesPoint sp = new SeriesPoint(item.Key, item.Value);
                ser.Points.Add(sp);
            }
            SecondaryAxisY sy = new SecondaryAxisY();
            sy.GridSpacing = 1;
            return ser;
        }
        /// <summary>
        /// 统计类型源
        /// </summary>
        /// <returns></returns>
        public static List<string> get_chartStaticsType()
        {
            List<string> list = new List<string>();
            SqlConnection con = DataBaseOperate.getSqlCon();
            string strsql = "select distinct STANAME from VISTATYPEINFO";
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                list.Add(read[0].ToString());
            }
            con.Close();
            return list;
        }

        /// <summary>
        /// 指标类型源
        /// </summary>
        /// <returns></returns>
        public static List<string> get_chartIndexType()
        {
            List<string> list = new List<string>();
            SqlConnection con = DataBaseOperate.getSqlCon();
            string strsql = "select distinct VINAME from VITYPEINFO";
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                list.Add(read[0].ToString());
            }
            con.Close();
            return list;
        }

        /// <summary>
        ///指标类型代码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string get_VITYPE(string name)
        {
            string strsql = "select VITYPE from VITYPEINFO where VINAME=@name";
            SqlParameter parm = new SqlParameter("@name", name);
            string result = DataBaseOperate.getResult(strsql, parm);
            return result;
        }

        /// <summary>
        ///指标类型中文名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string get_VINAME(string name)
        {
            string strsql = "select VINAME from VITYPEINFO where VITYPE=@name";
            SqlParameter parm = new SqlParameter("@name", name);
            string result = DataBaseOperate.getResult(strsql, parm);
            return result;
        }

        /// <summary>
        /// 传感器类型源
        /// </summary>
        /// <returns></returns>
        public static List<string> get_SensorSource()
        {
            List<string> list = new List<string>();
            SqlConnection con = DataBaseOperate.getSqlCon();
            string strsql = "select distinct SENSORNAME from SENSORTYPEINFO";
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                list.Add(read[0].ToString());
            }
            con.Close();
            return list;
        }
        /// <summary>
        ///传感器类型代码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string get_SensorTYPE(string name)
        {
            string strsql = "select SENSORTYPE from SENSORTYPEINFO where SENSORNAME=@name";
            SqlParameter parm = new SqlParameter("@name", name);
            string result = DataBaseOperate.getResult(strsql, parm);
            return result;
        }

        /// <summary>
        ///传感器类型中文名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string get_SensorNAME(string name)
        {
            string strsql = "select SENSORNAME from SENSORTYPEINFO where SENSORTYPE=@name";
            SqlParameter parm = new SqlParameter("@name", name);
            string result = DataBaseOperate.getResult(strsql, parm);
            return result;
        }

        /// <summary>
        ///统计类型中文名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string get_STANAME(string name)
        {
            string strsql = "select STANAME from VISTATYPEINFO where STATYPE=@name";
            SqlParameter parm = new SqlParameter("@name", name);
            string result = DataBaseOperate.getResult(strsql, parm);
            return result;
        }


        /// <summary>
        ///统计类型代码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string get_STATYPE(string name)
        {
            string strsql = "select STATYPE from VISTATYPEINFO where STANAME=@name";
            SqlParameter parm = new SqlParameter("@name", name);
            string result = DataBaseOperate.getResult(strsql, parm);
            return result;
        }

        public static DataTable get_VillPlotData(SqlParameter[] param)
        {
            string strsql = "select  * from VI_PLOT where PLOTID=@name and VI_TYPE=@VI_TYPE and VI_STATYPE=@VI_STATYPE and MONITORTIME between @date1 and @date2 and SENSORTYPE=@SENSORTYPE order by MONITORTIME asc";
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            cmd.Parameters.AddRange(param);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return convert_PlotTableValue(return_CHPlotTable(dt));
        }

        public static DataTable get_VillPlotMulitData(string strsql)
        {
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlDataAdapter sa = new SqlDataAdapter(strsql,con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return convert_PlotTableValue(return_CHPlotTable(dt));
        }

        public static Dictionary<string, string> get_VillPlotChartData(SqlParameter[] param)
        {
            Dictionary<string, string> dicts = new Dictionary<string, string>();
            string strsql = "select CONVERT(varchar(100), MONITORTIME, 111),VI_VALUE from VI_PLOT where PLOTID=@name and VI_TYPE=@VI_TYPE and VI_STATYPE=@VI_STATYPE and MONITORTIME between @date1 and @date2 and SENSORTYPE=@SENSORTYPE order by MONITORTIME asc";
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = DataBaseOperate.getSqlCmd(strsql, con);
            cmd.Parameters.AddRange(param);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dicts.Add(reader[0].ToString(), reader[1].ToString());
                }
                return dicts;
            }
            catch (Exception ex)
            { 
                MessageBox.Show("同一时间段内,存在两条记录！");
                return null;
            }
        }

        public static DataTable return_CHPlotTable(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string name = DataManager.get_TableCHName(dt.Columns[i].ColumnName);
                dt.Columns[i].ColumnName = name;
            }
            return dt;
        }
        /// <summary>
        /// 光谱表转换
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable convert_PlotTableValue(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = DataBaseOperate.get_PlotName(dt.Rows[i][0].ToString());
                dt.Rows[i][2] = DataBaseOperate.get_CropCHName(dt.Rows[i][2].ToString());
                dt.Rows[i][4] = get_VINAME(dt.Rows[i][4].ToString());
                dt.Rows[i][5] = get_STANAME(dt.Rows[i][5].ToString());
                dt.Rows[i][6] = get_SensorNAME(dt.Rows[i][6].ToString());
            }
            return dt;
        }

 
    }
}
