namespace CodelineAirlines.Website.Services.NotificationServices
{
    public interface ISmsService
    {
        Task SendSmsAsync(string to, string message);
    }
}