using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL.XXMbll
{
    public class xxmbll
    {
        XXMdal XXMdal = new XXMdal();
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn Commodity(object data)
        {
            try
            {
                return XXMdal.Commodity(data);
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }
    }
}
