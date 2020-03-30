using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace DAL
{
    public class XXMdal
    {
        //SQL语句
        DBHelper DBHelper = new DBHelper();

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn Commodity(object data)
        {
            try
            {
                CommodityInfo commodity = new CommodityInfo();
                if (data.ToString() != "System.object" && data.ToString() != "1")
                {
                    commodity = JsonConvert.DeserializeObject<CommodityInfo>(data.ToString());
                }
                var sql = String.Format($"insert into CommodityInfo (CommodityName,TypeId,ComndityImg,Price,CommditySum,CommodityState,Descride,CommditySize,Testuer,PutawayTime,ShopId) values('{commodity.CommodityName}','{commodity.TypeId}','{commodity.ComndityImg}','{commodity.Price}','{commodity.CommditySum}',1,'{commodity.Descride}','{commodity.CommditySize}','{commodity.Testuer}',GETDATE(),'{commodity.ShopId}')");
                var res = DBHelper.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res > 0)
                {
                    united.data = res;
                    united.msg = "添加成功!";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "添加失败!";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn CommodityType(object data)
        {
            try
            {
                TypeInfo commodity = new TypeInfo();
                if (data.ToString() != "System.object" && data.ToString() != "1")
                {
                    commodity = JsonConvert.DeserializeObject<TypeInfo>(data.ToString());
                }
                var sql = String.Format($"insert into TypeInfo values('{commodity.TypeName}'");
                var res = DBHelper.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res > 0)
                {
                    united.data = res;
                    united.msg = "添加成功!";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "添加失败!";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodityType(object data)
        {
            try
            {
                var sql = String.Format($"select * from TypeInfo");
                var res = DBHelper.GetToList<TypeInfo>(sql);
                UnitedReturn united = new UnitedReturn();
                if (res != null && res.Count > 0)
                {
                    united.data = res;
                    united.msg = "成功!";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "失败!";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
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
            var res = DBHelper.GetToList<ShopInfo>(sql);
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
        /// 已上架商品展示
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paging"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodity(object data)
        {
            try
            {
                var ass = 0;
                CommodityInfo orderforms = new CommodityInfo();
                //object初始值是System.object 所以判断一下
                if (data.ToString() != "System.object" && data.ToString() != "1")
                {
                    orderforms = JsonConvert.DeserializeObject<CommodityInfo>(data.ToString());
                }
                else
                {
                    ass = 1;
                    data = 1;
                }
                string sql = string.Format("select c.CommodityId,s.ShopName,c.CommodityName,c.ComndityImg,t.TypeName,c.CommditySum,c.Price from CommodityInfo as c join TypeInfo as t on c.TypeId = t.TypeId join ShopInfo as s on c.ShopId = s.ShopId join UserInfo as u on u.ShopId = s.ShopId where c.CommodityState > 0");
                var datas = DBHelper.GetToList<CommodityInfo>(sql);
                UnitedReturn unitedReturn = new UnitedReturn();
                if (datas.Count > 0 && datas != null)
                {
                    if (ass != 1)
                    {
                        if (orderforms.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderforms.CommodityName))
                        {
                            datas = datas.Where(s => s.CommodityName.Contains(orderforms.CommodityName)).ToList();
                        }
                        if (orderforms.TypeId > 0)
                        {
                            datas = datas.Where(s => s.TypeId == orderforms.TypeId).ToList();
                        }
                        if (orderforms.ShopId > 0)
                        {
                            datas = datas.Where(s => s.ShopId == orderforms.ShopId).ToList();
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
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
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
            try
            {
                var ass = 0;
                CommodityInfo orderforms = new CommodityInfo();
                //object初始值是System.object 所以判断一下
                if (data.ToString() != "System.object" && data.ToString() != "1")
                {
                    orderforms = JsonConvert.DeserializeObject<CommodityInfo>(data.ToString());
                }
                else
                {
                    ass = 1;
                    data = 1;
                }
                string sql = string.Format("select c.CommodityId,s.ShopName,c.CommodityName,c.ComndityImg,t.TypeName,c.CommditySum,c.Price from CommodityInfo as c join TypeInfo as t on c.TypeId = t.TypeId join ShopInfo as s on c.ShopId = s.ShopId join UserInfo as u on u.ShopId = s.ShopId where c.CommodityState = 0");
                var datas = DBHelper.GetToList<CommodityInfo>(sql);
                UnitedReturn unitedReturn = new UnitedReturn();
                if (datas.Count > 0 && datas != null)
                {
                    if (ass != 1)
                    {
                        if (orderforms.CommodityName.Length > 0 && !string.IsNullOrEmpty(orderforms.CommodityName))
                        {
                            datas = datas.Where(s => s.CommodityName.Contains(orderforms.CommodityName)).ToList();
                        }
                        if (orderforms.TypeId > 0)
                        {
                            datas = datas.Where(s => s.TypeId==orderforms.TypeId).ToList();
                        }
                        if (orderforms.ShopId > 0)
                        {
                            datas = datas.Where(s => s.ShopId == orderforms.ShopId).ToList();
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
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }

        /// <summary>
        /// 删除已发布商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DelCommodity(object data)
        {
            try
            {
                var sql = String.Format($"Update CommodityInfo set CommodityState=-1 where CommodityId='{Convert.ToInt32(data)}'");
                var res = DBHelper.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res > 0)
                {
                    united.data = null;
                    united.msg = "删除成功!";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "删除失败!";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }

        /// <summary>
        /// 上架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn PutawayCommodity(object data)
        {
            try
            {
                var sql = String.Format($"Update CommodityInfo set CommodityState=1,PutawayTime=GETDATE() where CommodityId='{Convert.ToInt32(data)}'");
                var res = DBHelper.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res > 0)
                {
                    united.data = null;
                    united.msg = "已上架!";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "上架失败!";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }

        /// <summary>
        /// 下架操作
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn OutCommodity(object data)
        {
            try
            {
                var sql = String.Format($"Update CommodityInfo set CommodityState=0,OutTime=GETDATE() where CommodityId='{Convert.ToInt32(data)}'");
                var res = DBHelper.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res > 0)
                {
                    united.data = null;
                    united.msg = "已下架!";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "下架失败!";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {
                //错误日志 log4net
                //1请求接口
                //2请求参数
                //3错误信息
                //4请求时间

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
        }
    }
}
