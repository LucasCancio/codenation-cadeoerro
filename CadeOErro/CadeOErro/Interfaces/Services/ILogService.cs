using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.Log;
using System.Collections.Generic;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILogService
    {
        List<LogViewDTO> GetAll();
        LogViewDTO GetById(int id);
        List<LogViewDTO> GetByLevel(string environment, string level);
        List<LogViewDTO> GetByEnvironment(string shortName);
        List<LogViewDTO> GetByDescription(string environment, string description);
        List<LogViewDTO> GetBySource(string environment, string source);
        List<LogViewDTO> OrderByLevel(List<LogViewDTO> logs);
        List<LogViewDTO> OrderByFrequency(List<LogViewDTO> logs);

        LogUpdateDTO Update(LogUpdateDTO logToUpdate);
        LogCreateDTO Create(LogCreateDTO logToCreate);
        void Delete(int id);
    }
}
