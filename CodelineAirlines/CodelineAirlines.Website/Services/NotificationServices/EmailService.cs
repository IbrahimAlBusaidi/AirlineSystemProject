﻿using System.Net.Mail;
using System.Net;

namespace CodelineAirlines.Website.Services.NotificationServices
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;
        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("codelinecodeline2024@gmail.com", "tfge nrki htum idxy"),
                    EnableSsl = true
                };

                var message = new MailMessage("codelinecodeline2024@gmail.com", toEmail, subject, body);

                await client.SendMailAsync(message);

                _logger.LogInformation($"Email successfully sent to {toEmail}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                throw new Exception();
            }
        }




    }
}
