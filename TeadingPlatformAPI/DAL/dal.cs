using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dal
    {
        #region ycx_3/20 20:10
        /// <summary>
        /// 获取集合数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> PersonalInformation()
        {
            Helper_ycx help = new Helper_ycx();
            string textSql = "exec UserInfo_proc_Select";
            List<UserInfo> list = help.Getlist<UserInfo>(textSql);
            return list.ToList();
        }
        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPersonalInformation(UserInfo model)
        {
            Helper_ycx help = new Helper_ycx();
            string textSql = $"exec UserInfo_proc_Add '{model.UserName}','{model.UserPhoto}',{model.UserSex},{model.ShopId},'{model.UserNumder}','{model.UserAge}','{model.UserIDNumber}'";
            int result = help.GetLine(textSql);
            return result;

        }
        #endregion


    }
}
