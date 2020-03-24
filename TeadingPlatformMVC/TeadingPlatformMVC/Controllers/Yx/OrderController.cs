using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;
namespace TeadingPlatformMVC.Controllers
{
    public class OrderController : Controller
    {
        HttpClientHelper clientHelper = new HttpClientHelper();
        public ActionResult Order()
        {
            return View();
        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrder()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/YxApi/OrderShow", 1);
            var data = new List<Orderform>();
            if (res != null)
            {
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
            }
            if (request != null)
            {
                var orderforms = JsonConvert.DeserializeObject<Orderform>(request);
                if (orderforms.OrderState >= 0)
                {
                    data = data.Where(s => s.OrderState == orderforms.OrderState).ToList();
                }
                if (Convert.ToInt32(orderforms.OrderformId) > 0)
                {
                    data = data.Where(s => s.OrderformId == orderforms.OrderformId).ToList();
                }
                if (orderforms.UserName.Length > 0 && !string.IsNullOrEmpty(orderforms.UserName))
                {
                    data = data.Where(s => s.UserName.Contains(orderforms.UserName)).ToList();
                }
                if (orderforms.UserNumder.Length > 0 && !string.IsNullOrEmpty(orderforms.UserNumder))
                {
                    data = data.Where(s => s.UserNumder == orderforms.UserNumder).ToList();
                }
                if (orderforms.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderforms.CommodityName))
                {
                    data = data.Where(s => s.CommodityName.Contains(orderforms.CommodityName)).ToList();
                }
                if (orderforms.LogisticsId > 0)
                {
                    data = data.Where(s => s.LogisticsId == orderforms.LogisticsId).ToList();
                }
            }
            return Json(data);
        }
        /// <summary>
        /// 快递类型下拉列表
        /// </summary>
        /// <returns></returns>
        public JsonResult DropListLogistics()
        {
            var LogisticsList = clientHelper.Post("api/YxApi/LogisticsShow", 1);
            var ress = new List<Orderform>();
            if (LogisticsList != null)
            {
                ress = JsonConvert.DeserializeObject<List<Orderform>>((JsonConvert.DeserializeObject<UnitedReturn>(LogisticsList.ToString())).data.ToString());
            }

            return Json(ress, JsonRequestBehavior.AllowGet);
        }
    }
}