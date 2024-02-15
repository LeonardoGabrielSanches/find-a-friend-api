namespace FindAFriend.Domain.Exceptions;

public class MaxCountOfPhotosAddedException(int max) : DomainException($"The max number of photos to be added is {max}");