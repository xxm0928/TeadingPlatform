
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace TeadingPlatformAPI.Controllers
{
    public class UserApiController : ApiController
    {
        Bll bll = new Bll();
        /// <summary>
        /// 用户登录
        /// data 是统一参数值
        /// UnitedReturn 是统一返回的类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn UserLogin(object data)
        {
            return bll.UserLogin(data);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn UserAdd(object data)
        {
            return bll.UserAdd(data);
        }
        /// <summary>
        /// 店铺列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn GetShopInfo(object data)
        {
            return bll.GetShopInfo(data);
        }
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn AddShopInfo(object data)
        {
            return bll.AddShopInfo(data);
        }
        /// <summary>
        /// 关闭店铺
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn UpdatShopInfo(object data)
        {
            return bll.UpdatShopInfo(data);
        }
        /// <summary>
        /// 商品列表下拉
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn GetCommodityInfo(object data)
        {
            return bll.GetCommodityInfo(data);
        }
    }
}
