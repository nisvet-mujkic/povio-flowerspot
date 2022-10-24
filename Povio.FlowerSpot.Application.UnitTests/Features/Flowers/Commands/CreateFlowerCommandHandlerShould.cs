using Ardalis.Result;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;
using Povio.FlowerSpot.Application.Mappers;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Domain.Entities;
using Xunit;

namespace Povio.FlowerSpot.Application.UnitTests.Features.Flowers.Commands
{
    public class CreateFlowerCommandHandlerShould
    {
        private readonly CreateFlowerCommandHandler _sut;

        private readonly Mock<IFlowerRepository> _mockFlowerRepository;

        public CreateFlowerCommandHandlerShould()
        {
            _mockFlowerRepository = new Mock<IFlowerRepository>();

            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfile>());
            var mapper = mapperConfiguration.CreateMapper();

            _sut = new CreateFlowerCommandHandler(mapper, _mockFlowerRepository.Object);
        }

        [Fact]
        public async Task CreateFlowerEntity()
        {
            // Arrange
            var command = new Fixture().Create<CreateFlowerCommand>();

            // Act
            var result = await _sut.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Result<CreateFlowerResponse>>();

            _mockFlowerRepository.Verify(
                x => x.AddAsync(It.Is<Flower>(
                    x => x.Name == command.Name && 
                    x.ImageRef == command.ImageRef && 
                    x.Description == command.Description), CancellationToken.None), 
                Times.Once);
        }
    }
}
