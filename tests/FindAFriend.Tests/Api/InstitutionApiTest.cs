using System.ComponentModel;
using System.Net.Http.Json;

using FindAFriend.UseCases.CreateInstitution;

using Microsoft.AspNetCore.Mvc.Testing;

namespace FindAFriend.Test.Api;

public class InstitutionApiTest
{
    [Fact(DisplayName = "Should create a new institution")]
    [Category("Integration")]
    public async Task Should_CreateANewInstitution()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();

        var client = webApplicationFactory.CreateClient();

        var response = await client.PostAsJsonAsync("/institutions", new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: "email@example.com",
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: "oneLetter1Number@"));

        response.EnsureSuccessStatusCode();
    }
}