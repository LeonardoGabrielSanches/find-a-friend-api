using FindAFriend.Domain.Enums;
using FindAFriend.UseCases.CreatePet;

namespace FindAFriend.Test.UseCases.CreatePetTest;

public class CreatePetRequestTest
{
    [Fact(DisplayName = "Should create a new request with valid values")]
    public async Task Should_CreateARequest_WithValidValues()
    {
        var request = new CreatePetRequest(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        await request.Validate();

        Assert.True(request.IsValid);
    }

    [Fact(DisplayName = "Should create a new request with invalid values")]
    public async Task Should_CreateARequest_WithInvalidValues()
    {
        var request = new CreatePetRequest(
            name: "",
            about: "",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        await request.Validate();

        Assert.False(request.IsValid);
    }
}