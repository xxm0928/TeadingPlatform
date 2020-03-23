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
        public UnitedReturn OrderShow(object data)
        {
            string sql = string.Format("select * from Orderform o join UserInfo u on u.UserId=o.UserId join CommodityInfo c on c.CommodityId = o.CommodityId join LogisticsInfo l on l.LogisticsId = o.LogisticsId join ShopInfo s on s.CommodityId = c.CommodityId join TypeInfo t on t.TypeId = c.TypeId where o.OrderState=1");
            var res = YxDBHelper.GetToList<Orderform>(sql);
            UnitedReturn unitedReturn = new UnitedReturn();
            if (res.Count > 0)
            {
                unitedReturn.data=res;
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
