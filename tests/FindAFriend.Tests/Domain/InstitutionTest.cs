using FindAFriend.Domain;

namespace FindAFriend.Test.Domain;

public class InstitutionTest
{
    [Fact(DisplayName = "Should create a new institution")]
    public void Should_CreateInstitution()
    {
        var institution = new Institution(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email@example.com",
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: "oneLetter1Number@");

        Assert.NotNull(institution);
    }
}