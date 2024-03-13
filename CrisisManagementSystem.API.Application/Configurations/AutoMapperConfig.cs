using AutoMapper;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.DTOs.User;

namespace CrisisManagementSystem.API.Application.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
                //Auto mapper will use the name of the property and will autamaticlly map
                CreateMap<User, CreateUserDto>().ReverseMap();
                CreateMap<User, GetUserDto>().ReverseMap();
                CreateMap<User, UpdateUserDto>().ReverseMap();
                CreateMap<SystemUserDto, SystemUser>().ReverseMap();
        }
    }
}
