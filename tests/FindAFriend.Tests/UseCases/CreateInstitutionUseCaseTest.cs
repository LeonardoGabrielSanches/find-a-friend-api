using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;
using FindAFriend.Infra.Common.UnitOfWork;
using FindAFriend.UseCases.CreateInstitution;
using FindAFriend.UseCases.CreateInstitution.Exceptions;

using Moq;

namespace FindAFriend.Test.UseCases;

public class CreateInstitutionUseCaseTest
{
    private readonly Mock<IInstitutionRepository> _institutionRepository = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly CreateInstitutionUseCase _sut;

    private readonly CreateInstitutionRequest _request = new(
        "name",
        "responsibleName",
        "email",
        "zipCode",
        "address",
        "phone",
        "password");

    public CreateInstitutionUseCaseTest()
    {
        _sut = new CreateInstitutionUseCase(_institutionRepository.Object, _unitOfWork.Object);
    }

    [Fact(DisplayName = "Should not create a new institution with same email")]
    public async Task ShouldNot_CreateANewInstitution_WithSameEmail()
    {
        _institutionRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(new Institution("name",
            "responsibleName", "email", "zipCode", "address", "phone", "password"));

        await Assert.ThrowsAsync<InstitutionAlreadyRegisteredException>(() => _sut.Execute(_request));
    }

    [Fact(DisplayName = "Should create a new institution")]
    public async Task Should_CreateANewInstitution()
    {
        await _sut.Execute(_request);

        _institutionRepository.Verify(x => x.Add(It.IsAny<Institution>()), Times.Once);
        _unitOfWork.Verify(x => x.Commit(), Times.Once);
    }
}