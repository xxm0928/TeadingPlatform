using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
     public static class DbHelper
    {
        private const string ConnStr = "Data Source=.;Initial Catalog=TeadingPlatform;Integrated Security=True";
        public static List<T> GetList<T>(string sql) where T : class, new()
        {
            List<T> list = new List<T>();
            using (IDbConnection connection = new SqlConnection(ConnStr))
            {
                list = connection.Query<T>(sql).ToList();
            }
            return list;
        }
        /// <summary>
        /// 获取一条信息
        /// 使用此方法需判断
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static T GetInfo<T>(string sql) where T : class, new()
        {
            T info = new T();
            using (IDbConnection connection = new SqlConnection(ConnStr))
            {
                info = connection.QueryFirstOrDefault<T>(sql);
            }
            return info;
        }
        /// <summary>
        /// 执行缩起来语句
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            int res = 0;
            using (IDbConnection connection = new SqlConnection(ConnStr))
            {
                res = connection.Execute(sql);
            }
            return res;
        }

    }
}
