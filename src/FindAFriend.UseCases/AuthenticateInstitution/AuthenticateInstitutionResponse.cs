using FindAFriend.Domain;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public record AuthenticateInstitutionResponse(
    Guid Id,
    string Email,
    string Name,
    string ResponsibleName,
    string AddressZipCode,
    string AddressStreet,
    int AddressNumber,
    string AddressState,
    string AddressCity,
    string Phone)
{
    public static AuthenticateInstitutionResponse MapResponse(
        Institution institution)
    {
        return new AuthenticateInstitutionResponse(
            institution.Id,
            institution.Email,
            institution.Name,
            institution.ResponsibleName,
            institution.Address.ZipCode,
            institution.Address.Street,
            institution.Address.Number,
            institution.Address.State,
            institution.Address.City,
            institution.Phone);
    }
};