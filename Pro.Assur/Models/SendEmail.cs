using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using RazorEngine;
using RazorEngine.Templating;

namespace Pro.Assur.Models
{
    public static class SendEmail
    {

        public static async Task Report(Devis devis)
        {
            try
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                var toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"];
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"];
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"];
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"];
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"];
                
                var template = File.OpenText(HttpContext.Current.Server.MapPath("~/images/EmailTemplate.cshtml")).ReadToEnd(); 
                var body = Engine.Razor.RunCompile(template, "templateKey", null, devis);

                var message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName),
                    new MailAddress(toEmailAddress, "Malus-Assur.fr"))
                {
                    Subject = "Demande de devis par malus-assur.fr",
                    IsBodyHtml = true,
                    Body = body
                };

                var client = new SmtpClient
                {
                    Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                    Host = smtpHost,
                    EnableSsl = true,
                    Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0,
                    //UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,                   
                };
               await  client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                return;
                //throw (new Exception("Mail send failed to " + devis.Email + ", though registration done."));
            }
        }
    }
}