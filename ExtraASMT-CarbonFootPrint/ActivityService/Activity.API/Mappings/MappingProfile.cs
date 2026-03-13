using Activity.Application.DTOs;
using Activity.Domain.Entities;
using AutoMapper;

namespace Activity.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActivityEntry, ActivityResponseDto>();
            CreateMap<CreateActivityDto, ActivityEntry>();
            CreateMap<UpdateActivityDto, ActivityEntry>();
        }
    }
}
