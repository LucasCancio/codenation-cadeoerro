using CadeOErro.Server.DTOs.User;
using System.Collections.Generic;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface IUserService
    {
        List<UserViewDTO> GetAll();
        UserViewDTO GetById(int id);
        UserSaveDTO Update(UserSaveDTO userToUpdate);
        UserSaveDTO Create(UserSaveDTO userToCreate);
        void Delete(int id);

    }
}
