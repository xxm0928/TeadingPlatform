using System;
using System.Collections;
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

        LogHelper log = new LogHelper();
        HttpClientHelper clientHelper = new HttpClientHelper();
        /// <summary>
        /// 订单视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Order()
        {
            //HttpCookie cookie = new HttpCookie("NamePass");
            //cookie.Value = HttpUtility.UrlEncode("张三");
            //Response.Cookies.Add(cookie);
            return View();
        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrder()
        {
            try
            {
                var request = Request["data"];
                var res = clientHelper.Post("api/YxApi/OrderShow", 1);
                List<Orderform> data = new List<Orderform>();
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
            catch (Exception)
            {
                log.WriteLog("GetOrder", "获取订单数据");
                throw;
            }

        }
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCookie()
        {
            try
            {
                HttpCookie cookies = System.Web.HttpContext.Current.Request.Cookies["NamePass"];
                string Name = HttpUtility.UrlDecode(cookies.Value);
                GetName getName = new GetName()
                {
                    Name = Name
                };
                return Json(getName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("GetCookie", "获取Cookie");
                throw;
            }

        }
        /// <summary>
        /// 快递类型下拉列表
        /// </summary>
        /// <returns></returns>
        public JsonResult DropListLogistics()
        {
            try
            {
                var LogisticsList = clientHelper.Post("api/YxApi/LogisticsShow", 1);
                var ress = new List<Orderform>();
                if (LogisticsList != null)
                {
                    ress = JsonConvert.DeserializeObject<List<Orderform>>((JsonConvert.DeserializeObject<UnitedReturn>(LogisticsList.ToString())).data.ToString());
                }
                return Json(ress, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("DropListLogistics", "快递下拉列表");
                throw;
            }

        }
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateOrderState()
        {
            try
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
            catch (Exception)
            {
                log.WriteLog("UpdateOrderState", "修改订单状态");
                throw;
            }

        }
        /// <summary>
        /// 通过订单编号来获取订单状态 进行不同的操作 查看详情 或者 订单发货
        /// </summary>
        /// <returns></returns>
        public JsonResult GetState()
        {
            try
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
            catch (Exception)
            {
                log.WriteLog("GetState", "通过订单编号来获取订单状态 进行不同的操作 查看详情 或者 订单发货");
                throw;
            }

        }
        /// <summary>
        /// 获取订单详情的视图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOrderDetailView()
        {
            try
            {
                var strUrl = Request.Url.ToString();
                var splitArr = strUrl.Split('/');
                var splitId = (splitArr[splitArr.Length - 1]).Split('s');
                var Id = splitId[splitId.Length - 1];
                Session["Id"] = Id;
                return View();
            }
            catch (Exception)
            {
                log.WriteLog("GetOrderDetailView", "获取订单详情的视图");
                throw;
            }

        }
        /// <summary>
        /// 获取订单详情返回前台的数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrderDetail()
        {
            try
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
            catch (Exception)
            {
                log.WriteLog("GetOrderDetail", "获取订单详情返回前台的数据");
                throw;
            }

        }
        /// <summary>
        /// 判断cookie是否通过登录来保存
        /// </summary>
        /// <returns></returns>
        public JsonResult Cookie()
        {
            try
            {
                var res = Request.Cookies["Name"];
                GetName getName = new GetName();
                if (res == null)
                {
                    getName.Name = "";
                }
                else
                {
                    getName.Name = HttpUtility.UrlDecode(res.Value);
                }
                return Json(getName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("Cookie", "判断cookie是否通过登录来保存");
                throw;
            }

        }
        /// <summary>
        /// 用cookie保存修改订单的id
        /// </summary>
        public void UpdateOrder()
        {
            try
            {
                HttpCookie cookie = new HttpCookie("UpdateOrderId");
                var Id = Convert.ToString(Request["data"]);
                cookie.Value = HttpUtility.UrlEncode(Id);
                Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
                log.WriteLog("UpdateOrder", "用cookie保存修改订单的id");
                throw;
            }

        }
        /// <summary>
        /// 这是做修改的视图
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateOrderView()
        {
            return View();
        }
        /// <summary>
        /// 反填用的视图
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateOrderData()
        {
            try
            {
                var Id = Request.Cookies["UpdateOrderId"];
                var requsetId = 0;
                if (Id == null)
                {
                    requsetId = 0;
                }
                else
                {
                    //解码后把id传到前台
                    requsetId = Convert.ToInt32(HttpUtility.UrlDecode(Id.Value));
                }
                var res = clientHelper.Post("api/YxApi/OrderShow", 1);
                List<Orderform> data = new List<Orderform>();
                if (res != null)
                {
                    var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                    data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
                }
                if (requsetId > 0)
                {
                    data = data.Where(s => s.OrderformId == requsetId).ToList();
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("UpdateOrderData", "反填用的视图");
                throw;
            }

        }
        /// <summary>
        /// 店铺的下拉列表
        /// </summary>
        /// <returns></returns>
        public JsonResult DropListShop()
        {
            try
            {
                var request = Request["data"];
                var res = clientHelper.Post("api/YxApi/DropListShop", 1);
                List<Orderform> data = new List<Orderform>();
                if (res != null)
                {
                    var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                    data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("DropListShop", "店铺的下拉列表");
                throw;
            }

        }
        /// <summary>
        /// 修改订单并接受返回数据
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateOrderDataAndReturnData()
        {
            try
            {
                var request = Request["data"];
                GetName get = new GetName();
                if (request != null)
                {
                    var res = clientHelper.Post("api/YxApi/UpdateOrderDataAndReturnData", request);
                    var data = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                    var Id = data.res;
                    if (Id > 0)
                    {
                        get.Name = "修改成功";
                    }
                    else
                    {
                        get.Name = "修改失败";
                    }
                }
                return Json(get, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("UpdateOrderDataAndReturnData", "修改订单并接受返回数据");
                throw;
            }



        }
        /// <summary>
        /// 写入Redis
        /// </summary>
        /// <returns></returns>
        //public JsonResult DataRedis()
        //{
        //    RedisHelper Redishelper = new RedisHelper();
        //    var msg = "";
        //    //从redis里面拿到这个数据
        //    var str = Redishelper.StringGetRedis("NameList");
        //    if (str == "Redis取出数据失败" || str == "发生错误")
        //    {

        //        var res = clientHelper.Post("api/YxApi/GetUserInfo", 1);
        //        if (res != null)
        //        {
        //            var data = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
        //            var Data = data.data;
        //            //把范形集合数据存到redis里面
        //            Redishelper.StringSetToRedis("NameList", Data.ToString());
        //            var Redis = Redishelper.StringGetRedis("NameList");
        //            if (Redis != null && Redis != "Redis取出数据失败")
        //            {
        //                msg = "数据存到Redis成功";
        //            }
        //            else
        //            {
        //                msg = "数据存到Redis失败";
        //            }
        //        }
        //        else
        //        {
        //            msg = "获取不到数据";
        //        }
        //    }
        //    else
        //    {
        //        //把获取到的Redis数据存到cookie中
        //        HttpCookie cookie = new HttpCookie("NameList");
        //        cookie.Value = HttpUtility.UrlEncode(str);
        //        Response.Cookies.Add(cookie);
        //        msg = "获取Redis数据成功";
        //    }

        //    return Json(new { Name = msg }, JsonRequestBehavior.AllowGet);
        //}
        /// <summary>
        /// 根据名字查询是否存在
        /// </summary>
        /// <returns></returns>
        public JsonResult SelectName()
        {
            try
            {
                GetName get = new GetName();
                //拿到要判断的名字
                var Name = Request["data"];

                //如果没查到 再去数据库查询
                var res = clientHelper.Post("api/YxApi/OrderShow", 1);
                List<Orderform> data = new List<Orderform>();
                if (res != null)
                {
                    var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                    data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
                    if (!string.IsNullOrEmpty(Name))
                    {
                        data = data.Where(s => s.UserName == Name.ToString()).ToList();
                        if (data.Count >= 1)
                        {
                            get.Name = "有该用户";
                        }
                        else
                        {
                            get.Name = "没有该用户";
                        }
                    }
                    else
                    {
                        get.Name = "用户名不能为空";
                    }
                }
                else
                {
                    get.Name = "服务器内部错误";
                }
                return Json(get, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                log.WriteLog("SelectName", "判断用户是否存在");
                throw;
            }

        }
    }
}