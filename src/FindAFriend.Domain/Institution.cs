using FindAFriend.Domain.Contracts;
using FindAFriend.Domain.Core;

namespace FindAFriend.Domain;

public class Institution : Entity
{
    public Institution(
        string name,
        string responsibleName,
        string email,
        string zipCode,
        string address,
        string phone,
        string password)
    {
        Name = name;
        ResponsibleName = responsibleName;
        Email = email;
        ZipCode = zipCode;
        Address = address;
        Phone = phone;
        Password = password;

        AddNotifications(new CreateInstitutionContract(this));
    }

    public string Name { get; private set; }
    public string ResponsibleName { get; private set; }
    public string Email { get; private set; }
    public string ZipCode { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }
}