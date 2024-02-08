using Flunt.Notifications;

namespace FindAFriend.Domain.Extensions;

public static class NotificationExtension
{
    public static string GetNotifications(this IReadOnlyCollection<Notification> notifications)
        => string.Join(",", notifications.Select(x => x.Message));
}