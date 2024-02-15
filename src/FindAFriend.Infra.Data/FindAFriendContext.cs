using FindAFriend.Domain;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infra.Data;

public class FindAFriendContext(DbContextOptions<FindAFriendContext> options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Institution> Institutions { get; set; }
}