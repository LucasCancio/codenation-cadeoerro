using System;
using System.Collections.Generic;
using CadeOErro.Server.DTOs.Log;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CadeOErro.Domain.Exceptions.Log;

namespace CadeOErro.Server.Controllers
{
    [Route("api/Logs")]
    [ApiController]
    [AllowAnonymous]//////////
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;
        public LogController(ILogService service)
        {
            _service = service;
        }

        [HttpGet]
        public ObjectResult GetAll(string orderBy, [FromQuery] PaginationParameters pagination)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetAll(pagination);

                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{id}/filed/{status}")]
        public ObjectResult ChangeFileStatus([FromRoute] int id, [FromRoute] bool status)
        {
            try
            {
                LogViewDTO log = _service.UpdateFileStatus(id, status);
                return Ok(log);
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


        [HttpGet("{id}")]
        public ObjectResult GetById([FromRoute] int id)
        {
            try
            {
                LogViewDTO log = _service.GetById(id);
                return Ok(log);
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

        [HttpGet("env/{env}")]
        public ObjectResult GetByEnvironment([FromRoute] string env, [FromQuery] string orderBy, [FromQuery] PaginationParameters pagination)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetByEnvironment(shortName: env, pagination: pagination);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpGet("env/{env}/level/{level}")]
        public ObjectResult GetByLevel([FromRoute] string env, [FromRoute] string level, [FromQuery] string orderBy, [FromQuery] PaginationParameters pagination)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetByLevel(env, level, pagination);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("env/{env}/desc/{desc}")]
        public ObjectResult GetByDescription([FromRoute] string env, [FromRoute] string desc, [FromQuery] string orderBy, [FromQuery] PaginationParameters pagination)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetByDescription(env, desc, pagination);
                OrderLogs(logs, orderBy);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("env/{env}/source/{source}")]
        public ObjectResult GetBySource([FromRoute] string env, [FromRoute] string source, [FromQuery] string orderBy, [FromQuery] PaginationParameters pagination)
        {
            try
            {
                List<LogViewDTO> logs = _service.GetBySource(env, source, pagination);
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
        public ObjectResult Post([FromBody] LogSaveDTO log)
        {
            try
            {
                var logCreated = _service.Create(log);

                return StatusCode(201, logCreated);
            }
            catch (InvalidLogException ex)
            {
                return BadRequest(ex.ValidationResult);
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
        //[Authorize(Roles = "admin")]
        public ObjectResult Delete([FromRoute] int id)
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
