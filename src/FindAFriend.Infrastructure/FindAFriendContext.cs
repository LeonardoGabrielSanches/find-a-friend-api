using FindAFriend.Domain;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infrastructure;

public class FindAFriendContext(DbContextOptions<FindAFriendContext> options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSnakeCaseNamingConvention();
}