using FindAFriend.UseCases.Common.Request;

namespace FindAFriend.UseCases.GetFilteredPets;

public class GetFilteredPetsRequest(string city) : Request
{
    public string City { get; } = city;

    public override async Task Validate()
    {
        AddNotifications(await new GetFilteredPetsContract().ValidateAsync(this));
    }
}