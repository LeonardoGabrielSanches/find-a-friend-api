using System.Text;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;

namespace FindAFriend.Infra.Common.Auth;

public class PasswordHasher(IConfiguration configuration) : IPasswordHasher
{
    public string HashPassword(string password)
    {
        var salt = Encoding.ASCII.GetBytes(configuration.GetSection("Auth:Token").Value!);

        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hash;
    }

    public bool VerifyPassword(string password, string hash)
    {
        var hashPassword = HashPassword(password);

        return string.Equals(hash, hashPassword, StringComparison.Ordinal);
    }
}