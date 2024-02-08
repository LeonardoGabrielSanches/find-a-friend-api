using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Test.UseCases.CreateInstitutionTest;

public class CreateInstitutionRequestTest
{
    [Fact(DisplayName = "Should create a new request with valid values")]
    public void Should_CreateARequest_WithValidValues()
    {
        var request = new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email@example.com",
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: "oneLetter1Number@");
        
        request.Validate();

        Assert.True(request.IsValid);
    }
    
    [Fact(DisplayName = "Should create a new request with invalid values")]
    public void Should_CreateARequest_WithInvalidValues()
    {
        var request = new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email@example.com",
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: "123@");
        
        request.Validate();
        
        Assert.False(request.IsValid);
    }
}