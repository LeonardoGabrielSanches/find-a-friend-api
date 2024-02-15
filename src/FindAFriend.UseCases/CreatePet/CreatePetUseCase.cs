using FindAFriend.Domain;
using FindAFriend.Domain.Exceptions;
using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.UploadFile;
using FindAFriend.UseCases.CreatePet.Exceptions;

namespace FindAFriend.UseCases.CreatePet;

public class CreatePetUseCase(
    IInstitutionRepository institutionRepository,
    IUploadFile uploadFile,
    IPetRepository petRepository)
{
    public async Task Execute(CreatePetRequest request)
    {
        var institution = await institutionRepository.GetById(request.InstitutionId);

        if (institution is null)
            throw new ResourceNotFoundException(nameof(Institution));

        var pet = new Pet(
            name: request.Name,
            about: request.About,
            age: request.Age,
            request.Size,
            request.EnergyLevel,
            request.DependencyLevel,
            request.EnvironmentSize,
            request.Gender,
            request.InstitutionId);

        foreach (var file in request.Files)
        {
            var uploadFileResponse = await uploadFile.Upload(new UploadFileRequest(file.Bytes));

            if (!uploadFileResponse.Success)
                throw new FileUploadException();

            pet.AddPhoto(new Photo(uploadFileResponse.Url, pet.Id));
        }
    
        petRepository.Add(pet);
    }
}