namespace FindAFriend.Domain.Exceptions;

public class MaxCountOfPhotosAddedException(int max) : Exception($"The max number of photos to be added is {max}");