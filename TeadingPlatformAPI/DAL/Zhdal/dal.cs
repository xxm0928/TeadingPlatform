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
            var sql = string.Format($"select u.UserName from UserInfo u where u.UserNumder='{userInfo.UserNumder}' and u.UserPass='{userInfo.UserPass}'");
            //返回值
            var res = dBHelper.ExecuteScalar(sql);
            UnitedReturn united = new UnitedReturn();
            //如果登陆成功 给统一返回类型的model赋值
            if (res !=null)
            {
                //给统一返回类型的model赋值
                united.data = res;//返回的数据
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
            var sql = string.Format($"insert into [dbo].[UserInfo] values('{Info.ShopName}','{Info.UserPass}',' ','1','1','{Info.UserNumder}','1',' ')");
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
        /// <summary>
        /// 店铺列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn GetShopInfo(object data)
        {  
            var sql = string.Format("select s.ShopName,u.UserName from [dbo].[UserInfo] as u join [dbo].[ShopInfo] as s on u.ShopId=s.ShopId where s.ShopState=2");
            var res = dBHelper.GetToList<ShopInfo>(sql);
            UnitedReturn united = new UnitedReturn();
            if (res.Count > 0 && res != null)
            {
                //给统一返回类型的model赋值
                united.data = res;//返回的数据
                united.msg = "获取店铺信息成功";//返回的字符串
                united.res = 1;//返回的int值
            }
            else
            {
                //给统一返回类型的model赋值
                united.data = null;
                united.msg = "获取店铺信息失败";
                united.res = 0;
            }
            return united;
        }
       
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn AddShopInfo(object data)
        {
            ShopInfo Info = JsonConvert.DeserializeObject<ShopInfo>(data.ToString());
            var sql = string.Format($"insert into [dbo].[ShopInfo] values('{Info.ShopName}',' ','2')");
            var res = dBHelper.ExecuteNonQuery(sql);
            UnitedReturn united = new UnitedReturn();
            if (res > 0)
            {
                //给统一返回类型的model赋值
                united.data = null;//返回的数据
                united.msg = "添加成功";//返回的字符串
                united.res = 1;//返回的int值
            }
            else
            {
                //给统一返回类型的model赋值
                united.data = null;
                united.msg = "添加失败";
                united.res = 0;
            }
            return united;
        }

        /// <summary>
        /// 关闭店铺
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UpdatShopInfo(object data)
        {
            ShopInfo Info = JsonConvert.DeserializeObject<ShopInfo>(data.ToString());
            UnitedReturn united = new UnitedReturn();
            if (Convert.ToInt32(data)>0)
            {
                var sql = string.Format($"update  [dbo].[ShopInfo] set ShopState=1 where ShopId='{Convert.ToInt32(data)}')");
                var res = dBHelper.ExecuteNonQuery(sql);
                
                if (res > 0)
                {
                    //给统一返回类型的model赋值
                    united.data = null;//返回的数据
                    united.msg = "添加成功";//返回的字符串
                    united.res = 1;//返回的int值
                }
            }
            else
            {
                //给统一返回类型的model赋值
                united.data = null;
                united.msg = "添加失败";
                united.res = 0;
            }
            return united;
        }
    }
}
