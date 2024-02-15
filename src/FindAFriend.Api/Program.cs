using FindAFriend.Api.Endpoints;
using FindAFriend.Api.Extensions;
using FindAFriend.Infrastructure;

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

app.Run();