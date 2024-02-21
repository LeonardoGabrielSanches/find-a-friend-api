using FindAFriend.Domain;
using FindAFriend.Domain.ValueObjects;

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
            address: new Address("street", 1, "state", "city", "zipCode"),
            phone: "123456789",
            password: "oneLetter1Number@");

        Assert.NotNull(institution);
    }
}