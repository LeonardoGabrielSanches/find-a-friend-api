using System.Net;

using FindAFriend.UseCases.CreatePet;

namespace FindAFriend.Api.Endpoints;

public static class PetEndpoints
{
    public static void RegisterPetEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var petsGroupBuilder = routeGroupBuilder.MapGroup("pets").RequireAuthorization();

        petsGroupBuilder.MapPost("/", () => { Results.Ok("Need implementations"); })
            .WithName("CreatePet")
            .Produces((int)HttpStatusCode.Created)
            .WithOpenApi();
    }

    static async Task CreatePet(CreatePetUseCase createPetUseCase, CreatePetRequest request)
    {
        await createPetUseCase.Execute(request);

        Results.Created();
    }
}