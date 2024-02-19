namespace FindAFriend.Infra.Common.Auth;

public interface ITokenService
{
    string Generate(TokenGeneratorRequest request);
    (TokenUserInformation, bool) ValidateToken(string token);
}