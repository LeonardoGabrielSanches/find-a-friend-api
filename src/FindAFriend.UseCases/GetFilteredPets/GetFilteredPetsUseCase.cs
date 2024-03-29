using FindAFriend.Domain.Repositories;

namespace FindAFriend.UseCases.GetFilteredPets;

public class GetFilteredPetsUseCase(IPetRepository petRepository)
{
    public async Task<IEnumerable<GetFilteredPetsResponse>> Execute(GetFilteredPetsRequest request)
    {
        var pets = await petRepository.GetFiltered(new PetFilterRequest(
            request.City,
            request.Age,
            request.EnergyLevel,
            request.Size,
            request.DependencyLevel,
            request.Type));

        return pets.Select(pet => (GetFilteredPetsResponse)pet);
    }
}