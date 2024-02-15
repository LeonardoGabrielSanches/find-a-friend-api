using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;

namespace FindAFriend.Infra.Data.Repositories;

public class PetRepository(FindAFriendContext context) : IPetRepository
{
    public async Task Add(Pet pet)
    {
        context.Pets.Add(pet);
        await context.SaveChangesAsync();
    }
}