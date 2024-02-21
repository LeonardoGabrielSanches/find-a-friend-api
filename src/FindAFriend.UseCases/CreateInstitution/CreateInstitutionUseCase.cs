using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;
using FindAFriend.Domain.ValueObjects;
using FindAFriend.Infra.Common.Auth;
using FindAFriend.UseCases.CreateInstitution.Exceptions;

namespace FindAFriend.UseCases.CreateInstitution;

public class CreateInstitutionUseCase(
    IInstitutionRepository institutionRepository,
    IPasswordHasher passwordHasher)
{
    public async Task Execute(CreateInstitutionRequest request)
    {
        var institutionWithSameEmail = await institutionRepository.GetByEmail(request.Email);

        if (institutionWithSameEmail is not null)
            throw new InstitutionAlreadyRegisteredException();

        var passwordHash = passwordHasher.HashPassword(request.Password);

        var institution = new Institution(
            name: request.Name,
            responsibleName: request.ResponsibleName,
            email: request.Email,
            new Address(request.AddressStreet, request.AddressNumber, request.AddressState, request.AddressCity,
                request.AddressZipCode),
            phone: request.Phone,
            password: passwordHash);

        await institutionRepository.Add(institution);
    }
}