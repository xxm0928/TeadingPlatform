
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Newtonsoft.Json;
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
            var res = System.Web.Configuration.WebConfigurationManager.AppSettings["token"];
            UnitedReturn united = new UnitedReturn();
            var datas = JsonConvert.DeserializeObject<UserInfo>(data.ToString());
            var str = '"' + res.ToString() + '"';
            var token = datas.token;
            if (str == token)
            {
                return bll.UserLogin(data);
            }
            else
            {
                united.msg = "非法token";
                united.res = 0;
                united.data = null;
                return united;
            }
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

    }
}
