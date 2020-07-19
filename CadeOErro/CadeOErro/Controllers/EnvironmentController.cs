using System;
using System.Collections.Generic;
using AutoMapper;
using CadeOErro.Domain.Exceptions.Environment;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Server.DTOs;
using CadeOErro.Server.DTOs.EnvironmentDTO;
using CadeOErro.Server.Util.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CadeOErro.Server.Controllers
{
    [Route("api/Environments")]
    [ApiController]
    [AllowAnonymous]//////////
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly EnvironmentValidator _validator;
        public EnvironmentController(IEnvironmentRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = new EnvironmentValidator(mapper);
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                List<Domain.Models.Environment> environments = _repository.GetAll();
                var environmentsDTOs = _mapper.Map<List<EnvironmentViewDTO>>(environments);
                return Ok(environmentsDTOs);
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
                Domain.Models.Environment environment = _repository.FindById(id);

                if (environment == null) return NotFound("Ambiente inexistente.");

                var environmentDTO = _mapper.Map<EnvironmentViewDTO>(environment);
                return Ok(environmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }


        [HttpPost]
        //[Authorize(Roles = "admin")]
        public ObjectResult Post([FromBody] EnvironmentSaveDTO environmentDTO)
        {
            try
            {
                if (!_validator.IsValidSaveDTO(environmentDTO)) return BadRequest(_validator.ValidationResult);

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
        //[Authorize(Roles = "admin")]
        public ObjectResult Delete([FromRoute] int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("Ambiente deletado com sucesso!");
            }
            catch (EnvironmentNotFoundException ex)
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
