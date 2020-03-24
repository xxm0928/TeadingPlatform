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
        /// <summary>
        /// 订单视图
        /// </summary>
        /// <returns></returns>
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
                if (orderforms.OrderState > 0)
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
            return Json(data, JsonRequestBehavior.AllowGet);
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
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateOrderState()
        {
            var data = Request["data"];
            var UpdateOrderState = clientHelper.Post("api/YxApi/UpdateOrderState", data);
            var list = new UnitedReturn();
            if (UpdateOrderState != null)
            {
                list = JsonConvert.DeserializeObject<UnitedReturn>(UpdateOrderState.ToString());
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 通过订单编号来获取订单状态 进行不同的操作 查看详情 或者 订单发货
        /// </summary>
        /// <returns></returns>
        public JsonResult GetState()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/YxApi/OrderShow", 1);
            var data = new List<Orderform>();
            if (res != null)
            {
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
            }
            data = data.Where(s => s.OrderformId == Convert.ToInt32(request)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrderDetail()
        {
            var strUrl = Request.Url.ToString();
            var splitArr = strUrl.Split('/');
            var splitId = (splitArr[splitArr.Length - 1]).Split('s');
            var Id = splitId[splitId.Length - 1];
            var res = clientHelper.Post("api/YxApi/OrderShow", 1);
            var data = new List<Orderform>();
            if (res != null)
            {
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
            }
            data = data.Where(s => s.OrderformId == Convert.ToInt32(Id)).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}