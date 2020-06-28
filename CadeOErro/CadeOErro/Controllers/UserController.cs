using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Repositories;
using CadeOErro.Server.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            UserViewDTO user = await _service.GetById(id);
            return Ok(user);
        }


        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] UserSaveDTO user)
        {
            var userCreated = await _service.Create(user);
            return StatusCode(201, userCreated);
        }


        [HttpPut("{id}")]
        public async Task<ObjectResult> Put([FromBody] UserSaveDTO user)
        {
            var userUpdated = await _service.Update(user);
            return Ok(userUpdated);
        }


        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Usuário deletado com sucesso!");
        }
    }
}
