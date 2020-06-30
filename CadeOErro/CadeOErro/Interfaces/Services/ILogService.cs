using CadeOErro.Domain.Models;
using System.Collections.Generic;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILogService
    {
        List<Log> GetAll();
        Log GetById(int id);
        List<Log> GetByLevel(string level);
        List<Log> GetByEnvironment(string environment);
        List<Log> GetByDescription(string description);
        List<Log> GetBySource(string source);
        List<Log> OrderByLevelPriority(List<Log> logs);
        List<Log> OrderByFrequency(List<Log> logs);

        Log Update(Log logToUpdate);
        Log Create(Log logToCreate);
        void Delete(int id);
    }
}
