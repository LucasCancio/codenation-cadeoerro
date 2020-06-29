using AutoMapper;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Models;
using CadeOErro.Server.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadeOErro.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<UserViewDTO>> GetAll()
        {
            List<User> users = await _repository.GetAll();
            return _mapper.Map<List<UserViewDTO>>(users);
        }

        public async Task<UserViewDTO> GetById(int id)
        {
            User user = await _repository.FindById(id);
            if (user == null) throw new UserNotFoundException();

            return _mapper.Map<UserViewDTO>(user);
        }

        public async Task<UserSaveDTO> Create(UserSaveDTO userToCreate)
        {
            User user = _mapper.Map<User>(userToCreate);
            await _repository.Save(user);

            return userToCreate;
        }

        public async Task<UserSaveDTO> Update(UserSaveDTO userToUpdate)
        {
            User user = await _repository.FindById(userToUpdate.id);
            if (user == null) throw new UserNotFoundException();

            user = _mapper.Map<User>(userToUpdate);
            await _repository.Save(user);

            return userToUpdate;
        }

        async Task IUserService.Delete(int id)
        {
            User user = await _repository.FindById(id);

            if (user == null) throw new UserNotFoundException();

            _repository.Delete(user);
        }
    }
}
