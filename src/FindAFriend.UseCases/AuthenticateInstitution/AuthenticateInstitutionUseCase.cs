using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.AuthenticateInstitution.Exceptions;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public class AuthenticateInstitutionUseCase(
    IInstitutionRepository institutionRepository,
    IPasswordHasher passwordHasher,
    ITokenGenerator tokenGenerator)
{
    public async Task<AuthenticateInstitutionResponse> Execute(AuthenticateInstitutionRequest request)
    {
        var institution = await institutionRepository.GetByEmail(request.Email);

        if (institution is null)
            throw new AuthenticateFailedException();

        var passwordMatches = passwordHasher.VerifyPassword(request.Password, institution.Password);

        if (!passwordMatches)
            throw new AuthenticateFailedException();

        var token = tokenGenerator.Generate(
            new TokenGeneratorRequest(
                institution.Id.ToString(),
                institution.Email,
                IsRefreshToken: false));

        var refreshToken = tokenGenerator.Generate(
            new TokenGeneratorRequest(
                institution.Id.ToString(),
                institution.Email,
                IsRefreshToken: true));

        return AuthenticateInstitutionResponse.MapResponse(institution, token, refreshToken);
    }
}