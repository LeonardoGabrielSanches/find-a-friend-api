using Flunt.Validations;

namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionRequestContract : Contract<CreateInstitutionRequest>
{
    public CreateInstitutionRequestContract(CreateInstitutionRequest createInstitutionRequest)
    {
        Requires()
            .IsNotNullOrEmpty(createInstitutionRequest.Name, "Name")
            .IsNotNullOrEmpty(createInstitutionRequest.ResponsibleName, "Responsible Name")
            .IsEmail(createInstitutionRequest.Email, "Email")
            .IsNotNullOrEmpty(createInstitutionRequest.Address, "Address")
            .IsNotNullOrEmpty(createInstitutionRequest.ZipCode, "Zip Code")
            .IsNotNullOrEmpty(createInstitutionRequest.Phone, "Phone")
            .Matches(createInstitutionRequest.Password,
                @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", "Password",
                "Password must be valid.");
    }
}