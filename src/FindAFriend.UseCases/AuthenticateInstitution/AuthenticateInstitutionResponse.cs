using FindAFriend.Domain;

namespace FindAFriend.UseCases.AuthenticateInstitution;

public record AuthenticateInstitutionResponse(
    Guid Id,
    string Email,
    string Name,
    string ResponsibleName,
    string ZipCode,
    string Address,
    string Phone,
    string Token,
    string RefreshToken)
{
    public static AuthenticateInstitutionResponse MapResponse(
        Institution institution,
        string token,
        string refreshToken)
    {
        return new AuthenticateInstitutionResponse(
            institution.Id,
            institution.Email,
            institution.Name,
            institution.ResponsibleName,
            institution.ZipCode,
            institution.Address,
            institution.Phone,
            token,
            refreshToken);
    }
};