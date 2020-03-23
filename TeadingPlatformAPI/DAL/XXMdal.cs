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
                CommodityInfo commodity = JsonConvert.DeserializeObject<CommodityInfo>(data.ToString());
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

                return new UnitedReturn() { data = ex.InnerException.Message,res=-1,msg=ex.Message };
            }

        }
    }
}
