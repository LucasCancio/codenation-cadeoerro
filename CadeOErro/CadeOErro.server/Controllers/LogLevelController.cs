using System;
using System.Collections.Generic;
using AutoMapper;
using CadeOErro.Domain.Exceptions.LogLevel;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.LogLevel;
using CadeOErro.Server.Util.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadeOErro.Server.Controllers
{
    [Route("api/LogLevels")]
    [ApiController]
    [AllowAnonymous]//////////
    public class LogLevelController : ControllerBase
    {
        private readonly ILogLevelRepository _repository;
        private readonly IMapper _mapper;
        private readonly LogLevelValidator _validator;
        public LogLevelController(ILogLevelRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = new LogLevelValidator(mapper);
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                List<LogLevel> logLevels = _repository.GetAll();
                var logLevelsDTOs = _mapper.Map<List<LogLevelViewDTO>>(logLevels);
                return Ok(logLevelsDTOs);
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
                LogLevel logLevel = _repository.FindById(id);
                if (logLevel == null) return NotFound("LogLevel inexistente");

                var logLevelDTO = _mapper.Map<LogLevelViewDTO>(logLevel);
                return Ok(logLevelDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPost]
        //[Authorize(Roles = "admin")]
        public ObjectResult Post([FromBody] LogLevelSaveDTO logLevelDTO)
        {
            try
            {
                if (!_validator.IsValidSaveDTO(logLevelDTO)) return BadRequest(_validator.ValidationResult);

                var logLevel = _mapper.Map<LogLevel>(logLevelDTO);
                _repository.Create(logLevel);
                return Ok(_mapper.Map<LogLevelViewDTO>(logLevel));
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
                _repository.Delete(id);
                return Ok("LogLevel deletado com sucesso!");
            }
            catch (LogLevelNotFoundException ex)
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
