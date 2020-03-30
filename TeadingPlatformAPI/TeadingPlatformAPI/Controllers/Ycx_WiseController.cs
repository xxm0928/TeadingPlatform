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
        #region online

        
        YcxBll b = new YcxBll();
        /// <summary>
        /// 个人信息（存储过程的）
        /// </summary>
        /// <param name="sing"></param>
        /// <returns></returns>
        [Route("PersonalInformation"), HttpGet]
        public IHttpActionResult PersonalInformation(object data)
        {
            var list = b.PersonalInformation(data);
            return Json(list);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <returns></returns>
        [Route("add"), HttpPost]
        public IHttpActionResult AddPersonalInformation(UserInfo model,object data)
        {

            var result = b.AddPersonalInformation(model, data);
            return Json(result);

        }

        /// <summary>
        /// 编辑个人信息 api方法接口名称exit
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("exit"),HttpPost]
        public IHttpActionResult ExitPersonalInformation(UserInfo model, int ids,object data)
        {
            var result = b.ExitPersonalInformation(model, ids, data);
            return Json(result);
        }
        [HttpPost,Route("list")]
        public UnitedReturn GetList(object data)
        {
            return b.PersonalInformation(data);
        }
        #endregion

        #region Oper

        #endregion
    }



}
