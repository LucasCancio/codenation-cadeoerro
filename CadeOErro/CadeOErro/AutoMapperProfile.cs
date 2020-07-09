using AutoMapper;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs;
using CadeOErro.Server.DTOs.Log;
using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.DTOs.LogLevel;
using CadeOErro.Server.DTOs.User;

namespace CadeOErro.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateDTO>()
                .ReverseMap();
            CreateMap<User, UserUpdateDTO>()
                .ReverseMap();
            CreateMap<User, UserViewDTO>()
                .ReverseMap();

            CreateMap<Environment, EnvironmentDTO>()
                .ReverseMap();

            CreateMap<LogLevel, LogLevelDTO>()
                .ReverseMap();

            CreateMap<LogViewDTO, Log>()
                .ReverseMap();
            CreateMap<LogUpdateDTO, Log>()
                .ReverseMap();
        }
    }
}
