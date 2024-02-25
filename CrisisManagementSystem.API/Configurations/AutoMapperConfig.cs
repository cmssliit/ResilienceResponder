using AutoMapper;
using CrisisManagementSystem.API.DataLayer;

namespace CrisisManagementSystem.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Auto mapper will use the name of the property and will autamaticlly map
            CreateMap<User, DTOs.User.CreateUserDto>().ReverseMap();
            CreateMap<User, DTOs.User.GetUserDto>().ReverseMap();
            CreateMap<User, DTOs.User.UpdateUserDto>().ReverseMap();    
        }
    }
}
