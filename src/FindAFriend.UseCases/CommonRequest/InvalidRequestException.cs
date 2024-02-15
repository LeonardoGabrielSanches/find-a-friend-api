namespace FindAFriend.UseCases.CommonRequest;

public class InvalidRequestException(string message) : Exception(message);