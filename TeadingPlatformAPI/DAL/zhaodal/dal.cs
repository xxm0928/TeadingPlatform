using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Data.SqlClient;
namespace DAL
{
    public class Dal
    {
        DBHelper dBHelper = new DBHelper();
        /// <summary>
        /// 用户登录
        /// data 是统一参数值
        /// UnitedReturn 是统一返回的类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserLogin(object data)//这是模板 登录重新写账号密码 此类只作为参考
        {
            //把data转换成类的类型 
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(data.ToString());
            //sql语句
            var sql = string.Format($"select count(1) from UserInfo u where u.UserNumder='{userInfo.UserNumder}' and u.UserPass='{userInfo.UserPass}'");
            //返回值
            var res = Convert.ToInt32(dBHelper.ExecuteScalar(sql));
            UnitedReturn united = new UnitedReturn();
            //如果登陆成功 给统一返回类型的model赋值
            if (res > 0)
            {
                //给统一返回类型的model赋值
                united.data = null;//返回的数据
                united.msg = "登陆成功";//返回的字符串
                united.res = 1;//返回的int值
            }
            else
            {
                //给统一返回类型的model赋值
                united.data = null;
                united.msg = "登陆失败";
                united.res = 0;
            }
            return united;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserAdd(object data)
        {
            UserInfo Info = JsonConvert.DeserializeObject<UserInfo>(data.ToString());
            var sql = string.Format($"insert into [dbo].[UserInfo] values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",Info.UserName,Info.UserPass,' ',1,1,Info.UserNumder,1,' ');
            var res = dBHelper.ExecuteNonQuery(sql);
            UnitedReturn united = new UnitedReturn();
            if (res > 0)
            {
                //给统一返回类型的model赋值
                united.data = null;//返回的数据
                united.msg = "注册成功";//返回的字符串
                united.res = 1;//返回的int值
            }
            else
            {
                //给统一返回类型的model赋值
                united.data = null;
                united.msg = "注册失败";
                united.res = 0;
            }
            return united;
        }
    }
}
