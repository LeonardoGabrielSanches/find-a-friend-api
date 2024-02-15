using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;

namespace FindAFriend.Infrastructure.Repositories;

public class PetRepository(FindAFriendContext context) : IPetRepository
{
    public void Add(Pet pet)
        => context.Pets.Add(pet);
}