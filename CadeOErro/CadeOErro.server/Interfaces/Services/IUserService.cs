using CadeOErro.Server.DTOs.User;
using System.Collections.Generic;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface IUserService
    {
        List<UserViewDTO> GetAll();
        UserViewDTO GetById(int id);
        UserViewDTO Update(UserUpdateDTO userToUpdate);
        UserViewDTO Create(UserCreateDTO userToCreate);
        void Delete(int id);

    }
}
