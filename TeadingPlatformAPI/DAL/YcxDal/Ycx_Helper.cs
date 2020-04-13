using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ycx_Helper
    {
        /// <summary>
        /// ycx 连接数据库字符串
        /// </summary>
        string strconn = "Data Source=.;Initial Catalog=TeadingPlatform;Integrated Security=True";
        /// <summary>
        /// 返回集合（反序列化）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> Getlist<T>(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    conn.Open();//连接数据库
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable(); //容器
                    adapter.Fill(dt); //填充容器
                    adapter.Dispose(); //释放

                    conn.Close();//断开连接
                    return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt)); //序列化出需要的
                }
            }
            catch (Exception e)
            {
                return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(e));
            }
        }
        public int GetLine(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = sql;
                

                int result = com.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }
        private SqlConnection conn = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Ycx_Helper()
        {
            if (conn == null)
            {
                /// <summary>
                /// 连接字符串 自己写自己本地的数据库
                /// </summary>
                conn = new SqlConnection("Data Source=追着;Initial Catalog=TeadingPlatform;Integrated Security=True");
            }
        }
        /// <summary>
        /// 返回DataTable查询结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public DataTable GetTable(string sql, SqlParameter[] par = null)
        {
            try
            {
                SqlCommand com = new SqlCommand(sql, conn);
                if (par != null)
                {
                    com.Parameters.AddRange(par);
                }
                SqlDataAdapter ada = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                ada.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    this.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    this.Close();
                }
                throw;
            }
        }
        /// <summary>
        /// 返回List查询结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public List<T> GetToList<T>(string sql, SqlParameter[] par = null)
        {
            List<T> li = DataTableToList<T>(GetTable(sql));
            return li;
        }
        /// <summary>
        /// 返回查询结果首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, SqlParameter[] par = null)
        {
            try
            {
                this.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                if (par != null)
                {
                    com.Parameters.AddRange(par);
                }
                return com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                this.Close();
                throw;
            }
        }
        /// <summary>
        /// 返回执行结果受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SqlParameter[] par = null)
        {
            try
            {
                this.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                if (par != null)
                {
                    com.Parameters.AddRange(par);
                }
                return com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.Close();
                throw;
            }
        }
        /// <summary>
        /// Table转list集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<T> DataTableToList<T>(DataTable dt)
        {
            //初始化值
            List<T> result = new List<T>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertys)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (pro.Name.Equals(dt.Columns[j].ColumnName))
                        {
                            if (dt.Rows[i][j] != DBNull.Value)
                            {
                                pro.SetValue(_t, dt.Rows[i][j], null);
                            }
                            else
                            {
                                pro.SetValue(_t, null, null);
                            }
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }
        /// <summary>
        /// 打开数据库链接
        /// </summary>
        private void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        /// <summary>
        /// 关闭数据库链接
        /// </summary>
        private void Close()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Dispose();
            }
        }

    }
}
