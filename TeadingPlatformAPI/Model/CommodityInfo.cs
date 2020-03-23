using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    public class CommodityInfo
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ComndityImg { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int CommditySum { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int CommodityState { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descride { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string CommditySize { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string Testuer { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime PutawayTime { get; set; }
        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime OutTime { get; set; }
    }
}
