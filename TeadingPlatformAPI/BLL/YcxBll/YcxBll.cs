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
        public List<UserInfo> PersonalInformation()
        {
            List<UserInfo> list = d.PersonalInformation();
            return list.ToList();
        }
        /// <summary>
        /// 传送数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPersonalInformation(UserInfo model)
        {
            int result = d.addpersonalinformation(model);
            return result;
        }

        public int ExitPersonalInformation(UserInfo model, int id)
        {
            int result = d.ExitPersonalInformation(model, id);
            return result;
        }

    }
}
