using Flunt.Validations;

namespace FindAFriend.Domain.Contracts;

public class PhotoContract : Contract<Photo>
{
    public PhotoContract(Photo photo)
    {
        Requires()
            .IsUrl(photo.Url, "Url");
    }
}