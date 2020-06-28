using AutoMapper;
using CadeOErro.Server.DTOs;
using CadeOErro.Server.Models;

namespace CadeOErro.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}
