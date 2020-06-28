using System;
using System.Threading.Tasks;
using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.Interfaces.Services;
using CadeOErro.Server.Util.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadeOErro.Server.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                AuthenticateDTO authenticate = await _service.Authenticate(dto.email, dto.password);
                return Ok(authenticate);
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
