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
            if (name!=null)
            {
                Session["name"] = name;
                return 1;
            }
            return 0;
        }

    }
}