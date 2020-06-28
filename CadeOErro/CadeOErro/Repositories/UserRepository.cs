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
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> FindById(int id)
        {
            return await _context.Users
                .Where(user => user.id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            return await _context.Users
                .Where(user => user.email.ToLower() == email.ToLower() && user.password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<User> Save(User user)
        {
            var state = user.id == 0 ? EntityState.Added : EntityState.Modified;

            _context.Entry(user).State = state;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user == null) throw new UserNotFoundException("Usuário inexistente");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
