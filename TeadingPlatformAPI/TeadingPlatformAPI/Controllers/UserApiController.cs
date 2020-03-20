using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
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
        public UnitedReturn UserLogin(object data)
        {
            return bll.UserLogin(data);
        }
    }
}
