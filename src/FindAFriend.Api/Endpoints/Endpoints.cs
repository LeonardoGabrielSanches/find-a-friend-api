namespace FindAFriend.Api.Endpoints;

public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        var apiGroupBuilder = app.MapGroup("/api");
        apiGroupBuilder.RegisterPetEndpoints();
        apiGroupBuilder.RegisterInstitutionEndpoints();
    }
}