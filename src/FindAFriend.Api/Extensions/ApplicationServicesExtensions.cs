using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.Infra.Common.UploadFile;
using FindAFriend.Infra.CrossCutting.UploadFile;
using FindAFriend.Infra.Data.Repositories;
using FindAFriend.UseCases.AuthenticateInstitution;
using FindAFriend.UseCases.CreateInstitution;
using FindAFriend.UseCases.CreatePet;

using Refit;

namespace FindAFriend.Api.Extensions;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder
            .AddRepositories()
            .AddUseCases()
            .AddCommonServices()
            .AddCrossCuttingServices()
            .AddHttpServices();
    }

    static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        builder.Services.AddScoped<IPetRepository, PetRepository>();

        return builder;
    }

    static WebApplicationBuilder AddUseCases(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreatePetUseCase>();
        builder.Services.AddScoped<CreateInstitutionUseCase>();
        builder.Services.AddScoped<AuthenticateInstitutionUseCase>();

        return builder;
    }

    static WebApplicationBuilder AddCommonServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

        return builder;
    }

    static WebApplicationBuilder AddCrossCuttingServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUploadFileService, UploadFileService>();

        return builder;
    }

    static WebApplicationBuilder AddHttpServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddRefitClient<IUploadFileApi>()
            .ConfigureHttpClient(options =>
                options.BaseAddress = new Uri(builder.Configuration["Integrations:ImgBB:Url"]!));

        return builder;
    }
}