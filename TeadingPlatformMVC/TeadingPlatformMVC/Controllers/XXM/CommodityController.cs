using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;

namespace TeadingPlatformMVC.Controllers.XXM
{
    public class CommodityController : Controller
    {
        // GET: Commodity

        HttpClientHelper clientHelper = new HttpClientHelper();

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCommodity()
        {
            return View();
        }
        public JsonResult AddCommoditys()
        {
            var data = Request["data"];
            var UpdateOrderState = clientHelper.Post("api/XXM_Commodity/Commodity", data);
            var list = new UnitedReturn();
            if (UpdateOrderState != null)
            {
                list = JsonConvert.DeserializeObject<UnitedReturn>(UpdateOrderState.ToString());
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCommodity()
        {
            return View();
        }

        /// <summary>
        /// 商品类型下拉框
        /// </summary>
        /// <returns></returns>
        public JsonResult CommodityType()
        {
            var LogisticsList = clientHelper.Post("api/XXM_Commodity/SelCommodityType", 1);
            var ress = new List<TypeInfo>();
            if (LogisticsList != null)
            {
                ress = JsonConvert.DeserializeObject<List<TypeInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(LogisticsList.ToString())).data.ToString());
            }

            return Json(ress, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCookie()
        {
            HttpCookie cookies = System.Web.HttpContext.Current.Request.Cookies["NamePass"];
            string Name = HttpUtility.UrlDecode(cookies.Value);
            GetName getName = new GetName()
            {
                Name = Name
            };
            return Json(getName, JsonRequestBehavior.AllowGet);
        }
    }
}