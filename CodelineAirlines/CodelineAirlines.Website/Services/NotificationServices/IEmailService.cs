namespace CodelineAirlines.Website.Services.NotificationServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}