using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orderform
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderformId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumser { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int CommodityCount { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        ///物流编号
        /// </summary>
        public int LogisticsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ComndityImg { get; set; }
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
        /// <summary>
        /// 物流名称
        /// </summary>
        public string LogisticsName { get; set; }
        /// <summary>
        /// 店铺Id
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserPhoto { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public int UserSex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string UserNumder { get; set; }
        /// <summary>
        /// 用户年龄
        /// </summary>
        public int UserAge { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string UserIDNumber { get; set; }
    }
}
