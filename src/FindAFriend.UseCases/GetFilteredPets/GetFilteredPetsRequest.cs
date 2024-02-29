using FindAFriend.Domain.Enums;
using FindAFriend.UseCases.Common.Request;

namespace FindAFriend.UseCases.GetFilteredPets;

public class GetFilteredPetsRequest(
    string city,
    EPetAge? age = null,
    EPetEnergyLevel? energyLevel = null,
    EPetSize? size = null,
    EPetDependencyLevel? dependencyLevel = null,
    EPetType? type = null) : Request
{
    public string City { get; } = city;
    public EPetAge? Age { get; } = age;
    public EPetEnergyLevel? EnergyLevel { get; } = energyLevel;
    public EPetSize? Size { get; } = size;
    public EPetDependencyLevel? DependencyLevel { get; } = dependencyLevel;
    public EPetType? Type { get; } = type;

    public override async Task Validate()
    {
        AddNotifications(await new GetFilteredPetsContract().ValidateAsync(this));
    }
}