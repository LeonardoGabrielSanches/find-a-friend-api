using System.Security.Cryptography;
using System.Text;

namespace FindAFriend.UseCases.Common.Auth;

public static class PasswordHasher
{
    const int KeySize = 64;
    const int Iterations = 350000;
    static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

    public static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(KeySize);
        
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            Iterations,
            HashAlgorithm,
            KeySize);
        
        return Convert.ToHexString(hash);
    }
}