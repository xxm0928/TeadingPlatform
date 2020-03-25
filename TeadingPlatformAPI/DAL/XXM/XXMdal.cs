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
        //存储过程
        Ycx_Helper helper = new Ycx_Helper();

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
                var sql = String.Format($"insert into CommodityInfo values('{commodity.CommodityName}','{commodity.TypeId}','{commodity.ComndityImg}','{commodity.Price}','{commodity.CommditySum}','{commodity.CommodityState}','{commodity.Descride}','{commodity.CommditySize}','{commodity.Testuer}','{commodity.PutawayTime}','{commodity.OutTime}')");
                var res = DBHelper.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res > 0)
                {
                    united.data = null;
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
                var sql = String.Format($"select * from TyoeInfo");
                var res = DBHelper.GetToList<TypeInfo>(sql);
                UnitedReturn united = new UnitedReturn();
                if (res != null&& res.Count>0)
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
        /// 已发布商品展示
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paging"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn SelCommodity(object data, string name, int id)
        {
            try
            {
                CommodityPaging info = new CommodityPaging();
                if (data.ToString() != "System.object" && data.ToString() != "1")
                {
                    info = JsonConvert.DeserializeObject<CommodityPaging>(data.ToString());
                }
                var sql = String.Format($"exec ShowCommdity @id,@username,@pageindex,@pagesize,@totalcount out");

                SqlParameter[] sqls = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,SqlValue=id},
                        new SqlParameter{ ParameterName="@username",SqlDbType=System.Data.SqlDbType.VarChar,SqlValue=name},
                        new SqlParameter{ ParameterName="@pageindex",SqlDbType=System.Data.SqlDbType.Int,SqlValue=info.PagingPagIndex},
                        new SqlParameter{ ParameterName="@pagesize",SqlDbType=System.Data.SqlDbType.Int,SqlValue=info.PagingSize},
                        new SqlParameter{ ParameterName="@totalcount",SqlDbType=System.Data.SqlDbType.Int,Direction=System.Data.ParameterDirection.ReturnValue}
                    };

                var res = DBHelper.GetToList<CommodityPaging>(sql);

                UnitedReturn united = new UnitedReturn();

                if (res != null)
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
        /// 删除已发布商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn DelCommodity(object data)
        {
            try
            {
                var sql = String.Format($"Update CommodityInfo set CommodityState=-1 where CommodityName='{data.ToString()}'");
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
                var sql = String.Format($"Update CommodityInfo set CommodityState=1 where CommodityName='{data.ToString()}'");
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
                var sql = String.Format($"Update CommodityInfo set CommodityState=0 where CommodityName='{data.ToString()}'");
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
