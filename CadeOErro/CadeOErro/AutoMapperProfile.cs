using AutoMapper;
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
        }
    }
}
