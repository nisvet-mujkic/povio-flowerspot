using AutoMapper;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Flower, FlowerDto>();
        }
    }
}