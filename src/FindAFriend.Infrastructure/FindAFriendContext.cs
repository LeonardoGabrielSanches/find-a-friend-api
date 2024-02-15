using FindAFriend.Domain;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infrastructure;

public class FindAFriendContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Institution> Institutions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSnakeCaseNamingConvention();
}