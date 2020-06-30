using CadeOErro.Server.Data;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Models;
using CadeOErro.Server.Util.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CadeOErroContext _context;
        public UserRepository(CadeOErroContext context)
        {
            this._context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User FindById(int id)
        {

            var user = _context.Users
                .Where(user => user.id == id)
                .FirstOrDefault();

            return user;
        }
        public User FindByEmailAndPasswordAsync(string email, string password)
        {
            return _context.Users
                .Where(user => user.email.ToLower() == email.ToLower() && user.password == password)
                .FirstOrDefault();
        }

        public User Save(User user)
        {
            var state = user.id == 0 ? EntityState.Added : EntityState.Modified;

            _context.Entry(user).State = state;
            _context.SaveChangesAsync();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
