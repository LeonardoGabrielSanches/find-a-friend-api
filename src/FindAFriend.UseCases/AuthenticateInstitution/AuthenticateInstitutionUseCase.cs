using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.AuthenticateInstitution.Exceptions;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public class AuthenticateInstitutionUseCase(
    IInstitutionRepository institutionRepository,
    IPasswordHasher passwordHasher)
{
    public async Task<AuthenticateInstitutionResponse> Execute(AuthenticateInstitutionRequest request)
    {
        var institution = await institutionRepository.GetByEmail(request.Email);

        if (institution is null)
            throw new AuthenticateFailedException();

        var passwordMatches = passwordHasher.VerifyPassword(request.Password, institution.Password);

        if (!passwordMatches)
            throw new AuthenticateFailedException();

        return AuthenticateInstitutionResponse.MapResponse(institution);
    }
}