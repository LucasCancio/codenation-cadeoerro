using CadeOErro.Server.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserViewDTO>> GetAll();
        Task<UserViewDTO> GetById(int id);
        Task<UserViewDTO> Update(UserSaveDTO user);
        Task<UserViewDTO> Create(UserSaveDTO user);
        void Delete(int id);

    }
}
