using FindAFriend.Domain.Enums;

namespace FindAFriend.Domain.Repositories;

public record PetFilterRequest(string City)
{
    public IQueryable<Pet> Filter(IQueryable<Pet> pets)
    {
        if (!string.IsNullOrEmpty(City))
            pets = pets.Where(pet => pet.Institution.Address.City.ToLower().Contains(City.ToLower()));

        return pets;
    }
}

public record PetFilterResponse(
    string Name,
    EPetType PetType,
    string PhotoUrl);

public interface IPetRepository
{
    Task Add(Pet pet);
    Task<IEnumerable<PetFilterResponse>> GetFiltered(PetFilterRequest filterRequest);
}