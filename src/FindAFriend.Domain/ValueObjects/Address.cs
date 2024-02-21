namespace FindAFriend.Domain.ValueObjects;

public class Address(string street, int number, string state, string city, string zipCode)
{
    public string Street { get; private set; } = street;
    public int Number { get; private set; } = number;
    public string State { get; private set; } = state;
    public string City { get; private set; } = city;
    public string ZipCode { get; private set; } = zipCode;
}