using AutoMapper;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Models;
using CadeOErro.Server.Util.Exceptions;
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

        public async Task<UserSaveDTO> CreateAsync(UserSaveDTO userToCreate)
        {
            User user = _mapper.Map<User>(userToCreate);
            await _repository.SaveAsync(user);

            return userToCreate;
        }

        public async Task<UserSaveDTO> UpdateAsync(UserSaveDTO userToUpdate)
        {
            User user =  _repository.FindById(userToUpdate.id);
            if (user == null) throw new UserNotFoundException();

            user = _mapper.Map<User>(userToUpdate);
            await _repository.SaveAsync(user);

            return userToUpdate;
        }

        public void Delete(int id)
        {
            User user = _repository.FindById(id);

            if (user == null) throw new UserNotFoundException();

            _repository.Delete(user);
        }
    }
}
