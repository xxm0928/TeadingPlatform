using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TeadingPlatformMVC.Controllers
{
    public class HttpClientHelper
    {
        public object Post(string url,object data)
        {
            if (data == null)
            {
                data = 1;
            }
            var res = "";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:55041/");
            HttpContent content = new StringContent(data.ToString());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage message = httpClient.PostAsync(url, content).Result;
            if (message.IsSuccessStatusCode)
            {
                res = message.Content.ReadAsStringAsync().Result;
            }
            return res;
        }
    }
}