using FindAFriend.Domain;
using FindAFriend.UseCases.Common;

namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionUseCase
{
    public async Task Execute(CreateInstitutionRequest request)
    {
        // Hash password
        var passwordHash = PasswordHasher.HashPassword(request.Password);
        // Create a new institution 

        var institution = new Institution(
            name: request.Name,
            responsibleName: request.ResponsibleName,
            email: request.Email,
            zipCode: request.ZipCode,
            address: request.Address,
            phone: request.Phone,
            password: passwordHash);

        foreach (var file in request.Files)
        {
            
        }

        // Upload files
        // Save new institution
    }
}