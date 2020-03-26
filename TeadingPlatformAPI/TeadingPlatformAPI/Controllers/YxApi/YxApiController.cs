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
        /// <summary>
        /// 订单显示
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn OrderShow(object data)
        {
            return YxBll.OrderShow(data);
        }
        /// <summary>
        /// 发货公司下拉列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn LogisticsShow(object data)
        {
            return YxBll.LogisticsShow(data);
        }
        /// <summary>
        /// 修改订单状态 发货 State=1 待付款  2 待发货 3 已发货 4 已签收 5 已完成
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn UpdateOrderState(object data)
        {
            return YxBll.UpdateOrderState(data);
        }
        /// <summary>
        /// 店铺下拉
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn DropListShop(object data)
        {
            return YxBll.DropListShop(data);
        }
        /// <summary>
        /// 快递下拉
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn DropListLogistics(object data)
        {
            return YxBll.DropListLogistics(data);
        }
        /// <summary>
        /// 修改订单并接受返回数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public UnitedReturn UpdateOrderDataAndReturnData(object data)
        {
            return YxBll.UpdateOrderDataAndReturnData(data);
        }
    }
}
