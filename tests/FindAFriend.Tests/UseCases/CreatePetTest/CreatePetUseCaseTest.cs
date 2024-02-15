using FindAFriend.Domain;
using FindAFriend.Domain.Enums;
using FindAFriend.Domain.Exceptions;
using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.UnitOfWork;
using FindAFriend.Infra.Common.UploadFile;
using FindAFriend.UseCases.CreatePet;
using FindAFriend.UseCases.CreatePet.Exceptions;

using Moq;

namespace FindAFriend.Test.UseCases.CreatePetTest;

public class CreatePetUseCaseTest
{
    private readonly Mock<IInstitutionRepository> _institutionRepository = new();
    private readonly Mock<IUploadFile> _uploadFile = new();
    private readonly Mock<IPetRepository> _petRepository = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly CreatePetUseCase _sut;

    public CreatePetUseCaseTest()
    {
        _sut = new CreatePetUseCase(
            _institutionRepository.Object,
            _uploadFile.Object,
            _petRepository.Object,
            _unitOfWork.Object);
    }

    [Fact(DisplayName = "Should not create a new pet with invalid institution")]
    public async Task ShouldNot_CreateANewPet_WithInvalidInstitution()
    {
        var invalidRequest = new CreatePetRequest(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        await Assert.ThrowsAsync<ResourceNotFoundException>(() => _sut.Execute(invalidRequest));
    }

    [Fact(DisplayName = "Should not create a new pet when upload fails")]
    public async Task ShouldNot_CreateANewPet_WhenUploadFails()
    {
        _institutionRepository.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(new Institution(
                name: "Institution",
                responsibleName: "Responsible",
                email: "email@example.com",
                zipCode: "12345",
                address: "Address",
                phone: "123456789",
                password: "oneLetter1Number@"));

        _uploadFile.Setup(x => x.Upload(It.IsAny<UploadFileRequest>()))
            .ReturnsAsync(new UploadFileResponse(false, "url"));

        var validRequest = new CreatePetRequest(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        validRequest.AddFile(new CreatePetRequestFiles("file.png", new byte[1]));

        await Assert.ThrowsAsync<FileUploadException>(() => _sut.Execute(validRequest));
    }

    [Fact(DisplayName = "Should create a new pet")]
    public async Task ShouldN_CreateANewPet()
    {
        _institutionRepository.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(new Institution(
                name: "Institution",
                responsibleName: "Responsible",
                email: "email@example.com",
                zipCode: "12345",
                address: "Address",
                phone: "123456789",
                password: "oneLetter1Number@"));

        _uploadFile.Setup(x => x.Upload(It.IsAny<UploadFileRequest>()))
            .ReturnsAsync(new UploadFileResponse(true, "url"));

        var validRequest = new CreatePetRequest(
            name: "Pet",
            about: "About",
            age: EPetAge.Baby,
            gender: EPetGender.Male,
            size: EPetSize.Large,
            energyLevel: EPetEnergyLevel.High,
            dependencyLevel: EPetDependencyLevel.High,
            environmentSize: EPetEnvironmentSize.Small,
            institutionId: Guid.NewGuid());

        validRequest.AddFile(new CreatePetRequestFiles("file.png", new byte[1]));

        await _sut.Execute(validRequest);

        _petRepository.Verify(x => x.Add(It.IsAny<Pet>()), Times.Once);
        _unitOfWork.Verify(x => x.Commit(), Times.Once);
    }
}