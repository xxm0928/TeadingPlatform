using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class YcxDal
    {
        #region ycx_3/20 20:10
        /// <summary>
        /// 获取集合数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> PersonalInformation()
        {
            Ycx_Helper help = new Ycx_Helper();
            string textSql = "exec UserInfo_proc_Select";
            List<UserInfo> list = help.Getlist<UserInfo>(textSql);
            return list.ToList();
        }
        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addpersonalinformation(UserInfo model)
        {
            
            Ycx_Helper help = new Ycx_Helper();
            string textsql = $"exec userinfo_proc_add '{model.ShopName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
            int result = help.GetLine(textsql);
            return result;
        }
        #endregion
        /// <summary>
        /// 编辑个人信息 ycx
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ExitPersonalInformation(UserInfo model,int id)
        {
            string sql = $"exec UserInfo_proc_Exit {id},'{model.ShopName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
            Ycx_Helper help = new Ycx_Helper();
            
            int result =help.GetLine(sql);
            return result;


        }
    }


}

