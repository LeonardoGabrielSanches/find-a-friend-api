using System.Net;

using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.AuthenticateInstitution;

namespace FindAFriend.Api.Endpoints;

public static class SessionsEndpoints
{
    public static void RegisterSessionsEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var sessionsGroupBuilder = routeGroupBuilder.MapGroup("sessions");

        sessionsGroupBuilder.MapPost("/", CreateSession)
            .WithName("Login")
            .Produces((int)HttpStatusCode.OK)
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();

        sessionsGroupBuilder.MapPost("/refresh-token", RefreshToken)
            .WithName("RefreshToken")
            .WithOpenApi();
    }

    static async Task<IResult> CreateSession(
        AuthenticateInstitutionUseCase authenticateInstitutionUseCase,
        AuthenticateInstitutionRequest request,
        HttpContext context,
        ITokenService tokenService)
    {
        var response = await authenticateInstitutionUseCase.Execute(request);

        var token = tokenService.Generate(
            new TokenGeneratorRequest(
                response.Id.ToString(),
                response.Email,
                IsRefreshToken: false));

        var refreshToken = tokenService.Generate(
            new TokenGeneratorRequest(
                response.Id.ToString(),
                response.Email,
                IsRefreshToken: true));

        context.Response.Cookies.Append("refreshToken", refreshToken,
            new CookieOptions { Path = "/", Secure = true, SameSite = SameSiteMode.Strict, HttpOnly = true });

        return Results.Ok(new
        {
            response.Name,
            response.ResponsibleName,
            response.ZipCode,
            response.Address,
            response.Phone,
            token,
        });
    }

    static async Task<IResult> RefreshToken(HttpContext context)
    {
        Console.WriteLine(context.Request.Headers.Cookie);

        return Results.Ok();
    }
}