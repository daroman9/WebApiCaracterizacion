
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Services
{
    public class MailService : IMailService
    {
        public async Task SendEmail(string email, string subject, string htmlContent)
        {
            var apikey = "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";
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("desarrolloprosecto@gmail.com");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}