using CadeOErro.Server.Data;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Util.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CadeOErro.Server.Repositories
{
    public class EnvironmentRepository : IEnvironmentRepository
    {
        private readonly CadeOErroContext _context;
        public EnvironmentRepository(CadeOErroContext context)
        {
            this._context = context;
        }

        public Models.Environment Create(Models.Environment environment)
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

        public Models.Environment FindById(int id)
        {
            return _context.Environments.Find(id);
        }

        public List<Models.Environment> GetAll()
        {
            return _context.Environments.ToList();
        }
    }
}
