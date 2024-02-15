using FluentValidation.Results;

namespace FindAFriend.UseCases.CommonRequest;

public abstract class Request
{
    private readonly List<string> _notifications = [];

    public abstract Task Validate();

    public IReadOnlyCollection<string> Notifications => _notifications;
    public bool IsValid => _notifications.Count != 0;

    protected void AddNotifications(ValidationResult validationResult)
    {
        if (validationResult.IsValid)
            return;

        _notifications.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
    }
}