namespace FindAFriend.Domain.Repositories;

public interface IInstitutionRepository
{
    Task Add(Institution institution);
    Task<Institution?> GetByEmail(string email);
    Task<Institution?> GetById(Guid id);
}