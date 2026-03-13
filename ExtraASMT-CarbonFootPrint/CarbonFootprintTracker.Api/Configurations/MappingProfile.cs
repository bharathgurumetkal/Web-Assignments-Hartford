using AutoMapper;
using CarbonFootprintTracker.Api.DTOs;
using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserRegisterDto, User>();
            
            CreateMap<Activity, ActivityResponseDto>();
            CreateMap<CreateActivityDto, Activity>();
            CreateMap<UpdateActivityDto, Activity>();
        }
    }
}
