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
        /// 订单显示 。。。。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn OrderShow(object data)
        {
            var ass = 0;
            Orderform orderforms = new Orderform();
            //object初始值是System.object 所以判断一下
            if (data.ToString() != "System.object" && data.ToString() != "1")
            {
                orderforms = JsonConvert.DeserializeObject<Orderform>(data.ToString());
            }
            else
            {
                ass = 1;
                data = 1;
            }
            string sql = string.Format("select * from Orderform o join UserInfo u on u.UserId=o.UserId join CommodityInfo c on c.CommodityId = o.CommodityId join LogisticsInfo l on l.LogisticsId = o.LogisticsId join ShopInfo s on s.ShopId = u.ShopId join TypeInfo t on t.TypeId = c.TypeId ");
            var datas = YxDBHelper.GetToList<Orderform>(sql);
            UnitedReturn unitedReturn = new UnitedReturn();
            if (datas.Count > 0 && datas != null)
            {
                if (ass != 1)
                {
                    if (orderforms.OrderState >= 0)
                    {
                        datas = datas.Where(s => s.OrderState == orderforms.OrderState).ToList();
                    }
                    if (Convert.ToInt32(orderforms.OrderformId) > 0)
                    {
                        datas = datas.Where(s => s.OrderformId == orderforms.OrderformId).ToList();
                    }
                    if (orderforms.UserName.Length > 0 && !string.IsNullOrEmpty(orderforms.UserName))
                    {
                        datas = datas.Where(s => s.UserName.Contains(orderforms.UserName)).ToList();
                    }
                    if (orderforms.UserNumder.Length > 0 && !string.IsNullOrEmpty(orderforms.UserNumder))
                    {
                        datas = datas.Where(s => s.UserNumder == orderforms.UserNumder).ToList();
                    }
                    if (orderforms.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderforms.CommodityName))
                    {
                        datas = datas.Where(s => s.CommodityName.Contains(orderforms.CommodityName)).ToList();
                    }
                    if (orderforms.LogisticsId > 0)
                    {
                        datas = datas.Where(s => s.LogisticsId == orderforms.LogisticsId).ToList();
                    }
                }

                unitedReturn.data = datas;
                unitedReturn.res = 1;
                unitedReturn.msg = "获取信息成功";
                //如果res为空 说明查询没有结果
                if (datas.Count == 0)
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
        /// <summary>
        /// 修改订单状态 发货 State=1 待付款  2 待发货 3 已发货 4 已签收 5 已完成
        /// </summary>11
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UpdateOrderState(object data)
        {
            UnitedReturn unitedReturn = new UnitedReturn();
            if (Convert.ToInt32(data) > 0)
            {
                string sql = string.Format($"Update Orderform set OrderState=3 where OrderformId='{Convert.ToInt32(data)}'");
                var res = YxDBHelper.ExecuteNonQuery(sql);
                if (res > 0)
                {
                    unitedReturn.data = null;
                    unitedReturn.res = 1;
                    unitedReturn.msg = "发货成功";
                }
            }
            else
            {
                unitedReturn.data = null;
                unitedReturn.res = 0;
                unitedReturn.msg = "请选择要发货的订单";
            }
            return unitedReturn;
        }
        /// <summary>
        /// 店铺下拉
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DropListShop(object data)
        {
            UnitedReturn unitedReturn = new UnitedReturn();
            string sql = string.Format("select * from ShopInfo");
            var res = YxDBHelper.GetToList<ShopInfo>(sql);
            if (res != null)
            {
                unitedReturn.data = res;
                unitedReturn.res = 1;
                unitedReturn.msg = "查询成功";
            }
            else
            {
                unitedReturn.data = null;
                unitedReturn.res = 0;
                unitedReturn.msg = "查询失败";
            }
            return unitedReturn;
        }
        /// <summary>
        /// 快递下拉
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DropListLogistics(object data)
        {
            UnitedReturn unitedReturn = new UnitedReturn();
            string sql = string.Format("select * from LogisticsInfo");
            var res = YxDBHelper.GetToList<List<LogisticsInfo>>(sql);
            if (res != null)
            {
                unitedReturn.data = res;
                unitedReturn.res = 1;
                unitedReturn.msg = "查询成功";
            }
            else
            {
                unitedReturn.data = null;
                unitedReturn.res = 0;
                unitedReturn.msg = "查询失败";
            }
            return unitedReturn;
        }
        /// <summary>
        /// 修改订单并接受返回数据
        /// </summary>
        /// <returns></returns>
        public UnitedReturn UpdateOrderDataAndReturnData(object data)
        {
            UnitedReturn unitedReturn = new UnitedReturn();
            if (data != null || data.ToString() != "System.object")
            {
                var info = JsonConvert.DeserializeObject<Orderform>(data.ToString());
                string sql = string.Format($"update Orderform set CommodityCount={info.CommodityCount} where OrderformId={info.OrderformId}");
                var res = YxDBHelper.ExecuteNonQuery(sql);
                string sqls = string.Format($"update UserInfo set UserName='{info.UserName}', UserNumder='{info.UserNumder}' where UserId='{info.UserId}'");
                var ress = YxDBHelper.ExecuteNonQuery(sqls);
                if (res > 0 && ress > 0)
                {
                    unitedReturn.data = null;
                    unitedReturn.res = 1;
                    unitedReturn.msg = "修改成功";
                }
                else
                {
                    unitedReturn.data = null;
                    unitedReturn.res = 0;
                    unitedReturn.msg = "修改失败";
                }
            }
            else
            {
                unitedReturn.res = 0;
            }
            return unitedReturn;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UpdatePwd(object data)
        {
            UnitedReturn unitedReturn = new UnitedReturn();
            if (data != null || data.ToString() != "System.object")
            {
                var info = JsonConvert.DeserializeObject<UserInfo>(data.ToString());
                string sql = string.Format($"update UserInfo set UserPass='{info.UserPass}' where UserName='{info.UserName}'");
                var res = YxDBHelper.ExecuteNonQuery(sql);
                if (res > 0)
                {
                    unitedReturn.data = null;
                    unitedReturn.res = 1;
                    unitedReturn.msg = "修改成功";
                }
                else
                {
                    unitedReturn.data = null;
                    unitedReturn.res = 0;
                    unitedReturn.msg = "修改失败";
                }
            }
            else
            {
                unitedReturn.data = null;
                unitedReturn.res = 0;
                unitedReturn.msg = "修改失败";
            }
            return unitedReturn;
        }
    }
}
