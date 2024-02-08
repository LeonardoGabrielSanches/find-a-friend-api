using FindAFriend.Domain.Contracts;
using FindAFriend.Domain.Core;

namespace FindAFriend.Domain;

public class Photo : Entity
{
    public Photo(string url)
    {
        Url = url;
        
        AddNotifications(new CreatePhotoContract(this));
    }

    public string Url { get; private set; }
}