using System;
using System.Data;
using System.Text;


/// <summary>
/// SQLString 的摘要说明。
/// </summary>
public class SqlStringFormat
{
    /// <summary>
    /// 公有静态方法，将文本转换成适合在Sql语句里使用的字符串。
    /// </summary>
    /// <returns>转换后文本</returns>	
    public static String GetQuotedString(String pStr)
    {
        return ("'" + pStr.Replace("'", "''") + "'");
    }

    
    
    /// <summary>
    /// sql转换[]
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <returns></returns>
    public string ToLikeSql(string sqlstr)
    {
        if (sqlstr == null) return "";
        StringBuilder str = new StringBuilder(sqlstr);
        str.Replace("'", "''");
        str.Replace("[", "[[]");
        str.Replace("%", "[%]");
        str.Replace("_", "[_]");
        return str.ToString();
    }

}