namespace CodelineAirlines.Website.Services.Authentication
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
