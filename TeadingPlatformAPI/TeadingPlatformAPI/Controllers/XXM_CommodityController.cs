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
        [HttpPost]
        public UnitedReturn Commodity(object data)
        {
            return xxmbll.Commodity(data);
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn SelCommodityType(object data)
        {
            return xxmbll.SelCommodityType(data);
        }

        /// <summary>
        /// 已发布商品展示(分页模糊查询)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paging"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn SelCommodity(object data, string name, int id)
        {
            return xxmbll.SelCommodity(data, name, id);
        }

        /// <summary>
        /// 删除已发布商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn DelCommodity(object data)
        {
            return xxmbll.DelCommodity(data);
        }

        /// <summary>
        /// 上架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn PutawayCommodity(object data)
        {
            return xxmbll.PutawayCommodity(data);
        }

        /// <summary>
        /// 下架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn OutCommodity(object data)
        {
            return xxmbll.OutCommodity(data);
        }
    }
}
