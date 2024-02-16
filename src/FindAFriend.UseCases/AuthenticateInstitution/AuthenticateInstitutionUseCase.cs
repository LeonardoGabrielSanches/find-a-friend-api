using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.AuthenticateInstitution.Exceptions;
using FindAFriend.UseCases.Common.Auth;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public class AuthenticateInstitutionUseCase(
    IInstitutionRepository institutionRepository,
    ITokenGenerator tokenGenerator)
{
    public async Task<AuthenticateInstitutionResponse> Execute(AuthenticateInstitutionRequest request)
    {
        var institution = await institutionRepository.GetByEmail(request.Email);

        if (institution is null)
            throw new AuthenticateFailedException();

        var passwordHash = PasswordHasher.HashPassword(request.Password);

        var passwordMatches = string.Equals(passwordHash, institution.Password, StringComparison.OrdinalIgnoreCase);

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