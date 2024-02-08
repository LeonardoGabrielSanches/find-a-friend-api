using Flunt.Validations;

namespace FindAFriend.Domain.Contracts;

public class CreateInstitutionContract : Contract<Institution>
{
    public CreateInstitutionContract(Institution institution)
    {
        Requires()
            .IsNotNullOrEmpty(institution.Name, "Name")
            .IsNotNullOrEmpty(institution.ResponsibleName, "Responsible Name")
            .IsEmail(institution.Email, "Email")
            .IsNotNullOrEmpty(institution.Address, "Address")
            .IsNotNullOrEmpty(institution.ZipCode, "Zip Code")
            .IsNotNullOrEmpty(institution.Phone, "Phone")
            .Matches(institution.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$" ,"Password", "Password must be valid.");
    }
}