using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Pro.Assur.Models
{
    public static class SendEmail
    {

        public static async Task Report(Devis devis)
        {
            try
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"];
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"];
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"];
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"];

                var body = "Your registration has been done successfully. Thank you.";
                var message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName),
                    new MailAddress(devis.Email, devis.Prenom + " " + devis.Nom))
                {
                    Subject = "Thank You For Your Registration",
                    IsBodyHtml = true,
                    Body = body
                };

                var client = new SmtpClient
                {
                    Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                    Host = smtpHost,
                    EnableSsl = true,
                    Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0
                };
               await  client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw (new Exception("Mail send failed to " + devis.Email + ", though registration done."));
            }
        }
    }
}