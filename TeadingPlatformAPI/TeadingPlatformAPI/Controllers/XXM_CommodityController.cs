using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.XXMbll;
using Model;

namespace TeadingPlatformAPI.Controllers
{
    public class XXM_CommodityController : ApiController
    {
        xxmbll xxmbll = new xxmbll();
        public UnitedReturn UserLogin(object data)
        {
            return xxmbll.Commodity(data);
        }
    }
}
