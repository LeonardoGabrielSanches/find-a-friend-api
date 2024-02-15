using FindAFriend.Domain.Repositories;
using FindAFriend.Infrastructure.Repositories;
using FindAFriend.UseCases.CreateInstitution;
using FindAFriend.UseCases.CreatePet;

namespace FindAFriend.Api.Extensions;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder
            .AddRepositories()
            .AddUseCases();
    }

    static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        builder.Services.AddScoped<IPetRepository, PetRepository>();

        return builder;
    }

    static WebApplicationBuilder AddUseCases(this WebApplicationBuilder builder)
    {
        // builder.Services.AddScoped<CreatePetUseCase>();
        builder.Services.AddScoped<CreateInstitutionUseCase>();

        return builder;
    }
}