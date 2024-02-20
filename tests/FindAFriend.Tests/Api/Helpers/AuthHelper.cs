using System.Net.Http.Json;

using FindAFriend.Domain;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.Infra.Data;
using FindAFriend.UseCases.AuthenticateInstitution;
using FindAFriend.UseCases.CreateInstitution;

using Microsoft.Extensions.DependencyInjection;

namespace FindAFriend.Test.Api.Helpers;

record AuthResponseToken(string Token);

public record AuthenticatedUser(Guid Id, string Email, string Token);

public static class AuthHelper
{
    public static async Task<AuthenticatedUser> AuthenticateUser(HttpClient client, IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<FindAFriendContext>();
        var passwordHasher = scopedServices.GetRequiredService<IPasswordHasher>();

        const string
            email = "email2@example.com",
            password = "oneLetter1Number@";

        var institution = new Institution(name: "Institution",
            responsibleName: "Responsible",
            email: email,
            zipCode: "12345",
            address: "Address",
            phone: "123456789",
            password: passwordHasher.HashPassword(password));

        db.Institutions.Add(institution);

        await db.SaveChangesAsync();

        var response =
            await client.PostAsJsonAsync("/api/sessions", new AuthenticateInstitutionRequest(email, password));

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<AuthResponseToken>();

        return new AuthenticatedUser(institution.Id, email, content!.Token);
    }
}