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
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

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
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        Assert.False(pet.IsValid);
    }

    [Fact(DisplayName = "Should add new photo to pet")]
    public void Should_AddNewPhotoToPet()
    {
        var pet = new Pet(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        pet.AddPhoto(new Photo("https://pet.com", pet.Id));

        Assert.True(pet.IsValid);
    }
    
    [Fact(DisplayName = "Should be invalid when max count of photos is already added")]
    public void Should_BeInvalid_WhenMaxCountOfPhotosIsAlreadyAdded()
    {
        var pet = new Pet(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        pet.AddPhoto(new Photo("https://pet.com", pet.Id));
        pet.AddPhoto(new Photo("https://pet.com", pet.Id));
        pet.AddPhoto(new Photo("https://pet.com", pet.Id));
        pet.AddPhoto(new Photo("https://pet.com", pet.Id));

        Assert.False(pet.IsValid);
    }
}