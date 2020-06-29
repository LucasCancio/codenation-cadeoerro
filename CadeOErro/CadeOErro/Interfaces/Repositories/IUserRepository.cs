using CadeOErro.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> FindById(int id);
        Task<User> FindByEmailAndPassword(string email, string password);
        Task<User> Save(User user);
        void Delete(User user);
    }
}
