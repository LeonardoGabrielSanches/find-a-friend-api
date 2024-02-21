using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;

using FindAFriend.Domain.Enums;
using FindAFriend.Test.Api.Helpers;

namespace FindAFriend.Test.Api;

[Collection("Integration")]
public class PetApiTest(CustomWebApplication customWebApplication)
{
    private readonly HttpClient _httpClient = customWebApplication.HttpClient;
    private readonly Func<Task> _resetDatabase = customWebApplication.ResetDatabase;

    [Fact(DisplayName = "Should create a new pet")]
    [Category("Integration")]
    public async Task Should_CreateANewPet()
    {
        var authenticatedUser = await AuthHelper.AuthenticateUser(_httpClient, customWebApplication.Services);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", authenticatedUser.Token);

        var formDataBoundary = $"----------{Guid.NewGuid():N}";
        var content = new MultipartFormDataContent(formDataBoundary);

        content.Add(new StringContent("Name"), "Name");
        content.Add(new StringContent("About"), "About");
        content.Add(new StringContent(EPetAge.Adult.ToString()), "Age");
        content.Add(new StringContent(EPetSize.Large.ToString()), "Size");
        content.Add(new StringContent(EPetEnergyLevel.Low.ToString()), "EnergyLevel");
        content.Add(new StringContent(EPetEnvironmentSize.Small.ToString()), "EnvironmentSize");
        content.Add(new StringContent(EPetDependencyLevel.Low.ToString()), "DependencyLevel");
        content.Add(new StringContent(EPetGender.Female.ToString()), "Gender");
        content.Add(new StringContent(authenticatedUser.Id.ToString()), "InstitutionId");
        content.Add(new StreamContent(new MemoryStream(new byte[10])), "Files[0]", "file.png");

        var response = await _httpClient.PostAsync("/api/pets", content);

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        await _resetDatabase();
    }
}