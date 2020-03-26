using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeadingPlatformMVC.Controllers
{
    public class UserZController : Controller
    {
        // GET: UserZ
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="yzm"></param>
        /// <returns></returns>
        public int Loginyanz(string yzm)
        {
            int res = 0;
            string code = Session["CheckCode"].ToString();
            if (yzm.ToLower() == code.ToLower())
            {
                res = 1;
                return res;
            }
            else
            {
                return res;
            }
        }
        /// <summary>
        /// 获取登录人
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int LoginUser(string name = "")
        {
            if (name != null)
            {
                Session["name"] = name;
                return 1;
            }
            return 0;
        }
        public ActionResult Mainpage()
        {
            return View();
        }
        public JsonResult AddCookie()
        {
            var lala = Request["data"];
            HttpCookie cookie = new HttpCookie("Name");
            cookie.Value = HttpUtility.UrlEncode(lala);
            Response.Cookies.Add(cookie);
            GetName getName = new GetName()
            {
                Name = lala
            };
            return Json(getName, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCookie()
        {
            HttpCookie cookies = System.Web.HttpContext.Current.Request.Cookies["Name"];
            string Name = HttpUtility.UrlEncode(cookies.Value);
            GetName getName = new GetName()
            {
                Name = Name
            };
            return Json(getName, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Cookie()
        {
            var res = Request.Cookies["Name"];
            var Cookie = HttpUtility.UrlDecode(res.Value);
            GetName getName = new GetName()
            {
                Name = Cookie
            };
            return Json(getName,JsonRequestBehavior.AllowGet);
        }
    }
}