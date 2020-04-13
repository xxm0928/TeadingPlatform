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
        LogHelper log = new LogHelper();
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
            try
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
            catch (Exception)
            {
                log.WriteLog("GetCookie", "获取Cookie");
                throw;
            }
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
            if (request == null)
            {
                request = "1";
            }
            var res = clientHelper.Post("api/XXM_Commodity/SelCommodity", request);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 用来获取总数据条数
        /// </summary>
        /// <returns></returns>
        public JsonResult Count()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/SelCommodity", request);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            return Json(new { Count = data.Count }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IndexData()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/SelCommodity", request);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            PageIndex page = new PageIndex();
            if (!string.IsNullOrEmpty(request))
            {
                page = JsonConvert.DeserializeObject<PageIndex>(request);
            }
            page.Count = data.Count;
            data = data.Skip((Convert.ToInt32(page.Page) - 1) * page.Size).Take(page.Size).ToList();
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
            var res = clientHelper.Post("api/XXM_Commodity/SelOutCommodity", request);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 用来获取总数据条数
        /// </summary>
        /// <returns></returns>
        public JsonResult Counts()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/SelOutCommodity", request);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            return Json(new { Count = data.Count }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IndexDatas()
        {
            var request = Request["data"];
            var res = clientHelper.Post("api/XXM_Commodity/SelOutCommodity", request);
            List<CommodityInfo> data = new List<CommodityInfo>();
            if (res != null)
            {
                data = JsonConvert.DeserializeObject<List<CommodityInfo>>((JsonConvert.DeserializeObject<UnitedReturn>(res.ToString())).data.ToString());
            }
            PageIndex page = new PageIndex();
            if (!string.IsNullOrEmpty(request))
            {
                page = JsonConvert.DeserializeObject<PageIndex>(request);
            }
            page.Count = data.Count;
            data = data.Skip((Convert.ToInt32(page.Page) - 1) * page.Size).Take(page.Size).ToList();
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