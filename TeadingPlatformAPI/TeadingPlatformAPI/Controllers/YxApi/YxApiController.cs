using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;
namespace TeadingPlatformAPI.Controllers
{
    public class YxApiController : ApiController
    {
        YxBll YxBll = new YxBll();
        [HttpPost]
        public UnitedReturn OrderShow(object data)
        {
            return YxBll.OrderShow(data);
        }
    }
}
