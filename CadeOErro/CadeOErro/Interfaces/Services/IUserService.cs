using CadeOErro.Server.DTOs.User;
using System.Collections.Generic;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface IUserService
    {
        List<UserViewDTO> GetAll();
        UserViewDTO GetById(int id);
        UserUpdateDTO Update(UserUpdateDTO userToUpdate);
        UserCreateDTO Create(UserCreateDTO userToCreate);
        void Delete(int id);

    }
}
