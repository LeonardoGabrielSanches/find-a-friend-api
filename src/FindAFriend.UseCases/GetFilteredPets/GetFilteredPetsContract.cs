using FluentValidation;

namespace FindAFriend.UseCases.GetFilteredPets;

public class GetFilteredPetsContract : AbstractValidator<GetFilteredPetsRequest>
{
    public GetFilteredPetsContract()
    {
        RuleFor(x => x.City).NotNull().NotEmpty();
    }
}