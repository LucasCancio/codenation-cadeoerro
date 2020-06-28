using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public Task<UserViewDTO> Create(UserSaveDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserViewDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserViewDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewDTO> Update(UserSaveDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IUserService.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
