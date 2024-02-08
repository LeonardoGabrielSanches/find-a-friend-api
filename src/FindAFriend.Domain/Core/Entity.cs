using Flunt.Notifications;

namespace FindAFriend.Domain.Core;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}