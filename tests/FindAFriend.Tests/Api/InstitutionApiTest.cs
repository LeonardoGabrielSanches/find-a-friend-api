using System.ComponentModel;
using System.Net.Http.Json;

using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Test.Api;

[Collection("Integration")]
public class InstitutionApiTest(CustomWebApplication customWebApplication)
{
    private readonly HttpClient _httpClient = customWebApplication.HttpClient;

    [Fact(DisplayName = "Should create a new institution")]
    [Category("Integration")]
    public async Task Should_CreateANewInstitution()
    {
        var response = await _httpClient.PostAsJsonAsync("/api/institutions", new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email2@example.com",
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: "oneLetter1Number@"));

        response.EnsureSuccessStatusCode();
    }
}