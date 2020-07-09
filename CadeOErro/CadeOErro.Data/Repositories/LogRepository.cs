using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CadeOErro.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly CadeOErroContext _context;
        public LogRepository(CadeOErroContext context)
        {
            this._context = context;
        }

        public List<Log> GetAll()
        {
            return _context.Logs.ToList();
        }
        public Log FindById(int id)
        {

            var user = _context.Logs
                .Include(log => log.logLevel)
                .Include(log => log.environment)
                .Include(log => log.user)
                .Where(log => log.id == id)
                .FirstOrDefault();

            return user;
        }

        public List<Log> FindByEnvironment(string shortName)
        {
            return _context.Logs
                .Include(log => log.environment)
                .Where(log => log.environment.shortName.ToLower() == shortName.ToLower())
                .AsNoTracking()
                .ToList();
        }

        public List<Log> FindByEnvironmentAndLevel(string envShortName, string levelDescription)
        {
            return _context.Logs
                .Include(log => log.environment)
                .Include(log => log.logLevel)
                .Where(log => log.environment.shortName.ToLower() == envShortName.ToLower() &&
                        log.logLevel.description.ToLower() == levelDescription.ToLower())
                .AsNoTracking()
                .ToList();
        }

        public List<Log> FindByEnvironmentAndDescription(string envShortName, string logDescription)
        {
            return _context.Logs
                .Include(log => log.environment)
                .Where(log => log.environment.shortName.ToLower() == envShortName.ToLower() &&
                        log.description.ToLower().Contains(logDescription.ToLower()))
                .AsNoTracking()
                .ToList();
        }

        public List<Log> FindByEnvironmentAndSource(string envShortName, string source)
        {
            return _context.Logs
                .Include(log => log.environment)
                .Where(log => log.environment.shortName.ToLower() == envShortName.ToLower() &&
                        log.source.ToLower() == source.ToLower())
                .AsNoTracking()
                .ToList();
        }

        public Log Save(Log log)
        {
            var state = log.id == 0 ? EntityState.Added : EntityState.Modified;

            _context.Entry(log).State = state;
            _context.SaveChangesAsync();
            return log;
        }

        public void Delete(Log log)
        {
            _context.Logs.Remove(log);
            _context.SaveChanges();
        }
    }
}
