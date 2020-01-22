using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RMT.WebAPI.Helper
{
    public static class SmtpMail
    {
        public static void Send(string mail, string subject, string body)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();           
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = config.GetValue<string>("MailConfig:smtpHost");
                    smtpClient.Port = config.GetValue<int>("MailConfig:smtpPort");
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(config.GetValue<string>("MailConfig:smtpUsername"), config.GetValue<string>("MailConfig:smtpPassword"));
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(config.GetValue<string>("MailConfig:smtpUsername")),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };
                    msg.To.Add(mail);
                    smtpClient.Send(msg);
                    ;
                }
            }
            catch
            {
                Console.WriteLine("err");
            }
        }
    }
}
