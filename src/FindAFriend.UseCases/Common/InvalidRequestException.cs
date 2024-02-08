namespace FindAFriend.UseCases.Common;

public class InvalidRequestException(string message) : Exception(message);