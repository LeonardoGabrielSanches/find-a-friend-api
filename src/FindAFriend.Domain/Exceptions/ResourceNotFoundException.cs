namespace FindAFriend.Domain.Exceptions;

public class ResourceNotFoundException(string resourceType) : Exception($"Resource not found {resourceType}");