namespace FindAFriend.Infra.Common.Auth;

public interface ITokenService
{
    string Generate(TokenGeneratorRequest request);
    Guid ValidateToken(string token);
}