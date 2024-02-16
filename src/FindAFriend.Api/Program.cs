using System.Net;
using System.Text;

using FindAFriend.Api.Endpoints;
using FindAFriend.Api.Extensions;
using FindAFriend.Domain.Exceptions;
using FindAFriend.Infra.Data;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<FindAFriendContext>(options =>
{
    options.UseSnakeCaseNamingConvention();
    options.UseNpgsql(builder.Configuration["ConnectionString:DefaultConnection"]);
});

builder.AddApplicationServices();

var key = Encoding.ASCII.GetBytes(builder.Configuration["Auth:Secret"]!);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.AddMigrations();

app.UseAuthorization();
app.UseAuthentication();

app.Use(async (httpContext, next) =>
{
    try
    {
        await next();
    }
    catch (DomainException applicationException)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsJsonAsync(new { errors = new[] { applicationException.Message } });
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    }
});

app.Run();

public partial class Program;