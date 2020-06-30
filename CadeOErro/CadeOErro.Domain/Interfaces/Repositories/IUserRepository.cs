using CadeOErro.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadeOErro.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User FindById(int id);
        User FindByEmailAndPasswordAsync(string email, string password);
        User Save(User user);
        void Delete(User user);
    }
}
