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
            var sql = string.Format($"select count(1) from UserInfo u where u.Uname='{userInfo.UserNumder}' and '{userInfo.UserPass}'");
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
        /// 商品添加
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn AddCommdity(object data)
        {
            CommodityInfo commodity = JsonConvert.DeserializeObject<CommodityInfo>(data.ToString());
            var sql = string.Format($"insert into CommdityInfo values('{commodity.CommodityName}','{commodity.TypeId}','{commodity.ComndityImg}','{commodity.Price}','{commodity.CommditySum}','{commodity.CommodityState}','{commodity.Descride}','{commodity.CommditySize}','{commodity.Testuer}','{commodity.PutawayTime}','{commodity.OutTime}')");
            var res = Convert.ToInt32(dBHelper.ExecuteNonQuery(sql));
            UnitedReturn united = new UnitedReturn();
            //如果登陆成功 给统一返回类型的model赋值
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
    public class dal
    {
        #region ycx_3/20 20:10
        /// <summary>
        /// 获取集合数据
        /// </summary>
        /// <returns></returns>
        //public List<UserInfo> PersonalInformation()
        //{
        //    Helper_ycx help = new Helper_ycx();
        //    string textSql = "exec UserInfo_proc_Select";
        //    List<UserInfo> list = help.Getlist<UserInfo>(textSql);
        //    return list.ToList();
        //}
        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public int AddPersonalInformation(UserInfo model)
        //{
        //    Helper_ycx help = new Helper_ycx();
        //    string textSql = $"exec UserInfo_proc_Add '{model.UserName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
        //    int result = help.GetLine(textSql);
        //    return result;

        }
        #endregion


    }
}
