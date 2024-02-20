using System.Net;

using FindAFriend.Domain.Enums;
using FindAFriend.UseCases.CreatePet;

using Microsoft.AspNetCore.Mvc;

namespace FindAFriend.Api.Endpoints;

public record CreatePetHttpRequest(
    string Name,
    string About,
    EPetAge Age,
    EPetSize Size,
    EPetEnergyLevel EnergyLevel,
    EPetDependencyLevel DependencyLevel,
    EPetEnvironmentSize EnvironmentSize,
    EPetGender Gender,
    Guid InstitutionId,
    List<IFormFile> Files)
{
    public static implicit operator CreatePetRequest(CreatePetHttpRequest createPetHttpRequest)
    {
        var createPetRequest = new CreatePetRequest(
            createPetHttpRequest.Name,
            createPetHttpRequest.About,
            createPetHttpRequest.Age,
            createPetHttpRequest.Size,
            createPetHttpRequest.EnergyLevel,
            createPetHttpRequest.DependencyLevel,
            createPetHttpRequest.EnvironmentSize,
            createPetHttpRequest.Gender,
            createPetHttpRequest.InstitutionId);

        createPetHttpRequest.Files.ForEach(file =>
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            createPetRequest.AddFile(new CreatePetRequestFiles(file.FileName, fileBytes));
        });

        return createPetRequest;
    }
}

public static class PetEndpoints
{
    public static void RegisterPetEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var petsGroupBuilder = routeGroupBuilder.MapGroup("pets").RequireAuthorization();

        petsGroupBuilder.MapPost("/", CreatePet)
            .WithName("CreatePet")
            .Produces((int)HttpStatusCode.Created)
            .DisableAntiforgery()
            .WithOpenApi();
    }

    static async Task CreatePet(
        CreatePetUseCase createPetUseCase,
        [FromForm] CreatePetHttpRequest request)
    {
        await createPetUseCase.Execute(request);

        Results.Created();
    }
}