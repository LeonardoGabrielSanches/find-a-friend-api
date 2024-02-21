using System.Net;

using FindAFriend.Domain.Enums;
using FindAFriend.UseCases.Common.Request;
using FindAFriend.UseCases.CreatePet;

using Microsoft.AspNetCore.Mvc;

namespace FindAFriend.Api.Endpoints;

public static class PetEndpoints
{
    public static void RegisterPetEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var petsGroupBuilder = routeGroupBuilder.MapGroup("pets");

        petsGroupBuilder.MapPost("/", CreatePet)
            .WithName("CreatePet")
            .Produces((int)HttpStatusCode.Created)
            .RequireAuthorization()
            .DisableAntiforgery()
            .WithOpenApi();
    }

    static async Task<IResult> CreatePet(
        CreatePetUseCase createPetUseCase,
        [FromForm] CreatePetHttpRequest request)
    {
        await createPetUseCase.Execute(request);

        return Results.Created();
    }
}

public class CreatePetHttpRequest(
    string name,
    string about,
    EPetAge age,
    EPetSize size,
    EPetEnergyLevel energyLevel,
    EPetDependencyLevel dependencyLevel,
    EPetEnvironmentSize environmentSize,
    EPetGender gender,
    Guid institutionId,
    IFormFileCollection files) : Request
{
    private string Name { get; } = name;
    private string About { get; } = about;
    private EPetAge Age { get; } = age;
    private EPetSize Size { get; } = size;
    private EPetEnergyLevel EnergyLevel { get; } = energyLevel;
    private EPetDependencyLevel DependencyLevel { get; } = dependencyLevel;
    private EPetEnvironmentSize EnvironmentSize { get; } = environmentSize;
    private EPetGender Gender { get; } = gender;
    private Guid InstitutionId { get; } = institutionId;
    private IFormFileCollection Files { get; } = files;

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

        createPetHttpRequest.Files.ToList().ForEach(file =>
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            createPetRequest.AddFile(new CreatePetRequestFiles(file.FileName, fileBytes));
        });

        return createPetRequest;
    }

    public async override Task Validate()
    {
        var request = (CreatePetRequest)this;

        await request.Validate();

        AddNotifications(request.Notifications.ToList());
    }
}