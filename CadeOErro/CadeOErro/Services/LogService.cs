using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using CadeOErro.Server.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CadeOErro.Server.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        public LogService(ILogRepository repository)
        {
            this._repository = repository;
        }
        public Log Create(Log logToCreate)
        {
            throw new NotImplementedException();
        }
        public Log Update(Log logToUpdate)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetAll()
        {
            throw new NotImplementedException();
        }
        public Log GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetByEnvironment(string environment)
        {
            throw new NotImplementedException();
        }


        public List<Log> GetByLevel(string level)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetBySource(string source)
        {
            throw new NotImplementedException();
        }

        public List<Log> OrderByFrequency(List<Log> logs)
        {
            throw new NotImplementedException();
        }

        public List<Log> OrderByLevelPriority(List<Log> logs)
        {
            throw new NotImplementedException();
        }


    }
}
