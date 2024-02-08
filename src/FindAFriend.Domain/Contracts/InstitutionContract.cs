using Flunt.Validations;

namespace FindAFriend.Domain.Contracts;

public class InstitutionContract : Contract<Institution>
{
    public InstitutionContract(Institution institution)
    {
        Requires()
            .IsNotNullOrEmpty(institution.Name, "Name")
            .IsNotNullOrEmpty(institution.ResponsibleName, "Responsible Name")
            .IsEmail(institution.Email, "Email")
            .IsNotNullOrEmpty(institution.Address, "Address")
            .IsNotNullOrEmpty(institution.ZipCode, "Zip Code")
            .IsNotNullOrEmpty(institution.Phone, "Phone")
            .IsNotNullOrEmpty(institution.Password, "Password");
    }
}