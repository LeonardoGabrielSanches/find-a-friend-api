using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infra.Data.Repositories;

public class PetRepository(FindAFriendContext context) : IPetRepository
{
    public async Task Add(Pet pet)
    {
        context.Pets.Add(pet);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PetFilterResponse>> GetFiltered(PetFilterRequest filterRequest)
    {
        var pets = context.Pets.AsQueryable();

        var filteredPets = filterRequest.Filter(pets);

        return await filteredPets
            .Select(pet => new PetFilterResponse(pet.Name, pet.PetType, pet.Photos[0].Url)).ToListAsync();
    }
}