using CadeOErro.Server.Util.Validators;
using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.User
{
    public class UserCreateDTO
    {
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [UniqueEmailValidator]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [CPFValidator]
        public string cpf { get; set; }
        [Required]
        [RoleValidator]
        public string role { get; set; }
    }
}
