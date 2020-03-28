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
            return XXMdal.Commodity(data);
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodityType(object data)
        {
            return XXMdal.SelCommodityType(data);
        }

        /// <summary>
        /// 已发布商品展示(分页模糊查询)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paging"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodity(object data)
        {
            return XXMdal.SelCommodity(data);
        }

        /// <summary>
        /// 删除已发布商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DelCommodity(object data)
        {
            return XXMdal.DelCommodity(data);
        }

        /// <summary>
        /// 上架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn PutawayCommodity(object data)
        {
            return XXMdal.PutawayCommodity(data);
        }

        /// <summary>
        /// 下架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn OutCommodity(object data)
        {
            return XXMdal.OutCommodity(data);
        }

        /// <summary>
        /// 已下架商品展示
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paging"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn SelOutCommodity(object data)
        {
            return XXMdal.SelOutCommodity(data);
        }

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn CommodityType(object data)
        {
            return XXMdal.CommodityType(data);
        }

        /// <summary>
        /// 店铺下拉
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DropListShop(object data)
        {
            return XXMdal.DropListShop(data);
        }
    }
}
