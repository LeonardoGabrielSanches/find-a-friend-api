using FindAFriend.UseCases.CommonRequest;

namespace FindAFriend.Api.Filters;

public class ValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var requestToValidate = context.Arguments.FirstOrDefault(x => x?.GetType().BaseType == typeof(Request));
        
        if(requestToValidate is null)
            return await next(context);

        var request = context.GetArgument<Request>(context.Arguments.IndexOf(requestToValidate));

        await request.Validate();

        if (!request.IsValid)
            return Results.BadRequest(new { errors = request.Notifications.Select(x => x) });

        return await next(context);
    }
}