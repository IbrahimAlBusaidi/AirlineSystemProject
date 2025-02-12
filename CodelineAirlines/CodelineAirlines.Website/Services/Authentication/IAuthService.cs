using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.Authentication
{
    public interface IAuthService
    {
        JwtTokenResponse GenerateToken(User user);
        Task SaveTokenToCookie(string token);
        Task Logout();
    }
}