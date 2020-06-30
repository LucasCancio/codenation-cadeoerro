using System;
using System.Collections.Generic;
using AutoMapper;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.LogLevel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LogLevelController : ControllerBase
    {
        private readonly ILogLevelRepository _repository;
        private readonly IMapper _mapper;
        public LogLevelController(ILogLevelRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                List<LogLevel> logLevels = _repository.GetAll();
                var logLevelsDTOs = _mapper.Map<List<LogLevelDTO>>(logLevels);
                return Ok(logLevelsDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            try
            {
                LogLevel logLevel = _repository.FindById(id);
                var logLevelDTO = _mapper.Map<LogLevelDTO>(logLevel);
                return Ok(logLevelDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPost]
        public ObjectResult Post([FromBody] LogLevelDTO logLevelDTO)
        {
            try
            {
                var logLevel = _mapper.Map<LogLevel>(logLevelDTO);
                _repository.Create(logLevel);
                return Ok(logLevel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("LogLevel deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
    }
}
