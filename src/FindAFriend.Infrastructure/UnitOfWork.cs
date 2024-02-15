using FindAFriend.Infra.Common.UnitOfWork;

using Microsoft.EntityFrameworkCore;

namespace FindAFriend.Infrastructure;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    public async Task<bool> Commit()
        => await context.SaveChangesAsync() > 0;
}