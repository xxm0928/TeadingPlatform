using System;
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
        Orderform Orderform = new Orderform();
        public ActionResult Order()
        {
            UnitedReturn unitedReturn = new UnitedReturn();
            var data =1;
            var url = Request.Url.ToString();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:55041/");
            HttpContent content = new StringContent(data.ToString());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage message = httpClient.PostAsync("api/YxApi/OrderShow", content).Result;
            if (message.IsSuccessStatusCode)
            {
                var res = message.Content.ReadAsStringAsync().Result;
                var mata = JsonConvert.DeserializeObject<UnitedReturn>(res);
                ViewBag.List = mata.data;
                ViewBag.Id = mata.res;
                return View(mata);
            }
            return View();
        }
    }
}