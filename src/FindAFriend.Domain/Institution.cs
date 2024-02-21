using FindAFriend.Domain.Core;
using FindAFriend.Domain.ValueObjects;

namespace FindAFriend.Domain;

public class Institution : Entity
{
    protected Institution() { }

    public Institution(string name, string responsibleName, string email, Address address, string phone,
        string password)
    {
        Name = name;
        ResponsibleName = responsibleName;
        Email = email;
        Address = address;
        Phone = phone;
        Password = password;
    }

    private readonly List<Pet> _pets = [];

    public string Name { get; private set; }
    public string ResponsibleName { get; private set; }
    public string Email { get; private set; }

    public Address Address { get; private set; }

    public string Phone { get; private set; }
    public string Password { get; private set; }
    public IEnumerable<Pet> Pets => _pets;

    public void AddPet(Pet pet) => _pets.Add(pet);
}