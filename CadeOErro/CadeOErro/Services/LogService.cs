using AutoMapper;
using CadeOErro.Domain.Exceptions.Log;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using CadeOErro.Domain.Pagination;
using CadeOErro.Server.DTOs.Log;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Util.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadeOErro.Server.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        private readonly IMapper _mapper;
        private readonly LogValidator _validator;
        public LogService(ILogRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = new LogValidator(_mapper);
        }

        public PagedList<LogViewDTO> GetAll(PaginationParameters pagination)
        {
            List<Log> logs = _repository.GetAll();
            List<LogViewDTO> viewLogs = _mapper.Map<List<LogViewDTO>>(logs);

            return PagedList<LogViewDTO>.ToPagedList(viewLogs,
            pagination.pageNumber,
            pagination.pageSize);
        }

        public LogViewDTO GetById(int id)
        {
            Log log = _repository.FindById(id);
            if (log == null) throw new LogNotFoundException();

            return _mapper.Map<LogViewDTO>(log);
        }

        public PagedList<LogViewDTO> GetByEnvironment(string shortName, PaginationParameters pagination)
        {
            List<Log> logs = _repository.FindByEnvironment(shortName);

            List<LogViewDTO> viewLogs = _mapper.Map<List<LogViewDTO>>(logs);

            return PagedList<LogViewDTO>.ToPagedList(viewLogs,
            pagination.pageNumber,
            pagination.pageSize);
        }

        public PagedList<LogViewDTO> GetByDescription(string environment, string description, PaginationParameters pagination)
        {
            List<Log> logs = _repository.FindByEnvironmentAndDescription(environment, description);
            List<LogViewDTO> viewLogs = _mapper.Map<List<LogViewDTO>>(logs);

            return PagedList<LogViewDTO>.ToPagedList(viewLogs,
            pagination.pageNumber,
            pagination.pageSize);
        }

        public PagedList<LogViewDTO> GetByLevel(string environment, string level, PaginationParameters pagination)
        {
            List<Log> logs = _repository.FindByEnvironmentAndLevel(environment, level);
            List<LogViewDTO> viewLogs = _mapper.Map<List<LogViewDTO>>(logs);

            return PagedList<LogViewDTO>.ToPagedList(viewLogs,
            pagination.pageNumber,
            pagination.pageSize);
        }

        public PagedList<LogViewDTO> GetBySource(string environment, string source, PaginationParameters pagination)
        {
            List<Log> logs = _repository.FindByEnvironmentAndSource(environment, source);
            List<LogViewDTO> viewLogs = _mapper.Map<List<LogViewDTO>>(logs);

            return PagedList<LogViewDTO>.ToPagedList(viewLogs,
            pagination.pageNumber,
            pagination.pageSize);
        }

        public List<LogViewDTO> OrderByFrequency(List<LogViewDTO> logs)
        {
            var orderedLogs = logs.OrderBy(log => log.frequency).ToList();

            return orderedLogs;
        }

        public List<LogViewDTO> OrderByLevel(List<LogViewDTO> logs)
        {
            var orderedLogs = logs.OrderBy(log => log.idLogLevel).ToList();

            return orderedLogs;
        }



        public LogViewDTO Update(LogUpdateDTO logToUpdate)
        {
            if(!_validator.IsValidUpdateDTO(logToUpdate)) throw new InvalidLogException(_validator.ValidationResult);


            Log log = _repository.FindById(logToUpdate.id);
            if (log == null) throw new LogNotFoundException();

            log = _mapper.Map(logToUpdate, log);
            _repository.Save(log);

            return _mapper.Map<LogViewDTO>(log);
        }

        public LogViewDTO Create(LogSaveDTO logToCreate)
        {
            if (!_validator.IsValidSaveDTO(logToCreate)) throw new InvalidLogException(_validator.ValidationResult);

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
