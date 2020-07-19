using AutoMapper;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs;
using CadeOErro.Server.DTOs.EnvironmentDTO;
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
            CreateMap<User, UserViewDTO>()
                .ReverseMap();
            CreateMap<User, UserUpdateDTO>()
                .ReverseMap();
            CreateMap<User, UserCreateDTO>()
                .ReverseMap();


            CreateMap<Environment, EnvironmentViewDTO>()
                .ReverseMap();
            CreateMap<Environment, EnvironmentSaveDTO>()
                .ReverseMap();


            CreateMap<LogLevel, LogLevelViewDTO>()
                .ReverseMap();
            CreateMap<LogLevel, LogLevelSaveDTO>()
                .ReverseMap();


            CreateMap<Log, LogViewDTO>()
                .ReverseMap();
            CreateMap<Log, LogUpdateDTO>()
                .ReverseMap();
            CreateMap<Log, LogSaveDTO>()
                .ReverseMap();
        }
    }
}
