using AutoMapper;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CadeOErro.Server.Util.Extensions;
using CadeOErro.Domain.Exceptions.User;
using CadeOErro.Server.Util.Validators;

namespace CadeOErro.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserValidator _validator;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = new UserValidator(mapper, repository);
        }

        public List<UserViewDTO> GetAll()
        {
            List<User> users = _repository.GetAll();
            return _mapper.Map<List<UserViewDTO>>(users);
        }

        public UserViewDTO GetById(int id)
        {
            User user = _repository.FindById(id);
            if (user == null) throw new UserNotFoundException();

            return _mapper.Map<UserViewDTO>(user);
        }

        public UserViewDTO Create(UserCreateDTO userToCreate)
        {
            if (!_validator.IsValidCreateDTO(userToCreate)) throw new InvalidUserException(_validator.ValidationResult);

            User user = _mapper.Map<User>(userToCreate);
            _repository.Save(user.FixFields());

            return _mapper.Map<UserViewDTO>(user);
        }

        public UserViewDTO Update(UserUpdateDTO userToUpdate)
        {
            if (!_validator.IsValidUpdateDTO(userToUpdate)) throw new InvalidUserException(_validator.ValidationResult);

            User user = _repository.FindById(userToUpdate.id);
            if (user == null) throw new UserNotFoundException();

            user = _mapper.Map(userToUpdate, user);
            _repository.Save(user.FixFields());

            return _mapper.Map<UserViewDTO>(user);
        }

        public void Delete(int id)
        {
            User user = _repository.FindById(id);

            if (user == null) throw new UserNotFoundException();

            _repository.Delete(user);
        }
    }
}
