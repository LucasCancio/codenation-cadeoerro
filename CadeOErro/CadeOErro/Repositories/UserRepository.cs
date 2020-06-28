using CadeOErro.Server.Data;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Models;
using Microsoft.AspNetCore.Mvc;
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
            return await _context.Users.Include(user => user.role).ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .Include(user => user.role)
                .Where(user => user.id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users
                .Where(user => user.email.ToLower() == email.ToLower() && user.password == password)
                .Include(user => user.role)
                .FirstOrDefaultAsync();
        }

    }
}
