using FindAFriend.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.MapGet("/weatherforecast", () =>
    {
        Results.Ok();
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();