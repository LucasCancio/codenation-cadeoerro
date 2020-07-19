using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.Login
{
    public class PasswordDTO
    {
        public string email { get; set; }
        public string cpf { get; set; }

        [Required]
        public string newPassword { get; set; }
        [Compare(nameof(newPassword), ErrorMessage = "As senhas não estão iguais.")]
        public string confirmPassword { get; set; }
    }
}
