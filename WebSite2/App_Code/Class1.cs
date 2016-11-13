using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;//使用SqlConnection
using System.Linq;
using System.Web;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class Class1
{

    static string str = @"server=LAPTOP-HULUCDN3;Integrated Security=SSPI;database=Demo;";//创建连接字符串

    public Class1()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    static public int sqlhelp(string sql)
    {
        

        SqlConnection conn = new SqlConnection(str);//创建连接数据库的对象
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);             //创建一个数据库操作的对象，执行sql语句
        int result=cmd.ExecuteNonQuery();                                  //返回受影响的行数，返回类型为int
        conn.Close();
        return result;
    }
   

    static public DataTable select(string sql)
    {
        SqlConnection conn = new SqlConnection(str);//创建连接数据库的对象
        DataTable dt = new DataTable();                           //创建一个表
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);                               //创建一个在数据源与数据集间交换数据的数据适配器
        da.Fill(dt);                                                                 //执行查询，并把结果储存在dt中
 
            return dt;
       
    }

    
}