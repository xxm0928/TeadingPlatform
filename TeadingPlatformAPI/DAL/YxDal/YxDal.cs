using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
namespace DAL
{
    public class YxDal
    {
        YxDBHelper YxDBHelper = new YxDBHelper();
        /// <summary>
        /// 订单显示
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn OrderShow(object data)
        {
            var ass = 0;
            Orderform orderform = new Orderform();
            //object初始值是System.object 所以判断一下
            if (data.ToString() != "System.object" && data.ToString() != "1")
            {
                orderform = JsonConvert.DeserializeObject<Orderform>(data.ToString());
            }
            else
            {
                ass = 1;
                data = 1;
            }
            string sql = string.Format("select * from Orderform o join UserInfo u on u.UserId=o.UserId join CommodityInfo c on c.CommodityId = o.CommodityId join LogisticsInfo l on l.LogisticsId = o.LogisticsId join ShopInfo s on s.CommodityId = c.CommodityId join TypeInfo t on t.TypeId = c.TypeId where o.OrderState=1");
            var res = YxDBHelper.GetToList<Orderform>(sql);
            UnitedReturn unitedReturn = new UnitedReturn();
            if (res.Count > 0 && res != null)
            {
                if (ass != 1)
                {
                    if (orderform.OrderformId > 0)
                    {
                        res = res.Where(s => s.OrderformId == orderform.OrderformId).ToList();
                    }
                    if (orderform.UserName.Length > 0 && !string.IsNullOrEmpty(orderform.UserName))
                    {
                        res = res.Where(s => s.UserName.Equals(orderform.UserName)).ToList();
                    }
                    if (orderform.UserNumder.Length > 0 && !string.IsNullOrEmpty(orderform.UserNumder))
                    {
                        res = res.Where(s => s.UserNumder == orderform.UserNumder).ToList();
                    }
                    if (orderform.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderform.CommodityName))
                    {
                        res = res.Where(s => s.CommodityName == orderform.CommodityName).ToList();
                    }
                    if (orderform.LogisticsId > 0)
                    {
                        res = res.Where(s => s.LogisticsId == orderform.LogisticsId).ToList();
                    }
                }

                unitedReturn.data = res;
                unitedReturn.res = 1;
                unitedReturn.msg = "获取信息成功";
                //如果res为空 说明查询没有结果
                if (res.Count == 0)
                {
                    unitedReturn.msg = "获取信息成功,但是没有查询到结果";
                }
            }
            else
            {
                unitedReturn.data = null;
                unitedReturn.res = 0;
                unitedReturn.msg = "获取信息失败";
            }
            return unitedReturn;
        }
        /// <summary>
        /// 发货公司下拉列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn LogisticsShow(object data)
        {
            string sql = string.Format("select * from  LogisticsInfo ");
            var res = YxDBHelper.GetToList<Orderform>(sql);
            UnitedReturn unitedReturn = new UnitedReturn();
            if (res.Count > 0 && res != null)
            {
                unitedReturn.data = res;
                unitedReturn.res = 1;
                unitedReturn.msg = "获取信息成功";
            }
            else
            {
                unitedReturn.data = null;
                unitedReturn.res = 0;
                unitedReturn.msg = "获取信息失败";
            }
            return unitedReturn;
        }
    }
}
