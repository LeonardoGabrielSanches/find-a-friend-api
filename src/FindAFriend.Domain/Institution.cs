using FindAFriend.Domain.Core;

namespace FindAFriend.Domain;

public class Institution(
    string name,
    string responsibleName,
    string email,
    string zipCode,
    string address,
    string phone,
    string password)
    : Entity
{
    private readonly List<Pet> _pets = [];

    public string Name { get; private set; } = name;
    public string ResponsibleName { get; private set; } = responsibleName;
    public string Email { get; private set; } = email;
    public string ZipCode { get; private set; } = zipCode;
    public string Address { get; private set; } = address;
    public string Phone { get; private set; } = phone;
    public string Password { get; private set; } = password;
    public IReadOnlyList<Pet> Pets => _pets;

    public void AddPet(Pet pet)
        => _pets.Add(pet);
}