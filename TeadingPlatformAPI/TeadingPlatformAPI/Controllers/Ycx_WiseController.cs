using BLL;
using DAL;
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
      //路由名字
    public class Ycx_WiseController : ApiController
    {
        #region online

        
        YcxBll b = new YcxBll();
        /// <summary>
        /// 个人信息（存储过程的）
        /// </summary>
        /// <param name="sing"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PersonalInformation(object data)
        {
            var list = b.PersonalInformation(data);
            return Json(list);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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
        [HttpPost]
        public IHttpActionResult ExitPersonalInformation(UserInfo model, int ids,object data)
        {
            var result = b.ExitPersonalInformation(model, ids, data);
            return Json(result);
        }
        [HttpPost]
        public UnitedReturn GetList(object data)
        {
            return b.PersonalInformation(data);
        }
        #endregion

        Ycx_Helper helpx = new Ycx_Helper();
        #region 真


       [HttpPost]
        public UnitedReturn Add(UserInfo um,object obj)
        {
            if (obj.ToString() !="System.object" && obj.ToString()!="1")
            {
                um = JsonConvert.DeserializeObject<UserInfo>(JsonConvert.SerializeObject(obj));
            }
            string sql = $"insert into UserInfo values('{um.UserName}','{um.UserPhoto}',{um.UserSex},{um.ShopId},'{um.UserNumder}',{um.UserAge},'{um.UserIDNumber}')";
            var res = helpx.ExecuteNonQuery(sql);
            UnitedReturn united = new UnitedReturn();
            if (res>0)
            {
                united.data = res;
                united.msg = "添加成功！";
                united.res = 1;
            }
            else
            {
                united.data = null;
                united.msg = "添加失败！";
                united.res = 0;
            }
            return united;


        }

        //public UnitedReturn SelectWere()
        //{
        //    string sql = "";
        //}

        #endregion
    }



}
