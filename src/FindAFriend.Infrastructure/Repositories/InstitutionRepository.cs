using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infrastructure.Repositories;

public class InstitutionRepository(FindAFriendContext context) : IInstitutionRepository
{
    public void Add(Institution institution)
        => context.Institutions.Add(institution);

    public async Task<Institution?> GetByEmail(string email)
        => await context.Institutions.FirstOrDefaultAsync(x => x.Email == email);

    public async Task<Institution?> GetById(Guid id)
        => await context.Institutions.FirstOrDefaultAsync(x => x.Id == id);
}