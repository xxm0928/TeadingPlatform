using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeadingPlatformMVC.Controllers
{
    public class RedisHelper
    {
        ConnectionMultiplexer redis;

        public RedisHelper()
        {
            redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        }
        /// <summary>
        /// string类型存储到Redis
        /// </summary>
        /// <param name="RedisName">Redis键名</param>
        /// <param name="RedisValue">Redis键值</param>
        /// <returns></returns>
        public string StringSetToRedis(string RedisName, string RedisValue)
        {
            try
            {
                //设置0号端口
                IDatabase db1 = redis.GetDatabase();
                //根据键值对格式存
                db1.StringSet(RedisName, RedisValue);
                //如果存到Redis成功 给到一个前台提示
                if (db1.KeyExists(RedisName))
                {
                    return "数据存到Redis成功";
                }
                else
                {
                    return "数据存到Redis失败";
                }
            }
            catch (Exception)
            {
                return "发生错误";
                throw;
            }

        }
        /// <summary>
        /// Redis取出string类型数据
        /// </summary>
        /// <param name="RedisName">要取出的键</param>
        /// <returns></returns>
        public string StringGetRedis(string RedisName)
        {
            try
            {
                //设置0号端口
                IDatabase db1 = redis.GetDatabase();
                string RedisValue = db1.StringGet(RedisName);
                if (!string.IsNullOrEmpty(RedisValue))
                {
                    return RedisValue;
                }
                else
                {
                    return "Redis取出数据失败";
                }
            }
            catch (Exception)
            {
                return "发生错误";
                throw;
            }
        }

        /// <summary>
        /// 将一个泛型List添加到缓存中
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="listkey">Key 键值对的键 自己起的名字</param>
        /// <param name="list">list 范形集合</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public bool addList<T>(string listkey, List<T> list, int db_index = 0)
        {
            var db = redis.GetDatabase(db_index);
            var value = JsonConvert.SerializeObject(list);
            return db.StringSet(listkey, value);

        }
        /// <summary>
        /// 通过指定Key值获取泛型List
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="listkey">Key</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public List<T> getList<T>(string listkey, int db_index = 0)
        {
            var db = redis.GetDatabase(db_index);
            if (db.KeyExists(listkey))
            {
                var value = db.StringGet(listkey);
                if (!string.IsNullOrEmpty(value))
                {
                    var list = JsonConvert.DeserializeObject<List<T>>(value);
                    return list;
                }
                else
                {
                    return new List<T>();
                }
            }
            else
            {
                return new List<T>();
            }
        }
        /// <summary>
        /// 删除指定List<T>中满足条件的元素
        /// </summary>
        /// <param name="listkey">Key</param>
        /// <param name="func">lamdba表达式</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public bool delListByLambda<T>(string listkey, Func<T, bool> func, int db_index = 0)
        {
            var db = redis.GetDatabase(db_index);
            if (db.KeyExists(listkey))
            {
                var value = db.StringGet(listkey);
                if (!string.IsNullOrEmpty(value))
                {
                    var list = JsonConvert.DeserializeObject<List<T>>(value);
                    if (list.Count > 0)
                    {
                        list = list.SkipWhile<T>(func).ToList();
                        value = JsonConvert.SerializeObject(list);
                        return db.StringSet(listkey, value);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取指定List<T>中满足条件的元素
        /// </summary>
        /// <param name="listkey">Key</param>
        /// <param name="func">lamdba表达式</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public List<T> getListByLambda<T>(string listkey, Func<T, bool> func, int db_index = 0)
        {
            var db = redis.GetDatabase(db_index);
            if (db.KeyExists(listkey))
            {
                var value = db.StringGet(listkey);
                if (!string.IsNullOrEmpty(value))
                {
                    var list = JsonConvert.DeserializeObject<List<T>>(value);
                    if (list.Count > 0)
                    {
                        list = list.Where(func).ToList();
                        return list;
                    }
                    else
                    {
                        return new List<T>();
                    }
                }
                else
                {
                    return new List<T>();
                }
            }
            else
            {
                return new List<T>();
            }
        }
    }

}
