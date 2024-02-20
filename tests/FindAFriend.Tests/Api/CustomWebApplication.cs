using System.Data.Common;

using FindAFriend.Infra.Common.UploadFile;
using FindAFriend.Infra.Data;
using FindAFriend.Test.Api.ServiceMocks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Npgsql;

using Respawn;

using Testcontainers.PostgreSql;

namespace FindAFriend.Test.Api;

public class CustomWebApplication : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithDatabase(Guid.NewGuid().ToString())
        .WithPassword("postgres")
        .WithUsername("postgres")
        .Build();

    private DbConnection _dbConnection = default!;
    private Respawner _respawner = default!;

    public HttpClient HttpClient { get; private set; } = default!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<FindAFriendContext>));

            if (dbContextDescriptor is not null)
                services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbConnection));

            if (dbConnectionDescriptor is not null)
                services.Remove(dbConnectionDescriptor);

            services.AddDbContext<FindAFriendContext>(options =>
            {
                options.UseSnakeCaseNamingConvention();
                options.UseNpgsql(_dbContainer.GetConnectionString());
            });

            services.AddScoped<IUploadFileService, UploadFileServiceMock>();
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        _dbConnection = new NpgsqlConnection(_dbContainer.GetConnectionString());
        HttpClient = CreateClient(new WebApplicationFactoryClientOptions()
        {
            BaseAddress = new Uri("https://localhost/")
        });
        await InitializeRespawner();
    }

    private async Task InitializeRespawner()
    {
        await _dbConnection.OpenAsync();
        _respawner = await Respawner.CreateAsync(_dbConnection,
            new RespawnerOptions { DbAdapter = DbAdapter.Postgres, SchemasToInclude = ["public"] });
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }

    public async Task ResetDatabase()
        => await _respawner.ResetAsync(_dbConnection);
}