using FindAFriend.Domain.Core;
using FindAFriend.Domain.Enums;
using FindAFriend.Domain.Exceptions;

namespace FindAFriend.Domain;

public class Pet(
    string name,
    string about,
    EPetAge age,
    EPetSize size,
    EPetEnergyLevel energyLevel,
    EPetDependencyLevel dependencyLevel,
    EPetEnvironmentSize environmentSize,
    EPetGender gender,
    EPetType petType,
    Guid institutionId)
    : Entity
{
    private readonly List<Photo> _photos = [];
    private const int MAX_PHOTO_COUNT_SIZE = 3;

    public string Name { get; private set; } = name;
    public string About { get; private set; } = about;
    public EPetAge Age { get; private set; } = age;
    public EPetSize Size { get; private set; } = size;
    public EPetEnergyLevel EnergyLevel { get; private set; } = energyLevel;
    public EPetDependencyLevel DependencyLevel { get; private set; } = dependencyLevel;
    public EPetEnvironmentSize EnvironmentSize { get; private set; } = environmentSize;
    public EPetGender Gender { get; private set; } = gender;
    public EPetType PetType { get; private set; } = petType;
    public IReadOnlyList<Photo> Photos => _photos;

    public Guid InstitutionId { get; private set; } = institutionId;

    public Institution Institution { get; private set; }

    public void AddPhoto(Photo photo)
    {
        if (_photos.Count >= MAX_PHOTO_COUNT_SIZE)
            throw new MaxCountOfPhotosAddedException(MAX_PHOTO_COUNT_SIZE);

        _photos.Add(photo);
    }
}