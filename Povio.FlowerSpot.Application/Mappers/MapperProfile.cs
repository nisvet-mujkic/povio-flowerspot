using AutoMapper;
using Povio.FlowerSpot.Application.Features.Flowers.Commands;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.CreateSighting;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Flower, FlowerDto>();
            CreateMap<CreateFlowerCommand, Flower>()
                .ForMember(src => src.FlowerId, opt => opt.Ignore())
                .ForMember(src => src.CreatedDate, opt => opt.Ignore());

            CreateMap<CreateSightingCommand, Sighting>()
                .ForMember(src => src.SightingId, opt => opt.Ignore())
                .ForMember(src => src.CreatedDate, opt => opt.Ignore());
        }
    }
}