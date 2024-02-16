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
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();
    }

    static async Task<IResult> CreateInstitution(
        CreateInstitutionUseCase createInstitutionUseCase,
        CreateInstitutionRequest request)
    {
        await createInstitutionUseCase.Execute(request);

        return Results.Created();
    }
}