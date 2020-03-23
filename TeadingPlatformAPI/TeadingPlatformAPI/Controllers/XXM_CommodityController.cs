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

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn Commodity(object data)
        {
            try
            {
                return xxmbll.Commodity(data);
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

        /// <summary>
        /// 商品类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodityType(object data)
        {
            try
            {
                return xxmbll.SelCommodityType(data);
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

        /// <summary>
        /// 已发布商品展示(分页模糊查询)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paging"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodity(object data, string name, int id)
        {
            try
            {
                return xxmbll.SelCommodity(data, name, id);
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

        /// <summary>
        /// 删除已发布商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DelCommodity(object data)
        {
            try
            {
                return xxmbll.DelCommodity(data);
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

        /// <summary>
        /// 上架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn PutawayCommodity(object data)
        {
            try
            {
                return xxmbll.PutawayCommodity(data);
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

        /// <summary>
        /// 下架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn OutCommodity(object data)
        {
            try
            {
                return xxmbll.OutCommodity(data);
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
