using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;

using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Test.Api;

[Collection("Integration")]
public class InstitutionApiTest(CustomWebApplication customWebApplication)
{
    private readonly HttpClient _httpClient = customWebApplication.HttpClient;
    private readonly Func<Task> _resetDatabase = customWebApplication.ResetDatabase;

    [Fact(DisplayName = "Should create a new institution")]
    [Category("Integration")]
    public async Task Should_CreateANewInstitution()
    {
        var response = await _httpClient.PostAsJsonAsync("/api/institutions", new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email2@example.com",
            addressZipCode: "zipCode",
            addressCity: "city",
            addressNumber: 1,
            addressState: "state",
            addressStreet: "street",
            phone: "123456789",
            password: "oneLetter1Number@"));
        
        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        await _resetDatabase();
    }
}