using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Util.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            this._service = service;
        }


        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            List<UserViewDTO> users = await _service.GetAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            try
            {
                UserViewDTO user = await _service.GetById(id);
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
        public async Task<ObjectResult> Post([FromBody] UserSaveDTO user)
        {
            try
            {
                var userCreated = await _service.Create(user);
                return StatusCode(201, userCreated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }

        }


        [HttpPut("{id}")]
        public async Task<ObjectResult> Put([FromBody] UserSaveDTO user)
        {
            try
            {
                var userUpdated = await _service.Update(user);
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
