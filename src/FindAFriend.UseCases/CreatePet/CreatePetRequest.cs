using FindAFriend.Domain.Enums;
using FindAFriend.UseCases.Common.Request;

namespace FindAFriend.UseCases.CreatePet;

public class CreatePetRequest(
    string name,
    string about,
    EPetAge age,
    EPetSize size,
    EPetEnergyLevel energyLevel,
    EPetDependencyLevel dependencyLevel,
    EPetEnvironmentSize environmentSize,
    EPetGender gender,
    EPetType petType,
    Guid institutionId) : Request
{
    public string Name { get; } = name;
    public string About { get; } = about;
    public EPetAge Age { get; } = age;
    public EPetSize Size { get; } = size;
    public EPetEnergyLevel EnergyLevel { get; } = energyLevel;
    public EPetDependencyLevel DependencyLevel { get; } = dependencyLevel;
    public EPetEnvironmentSize EnvironmentSize { get; } = environmentSize;
    public EPetGender Gender { get; } = gender;
    public EPetType PetType { get; } = petType;
    public Guid InstitutionId { get; } = institutionId;
    public List<CreatePetRequestFiles> Files { get; } = [];

    public async override Task Validate()
    {
        AddNotifications(await new CreatePetRequestContract().ValidateAsync(this));
    }

    public void AddFile(CreatePetRequestFiles file)
        => Files.Add(file);
}

public record CreatePetRequestFiles(string Name, byte[] Bytes);