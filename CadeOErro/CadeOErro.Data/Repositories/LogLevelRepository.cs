using CadeOErro.Domain.Exceptions.LogLevel;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadeOErro.Data.Repositories
{
    public class LogLevelRepository : ILogLevelRepository
    {
        private readonly CadeOErroContext _context;
        public LogLevelRepository(CadeOErroContext context)
        {
            this._context = context;
        }

        public LogLevel FindById(int id)
        {
            return _context.LogLevels.Find(id);
        }

        public List<LogLevel> GetAll()
        {
            return _context.LogLevels.ToList();
        }

        public LogLevel Create(LogLevel logLevel)
        {
            _context.LogLevels.Add(logLevel);
            _context.SaveChanges();

            return logLevel;
        }

        public void Delete(int id)
        {
            var logLevel = this.FindById(id);
            if (logLevel == null) throw new LogLevelNotFoundException();

            _context.LogLevels.Remove(logLevel);
            _context.SaveChanges();
        }
    }
}
