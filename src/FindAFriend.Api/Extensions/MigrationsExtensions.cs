using FindAFriend.Infra.Data;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Api.Extensions;

public static class MigrationsExtensions
{
    public static void AddMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<FindAFriendContext>();

        context.Database.Migrate();
    }
}