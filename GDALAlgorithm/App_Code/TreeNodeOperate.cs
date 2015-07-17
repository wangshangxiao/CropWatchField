using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GDALAlgorithm
{
    public  class TreeNodeOperate
    {
        public static List<string> ReturnMultiValue(string sql)
        {
            List<string> nodeName = new List<string>();
            SqlConnection con = DataBaseOperate.getSqlCon();
            SqlCommand cmd = DataBaseOperate.getSqlCmd(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nodeName.Add(reader[0].ToString());
            }
            con.Close();
            return nodeName;
        }
        public static List<string> getRootName()
        {
            string strsql = "SELECT ProvinceName FROM PROVINCE";
            return ReturnMultiValue(strsql);
        }
        public static List<string> getSecondName(string levelName)
        {
            string code = DataBaseOperate.get_ProCode(levelName);
            string strsql = string.Format("SELECT [CityName] FROM [CITY] where ProCode='{0}'", code);
            return  ReturnMultiValue(strsql);
        }
        public static List<string> getThirdName(string levelName)
        {
            string code = DataBaseOperate.get_SHICode(levelName);
            string strsql = string.Format("SELECT [CountyName] FROM [COUNTY] where SHICode='{0}'", code);
            return ReturnMultiValue(strsql);
        }
        public static List<string> getForthName(string levelName)
         {
             string code = DataBaseOperate.get_QXCode(levelName);
             string strsql = string.Format("SELECT [TownName] FROM [TOWN] where QXCode='{0}'", code);
             return ReturnMultiValue(strsql);
         }
        public static List<string> getFifthName(string forthname,string thirdname)
         {
             string code1 = DataBaseOperate.get_QXCode(thirdname);
             string code = DataBaseOperate.get_TreeTownCode(forthname, code1);
             string strsql = string.Format("SELECT VillName FROM VILLAGE where TowCode='{0}'", code);
             return ReturnMultiValue(strsql);
         }

        public static List<string> getSixthName(string Fifthname)
         {
             string code = DataBaseOperate.getVillCode(Fifthname);
             string strsql = string.Format("SELECT FULLNAME FROM PLOT_DKINFO where JMZ='{0}'", code);
             return ReturnMultiValue(strsql);
         }

        public static void generateTree(TreeView view)
        {
            List<string> list_first = getRootName();
            foreach (var first in list_first)
            {
                TreeNode firstnode = new TreeNode(first);
                List<string> list_second = getSecondName(first);
                foreach (var second in list_second)//第二层
                {
                    TreeNode secondnode = new TreeNode(second);
                    List<string> list_third = getThirdName(second);
                    foreach (var third in list_third)//第三层
                    {
                        TreeNode thirdnode = new TreeNode(third);
                        List<string> list_forth = getForthName(third);
                        foreach (var forth in list_forth)//第四层
                        {
                            TreeNode forthnode = new TreeNode(forth);
                            List<string> list_fifth = getFifthName(forth,third);
                            foreach (var fifth in list_fifth)//第五层
                            {
                                TreeNode fifthnode = new TreeNode(fifth);
                                forthnode.Nodes.Add(fifthnode);
                            }
                            thirdnode.Nodes.Add(forthnode);
                        }
                        secondnode.Nodes.Add(thirdnode);
                    }
                    firstnode.Nodes.Add(secondnode);
                }
                view.Nodes.Add(firstnode);
            }
        }

        public static void generatePlotTree(TreeView view)
        {
            List<string> list_first = getRootName();
            foreach (var first in list_first)
            {
                TreeNode firstnode = new TreeNode(first);
                List<string> list_second = getSecondName(first);
                foreach (var second in list_second)//第二层
                {
                    TreeNode secondnode = new TreeNode(second);
                    List<string> list_third = getThirdName(second);
                    foreach (var third in list_third)//第三层
                    {
                        TreeNode thirdnode = new TreeNode(third);
                        List<string> list_forth = getForthName(third);
                        foreach (var forth in list_forth)//第四层
                        {
                            TreeNode forthnode = new TreeNode(forth);
                            List<string> list_fifth = getFifthName(forth, third);
                            foreach (var fifth in list_fifth)//第五层
                            {
                                TreeNode fifthnode = new TreeNode(fifth);
                                List<string> list_six = getSixthName(fifth);
                                foreach (var sixth in list_six)
                                {
                                    TreeNode sixthnode = new TreeNode(sixth);
                                    fifthnode.Nodes.Add(sixthnode);
                                }
                                forthnode.Nodes.Add(fifthnode);
                            }
                            thirdnode.Nodes.Add(forthnode);
                        }
                        secondnode.Nodes.Add(thirdnode);
                    }
                    firstnode.Nodes.Add(secondnode);
                }
                view.Nodes.Add(firstnode);
            }
        }
    }
}
