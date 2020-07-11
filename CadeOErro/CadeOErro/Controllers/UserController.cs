using System;
using System.Collections.Generic;
using CadeOErro.Domain.Util.Exceptions;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]//////////
    //[Authorize(Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            this._service = service;
        }


        [HttpGet]
        public ObjectResult GetAll()
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


        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            try
            {
                UserViewDTO user = _service.GetById(id);
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }

        }


        [HttpPost]
        public ObjectResult Post([FromBody] UserCreateDTO user)
        {
            try
            {
                var userCreated = _service.Create(user);
                return StatusCode(201, userCreated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }

        }


        [HttpPut]
        public ObjectResult Put([FromBody] UserUpdateDTO user)
        {
            try
            {
                var userUpdated = _service.Update(user);
                return Ok(userUpdated);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
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
                _service.Delete(id);
                return Ok("Usuário deletado com sucesso!");
            }
            catch (UserNotFoundException ex)
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
