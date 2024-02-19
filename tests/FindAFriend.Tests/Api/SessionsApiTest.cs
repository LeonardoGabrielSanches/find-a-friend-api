using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using FindAFriend.UseCases.AuthenticateInstitution;
using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Test.Api;

[Collection("Integration")]
public class SessionsApiTest(CustomWebApplication customWebApplication)
{
    private readonly HttpClient _httpClient = customWebApplication.HttpClient;
    private readonly Func<Task> _resetDatabase = customWebApplication.ResetDatabase;

    [Fact(DisplayName = "Should authenticate user")]
    [Category("Integration")]
    public async Task Should_Authenticate()
    {
        const string
            email = "email2@example.com",
            password = "oneLetter1Number@";

        var createUserResponse = await _httpClient.PostAsJsonAsync("/api/institutions", new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: email,
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: password));

        createUserResponse.EnsureSuccessStatusCode();

        var response =
            await _httpClient.PostAsJsonAsync("/api/sessions", new AuthenticateInstitutionRequest(email, password));

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        await _resetDatabase();
    }

    [Fact(DisplayName = "Should refresh user token")]
    [Category("Integration")]
    public async Task Should_RefreshUserToken()
    {
        const string
            email = "email2@example.com",
            password = "oneLetter1Number@";

        var createUserResponse = await _httpClient.PostAsJsonAsync("/api/institutions", new CreateInstitutionRequest(
            name: "Institution",
            responsibleName: "Responsible",
            email: email,
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: password));

        createUserResponse.EnsureSuccessStatusCode();

        var createSession =
            await _httpClient.PostAsJsonAsync("/api/sessions", new AuthenticateInstitutionRequest(email, password));

        createSession.EnsureSuccessStatusCode();

        var response =
            await _httpClient.PatchAsync("/api/sessions/refresh-token", null);

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        await _resetDatabase();
    }
}