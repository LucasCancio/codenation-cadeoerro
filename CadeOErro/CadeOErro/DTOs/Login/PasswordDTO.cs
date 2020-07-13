using CadeOErro.Server.Util.Validators;
using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.Login
{
    public class PasswordDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string email { get; set; }
        [Required]
        [CPFValidator]
        public string cpf { get; set; }
        [Required]
        public string newPassword { get; set; }
        [Required]
        [Compare(nameof(newPassword), ErrorMessage = "As senhas não estão iguais.")]
        public string confirmPassword { get; set; }
    }
}
