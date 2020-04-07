using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace TeadingPlatformMVC.Controllers
{
    public class UserZController : Controller
    {
        
        LogHelper logHelper = new LogHelper();
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
            try
            {
                return View();
            }
            catch (Exception)
            {
                logHelper.WriteLog("Login", "登录注册");
                throw;
            }
            
        }
        public JsonResult AddUser()
        {
            var password = Request["mm"];
            User user = new User();
            user.UserPass = GenerateMD5(password);
            GetName getName = new GetName()
            {
                Name = user.UserPass
            };
            return Json(getName, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// MD5字符串加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>加密后字符串</returns>
        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="yzm"></param>
        /// <returns></returns>
        public int Loginyanz(string yzm)
        {
            try
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
            catch (Exception)
            {
                logHelper.WriteLog("Loginyanz", "验证码");
                throw;
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
            try
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
            catch (Exception)
            {
                logHelper.WriteLog("Cookie", "获取cookie值");
                throw;
            }
           
        }
       
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
                ViewBag.Name = getName.Name;
                return Json(getName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                logHelper.WriteLog("Cookie", "读取cookie值");
                throw;
            }
            
        }
        /// <summary>
        /// 店铺
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopInfo()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                logHelper.WriteLog("ShopInfo", "店铺列表");
                throw;
            }
           
        }
        /// <summary>
        /// 添加店铺
        /// </summary>
        /// <returns></returns>
        public ActionResult AddShopInfo()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                logHelper.WriteLog("AddShopInfo", "添加店铺");
                throw;
            }
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
            try
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
            catch (Exception)
            {
                logHelper.WriteLog("GetEmailPass", "获取邮箱验证码");
                throw;
            }
          
        }
        HttpClientHelper clientHelper = new HttpClientHelper();
        /// <summary>
        /// 页面首次加载 生成token
        /// </summary>
        /// <returns></returns>
        public JsonResult Token()
        {
            try
            {
                GetName name = new GetName();
                var res = clientHelper.Post("api/Token/GetAuthToken", 1);
                if (res != null)
                {
                    name.Name = res.ToString();
                }
                return Json(name, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                logHelper.WriteLog("Token", "页面首次加载生成token");
                throw;
            }
            
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdatePwd()
        {
            try
            {
                UnitedReturn united = new UnitedReturn();
                var request = Request["Data"];
                if (request != null)
                {
                    var res = clientHelper.Post("api/YxApi/UpdatePwd", request);
                    united = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                }
                return Json(united, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                logHelper.WriteLog("UpdatePwd", "修改密码");
                throw;
            } 
        }
    }
}