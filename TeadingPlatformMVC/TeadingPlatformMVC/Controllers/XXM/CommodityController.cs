﻿using System;
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
            var request = Request["data"];
            GetName get = new GetName();
            if (request != null)
            {
                var res = clientHelper.Post("api/XXM_Commodity/Commodity", request);
                var data = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                var Id = data.res;
                if (Id > 0)
                {
                    get.Name = "添加成功";
                }
                else
                {
                    get.Name = "添加失败";
                }
            }
            return Json(get, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCommodityType()
        {
            return View();
        }
        public JsonResult AddCommodityTypes()
        {
            var request = Request["data"];
            GetName get = new GetName();
            if (request != null)
            {
                var res = clientHelper.Post("api/XXM_Commodity/CommodityType", request);
                var data = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                var Id = data.res;
                if (Id > 0)
                {
                    get.Name = "添加成功";
                }
                else
                {
                    get.Name = "添加失败";
                }
            }
            return Json(get, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 已上架商品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCommodity()
        {
            return View();
        }
        public JsonResult ShowCommoditys()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/SelCommodity", 1);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>(mata.data.ToString());
            }
            if (request != null)
            {
                var orderforms = JsonConvert.DeserializeObject<CommodityInfo>(request);
                if (orderforms.CommodityState >= 0)
                {
                    data = data.Where(s => s.CommodityState == orderforms.CommodityState).ToList();
                }
                if (orderforms.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderforms.CommodityName))
                {
                    data = data.Where(s => s.CommodityName.Contains(orderforms.CommodityName)).ToList();
                }
                if (orderforms.TypeName.Length > 0 && !string.IsNullOrEmpty(orderforms.TypeName))
                {
                    data = data.Where(s => s.TypeName.Contains(orderforms.TypeName)).ToList();
                }
                if (orderforms.ShopName.Length > 0 && !string.IsNullOrEmpty(orderforms.ShopName))
                {
                    data = data.Where(s => s.ShopName.Contains(orderforms.ShopName)).ToList();
                }
                if (orderforms.ComndityImg.Length > 0 && !string.IsNullOrEmpty(orderforms.ComndityImg))
                {
                    data = data.Where(s => s.ComndityImg == orderforms.ComndityImg).ToList();
                }
                if (orderforms.CommditySum > 0)
                {
                    data = data.Where(s => s.CommditySum == orderforms.CommditySum).ToList();
                }
                if (orderforms.Price > 0)
                {
                    data = data.Where(s => s.Price == orderforms.Price).ToList();
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 已下架商品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult OutCommodity()
        {
            return View();
        }
        public JsonResult ShowOutCommoditys()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/SelOutCommodity", 1);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>(mata.data.ToString());
            }
            if (request != null)
            {
                var orderforms = JsonConvert.DeserializeObject<CommodityInfo>(request);
                if (orderforms.CommodityState >= 0)
                {
                    data = data.Where(s => s.CommodityState == orderforms.CommodityState).ToList();
                }
                if (orderforms.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderforms.CommodityName))
                {
                    data = data.Where(s => s.CommodityName.Contains(orderforms.CommodityName)).ToList();
                }
                if (orderforms.TypeName.Length > 0 && !string.IsNullOrEmpty(orderforms.TypeName))
                {
                    data = data.Where(s => s.TypeName.Contains(orderforms.TypeName)).ToList();
                }
                if (orderforms.ShopName.Length > 0 && !string.IsNullOrEmpty(orderforms.ShopName))
                {
                    data = data.Where(s => s.ShopName.Contains(orderforms.ShopName)).ToList();
                }
                if (orderforms.ComndityImg.Length > 0 && !string.IsNullOrEmpty(orderforms.ComndityImg))
                {
                    data = data.Where(s => s.ComndityImg == orderforms.ComndityImg).ToList();
                }
                if (orderforms.CommditySum > 0)
                {
                    data = data.Where(s => s.CommditySum == orderforms.CommditySum).ToList();
                }
                if (orderforms.Price > 0)
                {
                    data = data.Where(s => s.Price == orderforms.Price).ToList();
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
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
        /// 店铺的下拉列表
        /// </summary>
        /// <returns></returns>
        public JsonResult DropListShop()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/DropListShop", 1);
            List<ShopInfo> data = new List<ShopInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<ShopInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            return Json(data, JsonRequestBehavior.AllowGet);
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

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteCommodityState()
        {
            var data = Request["data"];
            var UpdateOrderState = clientHelper.Post("api/XXM_Commodity/DelCommodity", data);
            var list = new UnitedReturn();
            if (UpdateOrderState != null)
            {
                list = JsonConvert.DeserializeObject<UnitedReturn>(UpdateOrderState.ToString());
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上架
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateCommodityPutaway()
        {
            var data = Request["data"];
            var UpdateOrderState = clientHelper.Post("api/XXM_Commodity/PutawayCommodity", data);
            var list = new UnitedReturn();
            if (UpdateOrderState != null)
            {
                list = JsonConvert.DeserializeObject<UnitedReturn>(UpdateOrderState.ToString());
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 下架
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateCommodityOut()
        {
            var data = Request["data"];
            var UpdateOrderState = clientHelper.Post("api/XXM_Commodity/OutCommodity", data);
            var list = new UnitedReturn();
            if (UpdateOrderState != null)
            {
                list = JsonConvert.DeserializeObject<UnitedReturn>(UpdateOrderState.ToString());
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}