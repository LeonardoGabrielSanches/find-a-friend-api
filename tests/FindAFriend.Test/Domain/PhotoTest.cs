using FindAFriend.Domain;

namespace FindAFriend.Test.Domain;

public class PhotoTest
{
    [Fact(DisplayName = "Should create a new Photo")]
    public void Should_CreatePhoto()
    {
        var photo = new Photo("https://photo.com");

        Assert.True(photo.IsValid);
    }
    
    [Fact(DisplayName = "Should create a new not valid Photo")]
    public void Should_CreateANotValidPhoto()
    {
        var photo = new Photo("url");

        Assert.False(photo.IsValid);
    }
}