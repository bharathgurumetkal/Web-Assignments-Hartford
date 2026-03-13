using Authentication.Application.DTOs;
using Authentication.Domain.Entities;
using AutoMapper;

namespace Authentication.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}
