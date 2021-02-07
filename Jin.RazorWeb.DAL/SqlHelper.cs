using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Jin.RazorWeb.DAL
{
    public class SqlHelper
    {
        //连接字符串
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;

        /// <summary>
        /// 执行SQL查询语句并返回影响行数
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行SQL查询语句并返回结果集中的第一行的第一列
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 执行SQL查询语句并返回一个SqlDataReader对象
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        connection.Open();
                        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    }
                    catch
                    {
                        connection.Close();
                        connection.Dispose();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行sql查询语句并返回DataTable
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(table);
                    }
                }
            }
            return table;
        }

        /// <summary>
        /// 执行sql查询语句并返回DataSet
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, params SqlParameter[] parameters)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }
            }
            return dataSet;
        }
    }
}