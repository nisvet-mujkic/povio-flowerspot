using AutoMapper;
using FluentAssertions;
using Povio.FlowerSpot.Application.Features.Flowers.Commands;
using Povio.FlowerSpot.Application.Mappers;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Domain.Entities;
using Xunit;

namespace Povio.FlowerSpot.Application.UnitTests.MapperTests
{
    public class MapperProfileShould
    {
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public MapperProfileShould()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());

            _mapper = _mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void HaveValidConfiguration()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        [Fact]
        public void MapCorrectlyFlowerEntityToFlowerDto()
        {
            var flower = new Flower()
            {
                Name = "flower-name",
                Description = "flower-description",
                ImageRef = "flower-image-ref"
            };

            var flowerDto = _mapper.Map<FlowerDto>(flower);

            flowerDto.Name.Should().Be(flower.Name);
            flowerDto.Description.Should().Be(flower.Description);
            flowerDto.ImageRef.Should().Be(flower.ImageRef);
        }

        [Fact]
        public void MapCorrectlyCreateFlowerCommandToFlowerEntity()
        {
            var createFlowerCommand = new CreateFlowerCommand("flower-name", "flower-image-ref", "flower-description");

            var flower = _mapper.Map<Flower>(createFlowerCommand);

            flower.Name.Should().Be(createFlowerCommand.Name);
            flower.Description.Should().Be(createFlowerCommand.Description);
            flower.ImageRef.Should().Be(createFlowerCommand.ImageRef);
        }
    }
}
