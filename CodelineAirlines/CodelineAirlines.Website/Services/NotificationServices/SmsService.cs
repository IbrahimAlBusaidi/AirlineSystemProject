using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CodelineAirlines.Website.Services.NotificationServices
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;

            // Initialize Twilio client
            TwilioClient.Init(
                _configuration["Twilio:AccountSid"],
                _configuration["Twilio:AuthToken"]
            );
        }

        public async Task SendSmsAsync(string to, string message)
        {
            var from = _configuration["Twilio:PhoneNumber"];
            await MessageResource.CreateAsync(
                to: new Twilio.Types.PhoneNumber(to),
                from: new Twilio.Types.PhoneNumber(from),
                body: message
            );
        }
    }
}
