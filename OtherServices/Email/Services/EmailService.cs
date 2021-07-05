using CurrencyExchange.CustomException;
using CurrencyExchange.Filter;
using CurrencyExchange.OtherServices.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Selle.WebApp.Services.External.Email.Dto;
using Selle.WebApp.Services.External.Email.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Selle.WebApp.Services.External.Email.Services
{
    //[CustomExceptionFilter]
    public class EmailService : BaseSevice
    {
        private readonly IOptions<Dto.EmailConfig> _emailConfig;

        public EmailService(IOptions<Dto.EmailConfig> emailConfig)
        {
            this._emailConfig = emailConfig;
        }

        internal Task SendEmail(string userEmail, string Body)
        {
            try
            {
                Body = Body.Trim();
                using (MailMessage mail = new MailMessage())
                {
                    var emailInfo = _emailConfig.Value;
                    mail.From = new MailAddress(emailInfo.AdminEmails.FirstOrDefault().Email);
                    mail.To.Add(userEmail);
                    mail.Subject = "Admin";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient(emailInfo.MailServer.OutgoingMailServer,
                                                            emailInfo.EmailPorts.FirstOrDefault(x => x.Name == Enum.EmailConfig.EmailPort.SMTP).Port))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emailInfo.AdminEmails.FirstOrDefault().Email,
                                                                 emailInfo.AdminEmails.FirstOrDefault().Password);
                        smtp.EnableSsl = true;
                        smtp.SendCompleted += (s, e) =>
                        {
                            throw e.Error;
                        };
                        smtp.Send(mail);
                    }
                }
                return Task.FromResult(true);
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
    }
}
