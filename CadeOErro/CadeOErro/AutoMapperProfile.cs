using AutoMapper;
using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Models;

namespace CadeOErro.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateDTO>()
                .ReverseMap();
            CreateMap<User, UserSaveDTO>()
                .ReverseMap();
            CreateMap<User, UserViewDTO>()
                .ReverseMap();
        }
    }
}
