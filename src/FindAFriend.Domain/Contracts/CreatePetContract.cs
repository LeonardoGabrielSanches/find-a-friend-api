using Flunt.Validations;

namespace FindAFriend.Domain.Contracts;

public class CreatePetContract : Contract<Pet>
{
    public CreatePetContract(Pet pet)
    {
        Requires()
            .IsNotNullOrEmpty(pet.Name, "Name")
            .IsNotNullOrEmpty(pet.About, "About")
            .IsNotNull(pet.Age, "Age")
            .IsNotNull(pet.Gender, "Gender")
            .IsNotNull(pet.Size, "Size")
            .IsNotNull(pet.DependencyLevel, "DependencyLevel")
            .IsNotNull(pet.EnvironmentSize, "EnvironmentSize");
    }
}