using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeadingPlatformMVC.Controllers.XXM
{
    public class CommodityController : Controller
    {
        // GET: Commodity

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCommodity()
        {
            return View();
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
        public ActionResult GetType()
        {
            return View();
        }
    }
}