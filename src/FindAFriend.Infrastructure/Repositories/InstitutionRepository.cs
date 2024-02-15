using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infrastructure.Repositories;

public class InstitutionRepository(FindAFriendContext context) : IInstitutionRepository
{
    public async Task Add(Institution institution)
    {
        context.Institutions.Add(institution);
        await context.SaveChangesAsync();
    }

    public async Task<Institution?> GetByEmail(string email)
        => await context.Institutions.FirstOrDefaultAsync(x => x.Email == email);

    public async Task<Institution?> GetById(Guid id)
        => await context.Institutions.FirstOrDefaultAsync(x => x.Id == id);
}