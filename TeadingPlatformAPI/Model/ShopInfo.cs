using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class ShopInfo
    {
        /// <summary>
        /// 店铺Id
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 店铺状态
        /// </summary>
        public int ShopState { get; set; }
    }
}
