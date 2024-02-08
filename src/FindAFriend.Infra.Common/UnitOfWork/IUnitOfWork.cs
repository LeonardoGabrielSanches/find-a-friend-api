namespace FindAFriend.Infra.Common.UnitOfWork;

public interface IUnitOfWork
{
    Task<bool> Commit();
}