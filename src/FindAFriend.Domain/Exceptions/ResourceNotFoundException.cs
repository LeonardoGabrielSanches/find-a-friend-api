namespace FindAFriend.Domain.Exceptions;

public class ResourceNotFoundException(string resourceType) : DomainException($"Resource not found {resourceType}");