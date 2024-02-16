using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FindAFriend.Infra.Common.Auth;

public record TokenGeneratorRequest(string Id, string Email, bool IsRefreshToken);

public class TokenGenerator(IConfiguration configuration) : ITokenGenerator
{
    public string Generate(TokenGeneratorRequest request)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, request.Id), new(ClaimTypes.Email, request.Email)
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("Auth:Token").Value!));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var expiresIn = request.IsRefreshToken ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expiresIn,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}