using Model;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeadingPlatformMVC.Controllers
{
    public class RedisSetAndGet
    {
        HttpClientHelper clientHelper = new HttpClientHelper();
        public string DataRedis()
        {
            try
            {
                var res = clientHelper.Post("api/YxApi/GetUserInfo", 1);
                if (res != null)
                {
                    var data = JsonConvert.DeserializeObject<UnitedReturn>(res.ToString());
                    var Data = data.data;
                    List<RedisUserName> namelist = JsonConvert.DeserializeObject<List<RedisUserName>>(Data.ToString());
                    RedisHelper helper = new RedisHelper("127.0.0.1");
                    //把范形集合数据存到redis里面
                    helper.addList("NameList", namelist, 0);
                    var Redis=helper.getList<RedisUserName>("NameList",0);
                    if (Redis != null)
                    {
                        return "数据存到Redis成功";
                    }
                    else
                    {
                        return "数据存到Redis失败";
                    }
                    

                }
                else
                {
                    return "获取不到数据";

                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}