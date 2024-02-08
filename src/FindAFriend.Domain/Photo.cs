using FindAFriend.Domain.Contracts;
using FindAFriend.Domain.Core;

namespace FindAFriend.Domain;

public class Photo : Entity
{
    public Photo(string url, Guid petId)
    {
        Url = url;
        PetId = petId;
        
        AddNotifications(new PhotoContract(this));
    }

    public string Url { get; private set; }
    public Guid PetId { get; private set; }
}