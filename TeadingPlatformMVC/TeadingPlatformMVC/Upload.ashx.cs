using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeadingPlatformMVC
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var num = context.Request.Files.Count;

            string path = "";

            for (int i = 0; i < num; i++)
            {
                HttpPostedFile file = context.Request.Files[i];
                //上传的文件保存到目录(为了保证文件名不重复，加个Guid)
                path = "/Img/" + Guid.NewGuid().ToString() + file.FileName;
                file.SaveAs(context.Request.MapPath(path));//必须得是相对路径

            }
            context.Response.Write(path);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}