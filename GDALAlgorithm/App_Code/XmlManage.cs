using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;

class XmlManage
{
    /// <summary>
    /// 读取XML的路径
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ReadXml(string str)
    {
        string sProPath = Application.StartupPath;
        string sXmlPath = sProPath.Substring(0, sProPath.LastIndexOf("bin"));
        //MessageBox.Show(sXmlPath);
        string sValue = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sXmlPath + "Config.xml");
        XmlNode serverPath = xmlDoc.DocumentElement;
        //获取节点的所有子节点
        XmlNodeList nodeList = serverPath.ChildNodes;
        //遍历所有子节点
        foreach (XmlNode xn in nodeList)
        {
            //XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
            if (xn.Name == str)//如果找到
            {
                sValue = xn.InnerText;
                break;//找到退出来
            }
        }
        //MessageBox.Show(sValue);
        return sValue;
    }

    /// <summary>
    /// 单节点
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static List<string> getListFromXml(string sPath,string str)
    {
        List<string> list = new List<string>();
        string sValue = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sPath);
        XmlNode ImageFormatType = xmlDoc.DocumentElement;
        //获取节点的所有子节点
        XmlNodeList nodeList = ImageFormatType.ChildNodes;
        //遍历所有子节点
        foreach (XmlNode xn in nodeList)
        {
            //XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
            if (xn.Name == str)//如果找到
            {
                sValue = xn.InnerText;
                list.Add(sValue);
            }
        }
        //MessageBox.Show(list.Count.ToString());
        return list;
    }

    public static List<string> getListFromXmlByNode(string sPath, string sNodeName,string sAttributeName)
    {
        List<string> list = new List<string>();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sPath);
        XmlNode XNode = xmlDoc.DocumentElement;
        //获取节点的所有子节点
        XmlNodeList nodeList = XNode.ChildNodes;
        //遍历所有子节点
        foreach (XmlNode xn in nodeList)
        {
            XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
            string sAttribute = xe.GetAttribute(sAttributeName);
            if (xn.Name == sNodeName)//如果找到
            {
               list.Add(sAttribute);
            }
        }
        //MessageBox.Show(list.Count.ToString());
        return list;
    }

    /// <summary>
    /// 获取XML中的值组成LIST
    /// </summary>
    /// <param name="sConfigFullPath"></param>
    /// <param name="NodeName1"></param>
    /// <param name="NodeName2"></param>
    /// <param name="NodeName3"></param>
    /// <returns></returns>
    public static List<string> getXmlListByNodesName(string sConfigFullPath, string NodeName1, string NodeName2, string NodeName3)
    {
        List<string> list = new List<string>();
        string sValue = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sConfigFullPath);

        //获取节点的所有子节点
        XmlNodeList nodeList1 = xmlDoc.GetElementsByTagName(NodeName1);
        //遍历所有子节点
        foreach (XmlNode xn1 in nodeList1)
        {
            //XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
            if (xn1.Name == NodeName1)//如果找到
            {
                XmlNodeList nodeList2 = xn1.ChildNodes;
                foreach (XmlNode xn2 in nodeList2)
                {
                    if (xn2.Name == NodeName2)//如果找到
                    {
                        XmlNodeList nodeList3 = xn2.ChildNodes;
                        foreach (XmlNode xn3 in nodeList3)
                        {
                            if (xn3.Name == NodeName3)//如果找到
                            {
                                sValue = xn3.InnerText;
                                list.Add(sValue);
                            }
                        }
                    }
                }
            }
        }
        //MessageBox.Show(sValue);
        return list;
    }

    public static List<string> getAttributeListFromXml(string sPath, int nIndex)
    {
        List<string> list = new List<string>();
        string sValue = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sPath);
        XmlNode ImageFormatType = xmlDoc.DocumentElement;
        //获取节点的所有子节点
        XmlNodeList nodeList = ImageFormatType.ChildNodes;
        //遍历所有子节点
        foreach (XmlNode xn in nodeList)
        {
            sValue = xn.Attributes.Item(nIndex).Value; 
            list.Add(sValue);
        }
        //MessageBox.Show(list.Count.ToString());
        return list;
    }

    public static DataTable getCropCodeFromXml(string sPath)
    {
        DataTable dt=new DataTable();
        dt.Columns.Add("代码", typeof(string));
        dt.Columns.Add("名称", typeof(string));
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sPath);
        XmlNode ImageFormatType = xmlDoc.DocumentElement;
        //获取节点的所有子节点
        XmlNodeList nodeList = ImageFormatType.ChildNodes;
        //遍历所有子节点
        foreach (XmlNode xn in nodeList)
        {
            DataRow dr = dt.NewRow();
            string sCode = xn.Attributes.Item(0).Value;
             string sName = xn.Attributes.Item(1).Value;
             dt.Rows.Add(new object[] { sCode, sName });
        }
        //MessageBox.Show(list.Count.ToString());
        return dt;
    }


    /// <summary>
    /// 读取XML的参数（三层节点）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ReadXmlByNodesName(string sConfigFullPath,string NodeName1, string NodeName2, string NodeName3)
    {
            
        //MessageBox.Show(sXmlPath);
        string sValue = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sConfigFullPath);
           
        //获取节点的所有子节点
        XmlNodeList nodeList1 = xmlDoc.GetElementsByTagName(NodeName1);
        //遍历所有子节点
        foreach (XmlNode xn1 in nodeList1)
        {
            //XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
            if (xn1.Name == NodeName1)//如果找到
            {
                XmlNodeList nodeList2 = xmlDoc.GetElementsByTagName(NodeName2);
                foreach (XmlNode xn2 in nodeList2)
                {
                    if (xn2.Name == NodeName2)//如果找到
                    {
                        XmlNodeList nodeList3 = xmlDoc.GetElementsByTagName(NodeName3);
                        foreach (XmlNode xn3 in nodeList3)
                        {
                            if (xn3.Name == NodeName3)//如果找到
                            {
                                sValue = xn3.InnerText;
                                break;//找到退出来
                            }
                        }
                    }
                }
            }
        }
        //MessageBox.Show(sValue);
        return sValue;
    }

    public static bool writexml(List<string> list,string sType,string sXmlPath)
    {
        bool b=true;
        try
        {
            // 创建XmlTextWriter类的实例对象
            XmlTextWriter textWriter = new XmlTextWriter(sXmlPath, null);
            textWriter.Formatting = Formatting.Indented;

            // 开始写过程，调用WriteStartDocument方法
            textWriter.WriteStartDocument();

            // 写入说明
            //textWriter.WriteComment("xml写入");
            //textWriter.WriteComment("w3sky.xml in root dir");

            //创建一个节点
            textWriter.WriteStartElement("Regions");
            int nCount = list.Count;
            for (int i = 0; i < nCount; i++)
            {
                textWriter.WriteStartElement("Region");
                textWriter.WriteAttributeString("Type", sType);
                string sName = list[i].ToString();
                textWriter.WriteAttributeString("Name", sName);
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();

            // 写文档结束，调用WriteEndDocument方法
            textWriter.WriteEndDocument();

            // 关闭textWriter
            textWriter.Close();
        }
        catch (Exception)
        {
            b = false;
            throw;
        }
        return b;
    }

    public static bool ModifyXml(List<string> list, string sType, string sXmlPath)
    {
        List<string> havelist = getListFromXmlByNode(sXmlPath, "Region","Name");
        //for (int j = 0; j < havelist.Count; j++)
        //{
        //    MessageBox.Show(havelist[j]);
        //}
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sXmlPath);
        XmlNode root = xmlDoc.SelectSingleNode("Regions");//查找<Regions> 
        
        int nCount = list.Count;
        for (int i = 0; i < nCount; i++)
        {
            for (int j = 0; j < havelist.Count; j++)
            {
                //MessageBox.Show(havelist[j]);
                if (list.Contains(havelist[j]))
                {
                    list.Remove(havelist[j]);
                }
            }
        }
        //MessageBox.Show(list.Count.ToString());
        for (int i = 0; i < list.Count; i++)
        {
            XmlElement xe1 = xmlDoc.CreateElement("Region");//创建一个<Region>节点
            xe1.SetAttribute("Type", sType);//设置该节点genre属性 
            string sName = list[i].ToString();
            xe1.SetAttribute("Name", sName);//设置该节点ISBN属性
            root.AppendChild(xe1);//添加到<Employees>节点中 
            xmlDoc.Save(sXmlPath);
        }
        return true;
    }

}
