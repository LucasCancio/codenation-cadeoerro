using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadeOErro.Data.Repositories
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

        public User FindByEmail(string email)
        {
            return _context.Users
                .Where(user => user.email.ToLower() == email.ToLower())
                .AsNoTracking()
                .FirstOrDefault();
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            return _context.Users
                .Where(user => user.email.ToLower() == email.ToLower() && user.password == password)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public User Save(User user)
        {
            var state = user.id == 0 ? EntityState.Added : EntityState.Modified;

            _context.Entry(user).State = state;
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
