using Flunt.Validations;

namespace FindAFriend.Domain.Contracts;

public class CreateInstitutionContract : Contract<Institution>
{
    public CreateInstitutionContract(Institution institution)
    {
        Requires()
            .IsNotNullOrEmpty(institution.Name, "Name", "Name must not be null.")
            .IsNotNullOrEmpty(institution.ResponsibleName, "Responsible Name", "Responsible Name must not be null.")
            .IsEmail(institution.Email, "Email", "Must be a valid email address.")
            .IsNotNullOrEmpty(institution.Address, "Address", "Must be a valid address.")
            .IsNotNullOrEmpty(institution.ZipCode, "Zip Code", "Must be a valid zip code.")
            .IsNotNullOrEmpty(institution.Phone, "Phone", "Must be a valid phone number.")
            .Matches(institution.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$" ,"Password", "Password must be valid.");
    }
}