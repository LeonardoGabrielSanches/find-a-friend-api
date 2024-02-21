using FindAFriend.Domain.Enums;
using FindAFriend.Domain.Repositories;

namespace FindAFriend.UseCases.GetFilteredPets;

public record GetFilteredPetsResponse(
    string Name,
    EPetType PetType,
    string PhotoUrl)
{
    public static implicit operator GetFilteredPetsResponse(PetFilterResponse petFilterResponse)
    {
        return new GetFilteredPetsResponse(
            petFilterResponse.Name,
            petFilterResponse.PetType,
            petFilterResponse.PhotoUrl);
    }
}