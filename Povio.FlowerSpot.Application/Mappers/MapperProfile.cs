using AutoMapper;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Create;
using Povio.FlowerSpot.Application.Features.Users.Commands.Register;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Contracts.Responses.Sightings;
using Povio.FlowerSpot.Domain.Entities;
using Povio.FlowerSpot.Domain.ValueObjects;

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

            CreateMap<Sighting, SightingDto>();
            CreateMap<CreateCommand, Sighting>()
                .ForMember(dest => dest.SightingId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => Coordinates.Create(src.Longitude, src.Latitude)));
            CreateMap<Sighting, CreateSightingResponse>()
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Coordinates.Longitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Coordinates.Latitude));

            CreateMap<RegisterUserCommand, User>()
               .ForMember(src => src.UserId, opt => opt.Ignore())
               .ForMember(src => src.CreatedDate, opt => opt.Ignore());
        }
    }
}