using Abbott.EmailCommunication.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Abbott.CrossCutting.EmailModel;
using System.Net;
using System.Net.Mail;

namespace Abbott.EmailCommunication
{
    public class EmailsCommunication : ICommunication
    {
        public IConfiguration Configuration { get; }
        private static readonly string AFFAIR = "Recuperación de contraseña - AbbottPrivider";
        private readonly string fromAddress;
        private readonly string fromName;
        private readonly string fromPassword;
        private readonly string host;
        private readonly int port;

        public EmailsCommunication(IConfiguration Conf)
        {
            Configuration = Conf;
            fromAddress = Configuration["EmailSettings:UsernameEmail"];
            fromName = Configuration["EmailSettings:FromEmail"];
            fromPassword = Configuration["EmailSettings:UsernamePassword"];
            host = Configuration["EmailSettings:PrimaryDomain"];
            port = Convert.ToInt32(Configuration["EmailSettings:PrimaryPort"]);
        }

        public Boolean SendEmailRecoverPassword(ConfirmationEmail confirmation)
        {
            string emailBody = "<p>Respetado<p>" + "<p>Usuario</p>";

            emailBody = emailBody + "<br><p>Para recuperar su contraseña en el Sistema de AbbottPrivider haga click <a href=" + confirmation.CallBack + ">aquí</a></p><br>";

            emailBody += "<p>Cordialmente,</p><br>";
            emailBody += "</p>AbbottPrivider</p>";
            emailBody += "</p>Abbott</p>";

            return SendEmail(confirmation.Email, AFFAIR, emailBody);
        }

        private Boolean SendEmail(string to, string subject, string body)
        {
            try
            {
                var frAddress = new MailAddress(fromAddress, fromName);
                var toAddress = new MailAddress(to, to);

                var smtp = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(frAddress.Address, fromPassword),
                    EnableSsl = true,
                };

                using (var message = new MailMessage(frAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
