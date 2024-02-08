using FindAFriend.Domain.Core;

namespace FindAFriend.Domain;

public class Photo(string url, Guid petId) : Entity
{
    public string Url { get; private set; } = url;
    public Guid PetId { get; private set; } = petId;
}