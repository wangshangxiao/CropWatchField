using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CropWatchField
{
     public class DataBase_ExportWord
    {
         /// <summary>
         /// 返回作业站符合条件的非Soil表
         /// </summary>
         /// <param name="tablename"></param>
         /// <param name="datetime"></param>
         /// <param name="cropcode"></param>
         /// <returns></returns>
         public static DataTable Return_VillageTable(string tablename, string datetime, string cropcode)
         {
             string sqlstr="";
             switch(tablename)
             {
                 case "CHLOROPHYLLRETRIEVAL":
                     sqlstr = "select VILLAGECODE,MONITORTIME,CROP_CODE,CHLOROPHYLLVALUE FROM CHLOROPHYLLRETRIEVAL_VILLAGE where MONITORTIME='" + datetime + "' and CROP_CODE='"+cropcode+"'";
                     break;
                 case "CROPYIELD":
                     sqlstr = "select VILLAGECODE,MONITORTIME,CROP_CODE,CROP_YIELD FROM CROPYIELD_VILLAGE where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
                 case "WATERRETRIEVAL":
                     sqlstr = "select VILLAGECODE,MONITORTIME,CROP_CODE,WATERVALUE FROM WATERRETRIEVAL_VILLAGE where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
                 case "MATUREPERIOD":
                     sqlstr = "select VILLAGECODE,MONITORTIME,CROP_CODE,MATURE_PERIOD FROM MATUREPERIOD_VILLAGE where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
             }
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlDataAdapter sa = new SqlDataAdapter(sqlstr, con);
             DataTable dt = new DataTable();
             sa.Fill(dt);
             return Convert_TableValue(Convert_TableName(dt));
         }

         /// <summary>
         /// 返回作业站符合条件的Soil表
         /// </summary>
         /// <param name="tablename"></param>
         /// <param name="datetime"></param>
         /// <param name="cropcode"></param>
         /// <returns></returns>
         public static DataTable Return_VillageSoilTable(string datetime, string cropcode,string nuterient)
         {
             string sqlstr = "select VILLAGECODE,MONITORTIME,CROP_CODE,NUTRIENT_CODE,SOIL_NUTRIENT FROM SOILNUTRIENT_VILLAGE where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "' and NUTRIENT_CODE='" + nuterient+"'";
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlDataAdapter sa = new SqlDataAdapter(sqlstr, con);
             DataTable dt = new DataTable();
             sa.Fill(dt);
             if (dt.Rows.Count != 0)
             {
                 return Convert_TableValue(Convert_TableName(dt));
             }
             else
             {
                 return null;
             }
         }

         /// <summary>
         /// 返回作业区符合条件的非Soil表
         /// </summary>
         /// <param name="tablename"></param>
         /// <param name="datetime"></param>
         /// <param name="cropcode"></param>
         /// <returns></returns>
         public static DataTable Return_TownTable(string tablename, string datetime, string cropcode)
         {
             string sqlstr = "";
             switch (tablename)
             {
                 case "CHLOROPHYLLRETRIEVAL":
                     sqlstr = "select TOWNCODE,MONITORTIME,CROP_CODE,CHLOROPHYLLVALUE FROM CHLOROPHYLLRETRIEVAL_TOWN where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
                 case "CROPYIELD":
                     sqlstr = "select TOWNCODE,MONITORTIME,CROP_CODE,CROP_YIELD FROM CROPYIELD_TOWN where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
                 case "WATERRETRIEVAL":
                     sqlstr = "select TOWNCODE,MONITORTIME,CROP_CODE,WATERVALUE FROM WATERRETRIEVAL_TOWN where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
                 case "MATUREPERIOD":
                     sqlstr = "select TOWNCODE,MONITORTIME,CROP_CODE,MATURE_PERIOD FROM MATUREPERIOD_TOWN where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "'";
                     break;
             }
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlDataAdapter sa = new SqlDataAdapter(sqlstr, con);
             DataTable dt = new DataTable();
             sa.Fill(dt);
             return Convert_TableValue(Convert_TableName(dt));
         }

         /// <summary>
         /// 返回作业区符合条件的Soil表
         /// </summary>
         /// <param name="tablename"></param>
         /// <param name="datetime"></param>
         /// <param name="cropcode"></param>
         /// <returns></returns>
         public static DataTable Return_TownSoilTable(string datetime, string cropcode, string nuterient)
         {
             string sqlstr = "select TOWNCODE,MONITORTIME,CROP_CODE,NUTRIENT_CODE,SOIL_NUTRIENT FROM SOILNUTRIENT_TOWN where MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "' and NUTRIENT_CODE='" + nuterient + "'";
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlDataAdapter sa = new SqlDataAdapter(sqlstr, con);
             DataTable dt = new DataTable();
             sa.Fill(dt);
             if (dt.Rows.Count != 0)
             {
                 return Convert_TableValue(Convert_TableName(dt));
             }
             else
             {
                 return null;
             }
         }
         /// <summary>
         /// 获取设定范围内的时间
         /// </summary>
         /// <param name="tablename"></param>
         /// <param name="date1"></param>
         /// <param name="date2"></param>
         /// <returns></returns>
         public static List<string> Get_TimeCount(string rank,string tablename,DateTime date1,DateTime date2)
         {
             List<string> list = new List<string>();
             string sqlstr = "";
             switch (tablename)
             {
                 case "CHLOROPHYLLRETRIEVAL":
                     sqlstr = "select distinct MONITORTIME FROM CHLOROPHYLLRETRIEVAL_"+rank+" where MONITORTIME between '"+date1 +"' and '"+date2+"'";
                     break;
                 case "CROPYIELD":
                     sqlstr = "select distinct MONITORTIME FROM CROPYIELD_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "WATERRETRIEVAL":
                     sqlstr = "select distinct MONITORTIME FROM WATERRETRIEVAL_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "MATUREPERIOD":
                     sqlstr = "select distinct MONITORTIME FROM MATUREPERIOD_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "SOILNUTRIENT":
                     sqlstr = "select distinct MONITORTIME FROM SOILNUTRIENT_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
             }
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlCommand cmd = DataBaseOperate.getSqlCmd(sqlstr, con);
             SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             while (dr.Read())
             {
                 list.Add(dr["MONITORTIME"].ToString());
             }
             con.Close();
             return list;
         }
         /// <summary>
         /// 获取作物类型
         /// </summary>
         /// <param name="tablename"></param>
         /// <param name="date1"></param>
         /// <param name="date2"></param>
         /// <returns></returns>
         public static List<string> Get_CropCount(string rank,string tablename, DateTime date1, DateTime date2)
         {
             List<string> list = new List<string>();
             string sqlstr = "";
             switch (tablename)
             {
                 case "CHLOROPHYLLRETRIEVAL":
                     sqlstr = "select distinct CROP_CODE FROM CHLOROPHYLLRETRIEVAL_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "CROPYIELD":
                     sqlstr = "select distinct CROP_CODE FROM CROPYIELD_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "WATERRETRIEVAL":
                     sqlstr = "select distinct CROP_CODE FROM WATERRETRIEVAL_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "MATUREPERIOD":
                     sqlstr = "select distinct CROP_CODE FROM MATUREPERIOD_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
                 case "SOILNUTRIENT":
                     sqlstr = "select distinct CROP_CODE FROM SOILNUTRIENT_" + rank + " where MONITORTIME between '" + date1 + "' and '" + date2 + "'";
                     break;
             }
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlCommand cmd = DataBaseOperate.getSqlCmd(sqlstr, con);
             SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             while (dr.Read())
             {
                 list.Add(dr["CROP_CODE"].ToString());
             }
             con.Close();
             return list;
         }
         /// <summary>
         /// 获取养分类型
         /// </summary>
         /// <param name="Crop_Code"></param>
         /// <param name="date1"></param>
         /// <param name="date2"></param>
         /// <returns></returns>
         public static List<string> Get_NuterientCount(string Crop_Code,DateTime date1, DateTime date2)
         {
             List<string> list = new List<string>();
             string sqlstr = "select distinct NUTRIENT_CODE FROM SOILNUTRIENT_VILLAGE where CROP_CODE='"+Crop_Code+"' and "+ "MONITORTIME between '" + date1 + "' and '" + date2 + "'";
             SqlConnection con = DataBaseOperate.getSqlCon();
             SqlCommand cmd = DataBaseOperate.getSqlCmd(sqlstr, con);
             SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             while (dr.Read())
             {
                 list.Add(dr["NUTRIENT_CODE"].ToString());
             }
             con.Close();
             return list;
         }
         
         /// <summary>
         /// 转换表头
         /// </summary>
         /// <param name="dt"></param>
         /// <returns></returns>
         public static DataTable Convert_TableName(DataTable dt)
         {
             for (int i = 0; i < dt.Columns.Count; i++)
             {
                 switch (dt.Columns[i].ColumnName)
                 {
                     case "VILLAGECODE":
                         dt.Columns[i].ColumnName = "作业站";
                         break;
                     case "TOWNCODE":
                         dt.Columns[i].ColumnName = "作业区";
                         break;
                     case "MONITORTIME":
                         dt.Columns[i].ColumnName = "检测时间";
                         break;
                     case "CROP_CODE":
                         dt.Columns[i].ColumnName = "作物类型";
                         break;
                     case "NUTRIENT_CODE":
                         dt.Columns[i].ColumnName = "养分类型";
                         break;
                     case "WATERVALUE":
                     case "SOIL_NUTRIENT":
                     case "MATURE_PERIOD":
                     case "CROP_YIELD":
                     case "CHLOROPHYLLVALUE":
                         dt.Columns[i].ColumnName = "汇总值";
                         break;
                 }
             }
             return dt;

         }
         
         /// <summary>
         /// 转换表中的值
         /// </summary>
         /// <param name="dt"></param>
         /// <returns></returns>
         public static DataTable Convert_TableValue(DataTable dt)
         {
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 if (dt.Columns.Count == 4)//根据输出列数判断是否是Soil
                 {
                     if (dt.Columns[0].ColumnName == "作业站")//根据列名判断作物范围
                     {
                         dt.Rows[i][0] = DataBaseOperate.getVillName(dt.Rows[i][0].ToString());
                     }
                     else if (dt.Columns[0].ColumnName == "作业区")
                     {
                         dt.Rows[i][0] = DataBaseOperate.getTownName(dt.Rows[i][0].ToString());
                     }
                     dt.Rows[i][1] = ((DateTime)dt.Rows[i][1]).ToShortDateString();
                     dt.Rows[i][2] = DataBaseOperate.get_CropCHName(dt.Rows[i][2].ToString());
                     dt.Rows[i][3] = Math.Round((double)dt.Rows[i][3], 3);
                 }
                 else//soil
                 {
                     if (dt.Columns[0].ColumnName == "作业站")
                     {
                         dt.Rows[i][0] = DataBaseOperate.getVillName(dt.Rows[i][0].ToString());
                     }
                     else if (dt.Columns[0].ColumnName == "作业区")
                     {
                         dt.Rows[i][0] = DataBaseOperate.getTownName(dt.Rows[i][0].ToString());
                     }
                     dt.Rows[i][1] = ((DateTime)dt.Rows[i][1]).ToShortDateString();
                     dt.Rows[i][2] = DataBaseOperate.get_CropCHName(dt.Rows[i][2].ToString());
                     dt.Rows[i][3] = DataBaseOperate.get_NutrientCHName(dt.Rows[i][3].ToString());
                     dt.Rows[i][4] = Math.Round((double)dt.Rows[i][4], 4);
                 }
             }
             return dt;
         }

    }
}
