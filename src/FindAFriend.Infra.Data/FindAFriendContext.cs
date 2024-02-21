using FindAFriend.Domain;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infra.Data;

public class FindAFriendContext(DbContextOptions<FindAFriendContext> options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Institution> Institutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Institution>().OwnsOne(x => x.Address);

        modelBuilder.Entity<Institution>().ToTable("institutions");
        modelBuilder.Entity<Pet>().ToTable("pets");
        modelBuilder.Entity<Photo>().ToTable("photos");
    }
}