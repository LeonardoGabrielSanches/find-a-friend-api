using Flunt.Validations;

namespace FindAFriend.Domain.Contracts;

public class CreatePhotoContract : Contract<Photo>
{
    public CreatePhotoContract(Photo photo)
    {
        Requires()
            .IsUrl(photo.Url, "Url");
    }
}