using CadeOErro.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
