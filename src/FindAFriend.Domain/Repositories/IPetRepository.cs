namespace FindAFriend.Domain.Repositories;

public interface IPetRepository
{
    Task Add(Pet pet);
}