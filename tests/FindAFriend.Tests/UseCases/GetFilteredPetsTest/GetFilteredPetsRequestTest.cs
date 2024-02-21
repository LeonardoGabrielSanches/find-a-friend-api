using FindAFriend.UseCases.GetFilteredPets;

namespace FindAFriend.Test.UseCases.GetFilteredPetsTest;

public class GetFilteredPetsRequestTest
{
    [Fact(DisplayName = "Should create a new request with valid values")]
    public async Task Should_CreateARequest_WithValidValues()
    {
        var request = new GetFilteredPetsRequest(
            city: "New York");

        await request.Validate();

        Assert.True(request.IsValid);
    }

    [Fact(DisplayName = "Should create a new request with invalid values")]
    public async Task Should_CreateARequest_WithInvalidValues()
    {
        var request = new GetFilteredPetsRequest(
            city: "");

        await request.Validate();

        Assert.False(request.IsValid);
    }
}