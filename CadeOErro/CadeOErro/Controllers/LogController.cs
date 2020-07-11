using System;
using System.Collections.Generic;
using CadeOErro.Domain.Util.Exceptions;
using CadeOErro.Server.DTOs.Log;
using CadeOErro.Server.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;
        public LogController(ILogService service)
        {
            _service = service;
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                List<LogViewDTO> logs = _service.GetAll();
                return Ok(logs);
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
                LogViewDTO log = _service.GetById(id);
                if (log == null) return NotFound("Log não encontrado!");
                return Ok(log);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{env}")]
        public ObjectResult GetByEnvironment(string env, string orderBy)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetByEnvironment(shortName: env);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpGet("{env}/level/{level}")]
        public ObjectResult GetByLevel(string env, string level, string orderBy)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetByLevel(env, level);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{env}/desc/{desc}")]
        public ObjectResult GetByDescription(string env, string desc, string orderBy)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetByDescription(env, desc);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{env}/source/{source}")]
        public ObjectResult GetBySource(string env, string source, string orderBy)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetBySource(env, source);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        private List<LogViewDTO> OrderLogs(List<LogViewDTO> logs, string orderBy)
        {
            if (orderBy == "frequency") return _service.OrderByFrequency(logs);
            else if (orderBy == "level") return _service.OrderByLevel(logs);
            return logs;
        }

        [HttpPost]
        public ObjectResult Post([FromBody] LogCreateDTO log)
        {
            try
            {
                var logCreated = _service.Create(log);
                return StatusCode(201, logCreated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPut]
        public ObjectResult Put([FromBody] LogUpdateDTO log)
        {
            try
            {
                var logUpdated = _service.Update(log);
                return Ok(logUpdated);
            }
            catch (LogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ObjectResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Log deletado com sucesso!");
            }
            catch (LogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
    }
}
