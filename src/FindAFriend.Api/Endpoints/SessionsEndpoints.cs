using System.Net;

using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.AuthenticateInstitution;

namespace FindAFriend.Api.Endpoints;

public static class SessionsEndpoints
{
    private const string RefreshTokenCookieKey = "refresh_token";

    public static void RegisterSessionsEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        var sessionsGroupBuilder = routeGroupBuilder.MapGroup("sessions");

        sessionsGroupBuilder.MapPost("/", CreateSession)
            .WithName("Login")
            .Produces((int)HttpStatusCode.OK)
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();

        sessionsGroupBuilder.MapPatch("/refresh-token", RefreshToken)
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

        context.Response.Cookies.Append(RefreshTokenCookieKey, refreshToken,
            new CookieOptions { Path = "/", Secure = true, SameSite = SameSiteMode.Strict, HttpOnly = true });

        return Results.Ok(new
        {
            response.Name,
            response.ResponsibleName,
            response.ZipCode,
            response.Address,
            response.Phone,
            token
        });
    }

    static IResult RefreshToken(
        HttpContext context,
        ITokenService tokenService)
    {
        var refreshToken = context.Request.Cookies.FirstOrDefault(x => x.Key == RefreshTokenCookieKey);

        if (refreshToken.Key is null)
            return Results.Unauthorized();

        (TokenUserInformation tokenInfo, bool isValid) = tokenService.ValidateToken(refreshToken.Value);

        if (!isValid)
            return Results.Unauthorized();

        var token = tokenService.Generate(
            new TokenGeneratorRequest(
                tokenInfo.Id.ToString(),
                tokenInfo.Email,
                IsRefreshToken: false));

        var newRefreshToken = tokenService.Generate(
            new TokenGeneratorRequest(
                tokenInfo.Id.ToString(),
                tokenInfo.Email,
                IsRefreshToken: true));

        context.Response.Cookies.Append(RefreshTokenCookieKey, newRefreshToken,
            new CookieOptions { Path = "/", Secure = true, SameSite = SameSiteMode.Strict, HttpOnly = true });

        return Results.Ok(new { token });
    }
}