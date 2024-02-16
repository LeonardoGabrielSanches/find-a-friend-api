using FindAFriend.UseCases.Common.Request;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public class AuthenticateInstitutionRequest(string email, string password) : Request
{
    public string Email { get; } = email;
    public string Password { get; } = password;

    public override Task Validate()
    {
        return Task.CompletedTask;
    }
}