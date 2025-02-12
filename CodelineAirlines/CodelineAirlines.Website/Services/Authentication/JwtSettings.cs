namespace CodelineAirlines.Website.Services.Authentication
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }

        public int ExpirationInMinutes { get; set; }
    }
}
