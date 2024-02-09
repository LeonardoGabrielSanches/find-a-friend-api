using Flunt.Validations;

namespace FindAFriend.UseCases.CreatePet;

public class CreatePetRequestContract : Contract<CreatePetRequest>
{
    public CreatePetRequestContract(CreatePetRequest createPetRequest)
    {
        Requires()
            .IsNotNullOrEmpty(createPetRequest.Name, "Name")
            .IsNotNullOrEmpty(createPetRequest.About, "About")
            .IsNotNull(createPetRequest.Age, "Age")
            .IsNotNull(createPetRequest.Gender, "Gender")
            .IsNotNull(createPetRequest.Size, "Size")
            .IsNotNull(createPetRequest.EnergyLevel, "EnergyLevel")
            .IsNotNull(createPetRequest.DependencyLevel, "DependencyLevel")
            .IsNotNull(createPetRequest.EnvironmentSize, "EnvironmentSize")
            .IsNotNull(createPetRequest.InstitutionId, "InstitutionId");
    }
}