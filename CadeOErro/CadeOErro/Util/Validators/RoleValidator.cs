using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.Util.Validators
{
    public class RoleValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(
          object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            if (IsRole(value.ToString()))
            {
                return new ValidationResult("Role inválida! Escolha entre 'admin' ou 'user'");
            }
            return ValidationResult.Success;
        }

        private static bool IsRole(string role)
        {
            role = role.ToLower();
            return (role != "admin" && role != "user");
        }
    }
}
