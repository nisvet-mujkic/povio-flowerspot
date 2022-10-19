using AutoMapper;
using Povio.FlowerSpot.Application.Features.Flowers.Commands;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.CreateSighting;
using Povio.FlowerSpot.Application.Features.Users.Commands.RegisterUser;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using Povio.FlowerSpot.Contracts.Responses.Sightings;
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

            CreateMap<Sighting, SightingDto>();
            CreateMap<CreateSightingCommand, Sighting>()
                .ForMember(src => src.SightingId, opt => opt.Ignore())
                .ForMember(src => src.CreatedDate, opt => opt.Ignore());
            CreateMap<Sighting, CreateSightingResponse>();


            CreateMap<RegisterUserCommand, User>()
               .ForMember(src => src.UserId, opt => opt.Ignore())
               .ForMember(src => src.CreatedDate, opt => opt.Ignore());
        }
    }
}