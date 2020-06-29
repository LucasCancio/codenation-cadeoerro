﻿using AutoMapper;
using CadeOErro.Server.Config;
using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Models;
using CadeOErro.Server.Util.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<AuthenticateDTO> Authenticate(string email, string password)
        {
            //User user = await _repository.FindByEmailAndPassword(email, password);

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
