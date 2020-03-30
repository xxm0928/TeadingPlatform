using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class YcxBll
    {
        //ycx_ 再次修改 3/20 21;41


        YcxDal d = new YcxDal();

        /// <summary>
        /// 借dal 传送数据
        /// </summary>
        /// <returns></returns>
        public UnitedReturn PersonalInformation(object data)
        {
            var list = d.PersonalInformation(data);
            return list;
        }
        /// <summary>
        /// 传送数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UnitedReturn AddPersonalInformation(UserInfo model,object data)
        {
            var result = d.addpersonalinformation(model,data);
            return result;
        }
        /// <summary>
        /// 编辑个人信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnitedReturn ExitPersonalInformation(UserInfo model, int id,object data)
        {
            var result = d.ExitPersonalInformation(model, id,data);
            return result;
        }

    }
}
