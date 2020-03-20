using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using System.Data.SqlClient;
namespace DAL
{
    public class Dal
    {
        
        /// <summary>
        /// 用户登录
        /// data 是统一参数值
        /// UnitedReturn 是统一返回的类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserLogin(object data)
        {

            var res = string.Format("$select * from UserInfo u where u.Uname='{}' and u.Upwd='{}'");
            return dal.UserLogin(data);
        }
    }
}
