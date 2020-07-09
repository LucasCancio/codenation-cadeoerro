using CadeOErro.Domain.Models;
using System.Collections.Generic;

namespace CadeOErro.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        List<Log> GetAll();
        Log FindById(int id);
        List<Log> FindByEnvironment(string shortName);
        List<Log> FindByEnvironmentAndLevel(string envShortName, string levelDescription);
        List<Log> FindByEnvironmentAndDescription(string envShortName, string logDescription);
        List<Log> FindByEnvironmentAndSource(string envShortName, string source);
        Log Save(Log log);
        void Delete(Log log);
    }
}
