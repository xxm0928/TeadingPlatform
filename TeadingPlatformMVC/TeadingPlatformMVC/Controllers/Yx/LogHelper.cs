using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeadingPlatformMVC.Controllers
{
    /// <summary>
    /// log4日志
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="Name">你的方法名</param>
        /// <param name="msg">你的错误信息</param>
        public void WriteLog(string Name, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(Name);
            log.Error("Error", ex);
        }
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="Name">你的方法名</param>
        /// <param name="msg">你的错误信息</param>
        public void WriteLog(string Name, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(Name);
            log.Error(msg);
        }

    }
}