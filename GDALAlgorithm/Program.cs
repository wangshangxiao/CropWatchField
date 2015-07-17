using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GDALAlgorithm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //WDLChart dbm = new WDLChart();
            //Application.Run(dbm);
            if (args.Length <= 0)
            {
                MessageBox.Show("请输入启动参数");
                Application.Exit();
            }
            if (args.Length == 1)
            {
                string[] sStrs = args[0].Split('_');
                switch (sStrs[0])
                {
                    case "0":
                        Application.Run(new VectorToRasterForm());//矢量转栅格
                        break;
                    case "1":
                        Application.Run(new ReSampleForm());//重采样
                        break;
                    case "2":
                        Application.Run(new LayerStackForm());//波段合成
                        break;
                    case "3":
                        Application.Run(new StatictisForm());//通用统计界面
                        break;
                    case "4":
                        Application.Run(new SoilStatictisForm());//土壤统计界面
                        break;
                    case "5":
                        AggregateToVillageForm atvf = new AggregateToVillageForm();
                        atvf.lbl_tablename.Text = sStrs[1];
                        Application.Run(atvf);//通用汇总到作业站界面
                        break;
                    case "6":
                        AggregateToTownForm attf = new AggregateToTownForm();
                        attf.lbl_tablename.Text = sStrs[1];
                        Application.Run(attf);//通用汇总到作业区界面
                        break;
                    case "7":
                        SoilAggregateToVillage satvf = new SoilAggregateToVillage();
                        satvf.lbl_tablename.Text = sStrs[1];
                        Application.Run(satvf);//土壤汇总到作业站界面
                        break;
                    case "8":
                        SoilAggregateToTown sattf = new SoilAggregateToTown();
                        sattf.lbl_tablename.Text = sStrs[1];
                        Application.Run(sattf);//土壤汇总到作业区界面
                        break;
                    case "9":
                        InsertPicture insert_Pic = new InsertPicture(sStrs[2], sStrs[3], sStrs[4]);
                        Application.Run(insert_Pic);//普通图片入库
                        break;
                    case "10":
                        InsertSoilPicture insert_SoilPic = new InsertSoilPicture(sStrs[2], sStrs[3], sStrs[4], sStrs[5]);
                        Application.Run(insert_SoilPic);//土壤图片入库
                        break;
                    case "11":
                        Application.Run(new ExportToWord());
                        break;
                    case "12":
                        AggregateToCountyForm atcf = new AggregateToCountyForm();
                        atcf.lbl_tablename.Text = sStrs[1];
                        Application.Run(atcf);//汇总到农场
                        break;
                    case "13":
                        SoilAggregateToCounty satc = new SoilAggregateToCounty();
                        satc.lbl_tablename.Text = sStrs[1];
                        Application.Run(satc);//土壤到农场
                        break;
                    case "14":
                        Application.Run(new DataBaseManager());
                        break;
                    case "15":
                        Application.Run(new DataBaseConnect());
                        break;
                    case "20":
                        Application.Run(new VICalculationForm());
                        break;
                    case "21":
                        Application.Run(new VIStatictisForm());
                        break;
                    case "22":
                        Application.Run(new PlotChart());
                        break;
                    case "23":
                        Application.Run(new MultPlotChart());
                        break;
                    case "24":
                        Application.Run(new WDLChart());
                        break;
                    default:
                        MessageBox.Show("启动参数错误，请重新输入");
                        Application.Exit();
                        break;
                }
            }
        }
    }
}
