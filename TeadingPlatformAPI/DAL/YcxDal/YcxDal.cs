using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class YcxDal
    {
        Ycx_Helper help = new Ycx_Helper();
        DBHelper helpX = new DBHelper();
        #region ycx_3/20 20:10
        /// <summary>
        /// 获取集合数据
        /// </summary>
        /// <returns></returns>
        public UnitedReturn PersonalInformation(object data)
        {
            try
            {
                var textSql = "exec UserInfo_proc_Select";
                List<UserInfo> ListT = helpX.GetToList<UserInfo>(textSql);
                UnitedReturn united = new UnitedReturn();
                
                if (ListT !=null && ListT.Count>0)
                {
                    united.data = ListT;
                    united.msg = "成功！";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "失败！";
                    united.res = 0; 
                }
                return united;
            }
            catch (Exception ex)
            {

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
            //Ycx_Helper help = new Ycx_Helper();
            ////string textSql = "exec UserInfo_proc_Select";
            //List<UserInfo> list = help.Getlist<UserInfo>(textSql);
            //return list.ToList();
        }
        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UnitedReturn addpersonalinformation(UserInfo model, object data)
        {

            try
            {
                //if (data.ToString()!="System.object" && data.ToString()!="1")
                //{
                //    model = JsonConvert.DeserializeObject<UserInfo>(JsonConvert.SerializeObject(data));
                //}
                var textsql = $"exec userinfo_proc_add '{model.UserName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
               
                var result = helpX.ExecuteNonQuery(textsql);
                UnitedReturn united = new UnitedReturn();

                if (result > 0)
                {
                    united.data = result;
                    united.msg = "添加成功";
                    united.res = 1;
                }
                else
                {
                    united.data = null;
                    united.msg = "添加失败";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }

            //string textsql = $"exec userinfo_proc_add '{model.UserName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
            //int result = help.GetLine(textsql);

        }
        #endregion
        /// <summary>
        /// 编辑个人信息 ycx
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn ExitPersonalInformation(UserInfo model, int id,object data)
        {
            try
            {
                var sql = $"exec UserInfo_proc_Exit {id},'{model.UserName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
                var res = helpX.ExecuteNonQuery(sql);
                UnitedReturn united = new UnitedReturn();
                if (res>0)
                {
                    united.data = res;
                    united.msg = "修改成功";
                    united.res = 1;

                }
                else
                {
                    united.data = null;
                    united.msg = "修改失败";
                    united.res = 0;
                }
                return united;
            }
            catch (Exception ex)
            {

                return new UnitedReturn() { data = ex.InnerException.Message, res = -1, msg = ex.Message };
            }
            //string sql = $"exec UserInfo_proc_Exit {id},'{model.UserName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
            //Ycx_Helper help = new Ycx_Helper();

            //int result = help.GetLine(sql);
            //return result;


        }
       

    }


}

