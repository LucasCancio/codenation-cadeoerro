using AutoMapper;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using CadeOErro.Domain.Util.Exceptions;
using CadeOErro.Server.DTOs.Log;
using CadeOErro.Server.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadeOErro.Server.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        private readonly IMapper _mapper;
        public LogService(ILogRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public List<LogViewDTO> GetAll()
        {
            List<Log> logs = _repository.GetAll();
            return _mapper.Map<List<LogViewDTO>>(logs);
        }

        public LogViewDTO GetById(int id)
        {
            Log log = _repository.FindById(id);
            if (log == null) throw new LogNotFoundException();

            return _mapper.Map<LogViewDTO>(log);
        }

        public List<LogViewDTO> GetByEnvironment(string shortName)
        {
            List<Log> logs = _repository.FindByEnvironment(shortName);
            return _mapper.Map<List<LogViewDTO>>(logs);
        }

        public List<LogViewDTO> GetByDescription(string environment, string description)
        {
            List<Log> logs = _repository.FindByEnvironmentAndDescription(environment, description);
            return _mapper.Map<List<LogViewDTO>>(logs);
        }

        public List<LogViewDTO> GetByLevel(string environment, string level)
        {
            List<Log> logs = _repository.FindByEnvironmentAndLevel(environment, level);
            return _mapper.Map<List<LogViewDTO>>(logs);
        }

        public List<LogViewDTO> GetBySource(string environment, string source)
        {
            List<Log> logs = _repository.FindByEnvironmentAndSource(environment, source);
            return _mapper.Map<List<LogViewDTO>>(logs);
        }

        public List<LogViewDTO> OrderByFrequency(List<LogViewDTO> logs)
        {
            return logs.OrderBy(log => log.frequency).ToList();
        }

        public List<LogViewDTO> OrderByLevel(List<LogViewDTO> logs)
        {
            return logs.OrderBy(log => log.idLogLevel).ToList();
        }



        public LogViewDTO Update(LogUpdateDTO logToUpdate)
        {
            Log log = _repository.FindById(logToUpdate.id);
            if (log == null) throw new LogNotFoundException();

            log = _mapper.Map(logToUpdate, log);
            _repository.Save(log);

            return _mapper.Map<LogViewDTO>(log);
        }

        public LogViewDTO Create(LogCreateDTO logToCreate)
        {
            Log log = _mapper.Map<Log>(logToCreate);
            _repository.Save(log);

            return _mapper.Map<LogViewDTO>(log);
        }

        public void Delete(int id)
        {
            Log log = _repository.FindById(id);

            if (log == null) throw new LogNotFoundException();

            _repository.Delete(log);
        }

        public LogViewDTO UpdateFileStatus(int id, bool status)
        {
            Log log = _repository.FindById(id);
            if (log == null) throw new LogNotFoundException();

            log.filed = status;
            if (log.filed) log.filedDate = DateTime.Now;

            _repository.Save(log);

            return _mapper.Map<LogViewDTO>(log);
        }
    }
}
