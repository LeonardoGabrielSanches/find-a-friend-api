namespace FindAFriend.Domain.Core;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}