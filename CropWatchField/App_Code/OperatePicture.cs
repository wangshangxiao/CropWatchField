using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CropWatchField
{
    public class OperatePicture
    {
        /// <summary>
        /// 非Soil图片入库
        /// </summary>
        /// <param name="list_picname"></param>
        public static void InsertPicture(string[] list_picname)
        {
            
            byte[] buffer = Return_Buffer();
            //string strSql = "insert into MONITOR_PICTURE(INDICATOR_NAME,CROP_CODE,MONITORTIME,PIC_MAP) values(@INDICATOR_NAME,@CROP_CODE,@MONITORTIME,@PIC_MAP)";
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = new SqlCommand("insert_Picture", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INDICATOR_NAME", list_picname[0]);
            cmd.Parameters.AddWithValue("@CROP_CODE", DataBaseOperate.getCrop_Code(list_picname[1]));
            cmd.Parameters.AddWithValue("@MONITORTIME", Convert.ToDateTime(list_picname[2]).ToShortDateString());
            cmd.Parameters.AddWithValue("@PIC_MAP", buffer);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Soil图片入库
        /// </summary>
        /// <param name="list_picname"></param>
        public static void InsertSoilPicture(string[] list_picname)
        {
            //string pic_date = list_picname[3].Substring(0, list_picname[3].IndexOf('.'));
            byte[] buffer = Return_Buffer();
            //string strSql2 = "insert into MONITOR_PICTURE(INDICATOR_NAME,NUTRIENT_CODE,CROP_CODE,MONITORTIME,PIC_MAP) values(@INDICATOR_NAME,@NUTRIENT_CODE,@CROP_CODE,@MONITORTIME,@PIC_MAP)";
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = new SqlCommand("insert_SoilPicture", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INDICATOR_NAME", list_picname[0]);
            cmd.Parameters.AddWithValue("@CROP_CODE", DataBaseOperate.getCrop_Code(list_picname[1]));
            cmd.Parameters.AddWithValue("@NUTRIENT_CODE", DataBaseOperate.getNUTRIENT_CODE(list_picname[2]));
            cmd.Parameters.AddWithValue("@MONITORTIME", Convert.ToDateTime(list_picname[3]).ToShortDateString());
            cmd.Parameters.AddWithValue("@PIC_MAP", buffer);
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// 图片流
        /// </summary>
        /// <returns></returns>
        public static byte[] Return_Buffer()
        {
            string filepath = Application.StartupPath + @"\Image\1.jpg";
            FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            stream.Close();
            return buffer;
        }

        /// <summary>
        /// 将图片流输出为文件
        /// </summary>
        /// <param name="tablename"></param>
        public static string ExportPicture(string type, string datetime,string cropcode)
        {
            byte[] imagebytes;
            string datetimeforamt = datetime.Substring(0, datetime.LastIndexOf(" ")).Replace('/', '-');
            string cropName = DataBaseOperate.get_CropCHName(cropcode);
            string pathname = Application.StartupPath + @"\Image\" + type + "_" + datetimeforamt + "_" + cropName + ".jpg";
            string strSql = "select PIC_MAP from MONITOR_PICTURE where INDICATOR_NAME='" + type + "' and MONITORTIME='" + datetime + "' and CROP_CODE='"+cropcode+"'";
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = new SqlCommand(strSql, con);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string value_path = "";
            while (reader.Read())
            {
                //获取图片数据
                imagebytes = (byte[])reader["PIC_MAP"];
                //将内存流格式化为位图
                if (imagebytes.Length > 0)
                {
                    MemoryStream stream = new MemoryStream(imagebytes);

                    if (File.Exists(pathname))
                    {
                        File.Delete(pathname);
                    }
                    Image image = Image.FromStream(stream);
                    image.Save(pathname);
                    stream.Close();
                    image.Dispose();
                    value_path = pathname;
                }
                else
                {
                    value_path = "";
                }
            }
            con.Close();
            return value_path;
        }

        /// <summary>
        /// 将图片流输出为文件
        /// </summary>
        /// <param name="tablename"></param>
        public static string ExportSoilPicture(string type, string datetime, string cropcode,string nurient)
        {
            byte[] imagebytes;
            string datetimeforamt = datetime.Substring(0, datetime.LastIndexOf(" ")).Replace('/', '-');
            string cropName = DataBaseOperate.get_CropCHName(cropcode);
            string nutrientName = DataBaseOperate.get_NutrientCHName(nurient);
            string pathname = Application.StartupPath + @"\Image\" + type + "_" + datetimeforamt + "_" + cropName +"_"+nutrientName+ ".jpg";
            string strSql = "select PIC_MAP from MONITOR_PICTURE where INDICATOR_NAME='" + type + "' and MONITORTIME='" + datetime + "' and CROP_CODE='" + cropcode + "' and NUTRIENT_CODE='" + nurient + "'";
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = new SqlCommand(strSql, con);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string value_path = "";
            while (reader.Read())
            {
                //获取图片数据
                imagebytes = (byte[])reader["PIC_MAP"];
                //将内存流格式化为位图
                if (imagebytes.Length > 0)
                {
                    MemoryStream stream = new MemoryStream(imagebytes);

                    if (File.Exists(pathname))
                    {
                        File.Delete(pathname);
                    }
                    Image image = Image.FromStream(stream);
                    image.Save(pathname);
                    stream.Close();
                    image.Dispose();
                  
                    value_path= pathname;
                }
                else
                {
                  
                    value_path= "";
                }
            }
            con.Close();
            return value_path;
        }


        //删除无用图片
        public static void DeletePicture()
        {
            string pathname = Application.StartupPath + @"\Image";
            DirectoryInfo dir = new DirectoryInfo(pathname);
            foreach (FileInfo file in dir.GetFiles("*.jpg"))
            {
                file.Delete();
            }
        }
    }
}
