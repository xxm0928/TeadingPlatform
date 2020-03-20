using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Orderform
    {
        public int OrderformId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string OrderNumser { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public int CommodityCount { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int LogisticsId { get; set; }
        /// <summary>
        ///物流编号
        /// </summary>
    }
}
