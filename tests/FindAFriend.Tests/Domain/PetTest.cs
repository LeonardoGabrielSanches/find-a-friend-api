using FindAFriend.Domain;
using FindAFriend.Domain.Enums;
using FindAFriend.Domain.Exceptions;

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
            petType: EPetType.Dog,
            institutionId: Guid.NewGuid());

        Assert.NotNull(pet);
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
            petType: EPetType.Dog,
            institutionId: Guid.NewGuid());

        pet.AddPhoto(new Photo("https://pet.com", pet.Id));

        Assert.Single(pet.Photos);
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
            petType: EPetType.Cat,
            institutionId: Guid.NewGuid());

        pet.AddPhoto(new Photo("https://pet.com", pet.Id));
        pet.AddPhoto(new Photo("https://pet.com", pet.Id));
        pet.AddPhoto(new Photo("https://pet.com", pet.Id));

        Assert.Throws<MaxCountOfPhotosAddedException>(() => pet.AddPhoto(new Photo("https://pet.com", pet.Id)));
    }
}