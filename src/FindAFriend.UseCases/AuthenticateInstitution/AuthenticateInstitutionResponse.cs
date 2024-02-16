using FindAFriend.Domain;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public record AuthenticateInstitutionResponse(
    Guid Id,
    string Email,
    string Name,
    string ResponsibleName,
    string ZipCode,
    string Address,
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
            institution.ZipCode,
            institution.Address,
            institution.Phone);
    }
};