using CadeOErro.Server.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface IUserService
    {
        List<UserViewDTO> GetAll();
        UserViewDTO GetById(int id);
        Task<UserSaveDTO> UpdateAsync(UserSaveDTO userToUpdate);
        Task<UserSaveDTO> CreateAsync(UserSaveDTO userToCreate);
        void Delete(int id);

    }
}
