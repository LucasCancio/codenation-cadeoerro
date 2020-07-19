using CadeOErro.Domain.Models;
using CadeOErro.Domain.Pagination;
using CadeOErro.Server.DTOs.Log;
using System.Collections.Generic;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILogService
    {
        PagedList<LogViewDTO> GetAll(PaginationParameters pagination);
        LogViewDTO GetById(int id);
        PagedList<LogViewDTO> GetByLevel(string environment, string level, PaginationParameters pagination);
        PagedList<LogViewDTO> GetByEnvironment(string shortName, PaginationParameters pagination);
        PagedList<LogViewDTO> GetByDescription(string environment, string description, PaginationParameters pagination);
        PagedList<LogViewDTO> GetBySource(string environment, string source, PaginationParameters pagination);
        List<LogViewDTO> OrderByLevel(List<LogViewDTO> logs);
        List<LogViewDTO> OrderByFrequency(List<LogViewDTO> logs);

        LogViewDTO Update(LogUpdateDTO logToUpdate);
        LogViewDTO Create(LogSaveDTO logToCreate);
        LogViewDTO UpdateFileStatus(int id, bool status);
        void Delete(int id);
    }
}
