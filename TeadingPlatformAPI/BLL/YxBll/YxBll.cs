using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class YxBll
    {
        YxDal YxDal = new YxDal();
        /// <summary>
        /// 订单显示
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn OrderShow(object data)
        {
            return YxDal.OrderShow(data);
        }
        /// <summary>
        /// 发货公司下拉列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn LogisticsShow(object data)
        {
            return YxDal.LogisticsShow(data);
        }
        /// <summary>
        /// 修改订单状态 发货 State=1 待付款  2 待发货 3 已发货 4 已签收 5 已完成
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UpdateOrderState(object data)
        {
            return YxDal.UpdateOrderState(data);
        }
    }
}
