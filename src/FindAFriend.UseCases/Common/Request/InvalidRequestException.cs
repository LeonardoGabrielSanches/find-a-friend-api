using FindAFriend.Domain.Exceptions;

namespace FindAFriend.UseCases.Common.Request;

public class InvalidRequestException(string message) : DomainException(message);