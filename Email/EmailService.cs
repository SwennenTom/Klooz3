using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Klooz3.Email
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
            var smtpServer = emailSettings["SmtpServer"];
            var port = int.Parse(emailSettings["Port"]);
            var userName = emailSettings["UserName"];
            var password = emailSettings["Password"];

            using (var client = new SmtpClient(smtpServer, port))
            {
                client.Credentials = new NetworkCredential(userName, password);
                client.EnableSsl = true; // Set to true if you need SSL
                client.Timeout = 20000; // Set your desired timeout value

                var from = new MailAddress("tswennen@gmail.com", "Tom Swennen");
                var to = new MailAddress(toEmail);

                using (var message = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to true if your email body contains HTML
                })
                {
                    try
                    {
                        await client.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        // Handle email sending failure
                        throw new Exception("Failed to send email.", ex);
                    }
                }
            }
        }
    }
}
