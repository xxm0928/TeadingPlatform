using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ycx_Helper
    {
        /// <summary>
        /// ycx 连接数据库字符串
        /// </summary>
        string strconn = "Data Source=追着;Initial Catalog=TeadingPlatform;Integrated Security=True";
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
    }
}
