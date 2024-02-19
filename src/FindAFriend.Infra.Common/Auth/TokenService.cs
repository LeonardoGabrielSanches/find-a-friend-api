using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FindAFriend.Infra.Common.Auth;

public record TokenGeneratorRequest(string Id, string Email, bool IsRefreshToken);

public record TokenUserInformation(Guid Id, string Email);

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string Generate(TokenGeneratorRequest request)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, request.Id), new(ClaimTypes.Email, request.Email)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration.GetSection("Auth:Token").Value!));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var expiresIn = request.IsRefreshToken ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expiresIn,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public (TokenUserInformation, bool) ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration.GetSection("Auth:Token").Value!);
        try
        {
            tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var email = jwtToken.Claims.First(x => x.Type == ClaimTypes.Email).Value;

            return (new TokenUserInformation(userId, email), true);
        }
        catch
        {
            return (new TokenUserInformation(Guid.Empty, String.Empty), false);
        }
    }
}