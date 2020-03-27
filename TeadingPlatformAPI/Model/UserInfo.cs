using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
       
        public string ShopName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserPhoto { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public int UserSex { get; set; }
        /// <summary>
        /// 店铺Id
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string UserNumder { get; set; }
        /// <summary>
        /// 用户年龄
        /// </summary>
        public int UserAge { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string UserIDNumber { get; set; }
    }
}
