using FindAFriend.Api.Filters;

namespace FindAFriend.Api.Endpoints;

public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        var apiGroupBuilder = app
            .MapGroup("/api")
            .AddEndpointFilter<ValidationFilter>();

        apiGroupBuilder.RegisterPetEndpoints();
        apiGroupBuilder.RegisterInstitutionEndpoints();
        apiGroupBuilder.RegisterSessionsEndpoints();
    }
}