namespace FindAFriend.Infra.Common.Auth;

public interface ITokenGenerator
{
    string Generate(TokenGeneratorRequest request);
}