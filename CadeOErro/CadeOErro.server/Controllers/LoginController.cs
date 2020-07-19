using System;
using CadeOErro.Domain.Exceptions.User;
using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Services;
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
        public ObjectResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                AuthenticateDTO authenticate = _service.Authenticate(dto);
                return Ok(authenticate);
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.ValidationResult);
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

        [HttpPost("recover")]
        public ObjectResult RecoverPassword([FromBody] PasswordDTO dto)
        {
            try
            {
                var userView = _service.ChangePassword(dto);
                return Ok(userView);
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.ValidationResult);
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
