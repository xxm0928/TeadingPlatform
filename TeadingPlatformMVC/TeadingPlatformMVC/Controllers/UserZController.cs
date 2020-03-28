using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
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
            ///保存用户名的cookie
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
            GetName getName = new GetName();
            if (res == null)
            {
                getName.Name = "";
            }
            else
            {
                getName.Name = HttpUtility.UrlDecode(res.Value);
            }
            ViewBag.Name = getName.Name;
            return Json(getName, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 店铺
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopInfo()
        {
            return View();
        }
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <returns></returns>
        public ActionResult AddShopInfo()
        {
            return View();
        }
        /// <summary>
        /// 找回密码的视图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPass()
        {
            return View();
        }
        /// <summary>
        /// 获取邮箱验证码
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEmailPass()
        {
            EmailAndName ands = new EmailAndName();
            var request = Request["data"];
            GetName data = new GetName();
            if (request != null)
            {
                var res = JsonConvert.DeserializeObject<EmailAndName>(request.ToString());
                Email email = new Email();
                ///返回的验证码
                data.Name = email.QQ_email(res.Email, res.Name);
            }
            else
            {
                data.Name = "信息为空,无法获取验证码";
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        HttpClientHelper clientHelper = new HttpClientHelper();
        /// <summary>
        /// 邮箱验证成功 根据用户名找密码
        /// </summary>
        /// <returns></returns>
        public JsonResult SetNameGetPass()
        {
            try
            {
                List<Orderform> data = new List<Orderform>();
                var request = Request["data"];
                User user = new User();
                if (request != null)
                {
                    var GetName = JsonConvert.DeserializeObject<GetName>(request.ToString());
                    var res = clientHelper.Post("api/YxApi/OrderShow", 1);
                    if (res != null)
                    {
                        var mata = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                        data = JsonConvert.DeserializeObject<List<Orderform>>(mata.data.ToString());
                    }
                    if (GetName != null)
                    {
                        data = data.Where(s => s.UserName == GetName.Name).ToList();
                    }
                }
                if (data.Count == 0)
                {
                    user.UserPass = "找不到该用户,请确认后重新输入";
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}