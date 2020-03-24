using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 统一返回值的类
    /// </summary>
    public class UnitedReturn
    {
        /// <summary>
        /// 返回值
        /// </summary>
        public int res { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 返回字段
        /// </summary>
        public string msg { get; set; }
    }
}
