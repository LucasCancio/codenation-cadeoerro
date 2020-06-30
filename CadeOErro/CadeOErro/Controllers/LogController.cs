using System;
using System.Collections.Generic;
using CadeOErro.Domain.Models;
using CadeOErro.Server.Interfaces.Services;
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
                List<Log> logs = _service.GetAll();
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
                List<UserViewDTO> users = _service.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{env}/level/{level}")]
        public ObjectResult GetByLevel(string env, string level, string orderBy = "frequency")
        {
            try
            {
                List<UserViewDTO> users = _service.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{env}/desc/{desc}")]
        public ObjectResult GetByDescription(string env, string desc, string orderBy = "frequency")
        {
            try
            {
                List<UserViewDTO> users = _service.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{env}/source/{source}")]
        public ObjectResult GetBySource(string env, string source, string orderBy = "frequency")
        {
            return "value";
        }


        [HttpPost]
        public ObjectResult Post([FromBody] string value)
        {
            try
            {
                List<UserViewDTO> users = _service.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] string value)
        {
            try
            {
                List<UserViewDTO> users = _service.GetAll();
                return Ok(users);
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
                List<UserViewDTO> users = _service.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
    }
}
