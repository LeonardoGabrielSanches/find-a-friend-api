using FindAFriend.Domain.Enums;

namespace FindAFriend.Domain.Repositories;

public record PetFilterRequest(
    string City,
    EPetAge? Age = null,
    EPetEnergyLevel? EnergyLevel = null,
    EPetSize? Size = null,
    EPetDependencyLevel? DependencyLevel = null,
    EPetType? Type = null)
{
    public IQueryable<Pet> Filter(IQueryable<Pet> pets)
    {
        if (!string.IsNullOrEmpty(City))
            pets = pets.Where(pet => pet.Institution.Address.City.ToLower().Contains(City.ToLower()));

        if (Age is not null)
            pets = pets.Where(pet => pet.Age == Age);

        if (EnergyLevel is not null)
            pets = pets.Where(pet => pet.EnergyLevel == EnergyLevel);

        if (Size is not null)
            pets = pets.Where(pet => pet.Size == Size);

        if (DependencyLevel is not null)
            pets = pets.Where(pet => pet.DependencyLevel == DependencyLevel);

        if (Type is not null)
            pets = pets.Where(pet => pet.PetType == Type);

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