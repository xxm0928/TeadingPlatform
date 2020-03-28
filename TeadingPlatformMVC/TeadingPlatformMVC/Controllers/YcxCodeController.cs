using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            string url = "http://localhost:55041/ycx/PersonalInformation";
            HttpClient client = new HttpClient();
            HttpResponseMessage message = client.GetAsync(url).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            List<Ycx_User> list = JsonConvert.DeserializeObject<List<Ycx_User>>(result);
            return View(list.ToList());
        }

        public ActionResult ExitUser()
        {
            return View();
        }
        [HttpPost]
        public void ExitUser(Ycx_User model,int id)
        {
            string url = "http://localhost:55041/ycx/exit?ids=" + id;
            HttpClient client = new HttpClient();
            string str = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(str);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            int key = Convert.ToInt32(result);
            if (key>0)
            {
                Response.Write("<script>alert('修改成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
            return View();
        }


    }

    public class Upload
    {
        public string uploadImage(FileUpload FUSShopURL, string UpladURL)
        {
            if (FUSShopURL.HasFile)
            {
                //获取当前时间，当作图片的名字
                string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + DateTime.Now.Millisecond.ToString();
                //获取图片的扩展名
                string Extent = System.IO.Path.GetExtension(FUSShopURL.PostedFile.FileName);
                //重命名图片
                fileName += Extent;
                //设置上传图片保存的文件夹
                string dir = System.Web.HttpContext.Current.Server.MapPath(UpladURL);
                //指定图片的路径及文件名
                string path = dir + "\\" + fileName;
                //把上传的图片保存到指定的文件中
                FUSShopURL.PostedFile.SaveAs(path);
                return fileName;
            }
            else
            {
                return "";
            }
        }
    }


}