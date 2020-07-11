using System;
using System.Collections.Generic;
using AutoMapper;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Server.DTOs;
using CadeOErro.Server.DTOs.EnvironmentDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentRepository _repository;
        private readonly IMapper _mapper;
        public EnvironmentController(IEnvironmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                List<Domain.Models.Environment> logLevels = _repository.GetAll();
                var logLevelsDTOs = _mapper.Map<List<EnvironmentViewDTO>>(logLevels);
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
                Domain.Models.Environment logLevel = _repository.FindById(id);
                var logLevelDTO = _mapper.Map<EnvironmentViewDTO>(logLevel);
                return Ok(logLevelDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPost]
        public ObjectResult Post([FromBody] EnvironmentCreateDTO environmentDTO)
        {
            try
            {
                var environment = _mapper.Map<Domain.Models.Environment>(environmentDTO);
                _repository.Create(environment);
                return Ok(_mapper.Map<EnvironmentViewDTO>(environment));
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
                return Ok("Ambiente deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
    }
}
