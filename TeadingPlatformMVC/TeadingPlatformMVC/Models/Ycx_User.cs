using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeadingPlatformMVC.Models
{
    public class Ycx_User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户头像(url)
        /// </summary>
        public string UserPhoto { get; set; }
        /// <summary>
        /// 用户性别  1 男 0 女
        /// </summary>
        public int UserSex { get; set; }
        /// <summary>
        /// 店铺ID 对应商品
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string UserNumder { get; set; }
        /// <summary>
        /// 用户年龄
        /// </summary>
        public int UserAge { get; set; }
        /// <summary>
        /// 用户身份证
        /// </summary>
        public string UserIDNumber { get; set; }
        public string ShopName { get; set; }
    }
}