using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using Model;
using Newtonsoft.Json;

namespace TeadingPlatformAPI.Controllers
{
    public class UserController : ApiController
    {

        Ycx_Helper helpx = new Ycx_Helper();
        [HttpPost]
        public UnitedReturn Add(object data)
        {
            UserInfo um = new UserInfo();
            
            if (data.ToString() != "System.object" && data.ToString() != "1")
            {
                um = JsonConvert.DeserializeObject<UserInfo>(JsonConvert.SerializeObject(data));
            }
            string sql = $"insert into UserInfo values('{um.UserName}','{um.UserPhoto}',{um.UserSex},{um.ShopId},'{um.UserNumder}',{um.UserAge},'{um.UserIDNumber}')";
            var res = helpx.ExecuteNonQuery(sql);
            UnitedReturn united = new UnitedReturn();
            if (res > 0)
            {
                united.data = res;
                united.msg = "添加成功！";
                united.res = 1;
            }
            else
            {
                united.data = null;
                united.msg = "添加失败！";
                united.res = 0;
            }
            return united;


        }
        [HttpPost]
        public UnitedReturn SelectUser(object data)
        {
            string sql = "select * from UserInfo ";
         
            UserInfo User = new UserInfo();
            //object初始值是System.object 所以判断一下
            if (data.ToString() != "System.object" && data.ToString() != "1")
            {
                User = JsonConvert.DeserializeObject<UserInfo>(data.ToString());
            }
           
            List<UserInfo> list=helpx.Getlist<UserInfo>(sql);
           
            UnitedReturn united = new UnitedReturn();
            if (list.Count>0 && list!=null)
            {
                united.data = list;
                united.res=1;
                united.msg = "获取信息成功";
            }
            else
            {
                united.data = null;
                united.res = 0;
                united.msg = "获取信息失败";
            }
            return united;
        }
        [HttpPost]
        public UnitedReturn SelectType(object data)
        {
            string sql = "select * from ShopInfo ";

            UserInfo User = new UserInfo();
            //object初始值是System.object 所以判断一下
            if (data.ToString() != "System.object" && data.ToString() != "1")
            {
                User = JsonConvert.DeserializeObject<UserInfo>(data.ToString());
            }

            List<ShopInfo> list = helpx.Getlist<ShopInfo>(sql);

            UnitedReturn united = new UnitedReturn();
            if (list.Count > 0 && list != null)
            {
                united.data = list;
                united.res = 1;
                united.msg = "获取信息成功";
            }
            else
            {
                united.data = null;
                united.res = 0;
                united.msg = "获取信息失败";
            }
            return united;
        }
        [HttpPost]
        public UnitedReturn UpdateUser(int ids,object data)
        {
            UserInfo um = new UserInfo();

            if (data.ToString() != "System.object" && data.ToString() != "1")
            {
                um = JsonConvert.DeserializeObject<UserInfo>(JsonConvert.SerializeObject(data));
            }
            string sql = $"update UserInfo set UserName='{um.UserName}',UserPhoto='{um.UserPhoto}',UserSex={um.UserSex},ShopId={um.ShopId},UserNumder='{um.UserNumder}',UserAge={um.UserAge},UserIDNumber='{um.UserIDNumber}' where UserNumder='{ids}'";
            var res = helpx.ExecuteNonQuery(sql);
            UnitedReturn united = new UnitedReturn();
            if (res > 0)
            {
                united.data = res;
                united.msg = "修改成功！";
                united.res = 1;
            }
            else
            {
                united.data = null;
                united.msg = "修改失败！";
                united.res = 0;
            }
            return united;
        }


    }
}
