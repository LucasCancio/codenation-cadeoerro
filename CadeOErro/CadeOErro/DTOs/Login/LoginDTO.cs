using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.Login
{
    public class LoginDTO
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
