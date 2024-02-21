using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Test.UseCases.CreateInstitutionTest;

public class CreateInstitutionRequestTest
{
    [Fact(DisplayName = "Should create a new request with valid values")]
    public async Task Should_CreateARequest_WithValidValues()
    {
        var request = new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email@example.com",
            addressZipCode: "zipCode",
            addressCity: "city",
            addressNumber: 1,
            addressState: "state",
            addressStreet: "street",
            phone: "123456789",
            password: "oneLetter1Number@");

        await request.Validate();

        Assert.True(request.IsValid);
    }

    [Fact(DisplayName = "Should create a new request with invalid values")]
    public async Task Should_CreateARequest_WithInvalidValues()
    {
        var request = new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email@example.com",
            addressZipCode: "zipCode",
            addressCity: "city",
            addressNumber: 1,
            addressState: "state",
            addressStreet: "street",
            phone: "123456789",
            password: "123@");

        await request.Validate();

        Assert.False(request.IsValid);
    }
}