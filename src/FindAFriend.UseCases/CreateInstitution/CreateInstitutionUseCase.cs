using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.UnitOfWork;
using FindAFriend.UseCases.Common;
using FindAFriend.UseCases.CreateInstitution.Exceptions;

namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionUseCase(
    IInstitutionRepository institutionRepository,
    IUnitOfWork unitOfWork)
{
    public async Task Execute(CreateInstitutionRequest request)
    {
        var institutionWithSameEmail = await institutionRepository.GetByEmail(request.Email);

        if (institutionWithSameEmail is not null)
            throw new InstitutionAlreadyRegisteredException();
        
        var passwordHash = PasswordHasher.HashPassword(request.Password);

        var institution = new Institution(
            name: request.Name,
            responsibleName: request.ResponsibleName,
            email: request.Email,
            zipCode: request.ZipCode,
            address: request.Address,
            phone: request.Phone,
            password: passwordHash);

        institutionRepository.Add(institution);

        await unitOfWork.Commit();
    }
}