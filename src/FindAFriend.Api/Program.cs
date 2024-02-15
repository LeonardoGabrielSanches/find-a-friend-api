using System.Net;

using FindAFriend.Api.Endpoints;
using FindAFriend.Api.Extensions;
using FindAFriend.Domain.Exceptions;
using FindAFriend.Infrastructure;
using FindAFriend.UseCases.CommonRequest;

using Microsoft.EntityFrameworkCore;

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.AddMigrations();

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