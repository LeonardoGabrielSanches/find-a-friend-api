using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.UnitOfWork;
using FindAFriend.UseCases.CreateInstitution;
using FindAFriend.UseCases.CreateInstitution.Exceptions;

using Moq;

namespace FindAFriend.Test.UseCases.CreateInstitutionTest;

public class CreateInstitutionUseCaseTest
{
    private readonly Mock<IInstitutionRepository> _institutionRepository = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly CreateInstitutionUseCase _sut;

    public CreateInstitutionUseCaseTest()
    {
        _sut = new CreateInstitutionUseCase(_institutionRepository.Object, _unitOfWork.Object);
    }

    [Fact(DisplayName = "Should not create a new institution with same email")]
    public async Task ShouldNot_CreateANewInstitution_WithSameEmail()
    {
        _institutionRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(new Institution("name",
            "responsibleName", "email", "zipCode", "address", "phone", "password"));
        
        var validRequest = new CreateInstitutionRequest(
            "name",
            "responsibleName",
            "email@example.com",
            "zipCode",
            "address",
            "phone",
            "password@1234");

        await Assert.ThrowsAsync<InstitutionAlreadyRegisteredException>(() => _sut.Execute(validRequest));
    }

    [Fact(DisplayName = "Should create a new institution")]
    public async Task Should_CreateANewInstitution()
    {
        var validRequest = new CreateInstitutionRequest(
            "name",
            "responsibleName",
            "email@example.com",
            "zipCode",
            "address",
            "phone",
            "oneLetter1Number@");
        
        await _sut.Execute(validRequest);

        _institutionRepository.Verify(x => x.Add(It.IsAny<Institution>()), Times.Once);
        _unitOfWork.Verify(x => x.Commit(), Times.Once);
    }
}