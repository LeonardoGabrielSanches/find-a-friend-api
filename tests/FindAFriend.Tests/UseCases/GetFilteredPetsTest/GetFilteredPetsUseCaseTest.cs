using FindAFriend.Domain;
using FindAFriend.Domain.Repositories;
using FindAFriend.UseCases.GetFilteredPets;

using Moq;

namespace FindAFriend.Test.UseCases.GetFilteredPetsTest;

public class GetFilteredPetsUseCaseTest
{
    private readonly Mock<IPetRepository> _petRepository = new();
    private readonly GetFilteredPetsUseCase _sut;

    public GetFilteredPetsUseCaseTest()
    {
        _sut = new GetFilteredPetsUseCase(
            _petRepository.Object);
    }


    [Fact(DisplayName = "Should get pets filtered")]
    public async Task Should_GetPetsFiltered()
    {
        _petRepository.Setup(x => x.GetFiltered(It.IsAny<PetFilterRequest>()))
            .ReturnsAsync(new List<PetFilterResponse>());

        await _sut.Execute(new GetFilteredPetsRequest("New york"));

        _petRepository.Verify(x => x.GetFiltered(It.IsAny<PetFilterRequest>()), Times.Once);
    }
}