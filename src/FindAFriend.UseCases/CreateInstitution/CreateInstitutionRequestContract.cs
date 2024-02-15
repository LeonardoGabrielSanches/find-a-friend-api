using FluentValidation;

namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionRequestContract : AbstractValidator<CreateInstitutionRequest>
{
    public CreateInstitutionRequestContract()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.ResponsibleName).NotNull().NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Address).NotNull().NotEmpty();
        RuleFor(x => x.ZipCode).NotNull().NotEmpty();
        RuleFor(x => x.Phone).NotNull().NotEmpty();
        RuleFor(x => x.Password).Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")
            .WithMessage("Password must be valid.");
    }
}