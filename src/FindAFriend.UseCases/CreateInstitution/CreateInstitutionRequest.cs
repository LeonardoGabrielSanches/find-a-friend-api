using FindAFriend.UseCases.Common;


namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionRequest(
    string name,
    string responsibleName,
    string email,
    string zipCode,
    string address,
    string phone,
    string password) : Request
{
    public string Name { get; } = name;
    public string ResponsibleName { get; } = responsibleName;
    public string Email { get; } = email;
    public string ZipCode { get; } = zipCode;
    public string Address { get; } = address;
    public string Phone { get; } = phone;
    public string Password { get; } = password;

    public override void Validate()
    {
        AddNotifications(new CreateInstitutionRequestContract(this));
    }
}