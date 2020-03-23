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
        public ActionResult Order()
        {
            var data = Request["data"];
            HttpClientHelper clientHelper = new HttpClientHelper();
            var res = clientHelper.Post("api/YxApi/OrderShow", data);
            if (res != null)
            {
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                var dataOrder = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
                ViewBag.OrderList = "";
                if (mata.msg == "获取信息成功,但是没有查询到结果")
                {
                    ViewBag.OrderList = "";
                }
                else
                {
                    ViewBag.OrderList = dataOrder;
                }
                
            }
            var LogisticsList = clientHelper.Post("api/YxApi/LogisticsShow", data);
            if (LogisticsList != null)
            {
                ViewBag.LogisticsList = JsonConvert.DeserializeObject<List<Orderform>>((JsonConvert.DeserializeObject<UnitedReturn>(LogisticsList.ToString())).data.ToString());
            }
            return View();
        }
    }
}