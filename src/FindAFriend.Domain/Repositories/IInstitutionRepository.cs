namespace FindAFriend.Domain.Repositories;

public interface IInstitutionRepository
{
    void Add(Institution institution);
    Task<Institution> GetByEmail(string email);
}