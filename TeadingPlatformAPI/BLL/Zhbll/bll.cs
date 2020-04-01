
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class Bll
    {
        Dal dal = new Dal();

        /// <summary>
        /// 用户登录
        /// data 是统一参数值
        /// UnitedReturn 是统一返回的类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserLogin(object data)
        {
            return dal.UserLogin(data);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserAdd(object data)
        {
            return  dal.UserAdd(data);
        }
        /// <summary>
        /// 店铺列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn GetShopInfo(object data)
        {
            return dal.GetShopInfo(data);
        }
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn AddShopInfo(object data)
        {
            return dal.AddShopInfo(data);
        }
        /// <summary>
        /// 关闭店铺
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UpdatShopInfo(object data)
        {
            return dal.UpdatShopInfo(data);
        }
    
    }
}
