using AutoMapper;
using CadeOErro.Server.Config;
using CadeOErro.Server.Data;
using CadeOErro.Server.DTOs;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<UserDTO> Logon(string email, string password)
        {
            User user = await _repository.GetByEmailAndPassword(email, password);

            if (user == null) return null;

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userDTO.email),
                    new Claim("CadeOErro", userDTO.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            userDTO.token = tokenHandler.WriteToken(token);
            userDTO.expires = tokenDescriptor.Expires;

            return userDTO;
        }
    }
}
