namespace FindAFriend.Domain.Core;

public abstract class Entity
{
    protected Entity()
    {
    }

    public Guid Id { get; protected set; } = Guid.NewGuid();
}