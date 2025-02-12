using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodelineAirlines.Website.Services.Authentication
{
    public class JwtHelper
    {
        //helper methods for jwt
        public static string ExtractToken(HttpRequest request)
        {
            const string authorizationHeader = "Authorization";
            const string bearerPrefix = "Bearer ";

            if (request.Headers.ContainsKey(authorizationHeader))
            {
                var token = request.Headers[authorizationHeader].ToString();
                if (token.StartsWith(bearerPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return token.Substring(bearerPrefix.Length).Trim();
                }
            }
            return null; // Token not found
        }
        public static string GetClaimValue(string jwtToken, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(jwtToken))
            {
                var jwtTokenObj = handler.ReadJwtToken(jwtToken);
                var claim = jwtTokenObj.Claims.FirstOrDefault(c => c.Type == claimType);
                return claim?.Value ?? throw new ArgumentException($"Claim '{claimType}' not found in the token.");
            }
            throw new ArgumentException("Invalid JWT Token.");
        }

        public static IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);

                // Return the claims from the token
                return jwtToken.Claims;
            }

            return Enumerable.Empty<Claim>();
        }
    }
}
