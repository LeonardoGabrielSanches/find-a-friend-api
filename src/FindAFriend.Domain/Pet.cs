using FindAFriend.Domain.Contracts;
using FindAFriend.Domain.Core;
using FindAFriend.Domain.Enums;

namespace FindAFriend.Domain;

public class Pet : Entity
{
    private readonly List<Photo> _photos = [];

    public Pet(
        string name,
        string about,
        EPetAge age,
        EPetSize size,
        EPetEnergyLevel energyLevel,
        EPetDependencyLevel dependencyLevel,
        EPetEnvironmentSize environmentSize,
        EPetGender gender)
    {
        Name = name;
        About = about;
        Age = age;
        Size = size;
        EnergyLevel = energyLevel;
        DependencyLevel = dependencyLevel;
        EnvironmentSize = environmentSize;
        Gender = gender;

        AddNotifications(new CreatePetContract(this));
    }

    public string Name { get; private set; }
    public string About { get; private set; }
    public EPetAge Age { get; private set; }
    public EPetSize Size { get; private set; }
    public EPetEnergyLevel EnergyLevel { get; private set; }
    public EPetDependencyLevel DependencyLevel { get; private set; }
    public EPetEnvironmentSize EnvironmentSize { get; private set; }
    public EPetGender Gender { get; private set; }
    public IReadOnlyList<Photo> Photos => _photos;

    public void AddPhoto(Photo photo)
        => _photos.Add(photo);
}