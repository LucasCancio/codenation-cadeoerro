using AutoMapper;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Domain.Models;
using CadeOErro.Domain.Util.Exceptions;
using System;
using System.Security.Claims;
using System.Text;
using CadeOErro.Server.DTOs.Login;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CadeOErro.Server.Config;

namespace CadeOErro.Server.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public LoginService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public  AuthenticateDTO Authenticate(string email, string password)
        {
            //User user =  _repository.FindByEmailAndPassword(email, password);

            //if (user == null) throw new UserNotFoundException("Email e/ou senha inválidos!");

            var user = new User() { email = email, password = password, role = "admin" };
            if (user.email != "teste" && user.password != "senha123") throw new UserNotFoundException("Email e/ou senha inválidos!");

            AuthenticateDTO authenticate = _mapper.Map<AuthenticateDTO>(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, authenticate.email),
                    new Claim(ClaimTypes.Role, authenticate.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            authenticate.token = tokenHandler.WriteToken(token);
            authenticate.expiresAt = tokenDescriptor.Expires;

            return authenticate;
        }
    }
}
