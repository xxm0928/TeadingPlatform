
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class Bll
    {
        Dal dal = new Dal();
        /// <summary>
        /// 用户登录
        /// data 是统一参数值
        /// UnitedReturn 是统一返回的类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UnitedReturn UserLogin(object data)
        {
            return dal.UserLogin(data);
        }
       
            #region 3/20 20:25
            /// <summary>
            /// 通过 bll 传递数据
            /// </summary>
            /// <returns></returns>
            //public List<UserInfo> PersonalInformation()
            //{
            //    dal d = new dal();
            //    List<UserInfo> list = d.PersonalInformation();
            //    return list.ToList();


            //}
            /// <summary>
            /// 通过 bll 传递数据
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            //public int AddPersonalInformation(UserInfo model)
            //{
            //    dal d = new dal();
            //    int result=d.AddPersonalInformation(model);
            //    return result;
            //}

            #endregion


       
    }
}
