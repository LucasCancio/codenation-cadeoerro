using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.User
{
    public class UserCreateDTO
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string role { get; set; }
    }
}
