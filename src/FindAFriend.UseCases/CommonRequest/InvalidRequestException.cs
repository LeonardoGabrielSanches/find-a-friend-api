using FindAFriend.Domain.Exceptions;

namespace FindAFriend.UseCases.CommonRequest;

public class InvalidRequestException(string message) : DomainException(message);