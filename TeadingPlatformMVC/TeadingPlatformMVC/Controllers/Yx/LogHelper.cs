using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeadingPlatformMVC.Controllers
{
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        public void WriteLog(string Name, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(Name);
            log.Error("Error", ex);
        }
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public void WriteLog(string Name, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(Name);
            log.Error(msg);
        }

    }
}