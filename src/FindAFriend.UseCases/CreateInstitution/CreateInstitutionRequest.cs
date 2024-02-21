using FindAFriend.UseCases.Common.Request;

namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionRequest(
    string name,
    string responsibleName,
    string email,
    string addressZipCode,
    string addressStreet,
    int addressNumber,
    string addressState,
    string addressCity,
    string phone,
    string password) : Request
{
    public string Name { get; } = name;
    public string ResponsibleName { get; } = responsibleName;
    public string Email { get; } = email;
    public string AddressZipCode { get; } = addressZipCode;
    public string AddressStreet { get; } = addressStreet;
    public int AddressNumber { get; } = addressNumber;
    public string AddressState { get; } = addressState;
    public string AddressCity { get; } = addressCity;
    public string Phone { get; } = phone;
    public string Password { get; } = password;

    public async override Task Validate()
    {
        AddNotifications(await new CreateInstitutionRequestContract().ValidateAsync(this));
    }
}