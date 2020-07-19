using CadeOErro.Domain.Exceptions.Environment;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadeOErro.Data.Repositories
{
    public class EnvironmentRepository : IEnvironmentRepository
    {
        private readonly CadeOErroContext _context;
        public EnvironmentRepository(CadeOErroContext context)
        {
            this._context = context;
        }

        public Environment Create(Environment environment)
        {
            _context.Environments.Add(environment);
            _context.SaveChanges();

            return environment;
        }

        public void Delete(int id)
        {
            var environment = this.FindById(id);
            if (environment == null) throw new EnvironmentNotFoundException();

            _context.Environments.Remove(environment);
            _context.SaveChanges();
        }

        public Environment FindById(int id)
        {
            return _context.Environments.Find(id);
        }

        public List<Environment> GetAll()
        {
            return _context.Environments.ToList();
        }
    }
}
