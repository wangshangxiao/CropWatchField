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
    public partial class ExportToWord : Form
    {
        public ExportToWord()
        {
            InitializeComponent();
        }

        List<string> list_types = new List<string>();
        //输入文档
        private void btn_Export_Click(object sender, EventArgs e)
        {
            string filename = "";
            Dictionary<DataTable,string> dicts = new Dictionary<DataTable,string>();
            saveFileDialog1.Filter = "word files(*.docx)|*.docx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }
            switch (comboBox_type.SelectedItem.ToString())
            {
                case "作业站":
                    for (int i = 0; i < list_types.Count; i++)
                    {
                        DataTable dt = null;
                        string image_path = "";
                        //表中符合条件的时间个数
                        List<string> list_timeCount = DataBase_ExportWord.Get_TimeCount("VILLAGE",list_types[i], dT_maize_s.Value, dT_maize_e.Value);
                        //表中符合条件的作物个数
                        List<string> list_cropCount = DataBase_ExportWord.Get_CropCount("VILLAGE",list_types[i], dT_maize_s.Value, dT_maize_e.Value);
                        //循环时间
                        for (int J = 0; J < list_timeCount.Count; J++)
                        {

                            //循环作物
                            for (int h = 0; h < list_cropCount.Count; h++)
                            {
                                if (list_types[i] != "SOILNUTRIENT")
                                {
                                    //存储作物的表
                                    dt = DataBase_ExportWord.Return_VillageTable(list_types[i], list_timeCount[J], list_cropCount[h]);
                                    //对应时间和作物的图片存储位置
                                    image_path = OperatePicture.ExportPicture(list_types[i], list_timeCount[J], list_cropCount[h]);
                                    if (!string.IsNullOrEmpty(image_path) || dt != null)
                                    {
                                        dicts.Add(dt,image_path);
                                    }
                                }
                                else
                                {
                                    List<string> list_NuterientCount = DataBase_ExportWord.Get_NuterientCount(list_cropCount[h], dT_maize_s.Value, dT_maize_e.Value);
                                    for (int k = 0; k < list_NuterientCount.Count; k++)
                                    {
                                        //存储作物的表
                                        dt = DataBase_ExportWord.Return_VillageSoilTable(list_timeCount[J], list_cropCount[h], list_NuterientCount[k]);
                                        //对应时间和作物的图片存储位置
                                        image_path = OperatePicture.ExportSoilPicture(list_types[i], list_timeCount[J], list_cropCount[h], list_NuterientCount[k]);
                                        if (dt != null)
                                        {
                                            dicts.Add(dt,image_path);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "作业区":
                    for (int i = 0; i < list_types.Count; i++)
                    {
                        DataTable dt = null;
                        string image_path = "";
                        //表中符合条件的时间个数
                        List<string> list_timeCount = DataBase_ExportWord.Get_TimeCount("TOWN", list_types[i], dT_maize_s.Value, dT_maize_e.Value);
                        //表中符合条件的作物个数
                        List<string> list_cropCount = DataBase_ExportWord.Get_CropCount("TOWN", list_types[i], dT_maize_s.Value, dT_maize_e.Value);
                        //循环时间
                        for (int J = 0; J < list_timeCount.Count; J++)
                        {
                            //循环作物
                            for (int h = 0; h < list_cropCount.Count; h++)
                            {
                                if (list_types[i] != "SOILNUTRIENT")
                                {
                                    //存储作物的表
                                    dt = DataBase_ExportWord.Return_TownTable(list_types[i], list_timeCount[J], list_cropCount[h]);
                                    //对应时间和作物的图片存储位置
                                    image_path = OperatePicture.ExportPicture(list_types[i], list_timeCount[J], list_cropCount[h]);
                                    if (!string.IsNullOrEmpty(image_path) || dt != null)
                                    {
                                        dicts.Add(dt, image_path);
                                    }
                                }
                                else
                                {
                                    List<string> list_NuterientCount = DataBase_ExportWord.Get_NuterientCount(list_cropCount[h], dT_maize_s.Value, dT_maize_e.Value);
                                    for (int k = 0; k < list_NuterientCount.Count; k++)
                                    {
                                        //存储作物的表
                                        dt = DataBase_ExportWord.Return_TownSoilTable(list_timeCount[J], list_cropCount[h], list_NuterientCount[k]);
                                        //对应时间和作物的图片存储位置
                                        image_path = OperatePicture.ExportSoilPicture(list_types[i], list_timeCount[J], list_cropCount[h], list_NuterientCount[k]);
                                        if (dt != null)
                                        {
                                            dicts.Add(dt, image_path);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }

            CreateWord.createNewWord3((object)filename, dicts);
            OperatePicture.DeletePicture();//删除Image下无用图片
            MessageBox.Show("导出成功!");
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox_WATERRETRIEVAL_CheckedChanged(object sender, EventArgs e)
        {
            //SOILNUTRIENT
            if (checkBox_WATERRETRIEVAL.Checked == true)
            {
                list_types.Add("WATERRETRIEVAL");
            }
            else
            {
                if (list_types.Contains("WATERRETRIEVAL"))
                {
                    list_types.Remove("WATERRETRIEVAL");
                }
            }
        }

        private void checkBox_SOILNUTRIENT_CheckedChanged(object sender, EventArgs e)
        {
            //SOILNUTRIENT
            if (checkBox_SOILNUTRIENT.Checked == true)
            {
                list_types.Add("SOILNUTRIENT");
            }
            else
            {
                if (list_types.Contains("SOILNUTRIENT"))
                {
                    list_types.Remove("SOILNUTRIENT");
                }
            }
        }

        private void checkBox_MATUREPERIOD_CheckedChanged(object sender, EventArgs e)
        {
            //MATUREPERIOD
            if (checkBox_MATUREPERIOD.Checked == true)
            {
                list_types.Add("MATUREPERIOD");
            }
            else
            {
                if (list_types.Contains("MATUREPERIOD"))
                {
                    list_types.Remove("MATUREPERIOD");
                }
            }
        }

        private void checkBox_CROPYIELD_CheckedChanged(object sender, EventArgs e)
        {
            //CROPYIELD
            if (checkBox_CROPYIELD.Checked == true)
            {
                list_types.Add("CROPYIELD");
            }
            else
            {
                if (list_types.Contains("CROPYIELD"))
                {
                    list_types.Remove("CROPYIELD");
                }
            }

        }

        private void checkBox_CHLOROPHYLLRETRIEVAL_CheckedChanged(object sender, EventArgs e)
        {
            //WATERRETRIEVAL
            if (checkBox_WATERRETRIEVAL.Checked == true)
            {
                list_types.Add("WATERRETRIEVAL");
            }
            else
            {
                if (list_types.Contains("WATERRETRIEVAL"))
                {
                    list_types.Remove("WATERRETRIEVAL");
                }
            }
        }



    }
}
