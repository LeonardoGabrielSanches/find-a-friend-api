using FindAFriend.Domain;
using FindAFriend.Domain.Enums;

namespace FindAFriend.Test.Domain;

public class PetTest
{
    [Fact(DisplayName = "Should create a new Pet")]
    public void Should_CreatePet()
    {
        var pet = new Pet(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small);

        Assert.True(pet.IsValid);
    }
    
    [Fact(DisplayName = "Should create a new not valid Pet")]
    public void Should_CreateNotValidPet()
    {
        var pet = new Pet(
            name: "",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small);

        Assert.False(pet.IsValid);
    }
}