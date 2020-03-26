using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TeadingPlatformMVC.Models;

namespace TeadingPlatformMVC.Controllers
{
    public class YcxCodeController : Controller
    {
        // GET: YcxCode
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserSelect()
        {
            

            return View();
        }
        [HttpPost]
        public void UserSelect(Ycx_User model)
        {
            string url = "http://localhost:55041/ycx/add";  //api链接
            HttpClient client = new HttpClient();  //
            string str = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(str);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt32(result);
            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');</script>");
            }
        }

        public ActionResult SelectUser()
        {
            string url = "http://localhost:55041/ycx/";
            HttpClient client = new HttpClient();
            HttpResponseMessage message = client.GetAsync(url).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            List<Ycx_User> list = JsonConvert.DeserializeObject<List<Ycx_User>>(result);
            return View(list.ToList());
        }

        public ActionResult ExitUser(Ycx_User model,int id)
        {
            string url = "http://localhost:55041/ycx/";
            HttpClient client = new HttpClient();
            string str = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(str);
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            int key = Convert.ToInt32(result);
            if (key>0)
            {
                Response.Write("<script>alert('添加成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }

        }
    }
}