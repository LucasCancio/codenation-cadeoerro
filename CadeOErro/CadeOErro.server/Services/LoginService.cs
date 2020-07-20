using AutoMapper;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Domain.Models;
using System;
using System.Security.Claims;
using System.Text;
using CadeOErro.Server.DTOs.Login;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CadeOErro.Server.Config;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Domain.Exceptions.User;
using CadeOErro.Server.Util.Validators;
using CadeOErro.Server.Util;

namespace CadeOErro.Server.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserValidator _validator;
        public LoginService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = new UserValidator(mapper, repository);
        }

        public AuthenticateDTO Authenticate(LoginDTO dto)
        {
            if (!_validator.IsValidLoginDTO(dto)) throw new InvalidUserException(_validator.ValidationResult);

            User user = _repository.FindByEmailAndPassword(dto.email, MD5Cryptography.GetHash(dto.password));

            if (user == null) throw new UserNotFoundException("Email e/ou senha inválidos!");

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

        public UserViewDTO ChangePassword(PasswordDTO dto)
        {
            if (!_validator.IsValidPasswordDTO(dto)) throw new InvalidUserException(_validator.ValidationResult);

            var user = _repository.FindByEmailAndCPF(dto.email, dto.cpf);
            if (user == null) throw new UserNotFoundException();

            user.password = dto.newPassword;
            var userView = _mapper.Map<UserViewDTO>(_repository.Save(user));

            return userView;
        }
    }
}
