using System.Net;

using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Api.Endpoints;

public static class InstitutionEndpoints
{
    public static void RegisterInstitutionEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var petsGroupBuilder = routeGroupBuilder.MapGroup("institutions");

        petsGroupBuilder.MapPost("/", CreateInstitution)
            .WithName("CreateInstitution")
            .Produces((int)HttpStatusCode.Created)
            .WithOpenApi();
    }

    static async Task CreateInstitution(
        CreateInstitutionUseCase createInstitutionUseCase,
        CreateInstitutionRequest request)
    {
        await createInstitutionUseCase.Execute(request);

        Results.Created();
    }
}