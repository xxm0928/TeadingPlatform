using BLL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeadingPlatformAPI.Controllers
{
    [RoutePrefix("ycx")]  //路由名字
    public class Ycx_WiseController : ApiController
    {

        YcxBll b = new YcxBll();
        /// <summary>
        /// 个人信息（存储过程的）
        /// </summary>
        /// <param name="sing"></param>
        /// <returns></returns>
        [Route("PersonalInformation"), HttpGet]
        public IHttpActionResult PersonalInformation()
        {
            List<UserInfo> list = b.PersonalInformation();
            return Json(list.ToList());
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <returns></returns>
        [Route("AddPersonalInformation"), HttpPost]
        public IHttpActionResult AddPersonalInformation(UserInfo model)
        {

            int result = b.AddPersonalInformation(model);
            return Json(result);

        }
    }
    /// <summary>
    /// ycx 临时model
    /// </summary>
    public class ycxModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户头像(url)
        /// </summary>
        public string UserPhoto { get; set; }
        /// <summary>
        /// 用户性别  1 男 0 女
        /// </summary>
        public int UserSex { get; set; }
        /// <summary>
        /// 店铺ID 对应商品
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string UserNumder { get; set; }
        /// <summary>
        /// 用户年龄
        /// </summary>
        public int UserAge { get; set; }
        /// <summary>
        /// 用户身份证
        /// </summary>
        public string UserIDNumber { get; set; }
    }

    /// <summary>
    /// ycx 临时helper 2020/3/20 
    /// </summary>
    public class YcxHelper
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
