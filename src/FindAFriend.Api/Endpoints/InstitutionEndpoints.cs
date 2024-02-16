using System.Net;

using FindAFriend.UseCases.CreateInstitution;

using Microsoft.AspNetCore.Http.HttpResults;

namespace FindAFriend.Api.Endpoints;

public static class InstitutionEndpoints
{
    public static void RegisterInstitutionEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var petsGroupBuilder = routeGroupBuilder.MapGroup("institutions");

        petsGroupBuilder.MapPost("/", CreateInstitution)
            .WithName("CreateInstitution")
            .Produces((int)HttpStatusCode.Created)
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();
    }

    static async Task<Created> CreateInstitution(
        CreateInstitutionUseCase createInstitutionUseCase,
        CreateInstitutionRequest request)
    {
        await createInstitutionUseCase.Execute(request);

        return TypedResults.Created();
    }
}