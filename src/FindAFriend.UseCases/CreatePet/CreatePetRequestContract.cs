using FluentValidation;

namespace FindAFriend.UseCases.CreatePet;

public class CreatePetRequestContract : AbstractValidator<CreatePetRequest>
{
    public CreatePetRequestContract()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.About).NotNull().NotEmpty();
        RuleFor(x => x.Age).NotNull().NotEmpty();
        RuleFor(x => x.Gender).NotNull().NotEmpty();
        RuleFor(x => x.Size).NotNull().NotEmpty();
        RuleFor(x => x.EnergyLevel).NotNull().NotEmpty();
        RuleFor(x => x.DependencyLevel).NotNull().NotEmpty();
        RuleFor(x => x.EnvironmentSize).NotNull().NotEmpty();
        RuleFor(x => x.InstitutionId).NotNull().NotEmpty();
    }
}