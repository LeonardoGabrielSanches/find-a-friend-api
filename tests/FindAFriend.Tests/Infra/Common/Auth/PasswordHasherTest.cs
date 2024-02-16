using FindAFriend.Infra.Common.Auth;

using Microsoft.Extensions.Configuration;

using Moq;

namespace FindAFriend.Test.Infra.Common.Auth;

public class PasswordHasherTest
{
    private readonly PasswordHasher _sut;
    private readonly Mock<IConfiguration> _configuration = new();

    public PasswordHasherTest()
    {
        var configurationSection = new Mock<IConfigurationSection>();
        configurationSection.Setup(x => x.Value).Returns("123");

        _configuration.Setup(x => x.GetSection("Auth:Secret"))
            .Returns(configurationSection.Object);

        _sut = new PasswordHasher(_configuration.Object);
    }

    [Fact(DisplayName = "Should hash password")]
    public void Should_HashPassword()
    {
        var hashedPassword = _sut.HashPassword("<PASSWORD>");

        Assert.NotNull(hashedPassword);
        Assert.NotEmpty(hashedPassword);
    }

    [Fact(DisplayName = "Should not match password")]
    public void ShouldNot_MatchPassword()
    {
        var hashedPassword = _sut.HashPassword("<PASSWORD>");

        var passwordMatch = _sut.VerifyPassword("<NOT_EQUAL_PASSWORD>", hashedPassword);

        Assert.False(passwordMatch);
    }
    
    [Fact(DisplayName = "Should match password")]
    public void Should_MatchPassword()
    {
        var hashedPassword = _sut.HashPassword("<PASSWORD>");

        var passwordMatch = _sut.VerifyPassword("<PASSWORD>", hashedPassword);

        Assert.True(passwordMatch);
    }
}