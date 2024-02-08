using FindAFriend.Domain;

namespace FindAFriend.Test.Domain;

public class PhotoTest
{
    [Fact(DisplayName = "Should create a new Photo")]
    public void Should_CreatePhoto()
    {
        var photo = new Photo("https://photo.com", Guid.NewGuid());

        Assert.NotNull(photo);
    }
}