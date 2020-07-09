using CadeOErro.Domain.Util.Validators;
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
        [CPFValidator(ErrorMessage = "CPF inválido")]
        public string cpf { get; set; }
        [Required]
        [RoleValidator(ErrorMessage = "Role inválida! Escolha entre 'admin' ou 'user'")]
        public string role { get; set; }
    }
}
