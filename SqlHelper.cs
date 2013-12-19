using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace GZDXCC
{
    public class SqlHelper
    {
        #region 数据的插入，删除，修改
        public static bool ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var item in parameters) { cmd.Parameters.AddWithValue(item.Key, item.Value); }
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception) { throw; }
            finally { if (con.State == ConnectionState.Open)con.Close(); }
        }

        public static bool ExecuteNonQuerySimple(string sql, Dictionary<string, object> parameters)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                { foreach (var item in parameters) { cmd.Parameters.AddWithValue(item.Key, item.Value); } }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { if (con.State == ConnectionState.Open)con.Close(); }
        }
        public static object ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                return (object)cmd.ExecuteScalar();
            }
        }
        #endregion

        #region 使用阅读器  适配器 查询数据
        public static SqlDataReader ExecuteReader(string sql, Dictionary<string, object> parameter)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                if (parameter != null)
                {
                    foreach (var item in parameter)
                    { cmd.Parameters.AddWithValue(item.Key, item.Value); }
                }
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception) { throw; }
            // 如果关闭数据库，则阅读器没有办法读取数据;
        }

        public static DataSet GetDataSet(string sql, Dictionary<string, object> parameters)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    { cmd.Parameters.AddWithValue(item.Key, item.Value); }
                }
                SqlDataAdapter da = new SqlDataAdapter();//创建一个适配器,它会根据具体需要打开和关闭数据库
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();//创建一个数据集市
                da.Fill(ds, "Stu"); //适配器将查询出来的数据填充到数据集市ds中去
                return ds;
            }
            catch (Exception) { throw; }
        }

        public static DataTable GetDataTable(string sql, Dictionary<string, object> parameters)
        {
            /*最最最简洁的写法
             * DataTable dt = SqlHelper.GetDataSet(sql, parameters).Tables[0];
             * return dt;
             */
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    { cmd.Parameters.AddWithValue(item.Key, item.Value); }
                }
                SqlDataAdapter da = new SqlDataAdapter();//创建一个适配器,它会根据具体需要打开和关闭数据库
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}