using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogLevelController : ControllerBase
    {
        private readonly ILogLevelRepository _repository;
        public LogLevelController(ILogLevelRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                List<LogLevel> logLevels = _repository.GetAll();
                return Ok(logLevels);
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
                return Ok(logLevel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPost]
        public ObjectResult Post([FromBody] LogLevel logLevel)
        {
            try
            {
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
