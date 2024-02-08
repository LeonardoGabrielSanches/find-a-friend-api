using FindAFriend.Domain.Enums;
using FindAFriend.UseCases.Common;

namespace FindAFriend.UseCases.CreatePet;

public class CreatePetRequest(
    string Name,
    string About,
    EPetAge Age,
    EPetSize Size,
    EPetEnergyLevel EnergyLevel,
    EPetDependencyLevel DependencyLevel,
    EPetEnvironmentSize EnvironmentSize,
    EPetGender Gender,
    Guid InstitutionId) : Request
{
    public override void Validate()
    {
        throw new NotImplementedException();
    }
}