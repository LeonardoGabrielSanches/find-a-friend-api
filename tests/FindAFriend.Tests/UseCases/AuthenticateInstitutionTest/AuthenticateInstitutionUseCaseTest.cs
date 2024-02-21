using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;
using FindAFriend.Domain.ValueObjects;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.AuthenticateInstitution;
using FindAFriend.UseCases.AuthenticateInstitution.Exceptions;

using Moq;

namespace FindAFriend.Test.UseCases.AuthenticateInstitutionTest;

public class AuthenticateInstitutionUseCaseTest
{
    private readonly Mock<IInstitutionRepository> _institutionRepository = new();
    private readonly Mock<IPasswordHasher> _passwordHasher = new();
    private readonly AuthenticateInstitutionUseCase _sut;

    public AuthenticateInstitutionUseCaseTest()
    {
        _sut = new AuthenticateInstitutionUseCase(_institutionRepository.Object, _passwordHasher.Object);
    }

    [Fact(DisplayName = "Should not authenticate institution when it does not exists")]
    public async Task ShouldNot_AuthenticateInstitution_WhenItDoesNotExists()
    {
        await Assert.ThrowsAsync<AuthenticateFailedException>(() =>
            _sut.Execute(new AuthenticateInstitutionRequest("email", "password")));
    }

    [Fact(DisplayName = "Should not authenticate institution when password is invalid")]
    public async Task ShouldNot_AuthenticateInstitution_WhenPasswordIsInvalid()
    {
        _institutionRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(new Institution("name",
            "responsibleName", "email", new Address("street", 1, "state", "city", "zipCode"), "phone", "1243"));

        await Assert.ThrowsAsync<AuthenticateFailedException>(() =>
            _sut.Execute(new AuthenticateInstitutionRequest("email", "password")));
    }

    [Fact(DisplayName = "Should authenticate institution")]
    public async Task Should_AuthenticateInstitution()
    {
        _institutionRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(new Institution("name",
            "responsibleName", "email", new Address("street", 1, "state", "city", "zipCode"), "phone", "123"));

        _passwordHasher.Setup(x => x.VerifyPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        var response = await _sut.Execute(new AuthenticateInstitutionRequest("email", "123"));

        Assert.NotNull(response);
        Assert.Equal("name", response.Name);
    }
}