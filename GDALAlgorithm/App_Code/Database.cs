using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace GDALAlgorithm
{

    /// <summary>
    /// 类，用于数据访问的类。
    /// </summary>
    public class Database : IDisposable
    {
        
        /// <summary>
        /// 保护变量，数据库连接。
        /// </summary>
        protected System.Data.OleDb.OleDbConnection Connection;
        /// <summary>
        /// 保护变量，数据库连接串。
        /// </summary>
        protected String ConnectionString;
        //XmlHandler xmlH = new XmlHandler();


        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="DatabaseConnectionString">数据库连接串</param>
        public Database()
        {
            //获取程序的基目录。
            string str = XmlManage.ReadXml("IDLPath");
            //System.Windows.Forms.MessageBox.Show(str);
            
            string sProPath = Application.StartupPath;
            //string sXmlPath = sProPath.Substring(0, sProPath.LastIndexOf("bin"));
            string sConfigFullPath = sProPath + "\\Config.xml";
            //System.Windows.Forms.MessageBox.Show(sConfigFullPath);
            string sMachine = XmlManage.ReadXmlByNodesName(sConfigFullPath, "SystemConfig", "OracleDBConfig", "ServerName");
            string sInstance = XmlManage.ReadXmlByNodesName(sConfigFullPath, "SystemConfig", "OracleDBConfig", "Instance");
            string sDatabase = XmlManage.ReadXmlByNodesName(sConfigFullPath, "SystemConfig", "OracleDBConfig", "DatabaseName");
            string sUserName = XmlManage.ReadXmlByNodesName(sConfigFullPath, "SystemConfig", "OracleDBConfig", "UserName");
            string sPassword = XmlManage.ReadXmlByNodesName(sConfigFullPath, "SystemConfig", "OracleDBConfig", "Password");
            
            //string sConn = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.9.200.252)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = orcl))) ;User Id=crop;Password=crop";
            string sConn = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST =" + sMachine + ")(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = " + sInstance + "))) ;User Id=" + sUserName + ";Password=" + sPassword + "";

            System.Windows.Forms.MessageBox.Show(sConn);
            ConnectionString = sConn;
        }



        /// <summary>
        /// 析构函数，释放非托管资源
        /// </summary>
        ~Database()
        {
            try
            {
                if (Connection != null)
                    Connection.Close();
            }
            catch { }
            try
            {
                Dispose();
            }
            catch { }
        }

        /// <summary>
        /// 保护方法，打开数据库连接。
        /// </summary>
        protected void Open()
        {
            if (Connection == null)
            {
                Connection = new System.Data.OleDb.OleDbConnection(ConnectionString);
            }
            if (Connection.State.Equals(ConnectionState.Closed))
            {
                Connection.Open();
                System.Windows.Forms.MessageBox.Show("数据库连接成功！");
            }
        }

        /// <summary>
        /// 公有方法，关闭数据库连接。
        /// </summary>
        public void Close()
        {
            if (Connection != null)
                Connection.Close();
        }

        /// <summary>
        /// 公有方法，释放资源。
        /// </summary>
        public void Dispose()
        {
            // 确保连接被关闭
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }

        public bool IsHasTable(string sTableName)
        {
            bool b = false;
            Open();
            DataTable schemaTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
            if (schemaTable != null)
            {

                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    string sName = schemaTable.Rows[i]["TABLE_NAME"].ToString();
                    if (sName == sTableName)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }

        /// <summary>
        /// 公有方法，获取数据，返回一个OracleDataReader （调用后主意调用OracleDataReader.Close()）。
        /// </summary>
        /// <param name="SqlString">Sql语句</param>
        /// <returns>OleDbDataReader</returns>
        public OleDbDataReader GetDataReader(String SqlString)
        {
            Open();
            OleDbCommand cmd = new OleDbCommand(SqlString, Connection);
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 公有方法，获取数据，返回一个DataSet。
        /// </summary>
        /// <param name="SqlString">Sql语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(String SqlString)
        {
            Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(SqlString, Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            Close();
            return dataset;
        }
        /// <summary>
        /// 公有方法，获取数据，返回一个DataTable。
        /// </summary>
        /// <param name="SqlString">Sql语句</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(String SqlString)
        {
            Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(SqlString, Connection);
            DataTable pDataTable = new DataTable();
            adapter.Fill(pDataTable);
            Close();
            return pDataTable;
        }
        /// <summary>
        /// 公有方法，获取数据，返回一个DataRow。
        /// </summary>
        /// <param name="SqlString">Sql语句</param>
        /// <returns>DataRow</returns>
        public DataRow GetDataRow(String SqlString)
        {
            DataSet dataset = GetDataSet(SqlString);
            dataset.CaseSensitive = false;
            if (dataset.Tables[0].Rows.Count > 0)
            {
                return dataset.Tables[0].Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 公有方法，执行Sql语句。
        /// </summary>
        /// <param name="SqlString">Sql语句</param>
        /// <returns>对Update、Insert、Delete为影响到的行数，其他情况为-1</returns>
        public int ExecuteSQL(String SqlString)
        {
            int count = -1;
            Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand(SqlString, Connection);
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                count = -1;
                ex.ToString();

            }
            finally
            {
                Close();
            }
            return count;
        }

        /// <summary>
        /// 公有方法，执行一组Sql语句。
        /// </summary>
        /// <param name="SqlStrings">Sql语句组</param>
        /// <returns>是否成功</returns>
        public bool ExecuteSQL(ArrayList SqlStrings)
        {
            ////System.Windows.Forms.MessageBox.Show("SqlStrings:" + SqlStrings);
            bool success = true;
            Open();
            OleDbCommand cmd = new OleDbCommand();
            OleDbTransaction trans = Connection.BeginTransaction();
            cmd.Connection = Connection;
            cmd.Transaction = trans;
            try
            {
                foreach (String str in SqlStrings)
                {
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
            finally
            {
                Close();
            }
            return success;
        }

        /// <summary>
        /// 公有方法，在一个数据表中插入一条记录。
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Cols">哈西表，键值为字段名，值为字段值</param>
        /// <returns>是否成功</returns>
        public bool Insert(String TableName, Hashtable Cols)
        {
            int Count = 0;

            if (Cols.Count <= 0)
            {
                return true;
            }

            String Fields = " (";
            String Values = " Values('";
            foreach (DictionaryEntry item in Cols)
            {
                if (Count != 0)
                {
                    Fields += ",";
                    Values += "','";
                }
                Fields += item.Key.ToString();
                Values += item.Value.ToString();
                Count++;
            }
            Fields += ")";
            Values += "')";

            String SqlString = "Insert into " + TableName + Fields + Values;
            return Convert.ToBoolean(ExecuteSQL(SqlString));
        }

        /// <summary>
        /// 公有方法，在一个数据表中插入一条记录。
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Cols">哈西表，键值为字段名，值为字段值</param>
        /// <returns>是否成功</returns>
        public bool InsertBool(String TableName, Hashtable Cols,bool b)
        {
            int Count = 0;

            if (Cols.Count <= 0)
            {
                return true;
            }

            String Fields = " (";
            String Values = " Values('";
            foreach (DictionaryEntry item in Cols)
            {
                if (item.Key.ToString() != "SM_ISVISIBLE")
                {
                    if (Count != 0)
                    {
                        Fields += ",";
                        Values += "','";
                    }

                    Fields += item.Key.ToString();
                    Values += item.Value.ToString();
                    Count++;
                }
            }
            Fields += ",SM_ISVISIBLE)";

            Values += "',"+b+")";

            String SqlString = "Insert into " + TableName + Fields + Values;
            return Convert.ToBoolean(ExecuteSQL(SqlString));
        }

        /// <summary>
        /// 公有方法，更新一个数据表。
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Cols">哈西表，键值为字段名，值为字段值</param>
        /// <param name="Where">Where子句</param>
        /// <returns>是否成功</returns>
        public bool Update(String TableName, Hashtable Cols, String Where)
        {
            int Count = 0;
            if (Cols.Count <= 0)
            {
                return true;
            }
            String Fields = " ";
            foreach (DictionaryEntry item in Cols)
            {
                if (Count != 0)
                {
                    Fields += ",";
                }
                Fields += item.Key.ToString();
                Fields += "=";
                Fields += "'" + item.Value.ToString() + "'";
                Count++;
            }
            Fields += " ";

            String SqlString = "Update " + TableName + " Set " + Fields + Where;

            return Convert.ToBoolean(ExecuteSQL(SqlString));
        }
        /// <summary>
        /// 判断删除数据是否成功
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Where">Where子句</param>
        /// <returns>是否成功</returns>
        public bool Delete(String TableName, String Where)
        {
            String SqlString = "delete from " + TableName + " " + Where;
            return Convert.ToBoolean(ExecuteSQL(SqlString));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Where"></param>
        public void DeleteInfo(string TableName, String Where)
        {
            Open();
            string sql = "delete from " + TableName + " " + Where;
            ////System.Windows.Forms.MessageBox.Show("sql:" + sql);
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            OleDbTransaction trans = Connection.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                cmd.ExecuteNonQuery();
                trans.Commit();
            }

            catch
            {
                trans.Rollback();
            }
            finally
            {
                Close();
            }
        }
    }
}