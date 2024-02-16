using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.Infra.Data.Repositories;
using FindAFriend.UseCases.AuthenticateInstitution;
using FindAFriend.UseCases.CreateInstitution;

namespace FindAFriend.Api.Extensions;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder
            .AddRepositories()
            .AddUseCases()
            .AddCommonServices();
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
        builder.Services.AddScoped<AuthenticateInstitutionUseCase>();

        return builder;
    }

    static WebApplicationBuilder AddCommonServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

        return builder;
    }
}