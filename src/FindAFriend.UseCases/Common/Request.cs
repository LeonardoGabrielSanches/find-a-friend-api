using Flunt.Notifications;

namespace FindAFriend.UseCases.Common;

public abstract class Request : Notifiable<Notification>
{
    public abstract void Validate();
};