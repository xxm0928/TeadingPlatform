using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace TeadingPlatformMVC.Controllers
{
    public class Email
    {
        //实例化一个发送邮件类。
        private static MailMessage mailMessage = new MailMessage();
        /// <summary>
        /// </summary>
        /// <param name="Email">邮箱地址</param>
        /// <param name="Name">用户名 用来找回密码的那个 不要写错拉</param>
        /// <returns></returns>
        public string QQ_email(string Email, string Name)
        {
            var Sname = "";
            if (Name == "")
            {
                Sname = "1";
            }
            else
            {
                Sname = Name;
            }
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress(Email, Sname);
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(Email));
            //邮件标题。
            mailMessage.Subject = "发送验证码";
            ///生成一个随机数
            Random random = new Random();
            ///最大值999999
            var randomNumber = random.Next(999999);
            //邮件内容。
            mailMessage.Body = "您好，您的验证码为：" + randomNumber;
            //添加到附件中
            var str = randomNumber;
            //AddAnnex("1号附件路径,2号附件路径,...");
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            //这个后面的字符串 是qq邮箱里面打开设置 账户里面把那个授权码获取到 每个人的都不一样
            //杨兴邮箱 2235577158@qq.com 授权码xtwvzvhkxeivdjjg
            //许学铭邮箱 2041314558@qq.com 授权码dwvwzhqyqtckeidd
            //赵航邮箱2385389803@qq.com 授权码tdnxowddgwnaeaib
            client.Credentials = new NetworkCredential(Email, "dwvwzhqyqtckeidd");
            //发送
            client.Send(mailMessage);
            //这个返回值是用来验证你找回密码是否跟这个一致 如果一致 则可以找回密码
            return str.ToString();
        }
        //这个附件是上传文件的 不需要 只需要验证码
        //private static void AddAnnex(string Path)
        //{
        //    string[] path = Path.Split(',');
        //    Attachment data;
        //    ContentDisposition disposition;
        //    for (int i = 0; i < path.Length; i++)
        //    {
        //        data = new Attachment(path[i], MediaTypeNames.Application.Octet);//实例化附件 
        //        disposition = data.ContentDisposition;
        //        disposition.CreationDate = System.IO.File.GetCreationTime(path[i]);//获取附件的创建日期 
        //        disposition.ModificationDate = System.IO.File.GetLastWriteTime(path[i]);//获取附件的修改日期 
        //        disposition.ReadDate = System.IO.File.GetLastAccessTime(path[i]);//获取附件的读取日期 
        //        mailMessage.Attachments.Add(data);//添加到附件中 
        //    }
        //}


    }
}