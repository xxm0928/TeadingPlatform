using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class Bll
    {
        Dal dal = new Dal();
        /// <summary>
        /// 用户登录
        /// data 是统一参数值
        /// UnitedReturn 是统一返回的类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserLogin(object data)
        {
            return dal.UserLogin(data);
        }
    }
}
