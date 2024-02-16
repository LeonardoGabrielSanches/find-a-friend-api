using FindAFriend.Infra.Common.Auth;

using Microsoft.Extensions.Configuration;

using Moq;

namespace FindAFriend.Test.Infra.Common.Auth;

public class TokenGeneratorTest
{
    private readonly TokenGenerator _sut;
    private readonly Mock<IConfiguration> _configuration = new();

    public TokenGeneratorTest()
    {
        var configurationSection = new Mock<IConfigurationSection>();
        configurationSection.Setup(x => x.Value)
            .Returns(
                "SecretTokenSecretTokenSecretTokenSecretTokenSecretTokenSecretTokenSecretTokenSecretTokenSecretToken");

        _configuration.Setup(x => x.GetSection("Auth:Token"))
            .Returns(configurationSection.Object);

        _sut = new TokenGenerator(_configuration.Object);
    }

    [Theory(DisplayName = "Should generate token")]
    [InlineData(true)]
    [InlineData(false)]
    public void Should_GenerateToken(bool isRefreshToken)
    {
        var token = _sut.Generate(new TokenGeneratorRequest("1", "<EMAIL>", isRefreshToken));

        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }
}